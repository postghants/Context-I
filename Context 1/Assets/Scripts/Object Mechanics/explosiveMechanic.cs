using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveMechanic : MechanicController
{
    public float xplDelay = 0.05f;
    public float xplRadius = 2f;
    public float xplForce = 1500f;
    public float xplDownOffset = 1f;

    private GameObject explosionEffect;

    private void Awake()
    {
        explosionEffect = Resources.Load<GameObject>("Objects/Explosion");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<characterJump>() != null)
        {
            StartCoroutine(Explode());
        }
    }

    public IEnumerator Explode()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position - Vector3.forward, Quaternion.identity);
        explosion.transform.localScale = transform.localScale;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, xplRadius * transform.localScale.x);
        yield return new WaitForSeconds(xplDelay);
        foreach(Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 force = rb.position - ((Vector2)transform.position + transform.localScale.x * xplDownOffset * Vector2.down);
                float x = 3 + Vector2.Distance(rb.position, (Vector2)transform.position); 
                force = force.normalized * Mathf.Pow(1.5f, -x);
                rb.AddForce(force * xplForce);
                Debug.Log(force * xplForce);
            }
        }
        Destroy(gameObject);
    }
}
