using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
   void Start(){
      DontDestroyOnLoad(this.gameObject);
   }
   public void ToggleSom(GameObject obj){
    obj.SetActive(!obj.activeSelf);

    if(obj.activeSelf){
         GetComponent<AudioSource>().Play();
         return;
    }
      GetComponent<AudioSource>().Pause();
    
   }
}
