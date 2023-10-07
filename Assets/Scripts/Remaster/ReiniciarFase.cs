using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarFase : MonoBehaviour
{
 

   public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProximaFase()
    {
        Time.timeScale = 1;
        int faseSelecionada = PlayerPrefs.GetInt("FaseSelecionada");
        PlayerPrefs.SetInt("FaseSelecionada",faseSelecionada+1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CarregaCena(string cena)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(cena);
    }
}
