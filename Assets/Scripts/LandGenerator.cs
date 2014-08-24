using UnityEngine;
using System.Collections;

public class LandGenerator : MonoBehaviour {
	public GameObject mountainObject;
	public GameObject beachObject;

	private float minHorizontalSize = 0.5f;
	private float maxHorizontalSize = 1.5f;
	private float minVerticalSize = 0.25f;
	private float maxVerticalSize = 1.0f;
	private float maxAngle = 25.0f;

	void Start () {
		mountainObject.transform.localScale = new Vector3 (Random.Range (minHorizontalSize, maxHorizontalSize), Random.Range (minVerticalSize, maxVerticalSize), Random.Range (minHorizontalSize, maxHorizontalSize));
		mountainObject.transform.Rotate (Vector3.left, Random.Range (0.0f, maxAngle));
		mountainObject.transform.Rotate (Vector3.up, Random.Range (0.0f, 360.0f));
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("Collided: " + collision.gameObject.tag + ":" + collision);
		if(collision.gameObject.tag == "Boat"){
			SendMessageUpwards("RaiseFlag", false, SendMessageOptions.RequireReceiver);
		}
	}
}
