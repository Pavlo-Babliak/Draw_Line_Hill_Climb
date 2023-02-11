using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Select_Car : MonoBehaviour
{
    public bool Buy;
    public float Massa;
    public float Power;
    public float Speed;
    public float Resor;
    public float While;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            Buy = true;
            Destroy(gameObject.transform.GetChild(4).gameObject);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }

        if (gameObject.name != PlayerPrefs.GetString("Active"))
        {
            if (gameObject.GetComponent<Select_Car>().Buy == true)
            {
                gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(155, 155, 155, 255);
            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void Select()
    {
        if (Buy == false)
        {
            if (PlayerPrefs.GetInt("Money") >= System.Convert.ToInt32(gameObject.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text))
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - System.Convert.ToInt32(gameObject.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text));
                GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
                PlayerPrefs.SetInt(gameObject.name, 1);
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Destroy(gameObject.transform.GetChild(4).gameObject);
                gameObject.transform.GetChild(5).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car", System.Convert.ToInt32(gameObject.name));
                for (int i = 0; i <= 14; i++) { GameObject.Find("Car").transform.GetChild(i).gameObject.SetActive(false); }
                GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.x, GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.y + 2, 0);
                GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.SetActive(true);
                GameObject.Find("Main Camera").GetComponent<CameraFollow>().target = GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform;
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
            for (int i = 0; i < 15; i++)
            {
                if (gameObject.transform.parent.GetChild(i).gameObject.GetComponent<Select_Car>().Buy == true)
                {
                    gameObject.transform.parent.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                    gameObject.transform.parent.GetChild(i).gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                    gameObject.transform.parent.GetChild(i).gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                    GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                }
            }

            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            if (System.Convert.ToInt32(gameObject.name) == 13) { GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(255, 255, 255, 255); }
            PlayerPrefs.SetString("Active", gameObject.name);
            PlayerPrefs.SetInt("Car", System.Convert.ToInt32(gameObject.name));
            for (int i = 0; i <= 14; i++) { GameObject.Find("Car").transform.GetChild(i).gameObject.SetActive(false); }
            GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.x, GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.y + 2, 0);
            GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().target = GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform;
        }
    }
    public void Select_buy_car()
    {
        for (int i = 0; i < 15; i++)
        {
            if (gameObject.transform.parent.GetChild(i).gameObject.GetComponent<Select_Car>().Buy == true)
            {
                gameObject.transform.parent.GetChild(i).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                gameObject.transform.parent.GetChild(i).gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                gameObject.transform.parent.GetChild(i).gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
                GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(155, 155, 155, 255);
            }
        }
        if (gameObject.GetComponent<Select_Car>().Buy == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            if (System.Convert.ToInt32(gameObject.name) == 13) { GameObject.FindWithTag("krulo").GetComponent<Image>().color = new Color32(255, 255, 255, 255); }

            PlayerPrefs.SetString("Active", gameObject.name);
            PlayerPrefs.SetInt("Car", System.Convert.ToInt32(gameObject.name));
            for (int i = 0; i <= 14; i++) { GameObject.Find("Car").transform.GetChild(i).gameObject.SetActive(false); }
            GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.x, GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.transform.position.y + 2, 0);
            GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().target = GameObject.Find("Car").transform.GetChild(System.Convert.ToInt32(gameObject.name)).gameObject.transform;
        }
    }
}
