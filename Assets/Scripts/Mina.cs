using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour {

	public Fase1 fase1;
	Animator anim;
	public Animator AnimPlayer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}


	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "Player") {
			fase1.CarregaInvokeErrdao ();
			Invoke ("CarregaMorte",2);
			anim.SetBool ("explode",true);
			AnimPlayer.SetBool ("Morto", true);
			Fase1.vivo = false;
			Destroy (gameObject, 0.5f);
		}
	
	}

}
