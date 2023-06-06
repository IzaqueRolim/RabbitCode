using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

	public static int ContCenouras; 

	public FaseSimples fase1;
	public Animator AnimPlayer;
	public Text txtCenoura;

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "cenoura"){
			Destroy (obj.gameObject);
			ContCenouras++;
			txtCenoura.text = ContCenouras.ToString();
		}

		if(obj.tag == "buraco"){
			FaseSimples.vivo = false;
			fase1.CarregaInvokeErrdao ();
			AnimPlayer.SetBool ("Morto", true);
		}
	}



	// Use this for initialization
	void Start () {
		ContCenouras = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
