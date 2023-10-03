using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspantalhoController : MonoBehaviour
{
    

    public void ChamarDesmaio()
    {
      PlayerController.Instance.AtivarAnimacaoDeDesmaio();
    }
}
