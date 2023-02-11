using UnityEngine;
using UnityEngine.U2D;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum;
    public Sprite[] Layer_Sprites;
    private GameObject[] Layer_Object = new GameObject[5];
    private int max_backgroundNum = 3;
    public SpriteShape[] Select_ground = new SpriteShape[4];
    public GameObject[] Ground = new GameObject[4];
    public int Scin;
    private void Awake()
    {
       // PlayerPrefs.SetInt("Scin", Scin);
    }
    public void Start()
    {

        backgroundNum = PlayerPrefs.GetInt("Map");
        if (Application.loadedLevel == 0)
        {
            if (PlayerPrefs.GetInt("LVL") <= 25 || PlayerPrefs.GetInt("LVL") == 101 || PlayerPrefs.GetInt("LVL") == 106 || PlayerPrefs.GetInt("LVL") == 111 || PlayerPrefs.GetInt("LVL") == 116 || PlayerPrefs.GetInt("LVL") == 121) { backgroundNum = 0;  }
            if (PlayerPrefs.GetInt("LVL") > 25 && PlayerPrefs.GetInt("LVL") <= 50 || PlayerPrefs.GetInt("LVL") == 102 || PlayerPrefs.GetInt("LVL") == 107 || PlayerPrefs.GetInt("LVL") == 112 || PlayerPrefs.GetInt("LVL") == 117 || PlayerPrefs.GetInt("LVL") == 122) { backgroundNum = 2;  }
            if (PlayerPrefs.GetInt("LVL") > 50 && PlayerPrefs.GetInt("LVL") <= 75 || PlayerPrefs.GetInt("LVL") == 103 || PlayerPrefs.GetInt("LVL") == 108 || PlayerPrefs.GetInt("LVL") == 113 || PlayerPrefs.GetInt("LVL") == 118 || PlayerPrefs.GetInt("LVL") == 123) { backgroundNum = 1;  }
            if (PlayerPrefs.GetInt("LVL") > 75 && PlayerPrefs.GetInt("LVL") <= 100 || PlayerPrefs.GetInt("LVL") == 104 || PlayerPrefs.GetInt("LVL") == 105 || PlayerPrefs.GetInt("LVL") == 109 || PlayerPrefs.GetInt("LVL") == 110 || PlayerPrefs.GetInt("LVL") == 114 || PlayerPrefs.GetInt("LVL") == 115 || PlayerPrefs.GetInt("LVL") == 119 || PlayerPrefs.GetInt("LVL") == 120 || PlayerPrefs.GetInt("LVL") == 124 || PlayerPrefs.GetInt("LVL") == 125) { backgroundNum = 3; }
            Ground[0].GetComponent<SpriteShapeController>().spriteShape = Select_ground[backgroundNum];
            Ground[1].GetComponent<SpriteShapeController>().spriteShape = Select_ground[backgroundNum];
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
        else if(Application.loadedLevel == 126)
        {
            if (backgroundNum == 0) { Physics2D.gravity = new Vector2(0, -9.8f); }
            if (backgroundNum == 2) { Physics2D.gravity = new Vector2(0, -9.8f); }
            if (backgroundNum == 1) { Physics2D.gravity = new Vector2(0, -7.5f); }
            if (backgroundNum == 3) { Physics2D.gravity = new Vector2(0, -5.4f); }
            for (int i = 0; i <= 3; i++) 
            {
                Ground[i].SetActive(false);
            }
            Ground[backgroundNum].SetActive(true);
        }
        else if(Application.loadedLevel >= 1 && Application.loadedLevel <126) 
        {
            if (PlayerPrefs.GetInt("LVL") <= 25 || PlayerPrefs.GetInt("LVL")==101 || PlayerPrefs.GetInt("LVL") == 106 || PlayerPrefs.GetInt("LVL") == 111 || PlayerPrefs.GetInt("LVL") == 116 || PlayerPrefs.GetInt("LVL") == 121) { backgroundNum =0; Physics2D.gravity = new Vector2(0, -9.8f); }
            if (PlayerPrefs.GetInt("LVL") > 25 && PlayerPrefs.GetInt("LVL") <= 50 || PlayerPrefs.GetInt("LVL") == 102 || PlayerPrefs.GetInt("LVL") == 107 || PlayerPrefs.GetInt("LVL") == 112 || PlayerPrefs.GetInt("LVL") == 117 || PlayerPrefs.GetInt("LVL") == 122) { backgroundNum =2; Physics2D.gravity = new Vector2(0, -9.8f); }
            if (PlayerPrefs.GetInt("LVL") > 50 && PlayerPrefs.GetInt("LVL") <= 75 || PlayerPrefs.GetInt("LVL") == 103 || PlayerPrefs.GetInt("LVL") == 108 || PlayerPrefs.GetInt("LVL") == 113 || PlayerPrefs.GetInt("LVL") == 118 || PlayerPrefs.GetInt("LVL") == 123) { backgroundNum =1; Physics2D.gravity = new Vector2(0, -7.5f); }
            if (PlayerPrefs.GetInt("LVL") > 75 && PlayerPrefs.GetInt("LVL") <= 100 || PlayerPrefs.GetInt("LVL") == 104 || PlayerPrefs.GetInt("LVL") == 105 || PlayerPrefs.GetInt("LVL") == 109 || PlayerPrefs.GetInt("LVL") == 110 || PlayerPrefs.GetInt("LVL") == 114 || PlayerPrefs.GetInt("LVL") == 115 || PlayerPrefs.GetInt("LVL") == 119 || PlayerPrefs.GetInt("LVL") == 120 || PlayerPrefs.GetInt("LVL") == 124 || PlayerPrefs.GetInt("LVL") == 125) { backgroundNum =3; Physics2D.gravity = new Vector2(0, -5.4f); }
        }
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);
        }

        ChangeSprite();
    }

    void ChangeSprite()
    {
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite = Layer_Sprites[backgroundNum * 5];
        for (int i = 1; i < Layer_Object.Length; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];
            //Change Layer_1->7
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite = changeSprite;
            //Change "Layer_(*)x" sprites in children of Layer_1->7
            Layer_Object[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = changeSprite;
            Layer_Object[i].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = changeSprite;
        }
    }
}
