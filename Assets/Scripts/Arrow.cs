using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 20f;
    [SerializeField] ParticleSystem hitEffect;

    Rigidbody2D myRigidBody;
    PlayerMovement playerMovement;
    float xSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * arrowSpeed;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        PlayHitEffect();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayHitEffect();
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
