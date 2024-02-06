using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class Campo
{
    public string Nome;
    public string Valor;

    public Campo(string nome, object valor)
    {
        Nome = nome;
        Valor = valor != null ? valor.ToString() : null;
    }
}

[System.Serializable]
public class Componente
{
    public string Nome;
    public List<Campo> Campos;

    public Componente(string nome)
    {
        Nome = nome;
        Campos = new List<Campo>();
    }

    public void AdicionarCampo(string nome, object valor)
    {
        Campo campo = new Campo(nome,valor);
        Campos.Add(campo);
    }
}

[System.Serializable]
public class Objeto
{
    public string Nome;
    public List<Componente> Componentes;

    public Objeto(string nome)
    {
        Nome = nome;
        Componentes = new List<Componente>();
    }

    public void AdicionarComponente(Componente componente)
    {
        Componentes.Add(componente);
    }
}

public class TesteCaptura : MonoBehaviour
{
    void Start()
    {
        List<Objeto> objList = new List<Objeto>();

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            Objeto objetoParaLista = new Objeto(obj.name);

            // Obtenha todos os componentes na cena
            Component[] allComponents = obj.GetComponents<Component>();

            foreach (Component component in allComponents)
            {
                if (component == null)
                {
                    continue;
                }

                Componente componente = new Componente(component.GetType().ToString());

                AccessFields(component, componente);
                objetoParaLista.AdicionarComponente(componente);
            }

            objList.Add(objetoParaLista);
        }

        string jsonString = JsonUtility.ToJson(new SerializableList<Objeto>(objList));
        
        string filePath = Path.Combine(Application.dataPath, "output.json");

        
        File.WriteAllText(filePath, jsonString);

        Debug.Log("JSON exportado com sucesso para: " + filePath);
    }

    void AccessFields(Component component, Componente componente)
    {
        Type type = component.GetType();
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

     

        foreach (PropertyInfo property in properties)
        {
            try
            {
                if (property.CanRead)
                {
                    object value = property.GetValue(component);

                    componente.AdicionarCampo(property.Name, value);
                    Debug.Log($"ObjName: {componente.Nome}, Property: {property.Name}, Type: {property.PropertyType}, Value: {value}");
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error accessing property {property.Name}: {e.Message}");
            }
        }

    }

    [System.Serializable]
    private class SerializableList<T>
    {
        public List<T> List;

        public SerializableList(List<T> list)
        {
            List = list;
        }
    }
}
