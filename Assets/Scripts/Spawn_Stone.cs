using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Stone : MonoBehaviour
{
    public int Count_Stone;
    public GameObject[] Stone = new GameObject[6];
    void Start()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<BackgroundControl_0>().backgroundNum == 2) 
        {
            StartCoroutine(Spawn());
        }
       
    }
    IEnumerator Spawn() 
    { 
        for (int i = 0; i < Count_Stone; i++) 
        {
            gameObject.transform.position = new Vector3(Random.Range(50, 1800), gameObject.transform.position.y, gameObject.transform.position.z);
            float k = Random.Range(0.55f, 1.5f);
            for (int j = 0; j < 5; j++) 
            {
                Stone[j].transform.localScale = new Vector3(k, k, 1);
            }
            Instantiate(Stone[Random.Range(0, 6)], gameObject.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.01f);
    }
}
