using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GLboardDatas : MonoBehaviour
{

    public GLBoard glboard;
    public GameObject formUsuario;

    async void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       // glboard = new GLBoard("mn-8DR90dOkt-EFDhMH6rQ", SystemInfo.deviceUniqueIdentifier);
       // glboard = new GLBoard("_Ai2LJ0dkle2JED3HekFxg", SystemInfo.deviceUniqueIdentifier);
        glboard = new GLBoard("FVDRusTYGpRC1cCtMLobtg", SystemInfo.deviceUniqueIdentifier);
        await glboard.LOAD_USER_DATA();
        glboard.SetLastLogin(DateTime.Now);

        
        StartCoroutine(glboard.SEND_USER_DATA());

        CriarDadosUsuario();
        CriarFases();

     
    }

    public  void CalcularPorcentagemVitoria(string phase_id)
    {

        List<Section> sections = glboard.GetSections(phase_id);
        if (sections == null || sections.Count == 0)
        {
           return; // Sem dados para calcular
        }

        int vitorias = 0;

        // Contar quantas se��es t�m "VITORIA"
        foreach (Section section in sections)
        {
            if (section.conclusion == "VITORIA")
            {
                vitorias++;
            }
        }

        // Calcular a porcentagem
        float porcentagemVitoria = (float)vitorias / sections.Count * 100f;

        if (porcentagemVitoria < 20)
        {
            glboard.SetDificultyPhase(phase_id, "MUITO DIFICIL");
        }
        else if (porcentagemVitoria < 40)
        {
            glboard.SetDificultyPhase(phase_id, "DIFICIL");
        }
        else if (porcentagemVitoria < 60)
        {
            glboard.SetDificultyPhase(phase_id, "INTERMEDIARIA");
        }
        else if (porcentagemVitoria < 80)
        {
            glboard.SetDificultyPhase(phase_id, "FACIL");
        }
        else if (porcentagemVitoria == 100)
        {
            glboard.SetDificultyPhase(phase_id, "MUITO FACIL");
        }

        StartCoroutine(glboard.SEND_USER_DATA());
    }


    void CriarDadosUsuario()
    {
        if (glboard.GetPlayerData() is { day_birthday: "", gender: "", id: "", name: "" })
        {
            Debug.Log("Devo salvar os dados");
            formUsuario.SetActive(true);
        }
    }

    public void EnviarNome(Text nome)
    {
        glboard.SetPlayerData(nome.text,"",GENDER.OUTROS);
    }
    public void EnviarGenero(string genero)
    {
        GENDER gender = genero == "M" ? GENDER.MASCULINO : genero =="F"?GENDER.FEMININO:GENDER.OUTROS;
        glboard.SetPlayerData(glboard.GetPlayerData().name, "", gender);
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
