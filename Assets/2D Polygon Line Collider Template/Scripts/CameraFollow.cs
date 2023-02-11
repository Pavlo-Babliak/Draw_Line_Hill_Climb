using System;
using TMPro;
using UnityEngine;

/*
 * 2D Polygon Line Collider Package
 *
 * @license		    Unity Asset Store EULA https://unity3d.com/legal/as_terms
 * @author		    Indie Studio - Baraa Nasser
 * @Website		    https://indiestd.com
 * @Asset Store     https://assetstore.unity.com/publishers/9268
 * @Unity Connect   https://connect.unity.com/u/5822191d090915001dbaf653/column
 * @email		    info@indiestd.com
 *
 */

[DisallowMultipleComponent]
public class CameraFollow : MonoBehaviour
{
    // Distance in the x axis the target can move before the camera follows.
    public float xMargin = 1f;
    // Distance in the y axis the target can move before the camera follows.
    public float yMargin = 1f;
    // How smoothly the camera catches up with it's target movement in the x axis.
    public float xSmooth = 8f;
    // How smoothly the camera catches up with it's target movement in the y axis.
    public float ySmooth = 8f;
    // Reference to the target's transform.
    public Transform target;
    // Reference to the target's x postion.
    private float targetX;
    // Reference to the target's y postion.
    private float targetY;
    // Whether to follow the target's x position or not
    public bool followX = true;
    // Whether to follow the target's y position or not
    public bool followY = true;

