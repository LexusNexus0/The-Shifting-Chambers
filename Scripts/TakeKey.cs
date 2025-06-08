using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakeKey : MonoBehaviour
{
    public TMP_Text takeText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            takeText.gameObject.SetActive(true);
            other.gameObject.GetComponent<RandomManager>().KeyGotten = true;
            this.gameObject.SetActive(false);
        }
    }
}