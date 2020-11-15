using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectGameModeMenu : MonoBehaviour
{
    [SerializeField]
    int NormalModeLevelNumber = 1;

    public void LoadNormalGameMode()
    {
        SceneManager.LoadScene(NormalModeLevelNumber);
    }

    public void HardGameMode()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
