using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_menu : MonoBehaviour
{
    public Sprite[] music = new Sprite[2];
    public Sprite[] sound = new Sprite[2];
    public GameObject Music;
    public GameObject Sound;
    public Image fon_settings;
    public GameObject Exit_trigger;
    public GameObject Dark_backgound;
    public TextMeshProUGUI Ads_prise;
    private int k;
    // Start is called before the first frame update
    void Start()
    {
        IronSource.Agent.init("15a47575d", IronSourceAdUnits.REWARDED_VIDEO);
        IronSource.Agent.shouldTrackNetworkState(true);
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;

        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
            Music.GetComponent<Image>().sprite = music[1];
            GameObject.Find("Cameras").GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            Music.GetComponent<Image>().sprite = music[PlayerPrefs.GetInt("Music")];
            if (PlayerPrefs.GetInt("Music") == 0) { GameObject.Find("Cameras").GetComponent<AudioSource>().enabled = false; }
            if (PlayerPrefs.GetInt("Music") == 1) { GameObject.Find("Cameras").GetComponent<AudioSource>().enabled = true; }
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
            Sound.GetComponent<Image>().sprite = sound[1];
        }
        else
        {
            Sound.GetComponent<Image>().sprite = sound[PlayerPrefs.GetInt("Sound")];
        } 
    }
    void RewardedVideoAvailabilityChangedEvent(bool available)
    {
        bool rewardedVideoAvailability = available;
    }
    public void RewardedVideoAdOpenedEvent()
    {
        if (PlayerPrefs.GetInt("Music") == 1) { GameObject.Find("Cameras").GetComponent<AudioSource>().Stop(); }
    }
    public void Exit_trigger_open() { Exit_trigger.SetActive(true); }
    public void Exit_trigger_close() { Exit_trigger.SetActive(false); }
    public void Exit_game() { Application.Quit(); }

    public void Setting_open()
    {
        if (fon_settings.fillAmount == 1) { fon_settings.fillAmount = 0; Music.SetActive(false); Sound.SetActive(false); }
        else { fon_settings.fillAmount = 1; Music.SetActive(true); Sound.SetActive(true); }
    }
    public void Sound_Button()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        Sound.GetComponent<Image>().sprite = sound[PlayerPrefs.GetInt("Sound")];
    }
    public void Music_Button()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            GameObject.Find("Cameras").GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            GameObject.Find("Cameras").GetComponent<AudioSource>().enabled = false;
        }
        Music.GetComponent<Image>().sprite = music[PlayerPrefs.GetInt("Music")];
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 99999);
    }
 
    public void Play_lvl()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LVL"));
    }
    public void Ads()
    {
       
        IronSource.Agent.showRewardedVideo();
        if (PlayerPrefs.GetInt("Music") == 1) { GameObject.Find("Cameras").GetComponent<AudioSource>().Play(); }
        Dark_backgound.SetActive(true);
        k = Random.Range(250, 1250);
        Ads_prise.text = "+" + System.Convert.ToString(k);
    }
    public void Get_Ads_money()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + k);
        GameObject.Find("Money_map").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
    }
    public void Menu()
    {
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.gameObject.transform.GetChild(0).GetComponent<WheelJoint2D>().useMotor = true;
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.gameObject.transform.GetChild(1).GetComponent<WheelJoint2D>().useMotor = true;
    }
    public void Garage()
    {
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.gameObject.transform.GetChild(0).GetComponent<WheelJoint2D>().useMotor = false;
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().target.gameObject.transform.GetChild(1).GetComponent<WheelJoint2D>().useMotor = false;
    }
}
