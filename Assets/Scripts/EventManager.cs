using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventManager : MonoBehaviour {
	public GameObject panel;
	public GameObject buttonA;
	public GameObject buttonB;
	public GameObject text;
	public GameEvent gameEvent;

	private float fadeSpeed = 2.0f;
	private bool visible = false;

	private float foodEatRate = 60.0f; // 1 food per 1 crew per X seconds
	private float timeSinceLastEat = 0.0f;

	private float starveRate = 60.0f; // Time between starvations in seconds
	private float timeSinceLastStarve = 0.0f;
	
	void Start () {
		StartCoroutine(ShowIntro ());
	}

	IEnumerator ShowIntro () {
		yield return new WaitForSeconds(2);
		// SetGameEvent (new IntroductionGameEvent ());
		SetGameEvent (new OverboardGameEvent ());
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
		Hide ();
		gameEvent.OnButtonAClicked ();
	}

	public void ButtonBClicked () {
		Hide ();
		gameEvent.OnButtonBClicked ();
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
		buttonA.GetComponent<Text>().text = gameEvent.buttonAText;
		buttonB.GetComponent<Text>().text = gameEvent.buttonBText;
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
