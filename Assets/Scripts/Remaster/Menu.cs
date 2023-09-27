using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	void Start () {
		VerificaInicio ();
	}
    void VerificaInicio()
    {
        if (PlayerPrefs.GetInt("PrimeiraVez") == 0)
        {
            PlayerPrefs.SetInt("PrimeiraVez", 1);
        }
    }

}
