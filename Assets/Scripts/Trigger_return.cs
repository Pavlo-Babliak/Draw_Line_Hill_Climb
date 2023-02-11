using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_return : MonoBehaviour
{
    public bool collision_;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.name == "Line" || collision.tag == "Stone" || collision.tag == "Finish")
        {
            collision_ = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.name == "Line" || collision.tag == "Stone" || collision.tag == "Finish")
        {
            collision_ = false;
        }
    }

}
