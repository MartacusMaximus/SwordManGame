using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private float bufferTime;
    public float OGbufferTime;
    bool isDead;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        bufferTime = OGbufferTime;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }
        if (bufferTime == 0)
        {
            currentHealth -= amount;

            bufferTime = OGbufferTime;
        }

        bufferTime -= 10 * Time.deltaTime;

        if (bufferTime <= 0.1f)
        {
            print(currentHealth);
            bufferTime = 0;
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        print("I am Dead");
        Destroy(gameObject, 2f);
    }
}
