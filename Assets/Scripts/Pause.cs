using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public void IniciaPause(){
        Time.timeScale = 0;
   }

   public void ParaPause(){
        Time.timeScale = 1;
   }

   public void SairParaSelecaoDeFases(){
   
   }

  
}
