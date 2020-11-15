#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField]
    private ParticleController ParticleSystemController;

    [SerializeField]
    private FireController FireController;

    [SerializeField]
    private WaterController WaterController;

    [SerializeField]
    private GameObject Records;

    [SerializeField]
    private GameObject CanvasHelper;


    [SerializeField]
    private GameObject GoldenSmilePrefab;
    [SerializeField]
    private GameObject MushroomSlimePrefab;
    [SerializeField]
    private GameObject SlimePrefab;
    [SerializeField]
    private GameObject MiddleSlimePrefab;
    [SerializeField]
    private GameObject FireSlimePrefab;
    [SerializeField]
    private GameObject IceSlimePrefab;

    [SerializeField]
    private LevelController LevelController;

    public List<Transform> SpawnPositions = new List<Transform>();
    public bool IsActive { get; set; } = true;
    public float DeltaTime { get; set; } = 3.5f;

    private bool isFireSlimeHasSpawned;
    private bool isIceSlimeHasSpawned;

    public UnityEngine.Events.UnityEvent OnFireSlimeSpawned;
    public UnityEngine.Events.UnityEvent OnIceSlimeSpawned;

    private void Start()
    {
        StartCoroutine(SpawnSlimeByTime());

#if DEBUG
        DebugAddSlimesToGame();
#endif

    }



    private void ChangeChanseToLevelCorrelation(ref Buff slime, int level)
    {
        switch (slime.SlimeType)
        {
            case SlimeType.Slime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.8f;
                        break;
                    case 2:
                        slime.Chance = 0.7f;
                        break;
                    case 3:
                        slime.Chance = 0.6f;
                        break;
                }
                break;

            case SlimeType.MushroomSlime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.1f; //70
                        break;
                    case 2:
                        slime.Chance = 0.2f; //40
                        break;
                    case 3:
                        slime.Chance = 0.3f; //30
                        break;
                }
                break;

            case SlimeType.GoldenSlime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.0f; //90
                        break;
                    case 2:
                        slime.Chance = 0.0f; //80
                        break;
                    case 3:
                        slime.Chance = 0.0f; //30
                        break;
                }
                break;

            case SlimeType.MiddleSlime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.1f; //100
                        break;
                    case 2:
                        slime.Chance = 0.1f; //100
                        break;
                    case 3:
                        slime.Chance = 0.1f; //50
                        break;
                }
                break;

            case SlimeType.FireSlime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.0f; //100
                        break;
                    case 2:
                        slime.Chance = 0.0f; //100
                        break;
                    case 3:
                        slime.Chance = 0.0f; //100
                        break;
                }
                break;

            case SlimeType.IceSlime:
                switch (level)
                {
                    case 1:
                        slime.Chance = 0.0f; //100
                        break;
                    case 2:
                        slime.Chance = 0.0f; //100
                        break;
                    case 3:
                        slime.Chance = 0.0f; //100
                        break;
                }
                break;
        }
    }

    private void DebugAddSlimesToGame()
    {
        SlimeBuff slimeBuff = new SlimeBuff();
        PlayerShop.AddBuff(slimeBuff);

        GoldenSmileBuff goldenSlimeBuff = new GoldenSmileBuff();
        PlayerShop.AddBuff(goldenSlimeBuff);

        MiddleSlimeBuff middleSlimeBuff = new MiddleSlimeBuff();
        PlayerShop.AddBuff(middleSlimeBuff);

        MushroomSmileBuff mushroomSmileBuff = new MushroomSmileBuff();
        PlayerShop.AddBuff(mushroomSmileBuff);

        FireSmileBuff fireSmileBuff = new FireSmileBuff();
        PlayerShop.AddBuff(fireSmileBuff);

        IceSlimeBuff iceSmileBuff = new IceSlimeBuff();
        PlayerShop.AddBuff(iceSmileBuff);
    }

    private void GetRandomSmileToSpawn()
    {
        Debug.Log("GetRandomSmileToSpawn");

        float tempMaxBuffChance = 0;
        Buff tempBuff = new Buff();
        Buff tempBuffToSpawn = new Buff();

        foreach (Buff buff in PlayerShop.Buffs)
        {
            Debug.Log("PlayerShop.Buffs Count -- " + PlayerShop.Buffs.Count);

            tempBuff = buff;
            ChangeChanseToLevelCorrelation(ref tempBuff, LevelController.Level);
            Debug.Log("Current chanse: " + tempBuff.Chance + " current slime: " + tempBuff.Name);

            if (Random.value <= tempBuff.Chance &&
                tempMaxBuffChance <= tempBuff.Chance) //to get a % 20 chance without the confusion. 
            {
                Debug.Log(buff.Name + " Should Spawn. With chance: " + buff.Chance + "%");
                tempMaxBuffChance = buff.Chance;
                tempBuffToSpawn = buff;

                //SpawnSlime(tempBuff.SlimeType);

            }
        }

        if (tempMaxBuffChance == 0)
        {
            Debug.Log("Spawning default slime...");

            SpawnSlime(SlimeType.Slime, SpawnPositions[0]);
        }
        else
        {
            SpawnSlime(tempBuffToSpawn.SlimeType, SpawnPositions[0]);
        }


        //ChangeChanseToLevelCorrelation(ref slime, LevelController.Level);

    }



    public void SpawnSlime(SlimeType slimeType, Transform spawnTransform)
    {
        GameObject objToSpawn = null;
        switch (slimeType)
        {
            case SlimeType.GoldenSlime:
                {
                    objToSpawn = GoldenSmilePrefab;
                }
                break;

            case SlimeType.MushroomSlime:
                {
                    objToSpawn = MushroomSlimePrefab;
                }
                break;

            case SlimeType.Slime:
                {
                    objToSpawn = SlimePrefab;
                }
                break;

            case SlimeType.MiddleSlime:
                {
                    objToSpawn = MiddleSlimePrefab;
                }
                break;

            case SlimeType.FireSlime:
                {
                    objToSpawn = FireSlimePrefab;
                    objToSpawn.GetComponent<FireSlime>().CanvasHelper = CanvasHelper;
                }
                break;

            case SlimeType.IceSlime:
                {
                    objToSpawn = IceSlimePrefab;
                    objToSpawn.GetComponent<IceSlime>().CanvasHelper = CanvasHelper;
                }
                break;
        }

        if (objToSpawn)
        {
            //objToSpawn.GetComponent<Slime>().ParticleSystemController
            objToSpawn.GetComponent<Slime>().ParticleSystemController = ParticleSystemController;
            objToSpawn.GetComponent<Slime>().WaterController = WaterController;
            objToSpawn.GetComponent<Slime>().FireController = FireController;





            GameObject spawnedSlime = Instantiate(objToSpawn, spawnTransform);

            spawnedSlime.GetComponent<Slime>().
                OnDeath.AddListener(() => { Records.GetComponent<Records>().IncreaseValue(slimeType); });

        }
    }

    IEnumerator SpawnSlimeByTime()
    {
        GetRandomSmileToSpawn();
        yield return new WaitForSeconds(DeltaTime);
        StartCoroutine(SpawnSlimeByTime());
    }

}



