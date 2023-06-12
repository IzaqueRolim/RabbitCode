using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour {

	public  void reiniciarFase(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void CarregaCena(string cena){
		SceneManager.LoadScene (cena);
	}

	public void SetaFezTutorial(){
	PlayerPrefs.SetInt("fezTutorial",1);
	}

}
