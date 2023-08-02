using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bloco1 : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler {


	Vector3 posicao;
	public Algoritmo algoritmo;
	public FaseSimples faseSimples;
	public Sprite sprite;

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
			List<string> optionsLinha = new List<string>();
			List<string> optionsColuna = new List<string>();
			Encaixado = true;

			bool spriteEhVerde = GetComponent<Image>().sprite == sprite;
			if(spriteEhVerde){
				for(int i = 0; i< 12;i++){ 
					optionsLinha.Add(i.ToString());
					if(i<6){
						optionsColuna.Add(i.ToString());
					}
				}
			}
			else{
				for(int i = 0; i< 12;i++){
					optionsColuna.Add(i.ToString());
					if(i<6){
						optionsLinha.Add(i.ToString());
					}
				}
				//optionsColuna.Add("0","1","2","3","4","5","6","7","8","9","10","11");
				//optionsLinha.Add("0","1","2","3","4","5");
			}
			algoritmo.AlgoritmoP [algoritmo.indice].sprite = GetComponent<Image>().sprite;

			algoritmo.DropLinha[algoritmo.indice].GetComponent<Dropdown>().AddOptions(optionsLinha);
			algoritmo.DropColuna[algoritmo.indice].GetComponent<Dropdown>().AddOptions(optionsColuna);

			algoritmo.DropLinha [algoritmo.indice].gameObject.SetActive (true);
			algoritmo.DropColuna [algoritmo.indice].gameObject.SetActive (true);
			//algoritmo.AlgoritmoP[algoritmo.indice].tag = "desativado";

			fase1.contadorBlocos++;
			fase1.AddDir(spriteEhVerde?"COL":"LIN");


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
