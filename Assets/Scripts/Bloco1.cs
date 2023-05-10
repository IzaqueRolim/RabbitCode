using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bloco1 : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler {


	Vector3 posicao;
	public Algoritmo algoritmo;
	public Sprite x;

	public static bool Encaixado;

	public FaseSimples fase1;



	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		posicao = gameObject.transform.position;

	}
	#endregion



	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		gameObject.transform.position = eventData.position;
	}
	#endregion



	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData)
	{
		gameObject.transform.position = posicao;


		if (BlocoLocal.tocando == true) {
			Encaixado = true;
			algoritmo.AlgoritmoP [algoritmo.indice].sprite = x;
			algoritmo.DropLinha [algoritmo.indice].gameObject.SetActive (true);
			algoritmo.DropColuna [algoritmo.indice].gameObject.SetActive (true);
			algoritmo.AlgoritmoP[algoritmo.indice].tag = "desativado";

			fase1.contadorBlocos++;


			algoritmo.indice++;
			if (algoritmo.indice < 10) {
				algoritmo.AlgoritmoP [algoritmo.indice].gameObject.SetActive (true);
				Invoke ("MudaEncaixado", 1);
			}
		}

	}
	#endregion

	void MudaEncaixado(){
		Encaixado = false;
	}

	// Use this for initialization
	void Start () {
		Encaixado = false;
	}

}
