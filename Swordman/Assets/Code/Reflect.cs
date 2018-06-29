using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour {

    public float reflectSpeed;
    private float speed;

    // Use this for initialization
    void Start ()
    {
        speed = 12;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
            speed = -reflectSpeed;
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            ph.TakeDamage(14);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
              EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
              eh.TakeDamage(14, contact.point);
                eh.bufferTime = 0;
            }
        }
    }
}
