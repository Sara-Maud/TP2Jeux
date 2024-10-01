using System.Collections;
using System.Collections.Generic;
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
        float spawnPosX = Random.Range(-rangeSpawn, rangeSpawn);
        float spawnPosZ = Random.Range(-rangeSpawn, rangeSpawn);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void SpawnVagueEnnemi(int nombreEnnemie)
    {
        amelioration += 0.2f;
        //Changer l'apparance des ennemies ici
        for (int i = 0; i < nombreEnnemie; i++)
        {
            ennemisRestant++;
            var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
            ennemi.GetComponent<EnemyController>().InitializeEnemy(amelioration);
        }
        //Spawn Power Up
        SpawnPowerUp();
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
