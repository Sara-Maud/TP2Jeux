using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.1f;
    private Rigidbody enemyRb;
    private GameObject player;

    private void Start()
    {
        InitializeEnemy();
    }


    // Start is called before the first frame update
    public void InitializeEnemy()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionCamera = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(directionCamera * speed);

        //Détruit ennemie si tomber de l'ile
        if(transform.position.y < -15) 
            Destroy(gameObject);
    }
}
