using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSign : MonoBehaviour
{
    public GameObject signText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("hmmm");
                signText.SetActive(true);
            }
        }
    }
}
