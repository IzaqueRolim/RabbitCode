﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [System.Serializable]
    public class Destino
    {
        
        public string direcao;
        public Vector3 destino;
    }

    int index = 0;
    int qtdCenouras = 0;
    int qtdEstrelas = 0;

    float velocidade = 3f;
    float velocidadeFome = 3f;
    float energia;
    string mensagemPerdeu;

    bool podeAndar = false;

    List<Destino> Destinos = new List<Destino>();
    
    public Image barraEnergia;
    public Image panelPerdeu;
    public Image panelGanhou;
    public Image imgEstrelas;
    public Sprite spriteUmaEstrela;
    public Sprite spriteDuasEstrela;
    public Sprite spriteTresEstrela;
    public Text txtCenouras;
    public Text txtEstrelas;
    public TextMeshProUGUI txtVida;

    private Animator anim;

    public static PlayerController Instance { get; private set; }

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        DefinirPosicaoInicialPlayer(0,3);

        anim = GetComponent<Animator>();
        
       // PlayerPrefs.DeleteAll();
    }

    public void DefinirPosicaoInicialPlayer(int posX, int posY)
    {
        this.transform.position = new Vector3(posX, posY, 0);
    }

    private void Update()
    {
        if (podeAndar)
        {
            if(energia > 0f)
            {
                IrAoDestino();
            }
            else
            {
                // O jimmy desmaia por falta de energia.
                mensagemPerdeu = "Suas energias acabaram!Faça um caminho mais curto da proxima vez";
                Desmaia();
            }
        }
    }

    public void IrAoDestino()
    {
        txtVida.text = ((int)energia).ToString();
        if (Destinos[index].direcao == "COL")   // Se a direção for igual a "Coluna" o player vai primeiro ate a Coluna de destino e depois para a Linha
        {
            anim.speed = 1f;
            if (Destinos[index].destino.y != transform.position.y) // Se o player ainda nao chegou na coluna de destino, ele continua andando ate chegar.  
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
                anim.SetBool("anda", true);
                anim.speed = 0.7f;
            }

            else if (Destinos[index].destino.x != transform.position.x) // Se o player ainda nao chegou na linha de destino, ele continua andando ate chegar. 
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
                anim.SetBool("anda", true);
                anim.speed = 1.5f;
            }
            else // Se ele chegou no destino, ele incrementa o index para poder ir ate o proximo destino da lista, ou finaliza o percurso se estiver na ultima posicao.
            {
                if (index == Destinos.Count - 1)    // Se o player tiver na ultima posicao da Lista ele para de andar.
                {
                    podeAndar = false;              // Para de andar.  
                    anim.SetBool("anda", false);    // Desativa a animação de andar.
                    Destinos.Clear();               // Limpa a lista de destino para adicionar outros elementos.
                    index = 0;                      // Seta o index pra 0 para poder percorrer a lista novamente.
                    return;
                }
                index++;
            }
        }

        // Se aplica a mesma logica porem aqui ele vai primeiro em direcao a Linha e depois pra Coluna
        else if (Destinos[index].direcao == "LIN")
        {
            
            if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
                anim.SetBool("anda", true);
                anim.speed = 1.5f;
            }
            else if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
                anim.SetBool("anda", true);
                anim.speed = 0.7f;
            }
            else
            {
                if (index == Destinos.Count - 1)
                {
                    podeAndar = false;
                    anim.SetBool("anda", false);
                    Destinos.Clear();
                    index = 0;
                    return;
                }
                index++;
            }
        }

        barraEnergia.fillAmount = energia / 20;
    }

    public void SetarDestino(List<string> direcao, List<int> X, List<int> Y)
    {
        for (int i = 0; i < X.Count; i++)
        {
            // Esse 5 - Y[i] inverte o valor da linha(5 vira 0, 4 vira 1, 3 vira 2, 2 vira 3, 1 vira 4, 0 vira 5)
            // Essa mudança foi solicitado pelo prof Carlos no dia 5/10/23.
            Destinos.Add(new Destino { direcao = direcao[i], destino = new Vector3(X[i], 5-Y[i]) });

            // Se alguma posicao desse array for a do Jimmy, ele inicia nela.
            // Resolve o erro dele sempre voltar pra primeira posicao.
            if(transform.position == new Vector3(X[i], Y[i]))
            {
                index = i;
            }
        }
        podeAndar = true;
        
    }

    public void SetarEnergiaInicial(float energiaInicial) {
        energia  = energiaInicial;
        txtVida.text = ((int)energia).ToString();
    }

    public void Desmaia()
    {
        panelPerdeu.gameObject.SetActive(true);

        int qtdFilhosPanel = panelPerdeu.transform.GetChild(0).childCount;

        Debug.Log(qtdFilhosPanel.ToString()+"Ola");
        panelPerdeu.transform.GetChild(0).GetChild(qtdFilhosPanel-1).GetComponent<TextMeshProUGUI>().text = mensagemPerdeu;  
    }

    public void AtivarAnimacaoDeDesmaio()
    {
        anim.SetTrigger("desmaia");
    }

    public void Ganhou()
    { 

        int FaseSelecionada = PlayerPrefs.GetInt("FaseSelecionada");
        int QuantidadeDeEstrelaDaFase = PlayerPrefs.GetInt("QuantidadeDeEstrelaDaFase" + FaseSelecionada.ToString());
        
        if (QuantidadeDeEstrelaDaFase <= qtdEstrelas){
            // Seta a quantidade de estrelas da fase para vizualicação na tela de seleção de fases.
            PlayerPrefs.SetInt("QuantidadeDeEstrelaDaFase" + FaseSelecionada.ToString(), qtdEstrelas);
        }

        // Seta que a fase foi concluida
        PlayerPrefs.SetInt("Fase" + FaseSelecionada, 1);

        // Abre o painel com a mensagem de vitoria.
        panelGanhou.gameObject.SetActive(true);

        // Seta sprite de quantidades de estrelas.
        Sprite spriteQtdEstrelas = qtdEstrelas == 3 ? spriteTresEstrela : qtdEstrelas == 2 ? spriteDuasEstrela : spriteUmaEstrela;
        imgEstrelas.sprite = spriteQtdEstrelas;
    }

    public Vector2 GetPosicaoPlayer()
    {
        return transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cenoura")
        {
            qtdCenouras++;
            txtCenouras.text = "Cenouras: " + qtdCenouras.ToString();
            energia+=5;
             
            Destroy(collision.gameObject);
            //Animacao do coelho guardando ou comendo a cenoura.
        }
        if (collision.gameObject.tag == "estrela")
        {
            qtdEstrelas++;
            txtEstrelas.text = "Estrelas: " + qtdEstrelas.ToString();

            Destroy(collision.gameObject);
            //Animacao da estrela sumindo.
        }
        if (collision.gameObject.tag == "armadilha")
        {
            mensagemPerdeu = "Cuidado com as armadilhas";
            podeAndar = false;
            
            collision.GetComponent<Animator>().SetTrigger("aparecer");

        }
        if (collision.gameObject.tag == "obstaculo")
        {
            mensagemPerdeu = "Cuidado com as caixas";
            podeAndar = false;
            anim.SetTrigger("desmaia");

        }
        if (collision.gameObject.tag == "toca")
        {
            Debug.Log("Ola");
            Ganhou();
        }
    }

}