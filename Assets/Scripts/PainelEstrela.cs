using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelEstrela : MonoBehaviour {

	public Image LocalEstrelas;
	public Sprite DuasEstrela;
	public Sprite TresEstrelas;
	public void Verifica(int fase){
		switch (Fase1.EstrelasNum) {
		case 2:
			LocalEstrelas.sprite = DuasEstrela;
			PlayerPrefs.SetInt ("E" + (fase - 1).ToString (), 2);
			break;
		case 3:
			LocalEstrelas.sprite = TresEstrelas;
			PlayerPrefs.SetInt ("E" + (fase - 1).ToString (), 3);
			break;
		default:
			PlayerPrefs.SetInt ("E" + (fase - 1).ToString (), 1);
			break;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
