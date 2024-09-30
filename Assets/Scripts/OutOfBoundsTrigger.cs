using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    private LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mechant"))
        {
            //Détruit ennemie si tomber de l'ile
            Destroy(other.gameObject);

            levelController.EnemyOutOfBound();
        }
        else if(other.CompareTag("Player"))
        {
            levelController.GameOver();
        }
    }
   
    

}
