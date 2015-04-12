using UnityEngine;
using System.Collections;

public class StoneText : MonoBehaviour {
	Player player;
	UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "×"+player.stoneStockSize;

	}
}