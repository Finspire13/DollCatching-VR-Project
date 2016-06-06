using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

	public Text coinNumText;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.instance);
		coinNumText.text = "Coin: "+GameManager.instance.getCoinNum ().ToString();
		scoreText.text = "Score: "+GameManager.instance.getScore ().ToString();
	}
}