//public void SetEmenies(List<bool> IsSpawning)
//{
//    for (int i = 0; i < IsSpawning.Count; i++)
//    {
//        if (IsSpawning[i] == true)
//        {
//            AreObjectsCouldSpawn[i] = true;
//        }
//        else
//        {
//            AreObjectsCouldSpawn[i] = false;
//        }
//    }
//}


//public void StartSpawningSlimesPermanently()
//{
//    StartCoroutine(SpawnSlimesPermanently());
//}

//IEnumerator SpawnSlimesPermanently()
//{
//    StartCoroutine(SpawnSlimes(1));
//    yield return new WaitForSeconds(DeltaTime);
//    StartSpawningSlimesPermanently();
//}

////ienumerator spawnobjects()
////{
////    for (int i = 0; i < objectstospawn.count; i++)
////    {
////        //if (areobjectscouldspawn[i])
////        //{
////        instantiate(objectstospawn[i], spawnpositions[0]);
////        //debug.log("spawn slime by time");
////        yield return new waitforseconds(deltatime);
////        startspawningobjects();
////        //}
////    }
////}


//bool isFirstWaveOver = false;
////public void StartSpawningEnemies()
////{
////    if (isFirstWaveOver == false)
////    {
////        StartCoroutine(SpawnSlimes(WaveCurrent.EnemiesInWave_1));
////    }
////    else
////    {
////        StartCoroutine(SpawnSlimes(WaveCurrent.EnemiesInWave_2));
////    }
////}




//public void StartSpawningEnemies()
//{
//    StartCoroutine(SpawnEnimes(SpawningCount));
//}

//IEnumerator SpawnEnimes(int count)
//{
//    //for (int i = 0; i < 10; i++)
//    //{
//    //    Debug.Log(i);
//    //    yield return new WaitForSeconds(3);
//    //}

//    //spawnedCount++;

//    for (int i = 0; i < count; i++)
//    {
//        if (i % 5 == 0 && i != 0)
//        {
//            StartCoroutine(SpawnSlimesMiddle());
//            yield return new WaitForSeconds(DeltaTime / 5);
//            //StartCoroutine(SpawnEnimes(count));
//        }
//        else
//        {
//            StartCoroutine(SpawnSlimes(1));
//            yield return new WaitForSeconds(DeltaTime / 5);
//            // StartCoroutine(SpawnEnimes(count));
//        }
//    }

//}

//IEnumerator SpawnSlimes(int count)
//{
//    //for (int y = 0; y < ObjectsToSpawn.Co unt; y++)
//    //{
//    float rndDeltaTime = Random.Range(0.3f, 1.2f);
//    for (int i = count; i > 0; i--)
//    {
//        //Debug.Log("spawn slime on Wave!");
//        Instantiate(ObjectsToSpawn[0], SpawnPositions[0]);
//        yield return new WaitForSeconds(rndDeltaTime);
//    }
//    //}


//    //    //isFirstWaveOver = true;
//    //}

//    //IEnumerator SpawnSlimesMiddle()
//    //{
//    //    Instantiate(ObjectsToSpawn[1], SpawnPositions[0]);
//    //    yield return null;
//    //}
//}
