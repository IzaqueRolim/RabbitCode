using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{

    string[] inventario = { "Item 1","Item 2","Item 3","Item 4" };
    List<List<string>> inventario2 = new List<List<string>>();

    Vector2 posicaoInicial  = new Vector2(0.2f,0.5f);

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Debug.Log("começou");
    }
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
