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
        MontarFase(1);

        // Fases 16,18,19 nao estao prontas
        // Fases 6,10,11 foram consertadas
   }

    void MontarFase(int numeroFase)
    {
        int numeroDaFase = PlayerPrefs.GetInt("FaseSelecionada");

        int[] posicoesObstaculoY1;
        int[] posicoesObstaculoY2;
        int[] posicoesObstaculoY3;
        int[] posicoesObstaculoY4;
        int[] posicoesObstaculoY5;
        int[] posicoesObstaculoY6;

        int[] posicoesObstaculoX1;

        switch (numeroFase)
        {
            case 1:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(0, 3);
                PlayerController.Instance.SetarEnergiaInicial(20);
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
                DefinirCenoura(8, 1);

                DefinirEstrela(4, 3);
                DefinirEstrela(8, 3);
                DefinirEstrela(10, 1);

                DefinirToca(11, 5);

                break;
            case 2:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(2,1);
                PlayerController.Instance.SetarEnergiaInicial(20);
                DefinirToca(9, 0);

                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }


                 DefinirArmadilha(4,1);
                 DefinirArmadilha(6,1);

                 DefinirCenoura(5, 1);

                 DefinirEstrela(4, 2);
                 DefinirEstrela(6, 0);
                 DefinirEstrela(9, 1);


                 break;
            case 3:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 2);
                PlayerController.Instance.SetarEnergiaInicial(20);
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

                DefinirCenoura(11,2);
                DefinirCenoura(5, 0);

                DefinirEstrela(6, 3);
                DefinirEstrela(4, 2);
                DefinirEstrela(10,4);

                DefinirToca(7, 2);
                 // Monta a Fase 3
                 break; 
            case 4:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(10, 3);
                PlayerController.Instance.SetarEnergiaInicial(21);

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

                DefinirCenoura(4, 2);
                DefinirCenoura(6, 3);

                DefinirEstrela(1, 2);
                DefinirEstrela(7, 2);
                DefinirEstrela(10, 1);

                DefinirToca(9, 1);
                 // Monta a Fase 4
                 break;
            case 5:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(11, 0);
                PlayerController.Instance.SetarEnergiaInicial(20);
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

                DefinirEstrela(9, 2);
                DefinirEstrela(4, 4);
                DefinirEstrela(6, 5);


                break;     
            case 6:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 3);
                DefinirToca(9, 3);

                DefinirEstrela(3, 3);
                DefinirEstrela(5, 3);
                DefinirEstrela(7, 3);

                posicoesObstaculoY1 = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11};
                posicoesObstaculoY2 = new int[] { 4,5,6,7};
                posicoesObstaculoX1 = new int[] { 1, 2, 3, 4,11 };

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 0); 
                    DefinirObstaculo(posicoesObstaculoY1[i],5);    
                }
                for (int i = 0; i < posicoesObstaculoX1.Length; i++)
                {
                    DefinirObstaculo(0,posicoesObstaculoX1[i]);
                    DefinirObstaculo(11,posicoesObstaculoX1[i]);  
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i],1);
                }

                break;
            case 7:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 5);
                PlayerController.Instance.SetarEnergiaInicial(20);
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

                DefinirCenoura(3, 1);
                DefinirCenoura(6, 0);
                DefinirCenoura(8, 0);
                DefinirCenoura(9, 4);

                DefinirArmadilha(3, 3);
                DefinirArmadilha(7, 0);

                DefinirEstrela(7, 3);
                DefinirEstrela(2, 0);
                DefinirEstrela(11,1);

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
                PlayerController.Instance.SetarEnergiaInicial(20);
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
                DefinirCenoura(11,0);
                DefinirCenoura(6,1);
                DefinirCenoura(10,4);

                DefinirArmadilha(3, 4);
                DefinirArmadilha(9, 2);

                DefinirEstrela(3, 2);
                DefinirEstrela(8, 2);
                DefinirEstrela(4, 4);

                break;
            case 9:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(4, 2);
                PlayerController.Instance.SetarEnergiaInicial(20);

                DefinirToca(5, 0);

                DefinirCenoura(3, 2);
                DefinirCenoura(6, 1);
                DefinirCenoura(10,2);
                DefinirCenoura(3, 4);

                DefinirArmadilha(2, 1);
                DefinirArmadilha(10, 0);

                DefinirEstrela(8, 5);
                DefinirEstrela(4, 4);
                DefinirEstrela(8, 0);

                for(int i = 0; i < 7; i++)
                {
                    DefinirObstaculo(i, 5);
                    DefinirObstaculo(i, 3);
                }
                DefinirObstaculo(0,4);
                DefinirObstaculo(1,4);
                DefinirObstaculo(7, 5);
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
             
                break;
            case 10:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 3);
                DefinirToca(10, 3);

                DefinirEstrela(2, 1);
                DefinirEstrela(4, 1);
                DefinirEstrela(6, 1);

                DefinirCenoura(8, 1);
                DefinirCenoura(5, 3);

                posicoesObstaculoY1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                posicoesObstaculoY2 = new int[] { 1, 3, 5, 7, 9, 10 };
                posicoesObstaculoX1 = new int[] { 1, 2, 3, 4, 11 };

                for (int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 0);
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 1);
                    DefinirObstaculo(posicoesObstaculoY2[i], 2);
                }

                for (int i = 0; i < posicoesObstaculoX1.Length; i++)
                {
                    DefinirObstaculo(0, posicoesObstaculoX1[i]);
                    DefinirObstaculo(11, posicoesObstaculoX1[i]);
                }

                break;
            case 11:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 3);
                DefinirToca(10, 4);

                DefinirEstrela(3, 3);
                DefinirEstrela(5, 3);
                DefinirEstrela(7, 3);

                DefinirCenoura(10, 1);
                DefinirCenoura(1, 1);
                DefinirCenoura(9, 3);

                posicoesObstaculoY1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                posicoesObstaculoY2 = new int[] { 2, 4, 6, 8, 10 };
                posicoesObstaculoX1 = new int[] { 1, 2, 3, 4, 11 };

                for (int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 0);
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 3);
                }

                for (int i = 0; i < posicoesObstaculoX1.Length; i++)
                {
                    DefinirObstaculo(0, posicoesObstaculoX1[i]);
                    DefinirObstaculo(11, posicoesObstaculoX1[i]);
                }


                break;
            case 12:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(11, 0);
                PlayerController.Instance.SetarEnergiaInicial(20);
                DefinirToca(0, 1);

                DefinirCenoura(3, 1);
                DefinirCenoura(7, 1);
                DefinirCenoura(3, 5);

                DefinirArmadilha(5, 4);
                DefinirArmadilha(4, 0);

                DefinirEstrela(7, 4);
                DefinirEstrela(5, 1);
                DefinirEstrela(5, 5);

                DefinirObstaculo(6, 5);
                DefinirObstaculo(7, 5);
                DefinirObstaculo(8, 5);

                DefinirObstaculo(6, 4);
                DefinirObstaculo(8, 4);
    
                DefinirObstaculo(8, 3);

                for(int i = 0; i < 10; i++)
                {
                    if (i != 7 && i != 2)
                    {
                        DefinirObstaculo(i, 2);
                    }
                }

                DefinirObstaculo(9, 1);
                DefinirObstaculo(10, 1);
                DefinirObstaculo(11, 1);

                DefinirObstaculo(7, 0);

                break;
            case 13:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(11, 4);
                PlayerController.Instance.SetarEnergiaInicial(20);
                DefinirToca(3, 0);

                DefinirCenoura(1, 4);
                DefinirCenoura(9, 4);
                DefinirCenoura(6, 4);
                DefinirCenoura(5, 2);

                DefinirArmadilha(9, 2);
                DefinirArmadilha(8, 0);

                DefinirEstrela(0, 2);
                DefinirEstrela(5, 1);
                DefinirEstrela(11, 0);

                for (int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }

                DefinirObstaculo(0, 4);
                DefinirObstaculo(8, 4);

                DefinirObstaculo(0, 3);
                DefinirObstaculo(2, 3);
                DefinirObstaculo(3, 3);
                DefinirObstaculo(4, 3);
                DefinirObstaculo(10, 3);

                DefinirObstaculo(10, 2);

                DefinirObstaculo(0, 1);
                DefinirObstaculo(1, 1);
                DefinirObstaculo(2, 1);
                DefinirObstaculo(3, 1);
                DefinirObstaculo(4, 1);
                DefinirObstaculo(10, 1);

                DefinirObstaculo(0, 0);
                DefinirObstaculo(1, 0);
                DefinirObstaculo(2, 0);





                break;
            case 14:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(5, 2);
                PlayerController.Instance.SetarEnergiaInicial(20);
                DefinirToca(11, 4);

                DefinirCenoura(2, 3);
                DefinirCenoura(5, 4);
                DefinirCenoura(1, 0);
                

                DefinirArmadilha(1, 3);
                DefinirArmadilha(8, 4);

                DefinirEstrela(8, 0);
                DefinirEstrela(9, 4);
                DefinirEstrela(1, 4);

                for(int i = 0; i < 12; i++)
                {
                    DefinirObstaculo(i, 5);
                }

                DefinirObstaculo(0, 5);

                for(int i = 3; i < 9; i++)
                {
                    if (i != 7)
                    {
                        DefinirObstaculo(i, 3);
                    }
                }

                DefinirObstaculo(2, 2);
                DefinirObstaculo(3, 2);
                DefinirObstaculo(6, 2);
                DefinirObstaculo(11, 2);

                DefinirObstaculo(2, 1);
                DefinirObstaculo(6, 1);
                DefinirObstaculo(10, 1);
                DefinirObstaculo(11, 1);

                DefinirObstaculo(5, 0);
                DefinirObstaculo(6, 0);
                DefinirObstaculo(9, 0);
                DefinirObstaculo(10, 0);
                DefinirObstaculo(11, 0);


                break;
            case 15:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(11, 3);
                PlayerController.Instance.SetarEnergiaInicial(20);

                DefinirToca(0, 2);

                DefinirCenoura(10, 4);
                DefinirCenoura(10,0);

                DefinirArmadilha(5, 5);
                DefinirArmadilha(5, 0);

                DefinirEstrela(5, 4);
                DefinirEstrela(5, 1);
                DefinirEstrela(10,2);

                int[] posicoesY1 = { 4, 6, 8, 9, 10, 11 };
                int[] posicoesY2 = { 4, 6, 8 };
                int[] posicoesY3 = { 0, 1, 2, 3, 4, 6, 7, 8, 10 };

                for(int  i = 0;i < posicoesY1.Length; i++)
                {
                    DefinirObstaculo(posicoesY1[i], 5);
                }
                for(int i = 0; i < posicoesY2.Length; i++)
                {
                    DefinirObstaculo(posicoesY2[i], 4);
                    DefinirObstaculo(posicoesY2[i], 0);
                }
                for (int i = 0; i < posicoesY3.Length; i++)
                {
                    DefinirObstaculo(posicoesY3[i], 3);
                    DefinirObstaculo(posicoesY3[i], 1);
                }

                break;
            case 16:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(0, 5);
                DefinirToca(9, 2);

                DefinirArmadilha(7, 2);

                DefinirEstrela(8, 3);
                DefinirEstrela(2, 3);
                DefinirEstrela(11,0);

                DefinirCenoura(2, 2);
                DefinirCenoura(0, 0);
                DefinirCenoura(11,4);
                DefinirCenoura(8, 2);

                posicoesObstaculoY1 = new int[]{ 1,2,3, 4,5,6,7,8,9,10,11};
                posicoesObstaculoY2 = new int[]{ 1};
                posicoesObstaculoY3 = new int[]{ 1,3,4,5,6,7,9,10};
                posicoesObstaculoY4 = new int[]{ 1,10};
                posicoesObstaculoY5 = new int[]{ 1,2,3,4,5,6,7,8,9,10};

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 4);
                }
                for (int i = 0; i < posicoesObstaculoY3.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY3[i], 3);
                }
                for (int i = 0; i < posicoesObstaculoY4.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY4[i], 2);
                }
                for (int i = 0; i < posicoesObstaculoY5.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY5[i], 1);
                }

                break;
            case 17:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(6, 2);
                PlayerController.Instance.SetarEnergiaInicial(20);
                DefinirToca(5, 4);

                DefinirCenoura(7, 3);
                DefinirCenoura(3, 0);
                DefinirCenoura(8, 0);
                DefinirCenoura(10, 5);

                DefinirArmadilha(6, 3);
                DefinirArmadilha(8, 4);

                DefinirEstrela(2, 0);
                DefinirEstrela(10,0);
                DefinirEstrela(9, 4);

                posicoesObstaculoY1 = new int[]{ 0,1,2,3,4,5};
                posicoesObstaculoY2 = new int[]{ 0,1,2,6,10};
                posicoesObstaculoY3 = new int[]{ 2,3,9};
                posicoesObstaculoY4 = new int[]{ 3,4,8};
                posicoesObstaculoY5 = new int[]{ 0,1,2,3,9,10,11};
                posicoesObstaculoY6 = new int[]{ 0,1,6};

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 4);
                }
                for (int i = 0; i < posicoesObstaculoY3.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY3[i], 3);
                }
                for (int i = 0; i < posicoesObstaculoY4.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY4[i], 2);
                }
                for (int i = 0; i < posicoesObstaculoY5.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY5[i], 1);
                }
                for (int i = 0; i < posicoesObstaculoY6.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY6[i], 0);
                }

                break;
            case 18:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(0, 0);
                DefinirToca(11, 3);

                DefinirCenoura(4, 4);
                DefinirCenoura(6, 4);
                DefinirCenoura(9, 4);
                DefinirCenoura(3, 2);
                DefinirCenoura(6, 0);
                DefinirCenoura(3, 0);

                DefinirArmadilha(6, 2);
                DefinirArmadilha(10, 2);

                DefinirEstrela(0, 2);
                DefinirEstrela(9, 1);

                posicoesObstaculoY1 = new int[] {0,1,2,3,4,5,6,7,8,9,10,11 };
                posicoesObstaculoY2 = new int[] {0,1,2,10 };
                posicoesObstaculoY3 = new int[] {0,1,2,4,5,6,7,8 };
                posicoesObstaculoY4 = new int[] {7,8 };
                posicoesObstaculoY5 = new int[] {0,1,2,4,5,6,7,8,11};
                posicoesObstaculoY6 = new int[] {8,9,10,11};

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 4);
                }
                for (int i = 0; i < posicoesObstaculoY3.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY3[i], 3);
                }
                for (int i = 0; i < posicoesObstaculoY4.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY4[i], 2);
                }
                for (int i = 0; i < posicoesObstaculoY5.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY5[i], 1);
                }
                for (int i = 0; i < posicoesObstaculoY6.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY6[i], 0);
                }


                break; 
            case 19:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(2, 5);
                DefinirToca(11, 5);

                DefinirCenoura(2, 5);
                DefinirCenoura(2, 2);
                DefinirCenoura(3, 2);
                DefinirCenoura(6, 2);
                DefinirCenoura(7, 4);
                DefinirCenoura(11,3);

                DefinirArmadilha(7, 0);
                DefinirArmadilha(8, 2);

                DefinirEstrela(3, 0);
                DefinirEstrela(9, 0);

                posicoesObstaculoY1 = new int[] {1,3,4,5,6,7,8,10 };
                posicoesObstaculoY2 = new int[] {1,3,4,5,8,10 };
                posicoesObstaculoY3 = new int[] {1,3,4,5,8,9,10 };
                posicoesObstaculoY4 = new int[] {1,9 };
                posicoesObstaculoY5 = new int[] {1,4,5,6 };

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i],4);
                }
                for (int i = 0; i < posicoesObstaculoY3.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY3[i], 3);
                }
                for (int i = 0; i < posicoesObstaculoY4.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY4[i], 2);
                }
                for (int i = 0; i < posicoesObstaculoY5.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY5[i], 1);
                    DefinirObstaculo(posicoesObstaculoY5[i], 0);
                }

                break; 
            case 20:
                PlayerController.Instance.DefinirPosicaoInicialPlayer(1, 5);
                PlayerController.Instance.SetarEnergiaInicial(25);
                DefinirToca(9, 0);

                DefinirCenoura(6, 4);
                DefinirCenoura(4, 3);
                DefinirCenoura(10,3);
                DefinirCenoura(1,2);

                DefinirArmadilha(5, 2);
                DefinirArmadilha(1, 1);

                DefinirEstrela(0, 0);
                DefinirEstrela(3, 2);
                DefinirEstrela(9, 2);

                posicoesObstaculoY1 = new int[] { 0,2,3,4,5,6,7,8,9,10,11 };
                posicoesObstaculoY2 = new int[] { 2,8 };
                posicoesObstaculoY3 = new int[] { 2,3,4,5,6,8,9,10 };

                for(int i = 0; i < posicoesObstaculoY1.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY1[i], 5);
                }
                for (int i = 0; i < posicoesObstaculoY2.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY2[i], 3);
                    if(i != 9 || i != 10)
                    {
                        DefinirObstaculo(posicoesObstaculoY2[i], 2);
                    }
                }
                for (int i = 0; i < posicoesObstaculoY3.Length; i++)
                {
                    DefinirObstaculo(posicoesObstaculoY3[i], 1);
                }

                DefinirObstaculo(2, 4);
                DefinirObstaculo(8, 0);

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