using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public static bool IsLevelLoading;
    public void LoadLevel(int index)
    {
        IsLevelLoading = true;
        SceneManager.LoadScene(index);
    }

    void Start()
    {
        IsLevelLoading = false;
    }

    //public Scene GameScene;
    //public List<GameObject> ObjectsToSpawn = new List<GameObject>();
    //public List<bool> AreObjectsCouldSpawn = new List<bool>();

    //public int FirstWaveEnemiesCount;
    //public int SecondWaveEnemiesCount;

    //// [SerializeField]


    //public void LoadLevel(int lvl)
    //{
    //    Wave wave = new Wave(FirstWaveEnemiesCount, SecondWaveEnemiesCount); //to
    //    Spawner.SetWave(wave);

    //    // Spawner.ObjectsToSpawn = ObjectsToSpawn;
    //    Spawner.AreObjectsCouldSpawn = AreObjectsCouldSpawn;

    //    SceneManager.LoadScene(lvl);
    //}
}
