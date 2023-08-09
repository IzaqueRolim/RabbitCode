using System.Collections;
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
    float energia = 20f;

    bool podeAndar = false;

    List<Destino> Destinos = new List<Destino>();
    
    public Image barraEnergia;
    public TextMeshProUGUI txtCenouras;
    public TextMeshProUGUI txtEstrelas;

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
    }

    void DefinirPosicaoInicialPlayer(int posX, int posY)
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
                Desmaia();
            }
        }
    }

    public void IrAoDestino()
    {
        if (Destinos[index].direcao == "COL")
        {
            if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
            }

            else if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
            }
            else
            {
                if (index == Destinos.Count - 1)
                {
                    podeAndar = false;
                    Destinos.Clear();
                    index = 0;
                    return;
                }
                index++;
            }
        }
        else if (Destinos[index].direcao == "LIN")
        {

            if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
            }
            else if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia -= Time.deltaTime * velocidadeFome;
            }
            else
            {
                if (index == Destinos.Count - 1)
                {
                    podeAndar = false;
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
            Destinos.Add(new Destino { direcao = direcao[i], destino = new Vector3(X[i], Y[i]) });
        }
        podeAndar = true;
    }

    public void Desmaia()
    {
        podeAndar = false;
        // animacao para andar
    }

    public void Ganhou()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cenoura")
        {
            qtdCenouras++;
            txtCenouras.text = "Cenouras: " + qtdCenouras.ToString();

            Destroy(collision.gameObject);
            //Animacao do coelho guardando ou comendo a cenoura.
        }
        if (collision.gameObject.tag == "estrela")
        {
            qtdEstrelas++;
            txtEstrelas.text = "Estrelas: " + qtdEstrelas.ToString();
        }
        if (collision.gameObject.tag == "armadilha")
        {
            //Desmaia();
        }
        if (collision.gameObject.tag == "obstaculo")
        {

        }
        if (collision.gameObject.tag == "toca")
        {
            Ganhou();
        }
    }

}