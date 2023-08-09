using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [System.Serializable]
    public class Destino
    {
        public string direcao;
        public Vector3 destino;
    }


    int index = 0;
    
    float velocidade = 3f;
    float velocidadeFome = 3f;
    public float energia = 200f;

    bool podeAndar = false;
    
    public static PlayerController Instance { get; private set; }

    public List<Destino> Destinos = new List<Destino>();

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
        DefinirPosicaoInicialPlayer(0, 0);
    }


    private void Update()
    {
        //IrAoDestino(5, 2);
        if (podeAndar)
        {
            IrAoDestino();
        }
    }
    public void IrAoDestino()
    {
        if (Destinos[index].direcao == "COL")
        {
            if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia += Time.deltaTime * velocidadeFome;
            }
               
            else if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y, 0), velocidade * Time.deltaTime);
                energia += Time.deltaTime * velocidadeFome;
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
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y, 0), velocidade * Time.deltaTime);
                energia += Time.deltaTime* velocidadeFome;
            }   
            else if (Destinos[index].destino.y != transform.position.y)
            {             
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
                energia += Time.deltaTime * velocidadeFome;
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
    }
    

    void DefinirPosicaoInicialPlayer(int posX,int posY) {
        this.transform.position = new Vector3(posX, posY,0);
    }

    public void Desmaia()
    {
        podeAndar = false;
        // animacao para andar
    }

    public void SetarDestino(List<string> direcao, List<int> X, List<int> Y)
    {
        for (int i = 0; i < X.Count; i++)
        {
            Destinos.Add(new Destino { direcao = direcao[i], destino = new Vector3(X[i], Y[i]) });
        }
        podeAndar = true;
    }

}