using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject ennemiMechant;
    private float rangeSpawn = 9;
    int ennemisRestant;
    int niveauDeVague = 2;
    public GameObject powerUpGameObject;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpGameObject, GetRandomPosition(),
            powerUpGameObject.transform.rotation);
        ennemisRestant = 0;
    }


    private Vector3 GetRandomPosition()
    {
        float spawnPosX = Random.Range(-rangeSpawn, rangeSpawn);
        float spawnPosZ = Random.Range(-rangeSpawn, rangeSpawn);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemisRestant == 0)
        {
            ennemisRestant = niveauDeVague;
            //Spawn Ennemies
            SpawnVagueEnnemi(niveauDeVague);
            niveauDeVague++;
            //Spawn Power Up
            Instantiate(powerUpGameObject, GetRandomPosition(), 
                powerUpGameObject.transform.rotation);
        }
    }



    private void SpawnVagueEnnemi(int nombreEnnemie)
    {
        //Changer l'apparance des ennemies ici
        for (int i = 0; i < nombreEnnemie; i++)
        {
            var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
            ennemi.GetComponent<EnemyController>().InitializeEnemy();
        }
    }

    internal void GameOver()
    {
        isGameOver = true;
    }

    internal void EnemyOutOfBound()
    {
        ennemisRestant--;
    }
}
