using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelecaoFase : MonoBehaviour {


	public List <Image> Estrelas;
	public List <Button> Botao;

	public Sprite UmaEstrela;
	public Sprite DuasEstrela;
	public Sprite TresEstrela;


	public void selecionaFase(int x){
		PlayerPrefs.SetInt ("FaseSelecionada",x);
		SceneManager.LoadScene ("Gameplay");
	}
		
	void VerificaBotoes(){
		Botao [0].interactable = true;

		for(int i = 1; i < 20; i ++){
			if (PlayerPrefs.GetInt ("B" + i.ToString ()) == 0) {
				Botao [i].interactable = false;
			} else {
				Botao [i].interactable = true;
			}
		}
		for (int i = 0; i < 20; i++) {
			if (PlayerPrefs.GetInt ("E" + i.ToString ()) == 1) {
				Estrelas [i].sprite = UmaEstrela;
			} else if (PlayerPrefs.GetInt ("E" + i.ToString ()) == 2) {
				Estrelas [i].sprite = DuasEstrela;
			} else if (PlayerPrefs.GetInt ("E" + i.ToString ()) == 3) {
				Estrelas [i].sprite = TresEstrela;
			}
		}

	}






	// Use this for initialization
	void Start () {
		VerificaBotoes ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
