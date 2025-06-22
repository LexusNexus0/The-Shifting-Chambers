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
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbarAnimator = health.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position;
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
                player.gameObject.GetComponent<PlayerMovement>().moveLocked = true;
                currentHealth = 3;
                GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().inGame = false;
                SceneManager.LoadScene(sceneName: "DeathScreen");
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
