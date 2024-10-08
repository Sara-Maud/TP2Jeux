using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PowerUp;

public class PlayerController : MonoBehaviour
{
    private float speed = 100f;
    private Rigidbody playerRb;
    private bool hasPowerUpForce;
    private float powerUpForce = 15f;
    public GameObject focalPoint;
    public GameObject player;
    private float ameliorationTaille = 1.5f;
    private float aparenceTaille = 0.2f;
    private float color = 0f;
    private float metalique = 0f;
    private float smootehness = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);

    }


    public void EnablePowerUp(PowerUpType typePowerUp)
    {
        var renderer = GetComponent<MeshRenderer>();
        var mat = renderer.material;
        if(typePowerUp == PowerUpType.taille)
        {
            player.transform.localScale += new Vector3(ameliorationTaille - 1, ameliorationTaille - 1, ameliorationTaille - 1);
            playerRb.mass *= ameliorationTaille;
            speed *= ameliorationTaille;
            color += aparenceTaille;
            metalique += aparenceTaille;
            smootehness += aparenceTaille;
            mat.SetFloat("_color", color);
            mat.SetFloat("_metalique", metalique);
            mat.SetFloat("_smootehness", smootehness);
        }
        else if(typePowerUp == PowerUpType.force)
        {
            hasPowerUpForce = true;
            mat.SetFloat("_opaciteForce",10);
            StartCoroutine(PowerUpForceCountDown());
        }
    }
    IEnumerator PowerUpForceCountDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUpForce = false;

        var renderer = GetComponent<MeshRenderer>();
        var mat = renderer.material;
        mat.SetFloat("_opaciteForce", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Mechant") && hasPowerUpForce)
        {
            Rigidbody enemiRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 eloigneDuJoueur = (collision.gameObject.transform.position - transform.position);

            enemiRigidbody.AddForce(eloigneDuJoueur * powerUpForce, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Mechant"))
        { 
            var renderer = GetComponent<MeshRenderer>();
            var mat = renderer.material;
            mat.SetFloat("_opacite", 1);
            StartCoroutine(HitCounDown());
        }
    }
    IEnumerator HitCounDown()
    {
        yield return new WaitForSeconds(1);
        var renderer = GetComponent<MeshRenderer>();
        var mat = renderer.material;
        mat.SetFloat("_opacite", 0);
    }
}
