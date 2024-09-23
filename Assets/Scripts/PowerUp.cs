using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject[] listePowerUp;

    public PlayerController playerController;


    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            Destroy(this.gameObject);
            //Appel fonction dans playercontroller pour lancer le powerup
            playerController.EnablePowerUp();
        }
    }
}
