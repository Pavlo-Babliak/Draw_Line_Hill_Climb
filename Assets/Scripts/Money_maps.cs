using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money_maps : MonoBehaviour
{
    private TextMeshProUGUI Mon_text;
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
    }
    void Start()
    {
        Mon_text = GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>();
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
            Mon_text.text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
        }
        else
        {
            Mon_text.text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
        }
    }
    public int Money_up(int money)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + money);
        Mon_text.text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
        return money;
    }
}
