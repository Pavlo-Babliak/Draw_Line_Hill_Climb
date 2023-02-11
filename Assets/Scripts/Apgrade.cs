using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Apgrade : MonoBehaviour
{
    public TextMeshProUGUI[] Count = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] Price = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] Money = new TextMeshProUGUI[2];
    public GameObject mass;
    public GameObject power;
    public GameObject speed;
    public GameObject resor;
    public GameObject while_;

    private void Start()
    {
        mass.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Massa / 50;
        power.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power / 600;
        speed.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed / 5000;
        resor.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor / 20;
        while_.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().While / 100;
        power.transform.GetChild(0).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power / 600 + (PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power) / 600;
        speed.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed / 5000) + (PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed) / 5000;
        resor.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor / 20) + (PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor) / 20;
        while_.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().While / 100) + (PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().While) / 100;
        for (int i = 0; i < 15; i++)
        {
            if (!PlayerPrefs.HasKey("Apgrade_Count_Motor_"+ System.Convert.ToString(i))) 
            {
                PlayerPrefs.SetInt("Apgrade_Count_Motor_" + System.Convert.ToString(i),0);
                PlayerPrefs.SetInt("Apgrade_Count_KPP_" + System.Convert.ToString(i),0);
                PlayerPrefs.SetInt("Apgrade_Count_Pidviska_" + System.Convert.ToString(i), 0);
                PlayerPrefs.SetInt("Apgrade_Count_Wheel_" + System.Convert.ToString(i), 0);
            }
            if (!PlayerPrefs.HasKey("Apgrade_Price_Motor_"+System.Convert.ToString(i)))
            {
                PlayerPrefs.SetInt("Apgrade_Price_Motor_" + System.Convert.ToString(i), 50);
                PlayerPrefs.SetInt("Apgrade_Price_KPP_" + System.Convert.ToString(i), 50);
                PlayerPrefs.SetInt("Apgrade_Price_Pidviska_" + System.Convert.ToString(i), 50);
                PlayerPrefs.SetInt("Apgrade_Price_Wheel_" + System.Convert.ToString(i), 50);
            }
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_Motor_0") < 19)
        {
            Count[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Motor_0")) + "/20";
            Price[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Motor_0"));
        }
        else
        {
            Count[0].text = "MAX";
            Price[0].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_KPP_0") < 19)
        {
            Count[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_KPP_0")) + "/20";
            Price[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_KPP_0"));
        }
        else
        {
            Count[1].text = "MAX";
            Price[1].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_Pidviska_0") < 19)
        {
            Count[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Pidviska_0")) + "/20";
            Price[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Pidviska_0"));
        }
        else
        {
            Count[2].text = "MAX";
            Price[2].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_Wheel_0") < 19)
        {
            Count[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Wheel_0")) + "/20";
            Price[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Wheel_0"));
        }
        else
        {
            Count[3].text = "MAX";
            Price[3].text = "MAX";
        }
    }
    public void Charateristic() 
    {
        mass.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Massa / 50;
        power.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power / 600;
        speed.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed / 5000;
        resor.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor / 20;
        while_.transform.GetChild(1).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().While / 100;
        power.transform.GetChild(0).GetComponent<Image>().fillAmount = gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power / 600 + (PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Power) / 600;
        speed.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed / 5000) + (PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Speed) / 5000;
        resor.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor / 20) + (PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().Resor) / 20;
        while_.transform.GetChild(0).GetComponent<Image>().fillAmount = (gameObject.transform.GetChild(14).GetComponent<Select_Car>().While / 100) + (PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name) * 0.05f * gameObject.transform.GetChild(14).GetComponent<Select_Car>().While) / 100;
    }
    public void OnEnable()
    {
        Select_Center();
    }
    public void Select_Center() 
    {
        gameObject.transform.GetChild(14).GetComponent<Select_Car>().Select_buy_car();
       
        if (PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            Count[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
            Price[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Motor_" + gameObject.transform.GetChild(14).gameObject.name));
        }
        else
        {
            Count[0].text = "MAX";
            Price[0].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            Count[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
            Price[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_KPP_" + gameObject.transform.GetChild(14).gameObject.name));
        }
        else
        {
            Count[1].text = "MAX";
            Price[1].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name) <19)
        {
            Count[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
            Price[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name));
        }
        else
        {
            Count[2].text = "MAX";
            Price[2].text = "MAX";
        }
        if (PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            Count[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
            Price[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Wheel_" + gameObject.transform.GetChild(14).gameObject.name));
        }
        else
        {
            Count[3].text = "MAX";
            Price[3].text = "MAX";
        }
    }
    public void Buy_Motor() 
    {
        if (PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            if (PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("Apgrade_Price_Motor_" + gameObject.transform.GetChild(14).gameObject.name))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("Apgrade_Price_Motor_" + gameObject.transform.GetChild(14).gameObject.name));
                PlayerPrefs.SetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name, PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name) + 1);
                PlayerPrefs.SetInt("Apgrade_Price_Motor_" + gameObject.transform.GetChild(14).gameObject.name, 50 + 50 * PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name));
                Count[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
                Price[0].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Motor_" + gameObject.transform.GetChild(14).gameObject.name));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                GameObject.Find("Garage").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            Count[0].text = "MAX";
            Price[0].text = "MAX";
        }
       
    }
    public void Buy_KPP()
    {
        if (PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            if (PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("Apgrade_Price_KPP_" + gameObject.transform.GetChild(14).gameObject.name))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("Apgrade_Price_KPP_" + gameObject.transform.GetChild(14).gameObject.name));
                PlayerPrefs.SetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name, PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name) + 1);
                PlayerPrefs.SetInt("Apgrade_Price_KPP_" + gameObject.transform.GetChild(14).gameObject.name, 50 + 50 * PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name));
                Count[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
                Price[1].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_KPP_" + gameObject.transform.GetChild(14).gameObject.name));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                GameObject.Find("Garage").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            Count[1].text = "MAX";
            Price[1].text = "MAX";
        }

    }
    public void Buy_Pidviska()
    {
        if (PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name) <19)
        {
            if (PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("Apgrade_Price_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("Apgrade_Price_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name));
                PlayerPrefs.SetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name, PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name) + 1);
                PlayerPrefs.SetInt("Apgrade_Price_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name, 50 + 50 * PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name));
                Count[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
                Price[2].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Pidviska_" + gameObject.transform.GetChild(14).gameObject.name));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                GameObject.Find("Garage").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            Count[2].text = "MAX";
            Price[2].text = "MAX";
        }

    }
    public void Buy_Wheel()
    {
        if (PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name) < 19)
        {
            if (PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("Apgrade_Price_Wheel_" + gameObject.transform.GetChild(14).gameObject.name))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("Apgrade_Price_Wheel_" + gameObject.transform.GetChild(14).gameObject.name));
                PlayerPrefs.SetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name, PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name) + 1);
                PlayerPrefs.SetInt("Apgrade_Price_Wheel_" + gameObject.transform.GetChild(14).gameObject.name, 50 + 50 * PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name));
                Count[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.transform.GetChild(14).gameObject.name)) + "/20";
                Price[3].text = System.Convert.ToString(PlayerPrefs.GetInt("Apgrade_Price_Wheel_" + gameObject.transform.GetChild(14).gameObject.name));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                GameObject.Find("Garage").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            Count[3].text = "MAX";
            Price[3].text = "MAX";
        }

    }
}
