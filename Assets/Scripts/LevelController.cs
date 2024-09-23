using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject ennemiMechant;
    private float rangeSpawn = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemy();
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
        
    }

    private void SpawnEnnemy()
    {
       var ennemi = Instantiate(ennemiMechant, GetRandomPosition(), ennemiMechant.transform.rotation);
        ennemi.GetComponent<EnemyController>().InitializeEnemy();
    }
}
