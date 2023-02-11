using UnityEngine;
using UnityEngine.UI;



[DisallowMultipleComponent]
public class LineFactory : MonoBehaviour
{
    public GameObject linePrefab;
    [HideInInspector]
    public Line currentLine;
    public Transform lineParent;
    public RigidbodyType2D lineRigidBodyType = RigidbodyType2D.Kinematic;
    public LineEnableMode lineEnableMode = LineEnableMode.ON_CREATE;
    public static LineFactory instance;
    public Image lineLife;
    public bool enableLineLife;
    public bool isRunning;
    public GameObject[] lines = new GameObject[20];
    public int count_lines = -1;
    bool act = true;
    GameObject Player;
    public GameObject Pen;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start_Gravity()
    {

        Player.GetComponent<Rigidbody2D>().simulated = true;
        Player.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = true;
        Player.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = true;
    }
    public void Stop_Gravity()
    {
        Player.GetComponent<Rigidbody2D>().simulated = false;
        Player.transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
        Player.transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
    }
    public void Run_down()
    {
        Player.GetComponent<Move_button>().Run();
    }
    public void Forward_down()
    {
        Player.GetComponent<Move_button>().Forward();
    }
    public void Run_up()
    {
        Player.GetComponent<Move_button>().Stop();
    }
    public void Static_Line()
    {
        lineRigidBodyType = RigidbodyType2D.Kinematic;
    }
    public void Dinamic_Line()
    {
        lineRigidBodyType = RigidbodyType2D.Dynamic;
    }
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player").gameObject;
        if (lineParent == null)
        {
            lineParent = GameObject.Find("Lines").transform;
        }

        if (lineLife != null)
        {
            if (enableLineLife)
            {
                lineLife.gameObject.SetActive(true);
            }
            else
            {
                lineLife.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            CreateNewLine();
            Pen.SetActive(true);
            if (PlayerPrefs.GetInt("Educ_first_line") == 1) 
            {
                GameObject.Find("Educ_First_line").gameObject.SetActive(false);
                PlayerPrefs.SetInt("Educ_first_line", 0);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            RelaseCurrentLine();
            Pen.SetActive(false);
        }
        if (currentLine != null)
        {
            currentLine.AddPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            UpdateLineLife();
            if (currentLine.ReachedPointsLimit())
            {
                RelaseCurrentLine();
            }
        }

    }

    private void CreateNewLine()
    {
        if (act == true)
        {
            if (count_lines < 9) { count_lines++; }
            else { count_lines = 0; }
            currentLine = (Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<Line>();
            if (lines[count_lines] != null) { Destroy(lines[count_lines].gameObject); }
            lines[count_lines] = currentLine.gameObject;
            currentLine.name = "Line";
            currentLine.transform.SetParent(lineParent);
            currentLine.SetRigidBodyType(lineRigidBodyType);
            currentLine.GetComponent<LineRenderer>().numCornerVertices = 0;
            lineLife.gameObject.transform.parent.gameObject.SetActive(true);
            
            if (lineEnableMode == LineEnableMode.ON_CREATE)
            {
                EnableLine();
            }
        }

    }
    public void Return()
    {
        act = false;
        if (lines[count_lines] != null)
        {
            Destroy(lines[count_lines].gameObject);
            if (count_lines > 0)
            {
                count_lines--;
            }
            else { count_lines = 9; }
        }

    }
    public void Ret_false() { act = true; }
    private void EnableLine()
    {

        if (currentLine)
        {
            currentLine.EnableCollider();
            currentLine.SimulateRigidBody();
            lineLife.gameObject.transform.parent.gameObject.SetActive(false);
            Pen.SetActive(false);
        }

    }

    private void RelaseCurrentLine()
    {

        if (lineEnableMode == LineEnableMode.ON_RELASE)
        {
            EnableLine();
        }
        currentLine = null;

    }

    private void UpdateLineLife()
    {
        if (!enableLineLife)
        {
            return;
        }

        if (lineLife == null)
        {
            return;
        }

        lineLife.fillAmount = 1 - (currentLine.points.Count / currentLine.maxPoints);
        Pen.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    public enum LineEnableMode
    {
        ON_CREATE,
        ON_RELASE
    }

    ;
}
