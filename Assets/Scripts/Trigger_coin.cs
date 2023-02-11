using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wheel1" || collision.gameObject.tag == "Wheel2")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            // GetComponent<Animator>().enabled = true;
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            GameObject.Find("Money_map").GetComponent<Money_maps>().Money_up(System.Convert.ToInt16(gameObject.name));
            StartCoroutine(Dest());
        }
        IEnumerator Dest()
        {
            yield return new WaitForSeconds(0.7f);
            Destroy(gameObject);
        }
    }
}
