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
        MontarFase(6);
        PlayerController.Instance.DefinirPosicaoInicialPlayer(0, 3);
    }

    void MontarFase(int numeroDaFase)
    {
        //int numeroDaFase = PlayerPrefs.GetInt("FaseSelecionada");

        switch (numeroDaFase)
        {
            /*case 1:

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

                break;*/
          

           /* case 2:
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
            case 3:
                DefinirArmadilha(1, 2);
                DefinirArmadilha(4, 2);
                DefinirArmadilha(8, 1);

                DefinirCenoura(2, 2);
                DefinirCenoura(7, 1);
                DefinirCenoura(11, 1);

                DefinirEstrela(3, 2);
                DefinirEstrela(8, 2);
                DefinirEstrela(10, 4);

                DefinirToca(11, 0);
                // Monta a Fase 3
                break; 
            case 4:
                DefinirArmadilha(0, 4);
                DefinirArmadilha(4, 5);
                DefinirArmadilha(2, 3);
                DefinirArmadilha(9, 5);
                DefinirArmadilha(11, 3);
                DefinirArmadilha(6, 3);

                DefinirCenoura(2, 5);
                DefinirCenoura(7, 5);
                DefinirCenoura(11, 4);

                DefinirEstrela(4, 3);
                DefinirEstrela(8, 3);
                DefinirEstrela(2, 4);

                DefinirToca(0, 5);
                // Monta a Fase 4
                break;
            case 5:

                DefinirArmadilha(1, 2);
                DefinirArmadilha(3, 3);
                DefinirArmadilha(4, 2);
                DefinirArmadilha(6, 1);

                DefinirCenoura(2, 2);
                DefinirCenoura(0, 2);
                DefinirCenoura(6, 0);
                DefinirCenoura(3, 5);

                DefinirEstrela(6, 5);
                DefinirEstrela(4, 4);
                DefinirEstrela(7, 2);

                DefinirToca(0, 0);
                // Monta a Fase 5
                break;
            case 6:
                DefinirArmadilha(3, 0);
                DefinirArmadilha(4, 2);
                DefinirArmadilha(1, 0);
                DefinirArmadilha(1, 3);
                DefinirArmadilha(9, 0);

                DefinirCenoura(2, 0);
                DefinirCenoura(3, 3);
                DefinirCenoura(7, 2);
                DefinirCenoura(0, 0);
                DefinirCenoura(5, 3);

                DefinirEstrela(10, 0);
                DefinirEstrela(2, 2);
                DefinirEstrela(5, 0);
                DefinirEstrela(6, 4);

                DefinirToca(7, 5);

                break;
            case 7:
                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(1, 3);
                DefinirArmadilha(3, 4);
                DefinirArmadilha(3, 2);
                DefinirArmadilha(8, 2);
                DefinirArmadilha(2, 1);
                DefinirArmadilha(5, 2);

                DefinirCenoura(2, 0);
                DefinirCenoura(7, 2);
                DefinirCenoura(3, 3);
                DefinirCenoura(4, 2);
                DefinirCenoura(6, 4);

                DefinirEstrela(0, 0);
                DefinirEstrela(0, 5);
                DefinirEstrela(0, 8);

                DefinirToca(2, 5);
                break;
            case 8:
                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(0, 1);
                DefinirArmadilha(1, 3);
                DefinirArmadilha(3, 3);
                DefinirArmadilha(2, 0);
                DefinirArmadilha(6, 1);
                DefinirArmadilha(10, 1);

                DefinirCenoura(0, 0);
                DefinirCenoura(1, 4);
                DefinirCenoura(5, 3);
                DefinirCenoura(8, 1);

                DefinirEstrela(3, 2);
                DefinirEstrela(2, 5);
                DefinirEstrela(9, 0);

                DefinirToca(10, 0);

                break;
            case 9:

                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(1, 2);
                DefinirArmadilha(5, 4);
                DefinirArmadilha(7, 1);
                DefinirArmadilha(6, 3);
                DefinirArmadilha(10, 3);

                DefinirCenoura(4, 2);
                DefinirCenoura(7, 0);
                DefinirCenoura(10, 0);

                DefinirEstrela(0, 0);
                DefinirEstrela(6, 2);
                DefinirEstrela(10, 3);

                DefinirToca(11, 3);
                break;
            case 10:

                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(1, 2);
                DefinirArmadilha(5, 4);
                DefinirArmadilha(7, 1);
                DefinirArmadilha(6, 3);
                DefinirArmadilha(9, 0);

                DefinirCenoura(4, 2);
                DefinirCenoura(8, 0);
                DefinirCenoura(10, 0);
                DefinirCenoura(6, 4);

                DefinirEstrela(0, 0);
                DefinirEstrela(6, 2);
                DefinirEstrela(10, 3);

                DefinirToca(11, 3);

                
                break;
            case 11:
                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(0, 3); //1
                DefinirArmadilha(3, 2); //2
                DefinirArmadilha(4, 2);//3
                DefinirArmadilha(6, 1);//4
                DefinirArmadilha(10, 2);//5

                DefinirCenoura(2, 0);
                DefinirCenoura(5, 4);
                DefinirCenoura(6, 2);
                DefinirCenoura(8, 15);
                DefinirArmadilha(11, 3);

                DefinirEstrela(2, 2);
                DefinirEstrela(8, 2);

                DefinirToca(8, 0);

                break;
            case 12:
                for (int i = 0; i <= 6; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i <= 7; i++)
                {
                    DefinirObstaculo(i, 1);
                }

                DefinirArmadilha(2, 0);
                DefinirArmadilha(3, 3);
                DefinirArmadilha(5, 1);
                DefinirArmadilha(9, 0);
                DefinirArmadilha(10, 3);
                DefinirArmadilha(7, 4);
                DefinirArmadilha(9, 5);

                DefinirCenoura(1, 0);
                DefinirCenoura(7, 0);
                DefinirCenoura(9, 3);
                DefinirCenoura(7, 5);
                DefinirCenoura(11, 0);

                DefinirEstrela(1, 2);
                DefinirEstrela(5, 0);
                DefinirEstrela(9, 1);

                DefinirToca(11, 3);

                break;*/
                



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