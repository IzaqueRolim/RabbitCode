using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faseController : MonoBehaviour
{
    public GameObject prefabArmadilha;
    public GameObject prefabObstaculo;
    public GameObject prefabToca;
    public GameObject prefabCenoura;
    public GameObject prefabEstrela;

    void Start()
    {
        MontarFase(1);
    }

    void MontarFase(int numeroFase)
    {
        switch (numeroFase)
        {
            case 1:

                for (int i = 0; i < 7; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 6; i < 9; i++)
                {
                    DefinirObstaculo(i, 4);
                }
                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 0);
                }
                for (int i = 5; i > 2; i--)
                {
                    DefinirObstaculo(10, i);
                }

                DefinirArmadilha(1, 3);
                DefinirArmadilha(3, 3);
                DefinirArmadilha(10, 2);

                DefinirCenoura(2, 3);
                DefinirCenoura(7, 5);
                DefinirCenoura(11, 4);

                DefinirEstrela(4, 3);
                DefinirEstrela(8, 3);
                DefinirEstrela(10, 1);

                DefinirToca(11, 5);

                break;
            case2:
                break;

            default:
                break;
        }
    }




    void DefinirObstaculo(int X, int Y)
    {
        Instantiate(prefabObstaculo, new Vector3(X, Y), Quaternion.identity);
    }
    void DefinirToca(int X, int Y)
    {
        Instantiate(prefabToca, new Vector3(X, Y), Quaternion.identity);
    }
    void DefinirArmadilha(int X, int Y)
    {
        Instantiate(prefabArmadilha, new Vector3(X, Y), Quaternion.identity);
    }
    void DefinirCenoura(int X, int Y)
    {
        Instantiate(prefabCenoura, new Vector3(X, Y), Quaternion.identity);
    }
    void DefinirEstrela(int X, int Y)
    {
        Instantiate(prefabEstrela, new Vector3(X, Y), Quaternion.identity);
    }

}