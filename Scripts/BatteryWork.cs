using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryWork : MonoBehaviour
{
    private Animator batteryAnimator;
    private bool isDestroyed = false;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        batteryAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Fireball(Clone)" && !isDestroyed)
        {
            batteryAnimator.SetBool("BatteryDestroyed", true);
            isDestroyed = true;
            Boss.GetComponent<BossFight>().activeBatteries--;
        }
    }
}
