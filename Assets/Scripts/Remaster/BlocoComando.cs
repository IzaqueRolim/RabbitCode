using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;



public class BlocoComando : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public  Vector3 posicaoInicial;
    Vector3 posicaoDestino;
    public bool estaTocando = false;


    private Sprite spriteDesteBloco;
    public Sprite spriteBlocoVerde;
    public Sprite spriteBordaBlocoVisivel;
    public Sprite spriteBordaBlocoInvisivel;

    TMP_Dropdown dropdownLinha;
    TMP_Dropdown dropdownColuna;

    List<string> linhas = new List<string>();
    List<string> colunas = new List<string>();

    // O bloco 
    GameObject blocoLocalCodigo = null;
    GameObject paiBlocoLocalCodigo;

    int index = 0;

    void Start()
    {
        posicaoInicial = this.transform.position;
        spriteDesteBloco = GetComponent<Image>().sprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(dropdownColuna.value);
        }
    }


    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
    #endregion

    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

    }
    #endregion

    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData)
    {
        if (estaTocando)
        {
            // Desativa o Collider do bloco(para resolver o bug de estar sumindo) e define o sprite como o sprite do bloco deste componente
            blocoLocalCodigo.GetComponent<BoxCollider2D>().enabled = false;
            blocoLocalCodigo.GetComponent<Image>().sprite = spriteDesteBloco;
            UnityEngine.Color corVisivel = blocoLocalCodigo.GetComponent<Image>().color;
            corVisivel.a = 1f;
            blocoLocalCodigo.GetComponent<Image>().color = corVisivel;

            DefinirValoresDoDropdown();
        }

        this.transform.position = posicaoInicial;
    }
    #endregion



    private void DefinirValoresDoDropdown()
    {
        // NESSA FUNCAO EU:
        // 1)ATIVO O DROPDOWN DE LINHA E DE COLUNA QUE SAO FILHAS DO GAMEOBJECT "BLOCOLOCALCODIGO" 
        // 2)SETO O "PAIBLOCOLOCALCODIGO" PARA ACESSAR OS BLOCOS DE COMANDOS
        // 3)SETO OS VALORES DO DROPDOWN DE LINHA E COLUNA DE ACORDO COM O SPRITE(SE FOR VERDE OU AZUL) {VALORES = [0,1,2,3,4,5] e [0,1,2,3,4,5,6,7,8,9,10,11]

        // Obtenha os Dropdowns que sao filhas do blocolocalcodigo.
        dropdownLinha = blocoLocalCodigo.transform.GetChild(0).gameObject.GetComponent<TMP_Dropdown>();
        dropdownColuna = blocoLocalCodigo.transform.GetChild(1).gameObject.GetComponent<TMP_Dropdown>();

        // Ative os DropDown de linha e coluna.
        dropdownLinha.gameObject.SetActive(true);
        dropdownColuna.gameObject.SetActive(true);

        // Limpe as listas de linhas e colunas para nao incrementar no proximo bloco.
        linhas.Clear();
        colunas.Clear();

        // Determine as linhas e caso o sprite for verde, inverte a linha pela coluna.
        int numLinhas = 6;
        int numColunas = 12;

        if (this.GetComponent<Image>().sprite == spriteBlocoVerde)
        {
            numLinhas = 12;
            numColunas = 6;
        }

        // Preencha as listas de linhas e colunas
        for (int i = 0; i < numLinhas; i++)
        {
            linhas.Add(i.ToString());
        }

        for (int i = 0; i < numColunas; i++)
        {
            colunas.Add(i.ToString());
        }

       
        // Adicione as opções aos Dropdowns
        dropdownLinha.ClearOptions();
        dropdownLinha.AddOptions(linhas);

        dropdownColuna.ClearOptions();
        dropdownColuna.AddOptions(colunas);

        // Marque o blocoLocalCodigo como "ativo"
        blocoLocalCodigo.tag = "ativo";

        // Obtenha o pai do blocoLocalCodigo
        paiBlocoLocalCodigo = blocoLocalCodigo.transform.parent.gameObject;

        // Conte o número de objetos ativos no pai
        int qtdObjetosAtivos = CountActiveGameObjects(paiBlocoLocalCodigo.transform);
        bool chegouNaQuantidadeMaximaDeBlocos = paiBlocoLocalCodigo.transform.childCount == qtdObjetosAtivos;
        int indexDoProximoBloco = chegouNaQuantidadeMaximaDeBlocos ? qtdObjetosAtivos-1 : qtdObjetosAtivos;

        // Obtem e ativa o proximo bloco que está invisivel.
        blocoLocalCodigo = paiBlocoLocalCodigo.transform.GetChild(indexDoProximoBloco).gameObject;
        blocoLocalCodigo.SetActive(true);

        // Incrementar o índice
        index++;

    }

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Quando ele detecta uma colisao:
        // 1)Seta a booleana "estaTocando" para true(para que quando estiver tocando e o usuario soltar o bloco, ele aparecer no array de blocos de comandos)
        // 2)Seta a posicao de destino como a posicao do objeto que colidiu(definir a posicao do bloco de comando)
        // 3)Muda o sprite do bloco de comando que esta no container de bloco(para dar um efeito de hover)

        if (collision.gameObject.tag == "blocoLocalCodigo")
        {
            estaTocando = true;
            posicaoDestino = collision.transform.position;
            blocoLocalCodigo = collision.gameObject;
            UnityEngine.Color corVisivel = blocoLocalCodigo.GetComponent<Image>().color;
            corVisivel.a = 1f;
            blocoLocalCodigo.GetComponent<Image>().color = corVisivel;
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Quando ele sai da colisâo:
        // 1)Seta o sprite do bloco como nulo(para dar continuidade no efeito de hover)
        // 

        if (collision.gameObject.tag == "blocoLocalCodigo")
        {
            UnityEngine.Color corTransparente = blocoLocalCodigo.GetComponent<Image>().color;
            corTransparente.a = 0f;
            blocoLocalCodigo.GetComponent<Image>().color = corTransparente;
            estaTocando = false;
        }
    }


}