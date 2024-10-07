using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject ennemiMechant;
    private float rangeSpawn = 9;
    int ennemisRestant;
    int niveauDeVague = 2;
    public GameObject[] powerUpListe;
    private bool isGameOver;
    float amelioration = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        ennemisRestant = 0;
        SpawnVagueEnnemi(niveauDeVague);
    }


    private Vector3 GetRandomPosition()
    {
        Vector2 spawnPos = Random.insideUnitCircle * 5;
        return new Vector3(spawnPos.x, 0, spawnPos.y);
    }

    private void SpawnVagueEnnemi(int nombreEnnemie)
    {
        if (!isGameOver)
        {

        
        amelioration += 0.2f;
        for (int i = 0; i < nombreEnnemie; i++)
        {
            ennemisRestant++;
            var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
            ennemi.GetComponent<EnemyController>().InitializeEnemy(amelioration);
        }
        //Spawn Power Up
        SpawnPowerUp();
        } else if(isGameOver)
        {
            for (int i = 0; i < 300; i++)
            {
                var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
                ennemi.GetComponent<EnemyController>().InitializeEnemy(amelioration);
                SpawnPowerUp();
            }


        }
    }

    private void SpawnPowerUp()
    {
        
        int nombrePowerUpSpawn = Random.Range(1, 3);
        int index = Random.Range(0, powerUpListe.Length);
        GameObject powerUp = powerUpListe[index];
        for (int i = 0;i < nombrePowerUpSpawn;i++)
            Instantiate(powerUp, GetRandomPosition(),
                powerUp.transform.rotation);
    }

    internal void GameOver()
    {
        isGameOver = true;
    }




    internal void EnemyOutOfBound()
    {
        ennemisRestant--;
        if(ennemisRestant == 0)
        {
            //Spawn Ennemies
            SpawnVagueEnnemi(niveauDeVague);
            niveauDeVague++;
        }
    }
}
