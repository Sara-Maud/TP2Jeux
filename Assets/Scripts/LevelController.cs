using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject ennemiMechant;
    private float rangeSpawn = 9;
    int ennemisRestant;
    int niveauDeVague = 2;

    // Start is called before the first frame update
    void Start()
    {
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
        ennemisRestant = FindObjectsOfType<EnemyController>().Length;
        if (ennemisRestant == 0)
        {
            SpawnVagueEnnemi(niveauDeVague);
            niveauDeVague++;
        }
    }



    private void SpawnVagueEnnemi(int nombreEnnemie)
    {
        for (int i = 0; i < nombreEnnemie; i++)
        {
            var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
            ennemi.GetComponent<EnemyController>().InitializeEnemy();
        }
    }

}
