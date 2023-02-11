using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Action_lvl : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("LVL")) 
        {
            PlayerPrefs.SetInt("LVL", 1);
        }
    }
    private void OnEnable()
    {
        if (System.Convert.ToInt32(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) == PlayerPrefs.GetInt("LVL")) 
        {
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(100, 255, 60,255);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.GetComponent<Button>().enabled = true;
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) > PlayerPrefs.GetInt("LVL"))
        {
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(255, 107, 120, 255);
            gameObject.GetComponent<Image>().color = new Color32(175, 175, 175, 175);
            gameObject.GetComponent<Button>().enabled = false;
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) < PlayerPrefs.GetInt("LVL"))
        {
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(110, 125, 255, 255);
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
