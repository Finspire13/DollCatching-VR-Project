using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

	public GameObject box;
	public GameObject doll;
	public GameObject handle;
	public GameObject gameManager;
	public GameObject objectsManager;

	public static GameLoader instance = null;
	// Use this for initialization
	void Awake () {

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    

		DontDestroyOnLoad (gameObject);

		initManagers ();

		//initPlayableItems ();

		GameManager.instance.changeGameState (GameState.start);

	}

	void Start(){
		GameManager.instance.addCoin (3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void initManagers()
	{
		if (GameManager.instance == null) {
			Instantiate (gameManager);
		}
		if (ObjectsManager.instance == null) {
			Instantiate (objectsManager);
		}
		ObjectsManager.instance.clearAll ();
	}

	public void initPlayableItems(){

		for (int i = 0; i < 10; i++) {
			GameObject dollInstance = Instantiate (doll) as GameObject;
			dollInstance.transform.position= new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 15f), Random.Range(-7f, 7f));
			dollInstance.transform.localScale= new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), Random.Range(1f, 5f));
			dollInstance.transform.localEulerAngles= new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
			ObjectsManager.instance.addDoll (dollInstance);
		}

		GameObject boxInstance = Instantiate (box)as GameObject;
		GameObject handleInstance = Instantiate (handle)as GameObject;
		ObjectsManager.instance.Box = boxInstance;
		ObjectsManager.instance.Handle = handleInstance;
	}

	public void destroyPlayableItems(){
		Destroy (ObjectsManager.instance.Box);
		Destroy (ObjectsManager.instance.Handle);
		foreach(GameObject g in ObjectsManager.instance.Dolls)	{
			Destroy (g);
		}
		ObjectsManager.instance.clearAll ();
	}
}
