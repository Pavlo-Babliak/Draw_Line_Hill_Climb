using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_anim : MonoBehaviour
{
    public void Stop_Anim() 
    {
        GetComponent<Animator>().enabled = false;
    }
}
