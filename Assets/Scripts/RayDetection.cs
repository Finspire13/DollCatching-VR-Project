using UnityEngine;
using System.Collections;

public class RayDetection : MonoBehaviour {

	public Material highLightedMaterial;
	public Material normalMaterial;
	private Rigidbody lastDetectedObject;
	private Rigidbody currentDetectedObject;

    private GameObject _deviceManager;

	// Use this for initialization
	void Start () {
		lastDetectedObject = null;
		currentDetectedObject = null;

        _deviceManager = GameObject.Find("DeviceManager");

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var gazePoint = _deviceManager.GetComponent<DeviceManager>().GetGazePoint();
        Ray ray = Camera.main.ScreenPointToRay(gazePoint);//using gaze point instead of mouse input

		if (Physics.Raycast (ray, out hit)) {
			currentDetectedObject = hit.rigidbody;



			if (currentDetectedObject != null) {
				if (currentDetectedObject != lastDetectedObject) {
					Renderer currentRand = currentDetectedObject.gameObject.GetComponent<Renderer> ();
					currentRand.material = highLightedMaterial;

					ObjectsManager.instance.SelectedDoll = currentDetectedObject.gameObject;

					if (lastDetectedObject != null) {
						Renderer lastRend = lastDetectedObject.gameObject.GetComponent<Renderer> ();
						lastRend.material = normalMaterial;
					}
					lastDetectedObject = currentDetectedObject;
				}
			} else {
				
				ObjectsManager.instance.SelectedDoll = null;

				if (lastDetectedObject != null) {
					Renderer lastRend = lastDetectedObject.gameObject.GetComponent<Renderer> ();
					lastRend.material = normalMaterial;
					lastDetectedObject = null;
				}
			}
		} else {

			ObjectsManager.instance.SelectedDoll = null;

			if (lastDetectedObject != null) {
				Renderer lastRend = lastDetectedObject.gameObject.GetComponent<Renderer> ();
				lastRend.material = normalMaterial;
				lastDetectedObject = null;
			}
		}
	}


}
