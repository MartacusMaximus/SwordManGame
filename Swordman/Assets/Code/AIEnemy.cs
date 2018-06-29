using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public Transform fpsTarget;
    Rigidbody theRigidbody;
    Renderer myRender;



	// Use this for initialization
	void Start () {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            myRender.material.color = Color.cyan;
            lookAtPlayer();
        }
        if (fpsTargetDistance < attackDistance)
        {
            myRender.material.color = Color.red;
            attackAggro();
            lookAtPlayer();
        }
        if (enemyLookDistance < fpsTargetDistance)
        {
            myRender.material.color = Color.magenta;
        }

	}

    void lookAtPlayer()
    {
        transform.LookAt(fpsTarget);
    }
    void attackAggro()
    {
        theRigidbody.AddForce(transform.forward * enemyMovementSpeed);
    }
    private void OnCollisionStay(Collision collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.tag == "Player")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                PlayerHealth enemyhealth = contact.otherCollider.GetComponent<PlayerHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(8);

                }
            }
        }

    }
}
