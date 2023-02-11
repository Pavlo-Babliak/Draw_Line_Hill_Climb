using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Win_trig : MonoBehaviour
{
    public GameObject Win_trigger;
    private GameObject car;
    private GameObject Cameras_Fon_music;
    private GameObject Camera_Engine_sound;
    public static int mon_start;
    public TextMeshProUGUI Record_money;
    public TextMeshProUGUI money;
    public TextMeshProUGUI Record_dist;
    public TextMeshProUGUI dist;
    int distanc =300;
    public int Kill_Power;

    // Start is called before the first frame update
    private void Awake()
    {
        Win_trigger = GameObject.Find("win_trig");
        Record_money = GameObject.Find("Money+_Re").GetComponent<TextMeshProUGUI>();
        money = GameObject.Find("Money+").GetComponent<TextMeshProUGUI>();
        Record_dist = GameObject.Find("Dist_Record").GetComponent<TextMeshProUGUI>();
        dist = GameObject.Find("Dist").GetComponent<TextMeshProUGUI>();
        Win_trigger.SetActive(false);
       // gameObject.GetComponent<HingeJoint2D>().breakTorque = Kill_Power;
    }
    void Start()
    {
        mon_start = PlayerPrefs.GetInt("Money");
        car = GameObject.FindWithTag("Player");
        Cameras_Fon_music = GameObject.Find("Cameras");
        Camera_Engine_sound = GameObject.Find("Main Camera");
        if (Application.loadedLevel != 126) { Win_trigger.transform.GetChild(3).gameObject.SetActive(false); Win_trigger.transform.GetChild(4).gameObject.SetActive(false); }
    }
   /* private void Update()
    {
        if (!gameObject.GetComponent<HingeJoint2D>()) 
        {
            GetComponent<AudioSource>().Play();
            car.GetComponent<Rigidbody2D>().simulated = false;
            car.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
            car.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
            Camera_Engine_sound.GetComponent<AudioSource>().Stop();
            Cameras_Fon_music.GetComponent<AudioSource>().Stop();
            GameObject.Find("Lines").GetComponent<LineFactory>().enabled = false;
            Win_trigger.SetActive(true);
            Win_trigger.transform.GetChild(3).GetComponent<Button_continue>().MuchMoney();
            GameObject.Find("Money+").GetComponent<TextMeshProUGUI>().text = "+" + System.Convert.ToString(PlayerPrefs.GetInt("Money") - mon_start);
            GameObject.Find("Dist").GetComponent<TextMeshProUGUI>().text = String.Format("{0:0#}", car.transform.position.x);
            if (!PlayerPrefs.HasKey("Record_Money"))
            {
                PlayerPrefs.SetInt("Record_Money", 0);
                if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text))
                {
                    PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
                else
                {
                    Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text))
                {
                    PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
                else
                {
                    Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
            }

            if (!PlayerPrefs.HasKey("Record_Dist"))
            {
                PlayerPrefs.SetInt("Record_Dist", 0);
                if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text))
                {
                    PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
                else
                {
                    Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text))
                {
                    PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
                else
                {
                    Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
            }
        }
    }*/
    public void Save_result() 
    {
        car.GetComponent<Rigidbody2D>().simulated = false;
        car.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
        car.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
        Camera_Engine_sound.GetComponent<AudioSource>().Stop();
        Cameras_Fon_music.GetComponent<AudioSource>().Stop();
        GameObject.Find("Lines").GetComponent<LineFactory>().enabled = false;
        Win_trigger.SetActive(true);
        Win_trigger.transform.GetChild(3).GetComponent<Button_continue>().MuchMoney();
        GameObject.Find("Money+").GetComponent<TextMeshProUGUI>().text = "+" + System.Convert.ToString(PlayerPrefs.GetInt("Money") - mon_start);
        GameObject.Find("Dist").GetComponent<TextMeshProUGUI>().text = String.Format("{0:0#}", car.transform.position.x);
        car.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        car.GetComponent<Rigidbody2D>().angularVelocity = 0;
        car.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        car.transform.GetChild(0).GetComponent<Rigidbody2D>().angularVelocity = 0;
        car.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        car.transform.GetChild(1).GetComponent<Rigidbody2D>().angularVelocity = 0;
        if (Application.loadedLevel >= 1 && Application.loadedLevel < 126)
        {
            Win_trigger.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (!PlayerPrefs.HasKey("Record_Money"))
        {
            PlayerPrefs.SetInt("Record_Money", 0);
            if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text))
            {
                PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
            }
            else
            {
                Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text))
            {
                PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
            }
            else
            {
                Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
            }
        }

        if (!PlayerPrefs.HasKey("Record_Dist"))
        {
            PlayerPrefs.SetInt("Record_Dist", 0);
            if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text))
            {
                PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
            }
            else
            {
                Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text))
            {
                PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
            }
            else
            {
                Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground"|| collision.name == "Line" || collision.tag == "Stone" || collision.tag == "Finish") 
        {
            if(collision.tag != "Finish") 
            {
                GetComponent<AudioSource>().Play();
            }
            else 
            {
                Win_trigger.transform.GetChild(3).gameObject.SetActive(false);
                Win_trigger.transform.GetChild(4).gameObject.SetActive(false);
            }
            if (collision.tag == "Finish")
            {
                if (Application.loadedLevel >= 1 && Application.loadedLevel < 126)
                {
                    PlayerPrefs.SetInt("LVL", Application.loadedLevel + 1);
                    Win_trigger.transform.GetChild(2).gameObject.SetActive(false);
                    Win_trigger.transform.GetChild(3).gameObject.SetActive(false);
                    Win_trigger.transform.GetChild(4).gameObject.SetActive(false);
                    Win_trigger.transform.GetChild(5).gameObject.SetActive(true);
                }
            }
            car.GetComponent<Rigidbody2D>().simulated = false;
            car.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
            car.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
            Camera_Engine_sound.GetComponent<AudioSource>().Stop();
            Cameras_Fon_music.GetComponent<AudioSource>().Stop();
            GameObject.Find("Lines").GetComponent<LineFactory>().enabled = false;
            Win_trigger.SetActive(true);
            if (Application.loadedLevel == 126) { Win_trigger.transform.GetChild(3).GetComponent<Button_continue>().MuchMoney(); }
            GameObject.Find("Money+").GetComponent<TextMeshProUGUI>().text = "+"+System.Convert.ToString(PlayerPrefs.GetInt("Money") - mon_start);
            GameObject.Find("Dist").GetComponent<TextMeshProUGUI>().text = String.Format("{0:0#}",car.transform.position.x);

            if (!PlayerPrefs.HasKey("Record_Money"))
            {
                PlayerPrefs.SetInt("Record_Money", 0);
                if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text))
                {
                    PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
                else
                {
                    Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Record_Money") < System.Convert.ToInt32(money.text)) 
                {
                    PlayerPrefs.SetInt("Record_Money", System.Convert.ToInt32(money.text)); Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
                else
                {
                    Record_money.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Money"));
                }
            }

            if (!PlayerPrefs.HasKey("Record_Dist"))
            {
                PlayerPrefs.SetInt("Record_Dist", 0);
                if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text)) 
                {
                    PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
                else
                {
                    Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Record_Dist") < System.Convert.ToInt32(dist.text)) 
                {
                    PlayerPrefs.SetInt("Record_Dist", System.Convert.ToInt32(dist.text)); Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist")); 
                }
                else
                {
                    Record_dist.text = System.Convert.ToString(PlayerPrefs.GetInt("Record_Dist"));
                }
            }
            if (System.Convert.ToInt32(dist.text) >= distanc && !PlayerPrefs.HasKey("Rate")) 
            {
                Camera_Engine_sound.GetComponent<Rate>().Open_Rate_BOX();
                distanc += 150;
            }
        }
    }
}
