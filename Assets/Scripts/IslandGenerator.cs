using UnityEngine;
using System.Collections;

public class IslandGenerator : MonoBehaviour {
	public GameObject landPrefab;
	public GameObject flag;

	private float islandSize = 6.0f;
	private int minLand = 1;
	private int maxLand = 10;

	private Vector3 center;
	private bool raisingFlag = false;
	private bool raisedFlag = false;
	private float flagRaiseSpeed = 3.0f;
	private float loweredFlagHeight = 2.0f;
	private float raisedFlagHeight = 5.0f;
	private float delayBeforeEvent = 1.0f;
	private bool eventShown = false;
	public GameEvent gameEvent;

	private EventManager eventManager;

	void Start () {
		int numLand = Random.Range (minLand, maxLand);
		GameObject firstLand = null;
		for(int ii = 0; ii < numLand; ii++){
			GameObject land = (GameObject)Instantiate (landPrefab);

			land.transform.parent = transform;

			Vector3 randomPosition = Random.insideUnitSphere * islandSize;
			randomPosition.y = 2.4f; // FIXME
			land.transform.localPosition = randomPosition;

			if(ii == 0){
				firstLand = land;
			}
		}

		// flag.transform.Rotate (Vector3.up * 180.0f);
		flag.transform.localPosition = new Vector3(firstLand.transform.localPosition.x, loweredFlagHeight, firstLand.transform.localPosition.z);
		// flag.transform.localScale = Vector3.zero;
		HideFlag ();

	}

	public void HideFlag () {
		Renderer[] renderers = flag.GetComponentsInChildren<Renderer> ();
		foreach(Renderer renderer in renderers){
			renderer.enabled = false;
		}
	}

	public void RaiseFlag () {
		if(!raisingFlag && !raisedFlag){
			Renderer[] renderers = flag.GetComponentsInChildren<Renderer> ();
			foreach(Renderer renderer in renderers){
				renderer.enabled = true;
			}
			flag.GetComponent<ParticleSystem> ().Play ();
			raisingFlag = true;
		}
	}

	void Update () {
		if(raisingFlag){
			if(flag.transform.localPosition.y < raisedFlagHeight - 0.2f){ // FIXME
				flag.transform.localPosition = Vector3.Lerp(flag.transform.localPosition, new Vector3(flag.transform.localPosition.x, raisedFlagHeight, flag.transform.localPosition.z), Time.deltaTime * flagRaiseSpeed);
			}else{
				raisingFlag = false;
				raisedFlag = true;
				Globals.Instance.inputActive = false;
			}
		}else{
			if(raisedFlag){
				if(delayBeforeEvent > 0.0f){
					delayBeforeEvent -= Time.deltaTime * 1.0f;
				}else{
					if(!eventShown){
						Globals.Instance.eventManager.SetGameEvent(gameEvent);
						eventShown = true;
					}
				}
			}
		}
	}
}
