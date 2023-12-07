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
       // glboard = new GLBoard("mn-8DR90dOkt-EFDhMH6rQ", SystemInfo.deviceUniqueIdentifier);
       // glboard = new GLBoard("_Ai2LJ0dkle2JED3HekFxg", SystemInfo.deviceUniqueIdentifier);
        glboard = new GLBoard("FVDRusTYGpRC1cCtMLobtg", SystemInfo.deviceUniqueIdentifier);
        await glboard.LOAD_USER_DATA();
        glboard.SetLastLogin(DateTime.Now);
        List<Section> sections = glboard.GetSections("1");

        Debug.Log("Porcentagem de vitoria" + CalcularPorcentagemVitoria(sections));
        
       StartCoroutine(glboard.SEND_USER_DATA());

       CriarDadosUsuario();
        CriarFases();
    }

    float CalcularPorcentagemVitoria(List<Section> sections)
    {
        if (sections == null || sections.Count == 0)
        {
            return 0f; // Sem dados para calcular
        }

        int vitorias = 0;

        // Contar quantas seções têm "VITORIA"
        foreach (Section section in sections)
        {
            if (section.conclusion == "VITORIA")
            {
                vitorias++;
            }
        }

        // Calcular a porcentagem
        float porcentagemVitoria = (float)vitorias / sections.Count * 100f;

        return porcentagemVitoria;
    }


    void CriarDadosUsuario()
    {
        if (glboard.GetPlayerData() is { day_birthday: "", gender: "", id: "", name: "" })
        {
            Debug.Log("Devo salvar os dados");
        }
    }

    async void CriarFases()
    {
        if(glboard.GetQuantPhaseGame() == 0)
        {
            glboard.SetQuantPhaseGame(18);

            for (int i = 1; i <= 18; i++)
            {
                glboard.AddPhaseGame(i.ToString());
            }
        
            StartCoroutine(glboard.SEND_USER_DATA());
        }
    }

    void Update()
    {
        
    }
}
