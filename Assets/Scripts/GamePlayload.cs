using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayload : MonoBehaviour {

	public InputField player1;
	public InputField player2;

	public void LoadLevel () {
		PlayerPrefs.SetInt ("key1",0);
		PlayerPrefs.SetInt ("key2", 0);

		PlayerPrefs.SetString ("player1name", player1.text);
		PlayerPrefs.SetString ("player2name", player2.text);

		Application.LoadLevel ("GamePlay");
	}
}
