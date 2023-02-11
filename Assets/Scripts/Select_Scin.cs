using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Scin : MonoBehaviour
{
    public Sprite[] Scin = new Sprite[2];
     void  Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Scin[PlayerPrefs.GetInt("Scin")];
    }
    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Scin[PlayerPrefs.GetInt("Scin")];
    }

}
