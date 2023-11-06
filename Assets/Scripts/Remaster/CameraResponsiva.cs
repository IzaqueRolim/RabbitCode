using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResponsiva : MonoBehaviour
{

    public float targetAspectRatio = 20f / 12f; // A relação de aspecto que você deseja (16:9 neste exemplo).
    public float pixelsToUnits = 100; // Pixels para unidades, ajuste de acordo com o seu jogo.

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        // Calcula o aspect ratio atual da tela
        float currentAspectRatio = (float)Screen.width / Screen.height;
        Debug.Log(currentAspectRatio);

        if (currentAspectRatio < 2f)
        {
            mainCamera.orthographicSize = 6.45f;
        }
        else
        {
            mainCamera.orthographicSize = 4.75f;
        }
    }
}
