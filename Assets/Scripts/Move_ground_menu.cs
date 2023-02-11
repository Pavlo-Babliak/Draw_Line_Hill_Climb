using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ground_menu : MonoBehaviour
{
    public GameObject Next_ground;
    public GameObject Next_trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Next_ground.transform.position = new Vector3(Next_ground.transform.position.x + 241, Next_ground.transform.position.y, Next_ground.transform.position.z);
            gameObject.SetActive(false);
            Next_trigger.SetActive(true);
        }
    }
}
