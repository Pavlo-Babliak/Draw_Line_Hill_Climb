using TMPro;
using UnityEngine;

public class Buy_Skin : MonoBehaviour
{
    public bool Buy;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Skin" + gameObject.name))
        {
            Buy = true;
            Destroy(gameObject.transform.GetChild(2).gameObject);
            for (int i = 0; i < 12; i++)
            {
                gameObject.transform.GetChild(1).GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        if (Buy == false)
        {
            for (int j = 0; j < 12; j++)
            {
                gameObject.transform.GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
            }
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
        }
        if (PlayerPrefs.GetString("ActiveSkin") != gameObject.name)
        {
            if (Buy == true)
            {
                for (int j = 0; j < 12; j++)
                {
                    gameObject.transform.GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                }
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
            }
        }
        else
        {
            for (int j = 0; j < 12; j++)
            {
                gameObject.transform.GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void Select()
    {
        if (Buy == false)
        {
            if (PlayerPrefs.GetInt("Money") >= System.Convert.ToInt32(gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - System.Convert.ToInt32(gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                PlayerPrefs.SetInt("Skin" + gameObject.name, 1);
                PlayerPrefs.SetString("ActiveSkin", gameObject.name);
                for (int i = 0; i < 7; i++)
                {
                    if (gameObject.transform.parent.GetChild(i).GetComponent<Buy_Skin>().Buy == true)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                            gameObject.transform.parent.GetChild(i).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                            gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                            gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                        }
                        
                    }
                }
                for (int i = 0; i < 12; i++)
                {
                    gameObject.transform.GetChild(1).GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                }
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                Destroy(gameObject.transform.GetChild(2).gameObject);
                GameObject.Find("Garage").GetComponent<AudioSource>().Play();
                Buy = true;
            }
            else
            {
                GameObject.Find("Money_map").GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (gameObject.transform.parent.GetChild(i).GetComponent<Buy_Skin>().Buy == true)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                        gameObject.transform.parent.GetChild(i).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                        gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                        gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                    }
                    
                }
            }
            for (int i = 0; i < 12; i++)
            {
                gameObject.transform.GetChild(1).GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            PlayerPrefs.SetString("ActiveSkin", gameObject.name);
            PlayerPrefs.SetInt("Scin", System.Convert.ToInt32(gameObject.name));
        }
    }
    public void Select_buy_car()
    {
        for (int i = 0; i < 7; i++)
        {
            if (gameObject.transform.parent.GetChild(i).GetComponent<Buy_Skin>().Buy == true)
            {
                for (int j = 0; j < 12; j++)
                {
                    gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(2).GetChild(j).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                    gameObject.transform.parent.GetChild(i).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                    gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                    gameObject.transform.parent.GetChild(i).GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
                }
            }
        }
        if (gameObject.GetComponent<Buy_Skin>().Buy == true)
        {
            for (int i = 0; i < 12; i++)
            {
                gameObject.transform.GetChild(1).GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            PlayerPrefs.SetString("ActiveSkin", gameObject.name);
            PlayerPrefs.SetInt("Scin", System.Convert.ToInt32(gameObject.name));
        }
    }
}
