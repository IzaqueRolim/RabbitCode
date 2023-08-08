using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public string direcao = "COL";

    readonly float velocidade = 3f;
    int posYGlobal = 1;

    bool estaNoDestino = false;
    public bool podeAndar = false;

    public List<Vector3> Destinos = new List<Vector3>();
    
    public static PlayerController Instance { get; private set; }
    int index = 0;

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
        if (direcao == "COL")
        {
            if (Destinos[index].y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].y), velocidade * Time.deltaTime);
            }
            else if (Destinos[index].x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].x, transform.position.y, 0), velocidade * Time.deltaTime);
            }
        }
        else if (direcao == "LIN")
        {
            if (Destinos[index].x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].x, transform.position.y, 0), velocidade * Time.deltaTime);
            }
            else if (Destinos[index].y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].y), velocidade * Time.deltaTime);
            }
        }
        else
        {
            index++;
        }

    }

    public void SetarDestino(List<int> X,List<int> Y)
    { 
        //Destinos = new List<Vector3>(){(X,Y);
       
        for(int i = 0;i < X.Count;i++)
        {
            Destinos.Add(new Vector3(X[i], Y[i]));
        }
        podeAndar = true;
    }

    void DefinirPosicaoInicialPlayer(int posX,int posY) {
        this.transform.position = new Vector3(posX, posY,0);
    }
}