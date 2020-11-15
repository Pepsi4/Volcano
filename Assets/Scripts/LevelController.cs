using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;


public class LevelController : MonoBehaviour
{
    public UnityEvent On5thLevel;
    public UnityEvent On10thLevel;
    public SlimeSpawner SlimeSpawner;

    const float DeltaTimeWave_5 = 4f;
    const float DeltaTimeWave_10 = 3f;


    private void ActionsOnLevelCorrelation(int level)
    {
        Debug.Log("ACTION!");
        switch (level)
        {
            case 5:
                On5thLevel.Invoke();
                //SlimeSpawner.DeltaTime = DeltaTimeWave_5;

                break;

            case 10:
                SlimeSpawner.DeltaTime = DeltaTimeWave_10;
                On10thLevel.Invoke();
                break;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }



    int level;
    public int Level
    {
        get { return level; }
        set
        {
            if (value % 5 == 0)
            {
                ActionsOnLevelCorrelation(value);
            }
            level = value;
        }
    }
    public TextMeshProUGUI textLabel;

    public void UpdateTextLabel()
    {
        textLabel.text = "level " + Level;
    }
}
