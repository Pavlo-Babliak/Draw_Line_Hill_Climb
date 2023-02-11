using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_skin : MonoBehaviour
{
   public void Select() 
    {
        PlayerPrefs.SetInt("Scin",  System.Convert.ToInt32(gameObject.name));
    }
}
