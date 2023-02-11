using System.Collections;
using UnityEngine;

public class Spawn_Meteor : MonoBehaviour
{
    public float Chastota;
    public GameObject Meteor;
    void Start()
    {
        if (GameObject.FindWithTag("MainCamera").GetComponent<BackgroundControl_0>().backgroundNum == 1)
        {
            StartCoroutine(Spawn());
        }
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        gameObject.transform.position = new Vector3(Random.Range(50, 1800), gameObject.transform.position.y, gameObject.transform.position.z);
        float k = Random.Range(0.9f, 2.5f);
        Meteor.transform.localScale = new Vector3(k, k, 1);
        Instantiate(Meteor, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Chastota);
        StartCoroutine(Spawn());
    }
}
