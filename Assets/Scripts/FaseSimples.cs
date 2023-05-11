 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// por João Queroga - 09/11/2018


public class FaseSimples: MonoBehaviour {

	public Animator animPlayer;

	public Sprite Mato;
	public Sprite Buraco;

	public GameObject PainelCerto;
	public GameObject PainelErrado;
	public GameObject PainelFaltaColetar;
	public GameObject painelSaiu;

	public static int EstrelasNum;

	public PainelEstrela1 painelEstrela;

	public Image Bomba1;
	public Image Bomba2;
	public Image Estrela1;
	public Image Estrela2;

	public Text TextoBomba1;
	public Text TextoBomba2;
	public Text TextoEstrela1;
	public Text TextoEstrela2;

	bool play;
	float velocidade = 100;
	public static bool vivo;
	int indiceDestino = 0;

	public Image Cenoura;
	public GameObject Pai;


	int LinhaPlayer;
	int ColunaPlayer; 
	int LinhaToca;
	int ColunaToca; 

	public Animator BombaAnim;
	public Animator EstrelaAnim;
	public Animator Bomba2Anim;
	public Animator Estrela2Anim;



	public static int NumCenouras;

	public Text TextLinha;
	public Text TextColuna;

	//##################################### CRIAÇÃO DE FASES ############################################

	void EscolhaFase(){
		switch(PlayerPrefs.GetInt("NF")){
		case 1:

			EstrelaAnim.SetBool ("mostraE", true);
			Estrela2Anim.SetBool ("mostraE", true);

			LinhaPlayer = 2;  // poisiçao player
			ColunaPlayer = 2; 

			LinhaToca = 2;  // posição Toca
			ColunaToca = 8;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			for(int i = 0; i < 12; i++){
				DefineObstaculo(0,i);
			}

			NumCenouras = 1;
			CriaCenoura (2,5);  // define local de Hortaliças

			PosicionaBomba1 (5,0);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,11);
			PosicionaEstrela1(2,3);
			PosicionaEstrela2 (2,7);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);
			break;
		case 2:

			EstrelaAnim.SetBool ("mostraE", true);

			BombaAnim.SetBool ("visivel", true);
			Bomba2Anim.SetBool ("visivel", true);

			LinhaPlayer = 4;  // poisiçao player
			ColunaPlayer = 2; 

			LinhaToca = 5;  // posição Toca
			ColunaToca = 9;

			//DefineObstaculo (1,1);  // define posicoes de Barreira
			for(int i = 0; i < 12; i++){
				DefineObstaculo(0,i);
			}


			NumCenouras = 1;
			CriaCenoura (4,5);  // define local de Hortaliças

			PosicionaBomba1 (4,4);  // posiciona Minas e Estrelas
			PosicionaBomba2 (4,6);
			PosicionaEstrela1(3,4);
			PosicionaEstrela2 (5,6);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 3:
			Bomba2Anim.SetBool ("visivel", true);
			LinhaPlayer = 3;  // poisiçao player
			ColunaPlayer = 1; 

			LinhaToca = 2;  // posição Toca
			ColunaToca = 7;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 2;
			CriaCenoura (4, 2);  // define local de Hortaliças
			CriaCenoura (4, 4);

			PosicionaBomba1 (3, 2);  // posiciona Minas e Estrelas
			PosicionaBomba2 (1, 4);
			PosicionaEstrela1 (4, 3);
			PosicionaEstrela2 (2, 4);

			for(int i = 1; i < 12; i++){
				DefineObstaculo(0,i);
			}
			for(int i = 1; i < 4; i++){
				DefineObstaculo(i,3);
			}

			DefineObstaculo (5,3);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 4:

			LinhaPlayer = 2;  // poisiçao player
			ColunaPlayer = 9; 

			LinhaToca = 4;  // posição Toca
			ColunaToca = 9;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 2;
			CriaCenoura (2, 8);  // define local de Hortaliças
			CriaCenoura (4, 8);

			PosicionaBomba1 (3, 4);  // posiciona Minas e Estrelas
			PosicionaBomba2 (3, 7);
			PosicionaEstrela1 (3, 3);
			PosicionaEstrela2 (4, 7);


