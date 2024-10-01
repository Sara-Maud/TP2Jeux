using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.3f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    public void InitializeEnemy(float amelioration)
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //Augmente la masse du l'ennemie à chaque vague
        enemyRb.mass *= amelioration;
        speed *= amelioration + 0.1f;

        //Change l'apparance de l'ennemie
        var renderer = GetComponent<MeshRenderer>();
        var mat = renderer.material;
        mat.SetFloat("_difficulter", amelioration);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionCamera = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(directionCamera * speed);

        
    }
}
