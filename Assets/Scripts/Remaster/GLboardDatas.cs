using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GLboardDatas : MonoBehaviour
{

    public GLBoard glboard;

    async void Start()
    {
       DontDestroyOnLoad(this.gameObject);
       glboard = new GLBoard("mn-8DR90dOkt-EFDhMH6rQ\r\n", SystemInfo.deviceUniqueIdentifier);
      // glboard = new GLBoard("_Ai2LJ0dkle2JED3HekFxg", SystemInfo.deviceUniqueIdentifier);
       await glboard.LOAD_USER_DATA();
       glboard.SetLastLogin(DateTime.Now);
        
       StartCoroutine(glboard.SEND_USER_DATA());

       CriarDadosUsuario();
    }


    void CriarDadosUsuario()
    {
        if (glboard.GetPlayerData() is { day_birthday: "", gender: "", id: "", name: "" })
        {
            Debug.Log("Devo salvar os dados");
        }
    }

    void CriarFases()
    {
        if(glboard.GetQuantPhaseGame() == 0)
        {
            Debug.Log("Devo criar as fases");
            glboard.SetQuantPhaseGame(18);

            for (int i = 1; i <= 18; i++)
            {
                if (glboard.GetQuantPhaseGame() > glboard.GetPhasesGames().Count)
                {
                    glboard.AddPhaseGame(i.ToString());
                }
            }
        
            StartCoroutine(glboard.SEND_USER_DATA());
        }
    }

    void Update()
    {
        
    }
}
