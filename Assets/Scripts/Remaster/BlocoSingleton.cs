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
            PlayerController.Instance.SetarDestino(Direcao, Linha, Coluna);
        }
    }

    public void SetarDestinoPlayer()
    {
        GetValoresDropdown();
        PlayerController.Instance.SetarDestino(Direcao, Linha, Coluna);
    }

    private void GetValoresDropdown()
    {
        int qtdValoresJogados = CountActiveGameObjects(this.transform);

        // Limpo as listas pois os valores repetem se nao limpar
        Linha.Clear();
        Coluna.Clear();
        Direcao.Clear();

        //  Começa em 2 porque eu quero ignorar  o 1 primeiro objeto dentro do GameObject "Panel - LocalCodigo"
        for (int i = 2; i < qtdValoresJogados; i++)
        {
            // Faço a verificação do sprite pra diferenciar qual o bloco de linha e coluna para nao setar errado.
            TMP_Dropdown linha;
            TMP_Dropdown coluna;
            string direcao;

            Transform childTransform = this.transform.GetChild(i);
            
            Image childImage = childTransform.GetComponent<Image>();

                Debug.Log(childTransform);
            if (childImage.sprite == spriteBlocoVerde)
            {
                linha = childTransform.GetChild(0).GetComponent<TMP_Dropdown>();
                coluna = childTransform.GetChild(1).GetComponent<TMP_Dropdown>();
                direcao = "COL";
            }
            else
            {
                linha = childTransform.GetChild(1).GetComponent<TMP_Dropdown>();
                coluna = childTransform.GetChild(0).GetComponent<TMP_Dropdown>();
                direcao = "LIN";
            }

            Direcao.Add(direcao);
            Linha.Add(linha.value);
            Debug.Log(5 - linha.value);
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

