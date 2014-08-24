using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public float minHeight = 2.0f;
	public float maxHeight = 2.3f;
	private float bobSpeed = 2.0f;
	private bool up = true;
	private Vector3 maxPosition;
	private Vector3 minPosition;
	private float bobT;
	private float scrollSpeed = 2.0f;
	private Vector2 scrollOffset = Vector2.zero;
	private Vector2 minScrollOffset = Vector2.zero;
	private Vector2 maxScrollOffset = new Vector2(0.2f, 0.2f);
	private bool forward = true;
	private float scrollT;
	
	void Start () {
		maxPosition = new Vector3 (transform.position.x, maxHeight, transform.position.z);
		minPosition = new Vector3 (transform.position.x, minHeight, transform.position.z);
		transform.position = minPosition;
		bobT = 0.0f;
		scrollT = 0.0f;
	}

	void Update () {
		bobT += Time.deltaTime / bobSpeed;
		if(up){
			// transform.position = Vector3.Slerp(transform.position, maxPosition, Time.deltaTime * bobSpeed);
			transform.position = Vector3.Lerp (minPosition, maxPosition, Mathf.SmoothStep(0.0f, 1.0f, bobT));

			if(transform.position.y == maxPosition.y){
				up = false;
				bobT = 0.0f;
			}
		}else{
			transform.position = Vector3.Lerp (maxPosition, minPosition, Mathf.SmoothStep(0.0f, 1.0f, bobT));

			if(transform.position.y == minPosition.y){
				up = true;
				bobT = 0.0f;
			}
		}

		scrollT += Time.deltaTime / scrollSpeed;
		if(forward){
			scrollOffset = Vector2.Lerp (minScrollOffset, maxScrollOffset, Mathf.SmoothStep(0.0f, 1.0f, scrollT));
			
			if(scrollOffset == maxScrollOffset){
				forward = false;
				scrollT = 0.0f;
			}
		}else{
			scrollOffset = Vector2.Lerp (maxScrollOffset, minScrollOffset, Mathf.SmoothStep(0.0f, 1.0f, scrollT));
			
			if(scrollOffset == minScrollOffset){
				forward = true;
				scrollT = 0.0f;
			}
		}
		renderer.material.SetTextureOffset ("_MainTex", scrollOffset);
	}

}
