using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public LevelController LevelController;
    public Transform RoadSpawnPositions;
    int roadsPassed;
    public int RoadsPassed
    {
        get { return roadsPassed; }

        set
        {
            roadsPassed = value;
            LevelController.Level++;
            LevelController.UpdateTextLabel();
        }
    }

    private void Start()
    {
        index = RoadsCount;
    }

    public int RoadsCount = 4;
    private int index;
    private int Index
    {
        get { return index; }

        set
        {
            index = value;
            //if (index <= 0)
            //{
            //    index = RoadsCount;
            //}
            //else { index = value; }

        }
    }

    public Transform NextSpawnTransform
    {
        get
        {
            //Index--;
            return RoadSpawnPositions;
        }
    }
}
