using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * PlayerController.cs
 * Assignment 8
 * This controls the player.
 */

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float horizontalInput;
    public float moveSpeed = 15;
    public float xRange = 10;
    RedBullet redBullet;
    BlueBullet blueBullet;

    // Start is called before the first frame update
    void Start()
    {
        redBullet = gameObject.AddComponent<RedBullet>();
        blueBullet = gameObject.AddComponent<BlueBullet>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            redBullet.isRed = true;
            blueBullet.isRed = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            redBullet.isRed = false;
            blueBullet.isRed = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }
    
    void Shoot()
    {
        if(redBullet.isRed == true && blueBullet.isRed == false)
        {
            Instantiate(bulletPrefab.transform, firePoint.transform.position, firePoint.transform.rotation);
        }
        else if (redBullet.isRed == false && blueBullet.isRed == true)
        {
            Instantiate(bulletPrefab2.transform, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
