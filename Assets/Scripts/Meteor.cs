using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Player") 
        {
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            for (int i = 0; i < 8; i++) 
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
                if (i != 0) { gameObject.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,2), Random.Range(-1, 2)) * 15, ForceMode2D.Impulse); }
                
            }
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            StartCoroutine(Dest());
        }
    }
    IEnumerator Dest() 
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
