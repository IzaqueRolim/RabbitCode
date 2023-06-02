using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caixa : MonoBehaviour
{
    public Sprite caixa;
    BoxCollider2D boxCollider;
    public FaseSimples fase;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
       
        if (GetComponent<Image>().sprite == caixa)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj){
            print("Entrei");
		if (obj.gameObject.tag == "Player") {
            fase.CarregaInvokeErrdao ();
			Invoke ("CarregaMorte",2);
			FaseSimples.vivo = false;
            fase.MudaPlay();
		}

	}
}
