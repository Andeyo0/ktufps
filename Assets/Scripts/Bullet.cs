using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;

    private float lifeTimer;
    Rigidbody rbBullet;
    
    void Start()
    {
        lifeTimer = lifeDuration;
        rbBullet = this.gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        rbBullet.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
        lifeTimer -= Time.fixedDeltaTime;
        
        if(lifeTimer <= 0f)
        {
            Destroy (gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
