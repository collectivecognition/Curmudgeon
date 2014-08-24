using UnityEngine;
using System.Collections;

public class BoatControls : MonoBehaviour {
	private float buoyancy = 75.0f;
	private float buoyancyTorque = 5.0f;
	private Vector3 centerOfMass = new Vector3(0, -1, 0);
	private float paddleSpeed = 25.0f;
	private float paddleTurnSpeed = 2.0f;
	private float maxPaddleSpeed = 30.0f;
	private float maxTurnSpeed = 0.5f;

	private bool inWater = false;

	void Start() {
		rigidbody.centerOfMass = centerOfMass;
		// rigidbody.maxAngularVelocity = maxTurnSpeed;
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Water") {
			inWater = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if(collider.tag == "Water") {
			inWater = false;
		}
	}

	void Update() {
		if(Globals.Instance.inputActive){
			if(rigidbody.velocity.magnitude < maxPaddleSpeed){
				rigidbody.AddForce(-transform.forward * paddleSpeed * -Input.GetAxis("Vertical"));
			}

			if(rigidbody.angularVelocity.y < maxTurnSpeed){
				rigidbody.AddRelativeTorque(transform.up * paddleTurnSpeed * Input.GetAxis("Horizontal") * Mathf.Sign(Input.GetAxis("Vertical")));
			}
		}
	}

	void FixedUpdate() {
		if(inWater) {

			// Apply buoyancy forces

			// Vector3 force = transform.up * buoyancy;
			// rigidbody.AddRelativeForce (force, ForceMode.Force);

			// Rotate upwards

			// Quaternion delta = Quaternion.FromToRotation (transform.up, Vector3.up);
			// rigidbody.AddTorque(delta.x * buoyancyTorque, delta.y * buoyancyTorque, delta.z * buoyancyTorque);
		}
	}
}