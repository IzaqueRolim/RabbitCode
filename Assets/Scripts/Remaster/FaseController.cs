using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Autor: Izaque Rolim
// Data: 27/08/23
// Contato: irc.lic22@uea.edu.br | izaque.rolim.canavarro@gmail.com | 92988397831
// Qualquer duvida, é so entrar em contato que eu respondo... 😊

public class faseController : MonoBehaviour
{
    public GameObject prefabArmadilha;
    public GameObject prefabObstaculo;
    public GameObject prefabToca;
    public GameObject prefabCenoura;
    public GameObject prefabEstrela;

    

    void Start()
    {
        MontarFase(9);
    }

    void MontarFase(int numeroDaFase)
    {
        //int numeroDaFase = PlayerPrefs.GetInt("FaseSelecionada");

        switch (numeroDaFase)
        {
            case 1:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(0, 3);
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
            case 2:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(0,1   );
                DefinirToca(9, 0);

                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }


                 DefinirArmadilha(4,1);
                 DefinirArmadilha(6,1);

                 DefinirCenoura(2, 1);
                 DefinirCenoura(5, 1);

                 DefinirEstrela(4, 2);
                 DefinirEstrela(6, 0);


                 break;
            case 3:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 2);
                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 1; i < 5; i++) 
                {
                    DefinirObstaculo(2, i);
                }

                DefinirObstaculo(7, 1);
                DefinirObstaculo(6, 2);


                DefinirArmadilha(7, 3);
                DefinirArmadilha(1, 1);

                DefinirCenoura(8, 3);
                DefinirCenoura(5, 0);

                DefinirEstrela(6, 3);
                DefinirEstrela(4, 2);

                DefinirToca(7, 2);
                 // Monta a Fase 3
                 break; 
            case 4:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(10, 3);
                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }
                for (int i = 3; i < 12; i++)
                {
                    if (i != 7 && i != 4)
                    {
                        DefinirObstaculo(i, 2);
                    }
                }


                DefinirArmadilha(2, 2);
                DefinirArmadilha(8, 3);

                DefinirCenoura(9, 0);
                DefinirCenoura(6, 3);

                DefinirEstrela(1, 2);
                DefinirEstrela(7, 2);

                DefinirToca(9, 1);
                 // Monta a Fase 4
                 break;
            case 5:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(11, 0);
                DefinirToca(1, 0);

                for (int i = 5; i > 0; i--)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        DefinirObstaculo(j, i);
                    }
                }

                for (int i = 5; i > 0; i--)
                {
                    for (int j = 11; j >= 12-i; j--)
                    {
                        DefinirObstaculo(j, i);
                    }
                }

                for(int  i = 4; i < 8; i++)
                {
                    DefinirObstaculo(i, 1);
                    if (i >= 5 && i <= 6)
                    {
                        DefinirObstaculo(i, 2);
                    }
                }


                DefinirArmadilha(6, 4);
                DefinirArmadilha(6, 0);
                DefinirArmadilha(4, 2);
                DefinirArmadilha(1, 1);

                DefinirCenoura(7, 2);
                DefinirCenoura(3, 3);
                DefinirCenoura(2, 2);

                DefinirEstrela(9, 2);
                DefinirEstrela(4, 4);

               
                break;
                 
             case 6:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(4, 0);
                DefinirToca(3, 0);

                for(int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }


                DefinirObstaculo(4, 4);
                DefinirObstaculo(2, 3);
                DefinirObstaculo(6, 3);
                DefinirObstaculo(4, 2);

                DefinirArmadilha(2, 2);
                DefinirArmadilha(1, 1);
              

                 DefinirCenoura(3, 4);
                 

                 DefinirEstrela(5, 2);
                 DefinirEstrela(3, 4);

                 break;
             case 7:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 5);
                DefinirToca(0, 0);

                for(int i = 0; i < 12; i++)
                {
                    if (i != 1)
                    {
                        DefinirObstaculo(i, 5);
                    }
                }
                for (int i = 0; i < 12; i++)
                {
                    if (i != 3 && i!= 7)
                    {
                        DefinirObstaculo(i, 3);
                        DefinirObstaculo(i, 2);
                    }
                }

                DefinirCenoura(2, 0);
                DefinirCenoura(6, 0);
                DefinirArmadilha(3, 3);
                DefinirArmadilha(7, 0);
                DefinirEstrela(7, 3);
                DefinirEstrela(3, 1);

                /*for (int i = 0; i <= 6; i++)
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

                 DefinirToca(2, 5);*/
                break;
             case 8:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(9, 5);
                DefinirToca(0, 0);

                for(int i = 0; i < 12; i++)
                {
                    if (i!=9)
                    {
                        DefinirObstaculo(i, 5);
                    }
                }

                DefinirObstaculo(4,3);
                DefinirObstaculo(5,3);
                DefinirObstaculo(6,3);
                DefinirObstaculo(7,3);
                DefinirObstaculo(10,3);
                DefinirObstaculo(4,2);
                DefinirObstaculo(5,2);
                DefinirObstaculo(6,2);
                DefinirObstaculo(10,2);
                DefinirObstaculo(4,1);
                DefinirObstaculo(5,1);
                DefinirObstaculo(9,1);
                DefinirObstaculo(10,1);


                DefinirCenoura(2, 2);
                DefinirArmadilha(3, 4);
                DefinirArmadilha(9, 2);
                DefinirEstrela(3, 2);
                DefinirEstrela(8, 2);
                /* for (int i = 0; i <= 6; i++)
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

                  DefinirToca(10, 0);*/



                break;
             case 9:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(4, 2);
                DefinirToca(0, 0);

                DefinirCenoura(2, 2);
                DefinirCenoura(8, 0);

                DefinirArmadilha(2, 1);
                DefinirArmadilha(10, 0);
                DefinirEstrela(4, 4);
                DefinirEstrela(9, 0);

                for(int i = 0; i < 7; i++)
                {
                    DefinirObstaculo(i, 5);
                    DefinirObstaculo(i, 3);
                }
                DefinirObstaculo(0,4);
                DefinirObstaculo(1,4);
                DefinirObstaculo(7,4);
                DefinirObstaculo(0,3);
                DefinirObstaculo(1,3);
                DefinirObstaculo(5,3);
                DefinirObstaculo(7, 3);

                DefinirObstaculo(0,1);
                DefinirObstaculo(1,1);
                DefinirObstaculo(3,1);
                DefinirObstaculo(4,1);
                DefinirObstaculo(5,1);
                DefinirObstaculo(7,1);
                DefinirObstaculo(8,1);
                DefinirObstaculo(9,1);
                DefinirObstaculo(10,1);
                DefinirObstaculo(11,1);
                DefinirObstaculo(11,0);
                /* for (int i = 0; i <= 6; i++)
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

                  DefinirToca(11, 3);*/
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