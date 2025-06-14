using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 3;
    public int currentHealth;
    private float immunity = 1.0f;
    private bool immune = false;
    public bool healthReady = false;
    public GameObject health;
    private Animator healthbarAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (healthReady)
        {
            health = GameObject.Find("PlayerHealth");
            healthbarAnimator = health.GetComponent<Animator>();
            healthReady = false;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attacks" && !immune)
        {
            immune = true;
            currentHealth--;
            StartCoroutine(HitCooldown());
            healthbarAnimator.SetInteger("Health", currentHealth);

            if (currentHealth <= 0)
            {
                // Add death here
            }
        }

        if (other.name == "Fireball(Clone)")
        {
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(immunity);
        immune = false;
    }
}
