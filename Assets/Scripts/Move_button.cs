using UnityEngine;

public class Move_button : MonoBehaviour
{
    private GameObject[] Wheel = new GameObject[2];
    public int Speed_Koeficient;
    public int Speed_Start;
    public int Torgle;
    JointMotor2D motor1;
    JointSuspension2D susp1;
    public  Vector2 ChekPoint;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().centerOfMass =new Vector2(gameObject.transform.GetChild(2).gameObject.transform.position.x, gameObject.transform.GetChild(2).gameObject.transform.position.y);
        Wheel[0] = GameObject.FindGameObjectWithTag("Wheel1");
        Wheel[1] = GameObject.FindGameObjectWithTag("Wheel2");
        Wheel[0].transform.parent.GetComponent<Rigidbody2D>().mass = Wheel[0].transform.parent.GetComponent<Rigidbody2D>().mass - ((Wheel[0].GetComponent<Rigidbody2D>().mass * PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) -  (Wheel[1].GetComponent<Rigidbody2D>().mass * PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20));
        Wheel[0].GetComponent<Rigidbody2D>().mass = (Wheel[0].GetComponent<Rigidbody2D>().mass * PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20)+ Wheel[0].GetComponent<Rigidbody2D>().mass;
        Wheel[0].GetComponent<Rigidbody2D>().mass = (Wheel[1].GetComponent<Rigidbody2D>().mass * PlayerPrefs.GetInt("Apgrade_Count_Pidviska_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) + Wheel[1].GetComponent<Rigidbody2D>().mass;
        susp1.dampingRatio = 0.8f;
        susp1.frequency = (Wheel[0].GetComponent<WheelJoint2D>().suspension.frequency * PlayerPrefs.GetInt("Apgrade_Count_Wheel_" + gameObject.name.Substring(0, gameObject.name.IndexOf('(')))/20)+ Wheel[0].GetComponent<WheelJoint2D>().suspension.frequency;
        Wheel[0].GetComponent<WheelJoint2D>().suspension = susp1;
        Wheel[1].GetComponent<WheelJoint2D>().suspension = susp1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chekpoint")
        {
            ChekPoint = collision.transform.position;
        }
        if (collision.name == "Trigger_educ_first_line")
        {
            if (!PlayerPrefs.HasKey("Educ_first_line"))
            {
                GameObject.Find("Educ_First_line").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Educ_First_line").transform.GetChild(1).gameObject.SetActive(true);
                PlayerPrefs.SetInt("Educ_first_line", 1);
            }
        }

    }
    public void Run()
    {
        if (!PlayerPrefs.HasKey("Education")) { GameObject.Find("Education").SetActive(false); PlayerPrefs.SetInt("Education", 1); }
        motor1.motorSpeed = (Speed_Start * PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) + Speed_Start * Speed_Koeficient;
        motor1.maxMotorTorque = (Torgle * PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) + Torgle ;
        Wheel[1].GetComponent<WheelJoint2D>().useMotor = true;
        Wheel[1].GetComponent<WheelJoint2D>().motor = motor1;
        Wheel[0].GetComponent<WheelJoint2D>().useMotor = true;
        Wheel[0].GetComponent<WheelJoint2D>().motor = motor1;
    }
    public void Forward()
    {
        motor1.motorSpeed = ((-Speed_Start * PlayerPrefs.GetInt("Apgrade_Count_KPP_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) - Speed_Start * Speed_Koeficient)/2;
        motor1.maxMotorTorque = (Torgle * PlayerPrefs.GetInt("Apgrade_Count_Motor_" + gameObject.name.Substring(0, gameObject.name.IndexOf('('))) / 20) + Torgle;
        Wheel[1].GetComponent<WheelJoint2D>().useMotor = true;
        Wheel[1].GetComponent<WheelJoint2D>().motor = motor1;
        Wheel[0].GetComponent<WheelJoint2D>().useMotor = true;
        Wheel[0].GetComponent<WheelJoint2D>().motor = motor1;
    }
    public void Stop()
    {
        Wheel[1].GetComponent<WheelJoint2D>().useMotor = false;
        Wheel[0].GetComponent<WheelJoint2D>().useMotor = false;
    }
    public void Reset_pos()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        transform.rotation = Quaternion.identity;
    }
}
