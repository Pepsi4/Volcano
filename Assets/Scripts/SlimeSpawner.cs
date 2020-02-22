using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : Spawner
{
    public GameObject Slime;
    public int SpawningCount { get; set; }
    public bool IsActive { get; set; } = true;
    public float DeltaTime { get; set; } = 5f;

    private void Start()
    {
        StartSpawningSlimesPermanently();
    }

    public void SetEmenies(List<bool> IsSpawning)
    {
        for (int i = 0; i < IsSpawning.Count; i++)
        {
            if (IsSpawning[i] == true)
            {
                AreObjectsCouldSpawn[i] = true;
            }
            else
            {
                AreObjectsCouldSpawn[i] = false;
            }
        }
    }


    public void StartSpawningSlimesPermanently()
    {
        StartCoroutine(SpawnSlimesPermanently());
    }

    IEnumerator SpawnSlimesPermanently()
    {
        StartCoroutine(SpawnSlimes(1));
        yield return new WaitForSeconds(DeltaTime);
        StartSpawningSlimesPermanently();
    }

    //ienumerator spawnobjects()
    //{
    //    for (int i = 0; i < objectstospawn.count; i++)
    //    {
    //        //if (areobjectscouldspawn[i])
    //        //{
    //        instantiate(objectstospawn[i], spawnpositions[0]);
    //        //debug.log("spawn slime by time");
    //        yield return new waitforseconds(deltatime);
    //        startspawningobjects();
    //        //}
    //    }
    //}


    bool isFirstWaveOver = false;
    //public void StartSpawningEnemies()
    //{
    //    if (isFirstWaveOver == false)
    //    {
    //        StartCoroutine(SpawnSlimes(WaveCurrent.EnemiesInWave_1));
    //    }
    //    else
    //    {
    //        StartCoroutine(SpawnSlimes(WaveCurrent.EnemiesInWave_2));
    //    }
    //}




    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawnEnimes(SpawningCount));
    }

    IEnumerator SpawnEnimes(int count)
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);
        //    yield return new WaitForSeconds(3);
        //}

        //spawnedCount++;

        for (int i = 0; i < count; i++)
        {
            if (i % 5 == 0 && i != 0)
            {
                StartCoroutine(SpawnSlimesMiddle());
                yield return new WaitForSeconds(DeltaTime / 5);
                //StartCoroutine(SpawnEnimes(count));
            }
            else
            {
                StartCoroutine(SpawnSlimes(1));
                yield return new WaitForSeconds(DeltaTime / 5);
                // StartCoroutine(SpawnEnimes(count));
            }
        }

    }

    IEnumerator SpawnSlimes(int count)
    {
        //for (int y = 0; y < ObjectsToSpawn.Co unt; y++)
        //{
        float rndDeltaTime = Random.Range(0.3f, 1.2f);
        for (int i = count; i > 0; i--)
        {
            //Debug.Log("spawn slime on Wave!");
            Instantiate(ObjectsToSpawn[0], SpawnPositions[0]);
            yield return new WaitForSeconds(rndDeltaTime);
        }
        //}


        //isFirstWaveOver = true;
    }

    IEnumerator SpawnSlimesMiddle()
    {
        Instantiate(ObjectsToSpawn[1], SpawnPositions[0]);
        yield return null;
    }
}
