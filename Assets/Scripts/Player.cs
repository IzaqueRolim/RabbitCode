using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static int ContCenouras; 

	public Fase1 fase1;
	public Animator AnimPlayer;

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "cenoura"){
			Destroy (obj.gameObject);
			ContCenouras++;
		}

		if(obj.tag == "buraco"){
			Fase1.vivo = false;
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
