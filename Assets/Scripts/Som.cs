using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
   public void ToggleSom(GameObject obj){
    obj.SetActive(!obj.activeSelf);
   }
}
