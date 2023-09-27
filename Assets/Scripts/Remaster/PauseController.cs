using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPause;


    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    
    public void voltarPause()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

}
