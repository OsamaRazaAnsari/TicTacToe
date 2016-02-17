using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {


	public void LoadCreateProfile(){

		Application.LoadLevel ("Profile");
	}
	public void SelectGameMode(){

		Application.LoadLevel ("Selection Game Mode");
	}
}
