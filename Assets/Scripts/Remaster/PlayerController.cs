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

    List<Destino> Destinos;

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
            if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
            }
            else if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y, 0), velocidade * Time.deltaTime);
            }
            else
            {
                if(index == Destinos.Count-1){
                    podeAndar = false;
                    Destinos.Clear();
                    index = 0;
                    return;
                }
                index++;
            }
        }
        else if (direcao == "LIN")
        {
            if (Destinos[index].destino.x != transform.position.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Destinos[index].destino.x, transform.position.y, 0), velocidade * Time.deltaTime);
            }
            else if (Destinos[index].destino.y != transform.position.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Destinos[index].destino.y), velocidade * Time.deltaTime);
            }
            else
            {
                if(index == Destinos.Count-1){
                    podeAndar = false;
                    Destinos.Clear();
                    index = 0;
                    return;
                }
                index++;
            }
        }
        

    }

    public void SetarDestino(List<string> direcao, List<int> X,List<int> Y)
    { 
        //Destinos = new List<Vector3>(){(X,Y);
       
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