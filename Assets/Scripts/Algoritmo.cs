using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Algoritmo : MonoBehaviour {


	public List <Image> AlgoritmoP;
	public List <GameObject> DropLinha;
	public List <GameObject> DropColuna;

	public int indice;


	// Use this for initialization
	void Start () {
		indice = 0;
		AlgoritmoP [indice].gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
