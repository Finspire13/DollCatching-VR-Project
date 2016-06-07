using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayingCanvasAction : MonoBehaviour {

	public Text coinNumText;
	public Text scoreText;
	public Text brainValueText;
	public Button endButton;

	// Use this for initialization
	void Start () {
		endButton.onClick.AddListener (() => clickEndButton ());
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.instance);
		coinNumText.text = "Coin: "+GameManager.instance.getCoinNum ().ToString();
		scoreText.text = "Score: "+GameManager.instance.getScore ().ToString();
		brainValueText.text = "BrainValue: " + GameManager.instance.BrainValue.ToString ();
	}

	void clickEndButton(){
		GameManager.instance.changeGameState (GameState.end);
	}
}
