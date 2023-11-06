using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EfeitoDigitacao : MonoBehaviour
{
    public float velocidadeDeDigitacao;
    public string textoCompleto;
    private TextMeshProUGUI textoUI;

    private void Start()
    {
        velocidadeDeDigitacao = 0.05f;
        textoUI = GetComponent<TextMeshProUGUI>();
        textoCompleto = textoUI.text;
        textoUI.text = "";  // Inicia o texto vazio
        StartCoroutine(DigitarTexto());
    }

    private IEnumerator DigitarTexto()
    {
        foreach (char letra in textoCompleto)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadeDeDigitacao); // Quando maior o tempo, menor a velocidade.
        }
    }
}
