using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/LevelDatas", fileName = "LevelDatas")]
public class DataSO : ScriptableObject
{
    public List<Level> levelDatas;
}
