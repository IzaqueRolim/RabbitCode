using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	void VerificaInicio(){
		if(PlayerPrefs.GetInt("PrimeiraVez") == 0){
			PlayerPrefs.SetInt ("PrimeiraVez", 1);
		}
	}



	// Use this for initialization
	void Start () {
		VerificaInicio ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
