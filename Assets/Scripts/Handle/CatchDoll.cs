using UnityEngine;
using System.Collections;

public class CatchDoll : MonoBehaviour {

	private float force;
	private bool isCatching;
	private GameObject catchedObject;

	private Vector3 lastHandlePosition;
	// Use this for initialization
	void Start () {
		force = 0;    
		isCatching = false;
		catchedObject = null;
		lastHandlePosition = ObjectsManager.instance.Handle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		updateBrainValue ();
		updateForce ();
		//Debug.Log (GameManager.instance.BrainValue);
		//Debug.Log (ObjectsManager.instance.SelectedDoll);
		//Debug.Log (catchedObject);
	
		if ((!isCatching)&&GameManager.instance.BrainValue > 30&& (!checkIsHandleMoving ())) {
			if (ObjectsManager.instance.SelectedDoll != null) {
				if (GameManager.instance.tryOneCoin ()) {
					isCatching = true;
					catchedObject = ObjectsManager.instance.SelectedDoll;
					Debug.Log ("Start Catching");
				}
			}
		}

		if (isCatching && (GameManager.instance.BrainValue < 20||catchedObject!=ObjectsManager.instance.SelectedDoll)) {
			isCatching = false;
			catchedObject = null;
			Debug.Log ("Lost");
		}

		if (isCatching) {
			catchedObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
			if (catchedObject.GetComponent<Rigidbody> ().position.y > 10f) {
				isCatching = false;
				catchedObject = null;
				Destroy (ObjectsManager.instance.SelectedDoll);
				ObjectsManager.instance.SelectedDoll = null;
				GameManager.instance.addScore (100);
			}
		}
		if (!checkIsHandleMoving ()) {
			if (catchedObject == null && GameManager.instance.getCoinNum () == 0) {
				GameManager.instance.changeGameState (GameState.end);
			}
		}

	}

	void updateBrainValue()
	{
		if (Input.GetKey (KeyCode.W)) {
			GameManager.instance.BrainValue++;
			if (GameManager.instance.BrainValue > 100) {
				GameManager.instance.BrainValue = 100;
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			GameManager.instance.BrainValue--;
			if (GameManager.instance.BrainValue < 0) {
				GameManager.instance.BrainValue = 0;
			}
		}
	}

	void updateForce(){
		force = GameManager.instance.BrainValue * 0.5f;// + Random.Range (-10, 10);
		if (force < 0)
			force = 0;
		if (force > 50)
			force = 50;
	}

	private bool checkIsHandleMoving(){
		Vector3 currentHandlePosition=ObjectsManager.instance.Handle.transform.position;
		//Debug.Log (Vector3.Distance (currentHandlePosition, lastHandlePosition));
		if (Vector3.Distance(currentHandlePosition,lastHandlePosition)<0.002f) {
			lastHandlePosition = currentHandlePosition;
			return false;
		} else {
			lastHandlePosition = currentHandlePosition;
			return true;
		}
	}
}
