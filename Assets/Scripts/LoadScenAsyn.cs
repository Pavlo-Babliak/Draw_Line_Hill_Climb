using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenAsyn : MonoBehaviour
{
    void Start()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("LVL"));
        asyncOperation.allowSceneActivation = false;
    }
}
