using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI name_skin;
    private void Start()
    {
        name_skin.text = "Ben";
    }
    public void select() 
    {
        gameObject.transform.GetChild(6).GetComponent<Buy_Skin>().Select_buy_car();
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 0) 
        {
            name_skin.text = "Ben";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 1)
        {
            name_skin.text = "Harley Quinn";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 2)
        {
            name_skin.text = "Flash";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 3)
        {
            name_skin.text = "Batman";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 4)
        {
            name_skin.text = "Spider-Man";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 5)
        {
            name_skin.text = "Iron Man";
        }
        if (System.Convert.ToInt32(gameObject.transform.GetChild(6).gameObject.name) == 6)
        {
            name_skin.text = "Green Arrow";
        }
    }
}
