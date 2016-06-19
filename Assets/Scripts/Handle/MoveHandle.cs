using UnityEngine;
using System.Collections;

public class MoveHandle : MonoBehaviour {
	
	private Transform target;
	private Vector3 handleVelocity;
	private float smoothTime;
	private Vector3 origin;
	// Use this for initialization
	void Start () {
		handleVelocity = Vector3.zero;
		origin = new Vector3 (0, 0.6f, 0f);
		smoothTime = 0.8F;
	}
	
	// Update is called once per frame
	void Update () {
		if (ObjectsManager.instance.SelectedDoll != null&&GameManager.instance.getCoinNum()!=0) {
			target = ObjectsManager.instance.SelectedDoll.transform;
			float targetX = target.TransformPoint (new Vector3 (0, 0, 0)).x;
			float targetZ = target.TransformPoint (new Vector3 (0, 0, 0)).z;
			Vector3 targetPosition = new Vector3(targetX,origin.y,targetZ);
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref handleVelocity, smoothTime);
		} else {
			transform.position = Vector3.SmoothDamp (transform.position, origin, ref handleVelocity, smoothTime);
		}
	}

}
