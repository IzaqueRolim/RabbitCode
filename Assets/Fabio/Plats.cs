using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Plats : MonoBehaviour , IPointerDownHandler {


	public Image obj;

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		Image p =  Instantiate (obj);
		p.transform.position = eventData.position;
		p.transform.SetParent (gameObject.transform);
	}
	#endregion



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
