using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GazePointDataComponent))]
public class DeviceManager : MonoBehaviour {
    Vector2 gazePoint;
    int brainValue;
    TGCConnectionController controller;
    private int attention1;
	// Use this for initialization
	void Start () {

        gazePoint = new Vector2();

        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller.UpdateAttentionEvent += OnUpdateAttention;
	}
	
	// Update is called once per frame
	void Update () {

        brainValue = attention1;
	    // Get the last gaze point.     
        var lastGazePoint =  GetComponent<GazePointDataComponent>().LastGazePoint;
        if(lastGazePoint.IsWithinScreenBounds)     
        {         
            // Get the point in screen space coordinates.         
            gazePoint = lastGazePoint.Screen;    
        }
	}
    public float GetBrainValue()
    {
        return brainValue;
    }
    public Vector2 GetGazePoint()
    {
        return gazePoint;
    }
    void OnUpdateAttention(int value)
    {
        attention1 = value;
    }
}
