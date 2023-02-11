using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Select_Map : MonoBehaviour
{
    private GameObject Camera;
    public GameObject Confirm_buy;
    public GameObject yes;
    private void Start()
    {
        PlayerPrefs.SetInt("Buy_Maps_0", 1);
        Camera = GameObject.FindWithTag("MainCamera").gameObject;
        if (PlayerPrefs.GetInt("Buy_Maps_" + gameObject.name) == 1)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            if (gameObject.name != "0") { Destroy(gameObject.transform.GetChild(2).gameObject); }
            
        }
    }
    public void Select() 
    {
        if (PlayerPrefs.GetInt("Buy_Maps_" + gameObject.name) == 1)
        {
            PlayerPrefs.SetInt("Map", System.Convert.ToInt32(gameObject.name));
            Camera.GetComponent<BackgroundControl_0>().backgroundNum = System.Convert.ToInt32(gameObject.name);
            Camera.GetComponent<BackgroundControl_0>().Start();
        }
        else 
        {
            if (PlayerPrefs.GetInt("Money") >= System.Convert.ToInt32(gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text))
            {
                yes.SetActive(true);
                Confirm_buy.SetActive(true);
            }
            else 
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void Confirm_yes() 
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - System.Convert.ToInt32(gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
        GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
        PlayerPrefs.SetInt("Buy_Maps_" + gameObject.name, 1);
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        PlayerPrefs.SetInt("Map", System.Convert.ToInt32(gameObject.name));
        Camera.GetComponent<BackgroundControl_0>().backgroundNum = System.Convert.ToInt32(gameObject.name);
        Camera.GetComponent<BackgroundControl_0>().Start();
        Destroy(gameObject.transform.GetChild(2).gameObject);
        yes.SetActive(false);
        Confirm_buy.SetActive(false);
        GameObject.Find("Maps").GetComponent<AudioSource>().Play();
    }
}