			for(int i = 0; i < 12; i++){
				DefineObstaculo(0,i);
			}
			for(int i = 5 ;i<12;i++){
				if(i!=7){
					DefineObstaculo(3,i);
				}
			}

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 5:

			LinhaPlayer = 5;  // poisiçao player
			ColunaPlayer = 11; 

			LinhaToca = 5;  // posição Toca
			ColunaToca = 1;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 3;
			CriaCenoura (1,7);  // define local de Hortaliças
			CriaCenoura (2,4);
			CriaCenoura (3,3);

			PosicionaBomba1 (0,6);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,9);
			PosicionaEstrela1 (3,9);
			PosicionaEstrela2 (4,2);

			DefineObstaculo (0,0);
			DefineObstaculo (0,1);
			DefineObstaculo (0,2);
			DefineObstaculo (0,3);
			DefineObstaculo (0,4);
			DefineObstaculo (0,8);
			DefineObstaculo (0,9);
			DefineObstaculo (0,10);
			DefineObstaculo (0,11);
			DefineObstaculo (1,0);
			DefineObstaculo (1,1);
			DefineObstaculo (1,2);
			DefineObstaculo (1,3);
			DefineObstaculo (1,9);
			DefineObstaculo (1,10);
			DefineObstaculo (1,11);
			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,2);
			DefineObstaculo (2,6);
			DefineObstaculo (2,10);
			DefineObstaculo (2,11);
			DefineObstaculo (3,0);
			DefineObstaculo (3,1);
			DefineObstaculo (3,5);
			DefineObstaculo (3,6);
			DefineObstaculo (3,7);
			DefineObstaculo (3,11);
			DefineObstaculo (4,0);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		
		case 6:

			LinhaPlayer = 5;  // poisiçao player
			ColunaPlayer = 4; 

			LinhaToca = 0;  // posição Toca
			ColunaToca = 3;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 1;
			CriaCenoura (2, 4);  // define local de Hortaliças


			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);


			PosicionaBomba1 (3, 3);  // posiciona Minas e Estrelas
			PosicionaBomba2 (1, 5);
			PosicionaEstrela1 (3, 5);
			PosicionaEstrela2 (1, 3);


			DefineObstaculo (1,4);
			DefineObstaculo (2,2);
			DefineObstaculo (2,6);
			DefineObstaculo (3,4);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 7:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer = 1; 

			LinhaToca =5;  // posição Toca
			ColunaToca = 0;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 2;
			CriaCenoura (5,2);  // define local de Hortaliças
			CriaCenoura (5,6); 

			PosicionaBomba1 (2, 3);  // posiciona Minas e Estrelas
			PosicionaBomba2 (4, 7);
			PosicionaEstrela1 (2, 7);
			PosicionaEstrela2 (4, 3);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);


			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,2);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,6);
			DefineObstaculo (2,8);
			DefineObstaculo (2,9);
			DefineObstaculo (2,10);
			DefineObstaculo (2,11);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,8);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 8:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer = 9; 

			LinhaToca = 4;  // posição Toca
			ColunaToca = 2;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 1;
			CriaCenoura (3,2);  // define local de Hortaliças

			PosicionaBomba1 (1,3);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,2);
			PosicionaEstrela1 (3,3);
			PosicionaEstrela2 (3,8);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,6);
			DefineObstaculo (2,7);
			DefineObstaculo (2,10);
			DefineObstaculo (3,4);
			DefineObstaculo (3,5);
			DefineObstaculo (3,6);
			DefineObstaculo (3,10);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 9:

			LinhaPlayer = 3;  // poisiçao player
			ColunaPlayer = 4; 

			LinhaToca = 5;  // posição Toca
			ColunaToca = 0;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 2;
			CriaCenoura (3,2);  // define local de Hortaliças
			CriaCenoura (5,8);

			PosicionaBomba1 (4,2);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,10);
			PosicionaEstrela1 (1,4);
			PosicionaEstrela2 (5,9);

			DefineObstaculo (0,0);
			DefineObstaculo (0,1);
			DefineObstaculo (0,2);
			DefineObstaculo (0,3);
			DefineObstaculo (0,4);
			DefineObstaculo (0,5);
			DefineObstaculo (0,6);
			DefineObstaculo (0,7);
			DefineObstaculo (1,0);
			DefineObstaculo (1,1);
			DefineObstaculo (1,7);
			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,7);
			DefineObstaculo (3,0);
			DefineObstaculo (3,1);
			DefineObstaculo (3,5);
			DefineObstaculo (3,7);
			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,3);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);
			DefineObstaculo (5,11);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 10:

			LinhaPlayer = 5;  // poisiçao player
			ColunaPlayer = 2; 

			LinhaToca = 3;  // posição Toca
			ColunaToca = 11;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 5;
			CriaCenoura (3, 0);  // define local de Hortaliças
			CriaCenoura (3, 4);
			CriaCenoura (3, 6);
			CriaCenoura (3, 7);
			CriaCenoura (3, 8);

			PosicionaBomba1 (3, 3);  // posiciona Minas e Estrelas
			PosicionaBomba2 (4, 4);
			PosicionaEstrela1 (3, 1);
			PosicionaEstrela2 (1, 2);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0,3);
			DefineObstaculo (0,4);
			DefineObstaculo (0,5);

			DefineObstaculo (1,0);
			DefineObstaculo (1,1);
			DefineObstaculo (1,5);

			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,3);
			DefineObstaculo (2,5);
			DefineObstaculo (2,6);
			DefineObstaculo (2,7);
			DefineObstaculo (2,8);
			DefineObstaculo (2,9);
			DefineObstaculo (2,10);
			DefineObstaculo (2,11);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,3);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);

			DefineObstaculo (5,0);
			DefineObstaculo (5,1);
			DefineObstaculo (5,3);
			DefineObstaculo (5,4);
			DefineObstaculo (5,5);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 11:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer = 0; 

			LinhaToca = 2;  // posição Toca
			ColunaToca = 7;

			//DefineObstaculo (1,1);  // define posicoes de Barreira

			NumCenouras = 3;
			CriaCenoura (2,2);  // define local de Hortaliças
			CriaCenoura (4,4);
			CriaCenoura (5,6);

			PosicionaBomba1 (4,2);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,8);
			PosicionaEstrela1 (2,4);
			PosicionaEstrela2 (3,8);

			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);

			DefineObstaculo (1,3);
			DefineObstaculo (1,7);
			DefineObstaculo (1,8);
			DefineObstaculo (1,9);

			DefineObstaculo (2,0);
			DefineObstaculo (2,6);
			DefineObstaculo (2,9);

			DefineObstaculo (3,0);
			DefineObstaculo (3,1);
			DefineObstaculo (3,5);
			DefineObstaculo (3,6);
			DefineObstaculo (3,7);
			DefineObstaculo (3,9);


			DefineObstaculo (4,0);
			DefineObstaculo (4,6);
			DefineObstaculo (4,9);
		
			DefineObstaculo (5,0);
			DefineObstaculo (5,1);
			DefineObstaculo (5,2);
			DefineObstaculo (5,3);
			DefineObstaculo (5,9);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 12:
			
			LinhaPlayer = 5;  // poisiçao player
			ColunaPlayer = 11; 

			LinhaToca = 4;  // posição Toca
			ColunaToca = 0;

			NumCenouras = 2;
			CriaCenoura (4, 3);  // define local de Hortaliças
			CriaCenoura (4, 7);

			PosicionaBomba1 (5, 1);  // posiciona Minas e Estrelas
			PosicionaBomba2 (4, 5);
			PosicionaEstrela1 (1, 7);
			PosicionaEstrela2 (5, 4);


			DefineObstaculo (0, 6);
			DefineObstaculo  (0,7);
			DefineObstaculo (0,8);

			DefineObstaculo (1,6);
			DefineObstaculo (1,8);

			DefineObstaculo (2,6);
			DefineObstaculo (2,8);

			DefineObstaculo (3,0);
			DefineObstaculo (3,1);
			DefineObstaculo (3,2);
			DefineObstaculo (3,3);
			DefineObstaculo (3,4);
			DefineObstaculo (3,5);
			DefineObstaculo (3,6);
			DefineObstaculo (3,8);
			DefineObstaculo (3,9);

			DefineObstaculo (4,9);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);

			DefineObstaculo (5,7);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 13:

			LinhaPlayer = 1;  // poisiçao player
			ColunaPlayer = 11; 

			LinhaToca = 5;  // posição Toca
			ColunaToca = 3;

			NumCenouras = 4;
			CriaCenoura (1, 1);  // define local de Hortaliças
			CriaCenoura (1, 4);
			CriaCenoura (1, 6);
			CriaCenoura (3, 0);

			PosicionaBomba1 (3, 9);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5, 8);
			PosicionaEstrela1 (4, 6);
			PosicionaEstrela2 (5, 10);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1, 0);
			DefineObstaculo (1, 8);

			DefineObstaculo (2, 0);
			DefineObstaculo (2, 2);
			DefineObstaculo (2, 3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,10);

			DefineObstaculo (3,10);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,3);
			DefineObstaculo (4,4);
			DefineObstaculo (4,10);

			DefineObstaculo (5,0);
			DefineObstaculo (5,1);
			DefineObstaculo (5,2);



			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 14:

			LinhaPlayer = 3;  // poisiçao player
			ColunaPlayer = 5; 

			LinhaToca = 1;  // posição Toca
			ColunaToca = 11;

			NumCenouras = 4;
			CriaCenoura (1,2);
			CriaCenoura (1,5);
			CriaCenoura (4,4);
			CriaCenoura (5,1);

			PosicionaBomba1 (2,2);  // posiciona Minas e Estrelas
			PosicionaBomba2 (1,8);
			PosicionaEstrela1 (5,3);
			PosicionaEstrela2 (5,7);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1,0);
	
			DefineObstaculo (2,3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,6);
			DefineObstaculo (2,8);

			DefineObstaculo (3,2);
			DefineObstaculo (3,3);
			DefineObstaculo (3,6);
			DefineObstaculo (3,11);

			DefineObstaculo (4,2);
			DefineObstaculo (4,6);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);

			DefineObstaculo (5,5);
			DefineObstaculo (5,6);
			DefineObstaculo (5,9);
			DefineObstaculo (5,10);
			DefineObstaculo (5,11);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 15:

			LinhaPlayer = 2;  // poisiçao player
			ColunaPlayer = 11; 

			LinhaToca = 3;  // posição Toca
			ColunaToca = 0;

			NumCenouras = 4;
			CriaCenoura (1,10);  // define local de Hortaliças
			CriaCenoura (2,5);
			CriaCenoura (4,5);
			CriaCenoura (5,10);

			PosicionaBomba1 (0,5);  // posiciona Minas e Estrelas
			PosicionaBomba2 (5,5);
			PosicionaEstrela1 (1,5);
			PosicionaEstrela2 (3,10);


			DefineObstaculo (0,4);
			DefineObstaculo (0,6);
			DefineObstaculo (0,8);
			DefineObstaculo (0,9);
			DefineObstaculo (0,10);
			DefineObstaculo (0,11);

			DefineObstaculo (1,4);
			DefineObstaculo (1,6);
			DefineObstaculo (1,8);

			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,2);
			DefineObstaculo (2,3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,6);
			DefineObstaculo (2,7);
			DefineObstaculo (2,8);
			DefineObstaculo (2,10);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,3);
			DefineObstaculo (4,4);
			DefineObstaculo (4,6);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);
			DefineObstaculo (4,10);

			DefineObstaculo (5,4);
			DefineObstaculo (5,6);
			DefineObstaculo (5,8);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;

		case 16:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer = 0; 

			LinhaToca = 2;  // posição Toca
			ColunaToca = 8;

			NumCenouras = 11;
			CriaCenoura (4,0);  // define local de Hortaliças
			CriaCenoura (5,3);
			CriaCenoura (5,4);
			CriaCenoura (5,5);
			CriaCenoura (5,6);
			CriaCenoura (5,7);
			CriaCenoura (3,11);
			CriaCenoura (2,11);
			CriaCenoura (1,8);
			CriaCenoura (3,4);
			CriaCenoura (2,2);

			PosicionaBomba1 (1,2);  // posiciona Minas e Estrelas
			PosicionaBomba2 (3,9);
			PosicionaEstrela1 (2,2);
			PosicionaEstrela2 (2,0);

			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1,1);
			DefineObstaculo (1,3);
			DefineObstaculo (1,5);

			DefineObstaculo (2,1);
			DefineObstaculo (2,3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,7);
			DefineObstaculo (2,9);
			DefineObstaculo (2,10);

			DefineObstaculo (3,1);
			DefineObstaculo (3,10);

			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,3);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 17:

			LinhaPlayer = 3;  // poisiçao player
			ColunaPlayer = 6; 

			LinhaToca = 0;  // posição Toca
			ColunaToca = 4;

			NumCenouras = 4;
			CriaCenoura (1, 4);  // define local de Hortaliças
			CriaCenoura (2, 7);
			CriaCenoura (5, 3);
			CriaCenoura (5, 8);

			PosicionaBomba1 (2, 6);  // posiciona Minas e Estrelas
			PosicionaBomba2 (1,8);
			PosicionaEstrela1 (5, 2);
			PosicionaEstrela2 (5, 10);


			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1,0);
			DefineObstaculo (1,1);
			DefineObstaculo (1,2);
			DefineObstaculo (1,6);
			DefineObstaculo (1,10);



			DefineObstaculo (2,2);
			DefineObstaculo (2,3);
			DefineObstaculo (2,9);

			DefineObstaculo (3,3);
			DefineObstaculo (3,4);
			DefineObstaculo (3,8);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,3);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);
			DefineObstaculo (4,11);

			DefineObstaculo (5,0);
			DefineObstaculo (5,1);
			DefineObstaculo (5,6);
	
			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 18:

			LinhaPlayer = 5;  // poisiçao player
			ColunaPlayer =0; 

			LinhaToca = 2;  // posição Toca
			ColunaToca = 11;

			NumCenouras = 6;
			CriaCenoura (1,4);  // define local de Hortaliças
			CriaCenoura (1,6);
			CriaCenoura (1,9);
			CriaCenoura (3,3);
			CriaCenoura (5,6);
			CriaCenoura (5,3);


			PosicionaBomba1 (3,6);  // posiciona Minas e Estrelas
			PosicionaBomba2 (3,10);
			PosicionaEstrela1 (3,0);
			PosicionaEstrela2 (4,9);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 1);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1,0);
			DefineObstaculo (1,1);
			DefineObstaculo (1,2);
			DefineObstaculo (1,10);


			DefineObstaculo (2,0);
			DefineObstaculo (2,1);
			DefineObstaculo (2,2);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,6);
			DefineObstaculo (2,7);
			DefineObstaculo (2,8);

			DefineObstaculo (3,7);
			DefineObstaculo (3,8);

			DefineObstaculo (4,0);
			DefineObstaculo (4,1);
			DefineObstaculo (4,2);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,7);
			DefineObstaculo (4,8);
			DefineObstaculo (4,11);

			DefineObstaculo (5,7);
			DefineObstaculo (5,8);
			DefineObstaculo (5,9);
			DefineObstaculo (5,10);
			DefineObstaculo (5,11);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 19:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer =2; 

			LinhaToca = 0;  // posição Toca
			ColunaToca = 11;

			NumCenouras = 6;
			CriaCenoura (0,2);  // define local de Hortaliças
			CriaCenoura (3,2);
			CriaCenoura (3,3);
			CriaCenoura (3,6);  // define local de Hortaliças
			CriaCenoura (1,7);
			CriaCenoura (2,11);

			PosicionaBomba1 (5,7);  // posiciona Minas e Estrelas
			PosicionaBomba2 (3,8);
			PosicionaEstrela1 (5,3);
			PosicionaEstrela2 (5,9);

			DefineObstaculo (0,1);
			DefineObstaculo (0,3);
			DefineObstaculo (0,4);
			DefineObstaculo (0,5);
			DefineObstaculo (0,6);
			DefineObstaculo (0,7);
			DefineObstaculo (0,8);
			DefineObstaculo (0,10);

			DefineObstaculo (1,1);
			DefineObstaculo (1,3);
			DefineObstaculo (1,4);
			DefineObstaculo (1,5);
			DefineObstaculo (1,8);
			DefineObstaculo (1,10);

			DefineObstaculo (2,1);
			DefineObstaculo (2,3);
			DefineObstaculo (2,4);
			DefineObstaculo (2,5);
			DefineObstaculo (2,8);
			DefineObstaculo (2,9);
			DefineObstaculo (2,10);

			DefineObstaculo (3,1);
			DefineObstaculo (3,9);

			DefineObstaculo (4,1);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);

			DefineObstaculo (5,1);
			DefineObstaculo (5,4);
			DefineObstaculo (5,5);
			DefineObstaculo (5,6);


			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		case 20:

			LinhaPlayer = 0;  // poisiçao player
			ColunaPlayer = 1; 

			LinhaToca = 5;  // posição Toca
			ColunaToca = 9;

			NumCenouras = 7;
			CriaCenoura (5,3);  // define local de Hortaliças
			CriaCenoura (5,4);
			CriaCenoura (3,3);
			CriaCenoura (1,3);
			CriaCenoura (1,8);
			CriaCenoura (3,11);
			CriaCenoura (5,11);

			PosicionaBomba1 (3,5);  // posiciona Minas e Estrelas
			PosicionaBomba2 (4,1);
			PosicionaEstrela1 (5,0);
			PosicionaEstrela2 (2,3);

			DefineObstaculo (0, 0);
			DefineObstaculo (0, 2);
			DefineObstaculo (0, 3);
			DefineObstaculo (0, 4);
			DefineObstaculo (0, 5);
			DefineObstaculo (0, 6);
			DefineObstaculo (0, 7);
			DefineObstaculo (0, 8);
			DefineObstaculo (0, 9);
			DefineObstaculo (0, 10);
			DefineObstaculo (0, 11);

			DefineObstaculo (1,2);

			DefineObstaculo (2,2);
			DefineObstaculo (2,8);
			DefineObstaculo (2,9);
			DefineObstaculo (2,10);

			DefineObstaculo (3,2);
			DefineObstaculo (3,8);
			DefineObstaculo (3,9);
			DefineObstaculo (3,10);

			DefineObstaculo (4,2);
			DefineObstaculo (4,3);
			DefineObstaculo (4,4);
			DefineObstaculo (4,5);
			DefineObstaculo (4,6);
			DefineObstaculo (4,8);
			DefineObstaculo (4,9);
			DefineObstaculo (4,10);

			DefineObstaculo (5,8);

			PosicionaPlayer (LinhaPlayer, ColunaPlayer);
			PosicionaToca (LinhaToca, ColunaToca);

			break;
		default:
			break;
		}
	}
		
	void PosicionaPlayer(int i, int j){
		Jogador.transform.position = Matriz [i,j].transform.position;
		MostraPosicaoPlayer ();
	}

	void PosicionaToca(int i, int j){
		Toca.transform.position = Matriz [i,j].transform.position;
	}

	void DefineObstaculo(int i, int j){
		Matriz[i,j].sprite = Buraco;
		Matriz[i,j].tag = "buraco";
	}
		
	//##############################################################################  criação da Matriz

	public List <Image> ListaIMG;
	public Image[,] Matriz = new Image[6,12];

	int ind = 0;

	void iniciaMatriz(){
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 12; j++) {

				Matriz [i, j] = ListaIMG [ind];
				ind++;

			}
		}

	}

	//##################################################################################################

	public GameObject Jogador;
	public GameObject Toca;

	//##################################################################################################

	public List <int> LinhasMove = new List <int> ();
	public List <int> ColunaMove = new List <int> ();

	public int contadorBlocos;


	void IniciaLinhaColuna(){
	
		for (int i = 0; i < 10; i++) {
			LinhasMove.Add (0);
		}

		for (int i = 0; i < 10; i++) {
			ColunaMove.Add (0);
		}
	
	}
		
	public int IndiceAtual;

	public void MudaIndice(int i){
		IndiceAtual = i;
	}

	public void  SomaLinha(Dropdown dp){  // parei aqui
		LinhasMove[IndiceAtual] = dp.value;
	}

	public void  SomaColuna(Dropdown dp){
		ColunaMove [IndiceAtual] = dp.value;
	}

	//#################################################################################################

	List <GameObject> Destinos = new List<GameObject>();

	void CriaCaminho(){
		for(int i = 0; i < contadorBlocos; i++){

				Destinos.Add (Matriz [LinhasMove [i], ColunaMove [i]].gameObject);
				LinhaPlayer = LinhasMove [i];
				ColunaPlayer = ColunaMove [i];

		}
	}
		

	public void Iniciar(){
		CriaCaminho ();
		ProximoPasso ();
	}

	GameObject Destino;

	void ProximoPasso(){

		if (indiceDestino < contadorBlocos) {
			animPlayer.SetBool ("Andar",true);

			Destino = Destinos [indiceDestino];
			indiceDestino++;
			play = true;
		}
	}

	void SaiuDaMatriz(){
		Invoke ("InvokeSaiu", 5);
	}



	void CaminhaEntreOsPontos(){  // caminha até o proximo destino
		if (play == true && vivo == true) {
			float Passo = velocidade * Time.deltaTime;
			Jogador.transform.position = Vector3.MoveTowards (Jogador.transform.position, Destino.transform.position, Passo);

			if (Jogador.transform.position == Toca.transform.position) {
				play = false;
				animPlayer.SetBool ("Andar", false);

				if (Player1.ContCenouras == NumCenouras) {
					animPlayer.SetBool ("Comemorando", true);
					Invoke ("InvokeCerto", 2);
				} else {
					Invoke ("InvokeNaoColetou", 2);
				}

			} else if ((Jogador.transform.position.x == Destino.transform.position.x) && (Jogador.transform.position.y == Destino.transform.position.y)) {
				animPlayer.SetBool ("Andar", false);
				play = false;
				ProximoPasso ();
			} 
		}
	}
		
	// #########################################################################################################

	void CriaFase(){
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 12; j++) {
				Matriz [i, j].sprite = Mato;
			
			}
		}
	}

	void CriaCenoura(int i, int j){
		Image cenoura = Instantiate (Cenoura);
		cenoura.transform.position = Matriz [i, j].transform.position;
		cenoura.transform.SetParent (Pai.transform);	
	}
		
	public void CarregaInvokeErrdao(){
		Invoke ("InvokeErrado", 2);
	}
		
	void InvokeCerto(){
		painelEstrela.Verifica (PlayerPrefs.GetInt("NF"));
		PainelCerto.SetActive (true);
	}
	void InvokeErrado(){
		PainelErrado.SetActive (true);
	}
	void InvokeSaiu(){
		painelSaiu.SetActive (true);
	}
	void InvokeNaoColetou(){
		PainelFaltaColetar.SetActive (true);
	}


	void PosicionaBomba1(int i,int j){
		Bomba1.transform.position = Matriz [i, j].transform.position;
		TextoBomba1.text = " [" + i.ToString() + "][" + j.ToString() + "]";
	}
	void PosicionaBomba2(int i,int j){
		Bomba2.transform.position = Matriz [i, j].transform.position;
		TextoBomba2.text = " [" + i.ToString() + "][" + j.ToString() + "]";
	}
	void PosicionaEstrela1(int i,int j){
		Estrela1.transform.position = Matriz [i, j].transform.position;
		TextoEstrela1.text = " [" + i.ToString() + "][" + j.ToString() + "]";
	}
	void PosicionaEstrela2(int i,int j){
		Estrela2.transform.position = Matriz [i, j].transform.position;
		TextoEstrela2.text = " [" + i.ToString() + "][" + j.ToString() + "]";
	}

	void MostraPosicaoPlayer(){
		TextLinha.text = "L: " + LinhaPlayer.ToString ();
		TextColuna.text = "C: " + ColunaPlayer.ToString ();
	}


	public void ProximaFase(){
		if (PlayerPrefs.GetInt ("NF") < 20) {
			PlayerPrefs.SetInt ("B"+PlayerPrefs.GetInt ("NF").ToString(),1);
			PlayerPrefs.SetInt ("NF", PlayerPrefs.GetInt ("NF") + 1);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else {
			SceneManager.LoadScene ("SelecaoFase");
		}

	}


	// Use this for initialization
	void Start () {
		iniciaMatriz ();
		CriaFase ();
		vivo = true;
		EscolhaFase ();
		IniciaLinhaColuna ();
		EstrelasNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		CaminhaEntreOsPontos ();
	}
}
