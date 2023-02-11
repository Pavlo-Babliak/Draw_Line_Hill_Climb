using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_maps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 1) { GetComponent<AudioSource>().enabled = true; }
        if (PlayerPrefs.GetInt("Music") == 0) { GetComponent<AudioSource>().enabled = false; }
    }
}
