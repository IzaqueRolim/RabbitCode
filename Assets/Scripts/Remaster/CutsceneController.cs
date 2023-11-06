using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{

    public void AcionarCutscene(PlayableDirector cutsceneDirector)
    {
       
        cutsceneDirector.Play();
    }
    public void teste() { }
}
