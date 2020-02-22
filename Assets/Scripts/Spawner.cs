using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public int EnemiesInWave_1 { get; private set; }
    public int EnemiesInWave_2 { get; private set; }

    public Wave() { }

    public Wave(int enemiesWave_1, int enemiesWave_2)
    {
        EnemiesInWave_1 = enemiesWave_1;
        EnemiesInWave_2 = enemiesWave_2;
    }
}

public class Spawner : MonoBehaviour
{
    [Header("Hi there!")]
    public List<GameObject> ObjectsToSpawn = new List<GameObject>();
    public static List<bool> AreObjectsCouldSpawn = new List<bool>();
    public List<Transform> SpawnPositions = new List<Transform>();

    [SerializeField]
    protected static Wave WaveCurrent = new Wave();

    public static void SetWave(Wave wave)
    {
        WaveCurrent = wave;
    }

    public static Wave GetWave()
    {
        return WaveCurrent;
    }
}
