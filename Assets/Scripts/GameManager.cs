using UnityEngine;

using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public GameObject startCanvas;
	public GameObject playingCanvas;
	public GameObject endCanvas;
	private GameObject startCanvasInstance;
	private GameObject playingCanvasInstance;
	private GameObject endCanvasInstance;

	private int gameState;

	private int coinNum;
	private int score;
	// Use this for initialization

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);    

		DontDestroyOnLoad (gameObject);
		coinNum = 0;
		score = 0;
		gameState = 0;
		startCanvasInstance = null;
		playingCanvasInstance = null;
		endCanvasInstance = null;
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void addCoin(int num){
		coinNum += num;
	}
	public bool tryOneCoin(){
		if (coinNum > 0) {
			coinNum--;
			return true;
		} else {
			return false;
		}
	}
	public void resetCoin(){
		coinNum = 0;
	}
	public void resetScore(){
		score = 0;
	}
	public void addScore(int num){
		score += num;
	}
	public int getCoinNum(){
		return coinNum;
	}
	public int getScore(){
		return score;
	}
	public void checkToEndGame(){
		if (coinNum == 0) {
			Debug.Log ("Game End");
		}
	}

	public void startGame(){
		gameState = 0;
		startCanvasInstance = Instantiate (startCanvas) as GameObject;
	}

	public void playGame(){
		if (gameState == 0) {
			gameState = 1;
			Destroy (startCanvasInstance);
			playingCanvas = Instantiate (playingCanvas) as GameObject;
			GameLoader.instance.initPlayableItems ();
		}
	}

	public void endGame(){
		if (gameState == 1) {
			gameState = 2;
			Destroy (playingCanvas);
			endCanvas = Instantiate (endCanvas) as GameObject;
		}
	}
}
