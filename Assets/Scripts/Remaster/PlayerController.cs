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



    public string direcao = "COL";

    readonly float velocidade = 3f;
    int posYGlobal = 1;

    bool estaNoDestino = false;
    public bool podeAndar = false;
    
    public static PlayerController Instance { get; private set; }
    public int index = 0;

    List<Destino> Destinos = new List<Destino>();

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
        if (Destinos.Count == 0)
        {
            return;
        }

        Destino destinoAtual = Destinos[index];

        Vector3 novaPosicao = Vector3.zero;

        if (destinoAtual.direcao == "COL")
        {
            if (Mathf.Abs(destinoAtual.destino.y - transform.position.y) > 0.01f)
            {
                novaPosicao = new Vector3(transform.position.x, destinoAtual.destino.y, transform.position.z);
            }
            else if (Mathf.Abs(destinoAtual.destino.x - transform.position.x) > 0.01f)
            {
                novaPosicao = new Vector3(destinoAtual.destino.x, transform.position.y, transform.position.z);
            }
        }
        else if (destinoAtual.direcao == "LIN")
        {
            if (Mathf.Abs(destinoAtual.destino.x - transform.position.x) > 0.01f)
            {
                novaPosicao = new Vector3(destinoAtual.destino.x, transform.position.y, transform.position.z);
            }
            else if (Mathf.Abs(destinoAtual.destino.y - transform.position.y) > 0.01f)
            {
                novaPosicao = new Vector3(transform.position.x, destinoAtual.destino.y, transform.position.z);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, novaPosicao, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, novaPosicao) < 0.01f)
        {
            index++;

            if (index >= Destinos.Count)
            {
                FinalizarMovimento();
            }
        }
    }

    private void FinalizarMovimento()
    {
        podeAndar = false;
        Destinos.Clear();
        index = 0;
    }


    public void SetarDestino(List<string> direcao, List<int> X,List<int> Y)
    {
       
        for(int i = 0;i < X.Count;i++)
        {
            Destinos.Add(new Destino{direcao = direcao[i], destino = new Vector3(X[i], Y[i])} );
        }
        podeAndar = true;
    }

    void DefinirPosicaoInicialPlayer(int posX,int posY) {
        this.transform.position = new Vector3(posX, posY,0);
    }
}