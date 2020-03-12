﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * BlueEnemy.cs
 * Assignment 8
 * This is one of the enemy scripts.
 */

public class BlueEnemy : MonoBehaviour
{
    private GameManager gameManager;
    private float boundary = -10;
    public float speedInit;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {
        if (transform.position.z < boundary)
        {
            Destroy(gameObject);
            if (!gameManager.isGameWon)
            {
                gameManager.gameOver();
            }
        }
        transform.Translate(Vector3.back * Time.deltaTime * speedInit);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet"))
        {
            Destroy(gameObject);
        }
    }
}
