using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Select_Lvl : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadScene(System.Convert.ToString(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
    }
}
