using UnityEngine;

using System.Collections;

public enum GameState{start,playing,end};

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public GameObject startCanvas;
	public GameObject playingCanvas;
	public GameObject endCanvas;
	private GameObject currentCanvasInstance;
	private int brainValue;

	public int BrainValue
	{
		get{ return brainValue; }
		set{ brainValue = value; }
	}

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
		currentCanvasInstance = null;
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

	public void changeGameState(GameState gameState){
		switch (gameState) {
		case GameState.start:
			Destroy (currentCanvasInstance);
			score = 0;
			currentCanvasInstance = Instantiate (startCanvas) as GameObject;
			break;
		case GameState.playing:
			Destroy (currentCanvasInstance);
			currentCanvasInstance = Instantiate (playingCanvas) as GameObject;
			GameLoader.instance.initPlayableItems ();
			break;
		case GameState.end:
			Destroy (currentCanvasInstance);
			currentCanvasInstance = Instantiate (endCanvas) as GameObject;
			GameLoader.instance.destroyPlayableItems ();
			coinNum = 0;
			break;
		default:
			break;
		}
	}
}
