using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Education : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Education")) { gameObject.SetActive(false); }
    }
}
