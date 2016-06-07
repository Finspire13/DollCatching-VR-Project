using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndCanvasAction : MonoBehaviour {

	public Button retryButton;
	public Text endText;
	// Use this for initialization
	void Start () {
		retryButton.onClick.AddListener (() => clickRetryButton ());
		endText.text="Game Over. Score: "+GameManager.instance.getScore ().ToString();
	}

	// Update is called once per frame
	void Update () {
		endText.text="Game Over. Score: "+GameManager.instance.getScore ().ToString();
	}

	void clickRetryButton(){
		GameManager.instance.changeGameState (GameState.start);
		GameManager.instance.addCoin (3);
	}
}
