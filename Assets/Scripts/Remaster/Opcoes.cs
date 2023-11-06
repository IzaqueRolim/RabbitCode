using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opcoes : MonoBehaviour {


	public Transform PainelOp;
	public Transform Dentro;
	public Transform Fora;
	Transform Destino;
	Transform DestinoConfR;
	Transform DestinoInfo;
	float passo;

	public Transform ConfirmaRed;
	public Transform Info;


	bool EstouFora;
	bool play;



    public void opcoes(){
		
		if (EstouFora == true) {
			Destino = Dentro;
		} else {
			Destino = Fora;
		}

		EstouFora = !EstouFora;
	}

	public void Informacao(){
		DestinoInfo = Dentro;
	}
	public void FecharInfo(){
		DestinoInfo = Fora;
	}

	public void ConfirmaRedefinir(){
		DestinoConfR = Dentro;
	}
	public void FechaRedefinir(){
		DestinoConfR = Fora;
	}
	public void SimREdefinir(){
		PlayerPrefs.DeleteAll ();
		DestinoConfR = Fora;
	}



	void MovePainel(){
		PainelOp.position = Vector3.MoveTowards (PainelOp.position, Destino.position,passo);
	}

	void MoveConf(){
		ConfirmaRed.position = Vector3.MoveTowards (ConfirmaRed.position, DestinoConfR.position, passo);
	}

	void MoveInfo(){
		Info.position = Vector3.MoveTowards (Info.position, DestinoInfo.position, passo);
	}


	// Use this for initialization
	void Start () {
		EstouFora = true;

		passo = 100;
		Destino = Fora;
		DestinoConfR = Fora;
		DestinoInfo = Fora;
	}
	
	// Update is called once per frame
	void Update () {
		MovePainel ();
		MoveConf ();
		MoveInfo ();

        // Verifica se algum controle foi conectado
        if (Input.GetJoystickNames().Length > 0)
        {
            // Pelo menos um controle foi conectado
            string[] joystickNames = Input.GetJoystickNames();
            foreach (string name in joystickNames)
            {
                Debug.Log("Controle conectado: " + name);
            }
        }
        else
        {
            // Nenhum controle conectado
            Debug.Log("Nenhum controle conectado.");
        }
    }
}
