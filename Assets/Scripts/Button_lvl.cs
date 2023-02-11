using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class Button_lvl : MonoBehaviour
{

    public TextMeshProUGUI Money;
    public TextMeshProUGUI Money_ui;
    private int Cina_respawn = 50;
    GameObject Car;
    public GameObject[] Button = new GameObject[2];
    private GameObject Cameras_Fon_music;
    private GameObject Camera_Engine_sound;
    private bool start_ads_in_main;
    private bool start_ads_return, start_ads_next;
    private InterstitialAd interstitial;
    private BannerView bannerView;

    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-9572656335524853/6743113881";
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        //this.interstitial.OnAdClosed += HandleOnAdClosed;
    }
    private void Start()
    {
        RequestInterstitial();
       /* MobileAds.Initialize(initStatus => { });
        this.RequestBanner();*/
        Cameras_Fon_music = GameObject.Find("Cameras");
        Camera_Engine_sound = GameObject.Find("Main Camera");
        Money.text = "-" + System.Convert.ToString(Cina_respawn);
        Car = GameObject.FindWithTag("Player");
        if (!PlayerPrefs.HasKey("Ads")) { PlayerPrefs.SetInt("Ads",0); }
    }
    /*private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-9572656335524853/2246395287";
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }*/
    private void OnEnable()
    {
        IronSource.Agent.init("15a47575d", IronSourceAdUnits.INTERSTITIAL);
        //IronSource.Agent.loadInterstitial();
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent;
        IronSource.Agent.shouldTrackNetworkState(true);
        if (Application.loadedLevel == 126 || Application.loadedLevel == 0)
        {
            IronSource.Agent.init("15a47575d", IronSourceAdUnits.REWARDED_VIDEO);
            IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
            IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
            IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
        }
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.TOP);
        IronSource.Agent.displayBanner();
    }
    void RewardedVideoAvailabilityChangedEvent(bool available)
    {
        if (Application.loadedLevel == 126 || Application.loadedLevel == 0)
        {
            bool rewardedVideoAvailability = available;
        }
    }
    void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
    {
        if (Application.loadedLevel == 126 || Application.loadedLevel == 0)
        {
            IronSource.Agent.init("15a47575d", IronSourceAdUnits.REWARDED_VIDEO);
            IronSource.Agent.shouldTrackNetworkState(true);
        }
    }
    public void RewardedVideoAdOpenedEvent()
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }



    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }

    /*public void HandleOnAdClosed(object sender, EventArgs args)
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        if (start_ads_in_main == true)
        {
            start_ads_in_main = false;
            IronSource.Agent.destroyBanner();
            SceneManager.LoadScene(0);
        }
        if (start_ads_return == true)
        {
            start_ads_return = false;
            IronSource.Agent.destroyBanner();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        interstitial.Destroy();
    }*/
    void InterstitialAdShowSucceededEvent()
    {
       GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        if (start_ads_in_main == true)
        {
            start_ads_in_main = false;
            IronSource.Agent.destroyBanner();
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled =true;
            SceneManager.LoadScene(0);
        }
        if (start_ads_return == true)
        {
            start_ads_return = false;
            IronSource.Agent.destroyBanner();
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (start_ads_next == true)
        {
            start_ads_next = false;
            IronSource.Agent.destroyBanner();
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            SceneManager.LoadScene(Application.loadedLevel + 1);
        }
        interstitial.Destroy();
}
public void InterstitialAdOpenedEvent()
    {
        
    }
    public void InterstitialAdClosedEvent()
    {
  
    }

    public void Menu()
    {
         if (IronSource.Agent.isInterstitialReady())
         {
             start_ads_in_main = true;
             IronSource.Agent.showInterstitial();
         }
         else
         {
             IronSource.Agent.loadInterstitial();
             SceneManager.LoadScene(0);
         }
        /* if (this.interstitial.IsLoaded())
          {
              start_ads_in_main = true;
              this.interstitial.Show();
          }
          else
          {
             IronSource.Agent.destroyBanner();
             SceneManager.LoadScene(0);
          }*/
    }
    public void Next_lvl() 
    {
        if (IronSource.Agent.isInterstitialReady())
        {
            start_ads_next= true;
            IronSource.Agent.showInterstitial();
        }
        else
        {
            IronSource.Agent.loadInterstitial();
            SceneManager.LoadScene(Application.loadedLevel + 1);
        }
        
    }
    public void Return()
    {
        if (PlayerPrefs.GetInt("Ads") >= 2)
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                start_ads_return = true;
                IronSource.Agent.showInterstitial();
            }
            else
            {
                IronSource.Agent.loadInterstitial();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            IronSource.Agent.destroyBanner();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Ads", PlayerPrefs.GetInt("Ads") + 1);
        }  
       /* if( PlayerPrefs.GetInt("Ads") >= 2)
        {
            if (this.interstitial.IsLoaded())
            {
                start_ads_return = true;
                this.interstitial.Show();
                PlayerPrefs.SetInt("Ads", 0);
            }
            else
            {
                IronSource.Agent.destroyBanner();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            IronSource.Agent.destroyBanner();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Ads", PlayerPrefs.GetInt("Ads") + 1);
        }*/

    }
    public void Continue_money()
    {
        if (PlayerPrefs.GetInt("Money") >= Cina_respawn)
        {
            Camera_Engine_sound.GetComponent<AudioSource>().Play();
            Cameras_Fon_music.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Cina_respawn);
            Money_ui.text = System.Convert.ToString(PlayerPrefs.GetInt("Money"));
            Cina_respawn = Cina_respawn * 2;
            Money.text = "-" + System.Convert.ToString(Cina_respawn);
            Button[1].SetActive(true);
            Button[0].SetActive(false);
            Car.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.position = new Vector3(Car.GetComponent<Move_button>().ChekPoint.x, Car.GetComponent<Move_button>().ChekPoint.y+3, Car.transform.position.z); 
            Car.transform.rotation = Quaternion.identity;
            Car.GetComponent<Rigidbody2D>().simulated = true;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = true;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = true;
            GameObject.Find("win_trig").SetActive(false);
            GameObject.Find("Lines").GetComponent<LineFactory>().enabled = true;

            Win_trig.mon_start = PlayerPrefs.GetInt("Money");
        }
    }
    public void Continue_ads()
    {
        if (Application.loadedLevel == 126 || Application.loadedLevel == 0)
        {
            IronSource.Agent.showRewardedVideo();
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            Camera_Engine_sound.GetComponent<AudioSource>().Play();
            Cameras_Fon_music.GetComponent<AudioSource>().Play();
            Car.GetComponent<Rigidbody2D>().simulated = false;
            Button[1].SetActive(true);
            Button[0].SetActive(false);
            Car.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().angularVelocity = 0;
            Car.transform.position = new Vector3(Car.GetComponent<Move_button>().ChekPoint.x, Car.GetComponent<Move_button>().ChekPoint.y + 3, Car.transform.position.z);
            Car.transform.rotation = Quaternion.identity;
            Car.GetComponent<Rigidbody2D>().simulated = true;
            Car.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = true;
            Car.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = true;
            GameObject.Find("win_trig").SetActive(false);
            GameObject.Find("Lines").GetComponent<LineFactory>().enabled = true;
        }
    }

}
