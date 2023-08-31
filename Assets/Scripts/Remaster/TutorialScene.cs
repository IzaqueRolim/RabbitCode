using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.SetInt("fezTutorial",0);
        //PlayerPrefs.SetInt("NF",0);
        bool fezTutorial = PlayerPrefs.GetInt("fezTutorial") == 1 ? true: false;
    
        if(!fezTutorial){
           // IniciaCenaTutorial();
        }
    }

    public void IniciaCenaTutorial(){
        SceneManager.LoadScene ("CenaTutorial");
    }

    public void FinalizaCenaTutorial(){
        SceneManager.LoadScene ("Menu");
    }
    
}
