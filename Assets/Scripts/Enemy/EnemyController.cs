using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myrb;
    public float moveSpeed;

    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }


    void FixedUpdate()
    {
        if (GameObject.Find("Player") != null)
            myrb.velocity = (transform.forward * moveSpeed);
            transform.LookAt(thePlayer.transform.position);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            myrb.AddForce(-90f, 0f, 0, ForceMode.VelocityChange);
        }
    }
}
