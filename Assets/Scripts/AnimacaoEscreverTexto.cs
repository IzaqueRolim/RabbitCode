using UnityEngine;
using UnityEngine.UI;

public class AnimacaoEscreverTexto : MonoBehaviour
{
    public float velocidadeDigitação = 0.1f;
    private Text textoComponente;
    private string textoOriginal;
    private string textoAtual;
    private float tempoDecorrido = 0f;
    bool isActive;

    private void Awake()
    {
        textoComponente = GetComponent<Text>();
        textoOriginal = textoComponente.text;
        textoAtual = "";
        textoComponente.text = textoAtual;
    }

    private void Update()
    {
        if(gameObject.activeSelf){
    
            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido >= velocidadeDigitação)
            {
                tempoDecorrido = 0f;
                if (textoAtual.Length < textoOriginal.Length)
                {
                    textoAtual += textoOriginal[textoAtual.Length];
                    textoComponente.text = textoAtual;
                }
            }
        }
    }
}

