using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour {

	public  void reiniciarFase(){
        Time.timeScale = 1;
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void CarregaCena(string cena){
        Time.timeScale = 1;
        SceneManager.LoadScene (cena);
	}

	public void SetaFezTutorial(){
		PlayerPrefs.SetInt("fezTutorial",1);
	}

}
