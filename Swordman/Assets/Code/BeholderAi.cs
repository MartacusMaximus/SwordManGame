using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderAi : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float damping;
    public float attackSpeed;
    public GameObject projectileLaser;
    public Transform fpsTarget;
    public Transform laserSpawn;
    private float timer;
    Rigidbody theRigidbody;
    public float speed;


    // Use this for initialization
    void Start ()
    {
        theRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            lookAtPlayer();
        }
        if (fpsTargetDistance < attackDistance)
        {
            laserTime();
            lookAtPlayer();
            attackAggro();
        }
        
    }
    void attackAggro()
    {
        theRigidbody.AddForce(transform.forward * speed);
    }
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
    public void laserTime()
    {
        timer += Time.deltaTime;

        if (timer >= attackSpeed)
        {
            GameObject laser = Instantiate(projectileLaser, laserSpawn.position, laserSpawn.rotation);
            Destroy(laser, 4f);
            timer = 0f;
        }
    }

}
