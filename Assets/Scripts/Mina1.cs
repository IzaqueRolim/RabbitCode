using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina1 : MonoBehaviour {

	public FaseSimples fase1;
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
			FaseSimples.vivo = false;
			Destroy (gameObject, 0.5f);
		}
	
	}

}
