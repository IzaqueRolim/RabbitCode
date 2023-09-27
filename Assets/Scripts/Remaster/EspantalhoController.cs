using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspantalhoController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void ChamarDesmaio()
    {

      PlayerController.Instance.AtivarAnimacaoDeDesmaio();
    }
}
