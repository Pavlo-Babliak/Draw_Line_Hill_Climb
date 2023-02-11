using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_maps : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.GetInt("Buy_Maps_"+gameObject.name) == 1) 
        {
            SceneManager.LoadScene(126);
        }
    }
}
