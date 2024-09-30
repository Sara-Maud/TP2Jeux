using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    private bool isGameOver = false;
    private int ennemisRestant = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mechant"))
        {
            ennemisRestant--;
        }
        else if(other.CompareTag("Player"))
        {
            isGameOver = true;
        }
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public int GetNombreEnnemieRestant()
    {
        return ennemisRestant;
    }
    public void SetNombreEnnemieRestant(int nombreEnnemie)
    {
        ennemisRestant = nombreEnnemie;
    }

}
