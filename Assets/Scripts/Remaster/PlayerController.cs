using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    string direcao = "COL";

    float velocidade = 5f;

    private void Update()
    {
        IrAoDestino(5, 2);
    }
    void IrAoDestino(int posX, int posY)
    {
        if(direcao == "COL")
        {
            float distanciaY = posY - transform.position.y;
            float distanciaX = posX - transform.position.x;

            if (Mathf.Abs(distanciaY) > 0.1f) // Verifica se a distância Y é maior que 0.1 (outra constante pode ser utilizada)
            {
                // Movimento no eixo Y
                float direcaoY = Mathf.Sign(distanciaY); // Obtém a direção (1 para cima, -1 para baixo)
                Debug.Log(direcaoY);
                transform.Translate(new Vector2(0, direcaoY * velocidade * Time.deltaTime));
            }
            else
            {
                // O objeto chegou na altura desejada (posY), agora fazemos o movimento no eixo X
                if (Mathf.Abs(distanciaX) > 0.1f) // Verifica se a distância X é maior que 0.1 (outra constante pode ser utilizada)
                {
                    // Movimento no eixo X
                    float direcaoX = Mathf.Sign(distanciaX); // Obtém a direção (1 para direita, -1 para esquerda)
                    transform.Translate(new Vector2(direcaoX * velocidade * Time.deltaTime, 0));
                }
                // Não é necessário o "else" aqui, pois o objeto não se move mais se estiver exatamente em posX.
            }
        }
    }
}
