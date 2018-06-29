using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private Animator Anim;
    private Transform newTarget;
    public int swordDamage;
    private bool isAttacking = false;
    private bool isBlocking = false;
    private Vector3 oldVector;

    private void Start()
    {
        Anim = GetComponentInParent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            Anim.SetBool("Attack", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            Anim.SetBool("Attack", false);

        }

        if (Input.GetMouseButtonDown(1))
        {
            isBlocking = true;
            Anim.SetBool("Block", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            isBlocking = true;
            Anim.SetBool("Block", false);
            Anim.SetBool("Reflect", false);

        }
    }

    void OnCollisionStay(Collision collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.tag == "Enemy" && isAttacking == true)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                EnemyHealth enemyhealth = contact.otherCollider.GetComponent<EnemyHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(swordDamage, contact.point);
                }

            }
        }
    }
}