using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class BlocoSingleton : MonoBehaviour
{
   
    public List<int> Linha;
    public List<int> Coluna;
    public List<string> Direcao;

    PlayerController playerController = PlayerController.Instance;

    public Sprite spriteBlocoVerde;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            GetValoresDropdown();
            PlayerController.Instance.SetarDestino(Direcao,Linha, Coluna);
        }
    }

    private void GetValoresDropdown()
    {
        int qtdValoresJogados = CountActiveGameObjects(this.transform);

        // Limpo as listas pois os valores repetem se nao limpar
        Linha.Clear();
        Coluna.Clear();
        Direcao.Clear();

        //  Começa em 2 porque eu quero ignorar 2 primeiros objetos dentro do GameObject "Panel - LocalCodigo"
        for (int i = 1; i <= qtdValoresJogados; i++)
        {
            TMP_Dropdown linha  = this.transform.GetChild(i).GetChild(0).GetComponent<TMP_Dropdown>();
            TMP_Dropdown coluna = this.transform.GetChild(i).GetChild(1).GetComponent<TMP_Dropdown>();
            string direcao = this.transform.GetChild(i).GetComponent<Image>().sprite == spriteBlocoVerde? "COL":"LIN";

            Direcao.Add(direcao);
            Linha.Add(linha.value);
            Coluna.Add(coluna.value);
        }
    }


    // Essa função retorna a quantidade de gameObjects ativos dentro de um transform pai.
    int CountActiveGameObjects(Transform parent)
    {
        int count = 0;

        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf && child.GetComponent<Image>().color.a == 1f)
            {
                count++;
            }
        }

        return count;
    }


}

