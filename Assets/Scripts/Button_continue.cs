using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button_continue : MonoBehaviour
{

    public void MuchMoney()
    {
        if (PlayerPrefs.GetInt("Money") <Mathf.Abs(System.Convert.ToInt32(gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text)))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


}
