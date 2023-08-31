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
        int faseSelecionada = PlayerPrefs.GetInt("FaseSelecionada");
        PlayerPrefs.SetInt("FaseSelecionada",faseSelecionada+1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
