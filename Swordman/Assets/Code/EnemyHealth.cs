using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth;
    private int currentHealth;
    public float sinkSpeed;
    public AudioClip deathClip;
    public GameObject bloodPrefab;
    public float bufferTime;
    public float OGbufferTime;

    Animator anim;
    AudioSource enemyAudio;
    bool isDead;
    bool isSinking;

    private void Awake()
    {
        currentHealth = startingHealth;
        bufferTime = OGbufferTime;
    }

    // Use this for initialization
    void Start ()
    {

        currentHealth = startingHealth;
   
	}
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        if (bufferTime == 0)
        {
            currentHealth -= amount;

            bufferTime = 1;

            bufferTime = OGbufferTime;

            bloodPrefab.transform.position = hitPoint;

            GameObject bloodDrop = (GameObject)Instantiate(bloodPrefab, hitPoint, Quaternion.Euler(0, 0, 0));

            Destroy(bloodDrop, 3.0f);

            Rigidbody rigidbody = (Rigidbody)bloodDrop.GetComponent(typeof(Rigidbody));

            rigidbody.AddExplosionForce(10, transform.position, 20);

        }

        bufferTime -= 10 * Time.deltaTime;

        if (bufferTime <= 0.1f)
        {
            bufferTime = 0;
        }

        if (currentHealth <= 0)
        {
            Death();
            StartSinking();
        }
    }
    void Death()
    {
        isDead = true;
        print("I am Dead");
    }


    public void StartSinking()
    {
        isSinking = true;

        Destroy(gameObject, 2f);
    }
}
