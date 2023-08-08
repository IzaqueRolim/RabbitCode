using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


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

        Linha.Clear();
        Coluna.Clear();
        //  Começa em 2 porque eu quero ignorar 2 primeiros objetos dentro do GameObject "Panel - LocalCodigo"
        for (int i = 2; i <= qtdValoresJogados; i++)
        {
            Dropdown linha  = this.transform.GetChild(i).GetChild(0).GetComponent<Dropdown>();
            Dropdown coluna = this.transform.GetChild(i).GetChild(1).GetComponent<Dropdown>();
            Direcao[i] = this.transform.GetChild(i).GetComponent<Image>().sprite == spriteBlocoVerde? "":"";

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

    private void DefinirLinha(Dropdown dropdown)
    {
        Linha.Add(dropdown.value);
    }
    private void DefinirColuna(Dropdown dropdown)
    {
        Coluna.Add(dropdown.value);
    }

}

