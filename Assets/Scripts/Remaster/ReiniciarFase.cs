using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarFase : MonoBehaviour
{
 

   public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
