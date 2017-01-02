using UnityEngine;
using System.Collections.Generic;

public class Wind : MonoBehaviour {
	private float windForce = 50.0f;
	private float windTorque = 5.0f;
	private float maxDistance = 20.0f;

	private Vector3 windDirection;
	private List<GameObject> collidingObjects = new List<GameObject>();
	
	void Start() {
		windDirection = transform.forward;
	}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag == "Boat"){
			collidingObjects.Add (collider.gameObject);
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if(collider.gameObject.tag == "Boat"){
			collidingObjects.Remove (collider.gameObject);
		}
	}


	void Update() {
		Debug.DrawRay (transform.position, transform.forward * 5, Color.green);
	}
	
	void FixedUpdate() {
		foreach(GameObject obj in collidingObjects){
			float distance = Vector3.Distance(obj.transform.position, transform.position);
			float damping = Mathf.Max (1.0f - (distance / maxDistance), 0.0f);

			// obj.rigidbody.AddRelativeForce (windDirection * windForce * damping, ForceMode.Force);
			obj.GetComponent<Rigidbody>().AddForce (windDirection * windForce * damping, ForceMode.Force);

			// Debug.DrawRay (obj.transform.position, windDirection * windForce * damping, Color.cyan);

			Quaternion delta = Quaternion.FromToRotation (obj.transform.forward, windDirection);
			obj.GetComponent<Rigidbody>().AddTorque(0f, delta.y * windTorque * damping, 0f);
		}
	}
}
