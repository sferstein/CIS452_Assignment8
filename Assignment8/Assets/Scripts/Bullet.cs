using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * Bullet.cs
 * Assignment 8
 * This is the abstract class that will have the hook to change the Template Pattern.
 */

public abstract class Bullet : MonoBehaviour
{
    public float speed;
    private float maxDistance = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    public virtual bool IsRed()
    {
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
    }
}
