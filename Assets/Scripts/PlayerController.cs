using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 8f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    private bool hasPowerUpForce;
    private bool hasPowerUpTaille;
    private float powerUpForce = 15f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }


    public void EnablePowerUp(string typePowerUp)
    {
        if(typePowerUp == "PowerUpTaille")
        {
            hasPowerUpTaille = true;
            StartCoroutine(PowerUpTailleCountDown());
        }
        else if(typePowerUp == "PowerUpForce")
        {
            hasPowerUpForce = true;
            StartCoroutine(PowerUpForceCountDown());
        }
    }
    IEnumerator PowerUpForceCountDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUpForce = false;
    }
    IEnumerator PowerUpTailleCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUpTaille = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mechant") && hasPowerUpForce)
        {
            Rigidbody enemiRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 eloigneDuJoueur = (collision.gameObject.transform.position - transform.position);

            enemiRigidbody.AddForce(eloigneDuJoueur * powerUpForce, ForceMode.Impulse);
        }
    }
}
