using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Message : MonoBehaviour {

	public Text errorMsg;

	public void ErrorMessage () {
	
		errorMsg.gameObject.SetActive (true);
	}
	public void Msg(){

		errorMsg.gameObject.SetActive (true);

	}

}
