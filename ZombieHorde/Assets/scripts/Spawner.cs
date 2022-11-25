using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextSpawnTime;

    public GameObject Prefab;
    public float spawnDelay = 10;





    public int Spawned;

    private void Update()
    {
        if ((ShouldSpawn()) && (Spawned<=30))
        {
            Spawn();
        }


    }
    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(Prefab, transform.position, transform.rotation);
        Spawned++;
    }
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
