using UnityEngine;
using System.Collections;

public class ObjectsManager : MonoBehaviour {

	public static ObjectsManager instance = null;
	// Use this for initialization
	private GameObject selectedDoll;
	private ArrayList dolls;
	private GameObject box;
	private GameObject handle;

	public GameObject SelectedDoll
	{
		get{ return selectedDoll; }
		set{ selectedDoll = value; }
	}
	public GameObject Box
	{
		get{ return box; }
		set{ box = value; }
	}
	public GameObject Handle
	{
		get{ return handle; }
		set{ handle = value; }
	}

	public ArrayList Dolls
	{
		get{ return dolls; }
		set{ dolls = value; }
	}

	public void addDoll(GameObject doll){
		dolls.Add (doll);
	}
	public void removeDoll(GameObject doll){
		dolls.Remove (doll);
	}

	public void clearAll(){
		selectedDoll = null;
		dolls = new ArrayList ();
		box = null;
		handle = null;
	}

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    

		DontDestroyOnLoad (gameObject);
		dolls = new ArrayList ();
	}

	void Start () {
		selectedDoll = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
