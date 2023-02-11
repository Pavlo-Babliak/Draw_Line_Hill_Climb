using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    private bool connect;
    public ParticleSystem zemlua;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") { connect = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") { connect = false; }
    }
    public void Connect_Ground() { if (connect == true) { zemlua.Play(); } }
    public void Connect_Ground_off() { zemlua.Stop(); }
}
