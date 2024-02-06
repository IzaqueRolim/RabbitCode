using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;

public class ExibirAtributos : MonoBehaviour
{


    GameObject player;
    Transform playerTransform;
    Quaternion rotacao = Quaternion.identity;
    Color corVermelha = Color.red;
    Material meuMaterial;
    Collider colisorDoObjeto;
    Rigidbody corpoRigido;



    void Start()
    {
        // Substitua "NomeDaSuaClasse" pelo nome da classe que você deseja inspecionar
      //  ExibirAtributosDaClasse<Transform>();
    }

    void ExibirAtributosDaClasse<T>()
    {
        Type tipo = typeof(T);
        FieldInfo[] campos = tipo.GetFields(BindingFlags.Instance | BindingFlags.Public);
        PropertyInfo[] propriedades = tipo.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        Debug.Log($"Atributos da classe {tipo.Name}:");

        // Exibe campos
        foreach (var campo in campos)
        {
            object valorCampo = campo.GetValue(gameObject); // Use "this" para obter o valor do campo deste objeto
            Debug.Log($"{campo.Name}{valorCampo}");
           
        }

        // Exibe propriedades
        foreach (var propriedade in propriedades)
        {
          //  object valorPropriedade = propriedade.GetValue(this, null); // Use "this" para obter o valor da propriedade deste objeto
            Debug.Log($"{propriedade.Name}");
        }
    }
}
