using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class LevelData : ScriptableObject
{
    public List<LevelInfor> levelInfors;

    [Serializable]
    public class LevelInfor{
        public int level;
        public List<TargetLevel> targetLevels;
        public List<FoodCount> foodCounts;
    }
}