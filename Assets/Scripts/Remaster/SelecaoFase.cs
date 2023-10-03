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

    void Start()
    {
        VerificaBotoes();
    }

    public void selecionaFase(int x){
		PlayerPrefs.SetInt ("FaseSelecionada",x);
		SceneManager.LoadScene ("2 - Gameplay");
	}
		
	void VerificaBotoes(){
		Botao [0].interactable = true;

		for(int i = 1; i < 20; i ++){
			if (PlayerPrefs.GetInt ("Fase" + i.ToString ()) == 0) { // Caso o dado guardado na memoria seja igual a 0, quer dizer que a fase não foi concluida
				Botao [i].interactable = false;
			} else {
				Botao [i].interactable = true;
			}
		}
		for (int i = 0; i < 20; i++) {
			if (PlayerPrefs.GetInt ("QuantidadeDeEstrelaDaFase" + i.ToString ()) == 1) {
				Estrelas [i].sprite = UmaEstrela;
			} else if (PlayerPrefs.GetInt ("QuantidadeDeEstrelaDaFase" + i.ToString ()) == 2) {
				Estrelas [i].sprite = DuasEstrela;
			} else if (PlayerPrefs.GetInt ("QuantidadeDeEstrelaDaFase" + i.ToString ()) == 3) {
				Estrelas [i].sprite = TresEstrela;
			}
		}

	}

	
}