    public bool Camera_Move;
    public float Camera_MoveSpeed = 1.5f;
    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7];
    public GameObject[] Layer_Objects = new GameObject[7];

    private Transform _camera;
    private float[] startPos = new float[7];
    private float boundSizeX;
    private float sizeX;
    private GameObject Layer_0;

    public Vector2 maxSpeed;
    private Vector2 tempVector;
    private Rigidbody2D rigidBody2D;
    public bool moveOnStart;
    public GameObject[] Strilka = new GameObject[2];
    public float i;
    public float j;
    public RectTransform Car_icon;
    private TextMeshProUGUI dist;
    public GameObject Exit_trigger;
    public GameObject[] Prefub_cars = new GameObject[16];
    public GameObject Button_ads;
    private GameObject dum;
    private GameObject menu;
    //public Transform Start_pos;
    //public int car;
    public void Exit_trigger_open() { Exit_trigger.SetActive(true); }
    public void Exit_trigger_close() { Exit_trigger.SetActive(false); }
    public void Exit_game()
    {
        GameObject.Find("Head").GetComponent<Win_trig>().Save_result();
        //SceneManager.LoadScene(0); 
    }
    private void Awake()
    {
        menu = GameObject.Find("Menu");
        if (!PlayerPrefs.HasKey("LVL"))
        {
            PlayerPrefs.SetInt("LVL", 1);
        }
        if (Application.loadedLevel != 0)
        {
            if (!PlayerPrefs.HasKey("Car")) { Instantiate(Prefub_cars[0], new Vector3(0, 2, 0), Quaternion.identity, GameObject.Find("car").transform); target = GameObject.FindWithTag("Player").gameObject.transform; }
            else { Instantiate(Prefub_cars[PlayerPrefs.GetInt("Car")], new Vector3(0, 2, 0), Quaternion.identity, GameObject.Find("car").transform); target = GameObject.FindWithTag("Player").gameObject.transform; }
            dum = GameObject.Find("Particle_Dum").gameObject;
        }
        rigidBody2D = target.GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        if (Application.loadedLevel == 0)
        {
            for (int i = 0; i < 14; i++) { GameObject.Find("Car").transform.GetChild(i).gameObject.SetActive(false); }
            GameObject.Find("Car").transform.GetChild(PlayerPrefs.GetInt("Car")).gameObject.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().target = GameObject.Find("Car").transform.GetChild(PlayerPrefs.GetInt("Car")).gameObject.transform;
        }
    }
    public void SetUISpeed()
    {
        if (UIManager.instance.vechicleSpeed != null)
        {
            UIManager.instance.vechicleSpeed.text = String.Format("{0:0#}", rigidBody2D.velocity.magnitude * 5);
        }
    }
    void Start()
    {
        if (Application.loadedLevel > 0) { dist = GameObject.Find("Distanc_map").GetComponent<TextMeshProUGUI>(); }
        _camera = Camera.main.transform;
        sizeX = Layer_Objects[0].transform.localScale.x;
        boundSizeX = Layer_Objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for (int i = 0; i < 5; i++)
        {
            startPos[i] = _camera.position.x;
        }
        if (Application.loadedLevel != 126 && Application.loadedLevel != 0) { Car_icon.parent.gameObject.SetActive(false); }

    }

    void Update()
    {

        SetUISpeed();
        if (Application.loadedLevel > 0)
        {
            Strilka[0].transform.rotation = Quaternion.EulerAngles(0, 0, (-1 * rigidBody2D.velocity.magnitude / 10) + i);

            j = 1.5f - (System.Math.Abs(target.Find("Wheel").GetComponent<WheelJoint2D>().jointSpeed / 200));
            if (j <= -1.5f) { j = -1.5f; Strilka[1].transform.rotation = Quaternion.EulerAngles(0, 0, -1.6f); }
            else { Strilka[1].transform.rotation = Quaternion.EulerAngles(0, 0, j); }
            GetComponent<AudioSource>().volume = (-1 * j + 1.5f) / 3 + 0.4f;
            GetComponent<AudioSource>().pitch = (-1 * j + 1.5f) / 15 + 0.8f;
            dum.GetComponent<ParticleSystem>().startSpeed = 1 + GetComponent<AudioSource>().volume * 3;
            if (Application.loadedLevel == 126) { Car_icon.localPosition = new Vector3(0.15f * target.position.x - 140, Car_icon.localPosition.y, Car_icon.localPosition.z); }
            dist.text = String.Format("{0:0#}", target.position.x);
        }
        
            if (IronSource.Agent.isRewardedVideoAvailable())
            {
                Button_ads.SetActive(true);
            }
            else
            {
                Button_ads.SetActive(false);
            }
        if (Application.loadedLevel >= 1 && Application.loadedLevel < 126)
        {
            Button_ads.SetActive(false);
        }

            TrackTarget();
        if (Camera_Move)
        {
            _camera.position += Vector3.right * Time.deltaTime * Camera_MoveSpeed;
        }
        for (int i = 0; i < 5; i++)
        {
            float temp = ((_camera.position.x) * (1 - Layer_Speed[i]));
            float distance = _camera.position.x * Layer_Speed[i];
            Layer_Objects[i].transform.position = new Vector2(startPos[i] + distance, Layer_Objects[i].transform.position.y);
            if (temp + 7 > startPos[i] + boundSizeX * sizeX)
            {
                startPos[i] += boundSizeX * sizeX;
            }
            else if (temp - 7 < startPos[i] - boundSizeX * sizeX)
            {
                startPos[i] -= boundSizeX * sizeX;
            }

        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Application.loadedLevel == 0)
            {

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (GameObject.Find("Menu") == true)
                    {
                        Exit_trigger.SetActive(true);
                    }
                    if (GameObject.Find("Garage") == true)
                    {
                        GameObject.Find("Garage").SetActive(false);
                        menu.SetActive(true);
                        Exit_trigger.SetActive(true);
                    }
                    if (GameObject.Find("Maps") == true)
                    {
                        GameObject.Find("Maps").SetActive(false);
                        menu.SetActive(true);
                        Exit_trigger.SetActive(true);
                    }
                    if (GameObject.Find("Levels") == true)
                    {
                        GameObject.Find("Levels").SetActive(false);
                        menu.SetActive(true);
                        Exit_trigger.SetActive(true);
                    }
                }



            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Exit_trigger.SetActive(true);
                }
            }

        }

    }

    void TrackTarget()
    {
        if (target == null)
        {
            return;
        }

        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        targetX = transform.position.x;
        targetY = transform.position.y;

        if (followX)
        {
            // ... the target x coordinate should be a Lerp between the camera's current x position and the target's current x position.
            targetX = Mathf.Lerp(transform.position.x, target.position.x - xMargin, xSmooth * Time.deltaTime);
        }

        if (followY)
        {
            // ... the target y coordinate should be a Lerp between the camera's current y position and the target's current y position.
            targetY = Mathf.Lerp(transform.position.y, target.position.y - yMargin, ySmooth * Time.deltaTime);
        }

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
