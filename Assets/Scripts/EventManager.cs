using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventManager : MonoBehaviour {
	public GameObject panel;
	public GameObject buttonA;
	public GameObject buttonB;
	public GameObject buttonAText;
	public GameObject buttonBText;
	public GameObject text;
	public GameEvent gameEvent;
	public GameObject logo;

	private float fadeSpeed = 2.0f;
	private bool visible = true;

	private float foodEatRate = 50.0f; // 1 food per 1 crew per X seconds
	private float timeSinceLastEat = 0.0f;

	private float starveRate = 50.0f; // Time between starvations in seconds
	private float timeSinceLastStarve = 0.0f;
	
	void Start () {
		// StartCoroutine(ShowIntro ());
		SetGameEvent (new LogoGameEvent ());
	}

	IEnumerator ShowIntro () {
		yield return new WaitForSeconds(2);
		SetGameEvent (new IntroductionGameEvent ());
		// SetGameEvent (new SpoiledFoodGameEvent ());
	}

	void Hide () {
		Globals.Instance.inputActive = true;
		visible = false;
		panel.GetComponent<CanvasGroup> ().interactable = false;
	}

	void Show () {
		Globals.Instance.inputActive = false;
		visible = true;
		panel.GetComponent<CanvasGroup> ().interactable = true;
	}

	public void ButtonAClicked () {
		if(buttonAText.GetComponent<Text> ().text.Length > 0){
			Hide ();
			gameEvent.OnButtonAClicked ();
		}
	}

	public void ButtonBClicked () {
		if(buttonBText.GetComponent<Text> ().text.Length > 0){
			Hide ();
			gameEvent.OnButtonBClicked ();
		}
	}

	public void HighlightButtonA (){
		// buttonA.GetComponent<Text> ().color = Color.white;
	}

	public void UnHighlightButtonA (){
		// buttonA.GetComponent<Text> ().color = Color.red;
	}

	private Color buttonColor = new Color (131f, 117f, 83f);
	
	public void HighlightButtonB (){
		// buttonB.GetComponent<Text> ().color = Color.white;
	}
	
	public void UnHighlightButtonB (){
		// buttonB.GetComponent<Text> ().color = Color.red;
	}

	public void RandomGameEvent () {
		switch(Random.Range (0, 1)){
			case 0:
				// gameEvent = new TestGameEvent();
				break;
		}

		SetGameEvent (gameEvent);
	}

	public void SetGameEvent (GameEvent newGameEvent){
		gameEvent = newGameEvent;
		text.GetComponent<Text> ().text = gameEvent.text;
		buttonAText.GetComponent<Text>().text = gameEvent.buttonAText;
		if(gameEvent.buttonAText.Length == 0){
			buttonA.GetComponent<Image>().enabled = false;
		}else{
			buttonA.GetComponent<Image>().enabled = true;
		}
		buttonBText.GetComponent<Text>().text = gameEvent.buttonBText;
		if(gameEvent.buttonBText.Length == 0){
			buttonB.GetComponent<Image>().enabled = false;
		}else{
			buttonB.GetComponent<Image>().enabled = true;
		}
		Show ();
	}

	void Update () {

		// Handle fading of event panel

		CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup> ();
		if(visible && canvasGroup.alpha < 1.0f){
			canvasGroup.alpha += Time.deltaTime * fadeSpeed;
			canvasGroup.alpha = Mathf.Max(canvasGroup.alpha, 0.0f);
		}

		if(!visible && canvasGroup.alpha > 0.0f){
			canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
			canvasGroup.alpha = Mathf.Min(canvasGroup.alpha, 1.0f);
		}

		if(Globals.Instance.inputActive){ // Only do this stuff if input is active

			// Handle crew eating food

			timeSinceLastEat += Time.deltaTime;

			if(timeSinceLastEat >= foodEatRate / Globals.Instance.crew){
				Globals.Instance.food --;
				timeSinceLastEat = 0.0f;
				if(Globals.Instance.food < 0){
					Globals.Instance.food = 0;
				}
			}

			// Handle starvation

			if(Globals.Instance.food <= 0){
				timeSinceLastStarve += Time.deltaTime;

				if(timeSinceLastStarve >= starveRate){
					timeSinceLastStarve = 0.0f;

					Globals.Instance.eventManager.SetGameEvent(new StarveGameEvent());
				}
			}

			// Handle all crew dead

			if(Globals.Instance.crew <= 0){
				Globals.Instance.eventManager.SetGameEvent(new CrewDeadGameEvent());
			}

			// Handle winning

			if(Globals.Instance.spiceA && Globals.Instance.spiceB && Globals.Instance.spiceC && Globals.Instance.spiceD){
				Globals.Instance.eventManager.SetGameEvent(new WinGameEvent());
			}
		}
	}
}
