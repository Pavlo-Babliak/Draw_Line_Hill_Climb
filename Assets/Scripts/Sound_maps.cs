using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_maps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 1) { GetComponent<AudioSource>().enabled = true; }
        if (PlayerPrefs.GetInt("Sound") == 0) { GetComponent<AudioSource>().enabled = false; }
    }
}
