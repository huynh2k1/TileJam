using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/LevelDatas", fileName = "LevelDatas")]
public class DataSO : ScriptableObject
{
    public List<LevelData> levelDatas;
}

[Serializable]
public class LevelData
{
    public Level level;
    public int move;
}
