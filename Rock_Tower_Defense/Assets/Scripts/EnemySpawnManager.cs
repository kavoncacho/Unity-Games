using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject _zombiePrefab;
 public GameObject[] WallTarget;
 private GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
       if (spawnPoints == null)
       {
           spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
       }
       InvokeRepeating("waveSpawn",5f,10f);
       InvokeRepeating("waveSpawn15",15f,15f);
       WallTarget = GameObject.FindGameObjectsWithTag("Wall");
       populateSpawners(spawnPoints);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    private void populateSpawners(GameObject[] spawners)
    {
        
        foreach(GameObject spawney in spawners)
        {
            GameObject zombie = Instantiate(_zombiePrefab,spawney.transform.position,Quaternion.identity);
            //zombie.transform.localScale = new Vector3(5,5);
        }
    }
    private void waveSpawn()
    {
       foreach(GameObject spawney in spawnPoints)
        {
            GameObject zombie = Instantiate(_zombiePrefab,spawney.transform.position,Quaternion.identity);
            //zombie.transform.localScale = new Vector3(5,5);
        } 
    }
    private void waveSpawn15()
    {
       foreach(GameObject spawney in spawnPoints)
        {
            GameObject zombie = Instantiate(_zombiePrefab,spawney.transform.position,Quaternion.identity);
            //zombie.transform.localScale = new Vector3(7,7);
        } 
    }


}
