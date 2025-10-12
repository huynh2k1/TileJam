using UnityEngine;

public class LevelCtrl : MonoBehaviour
{
    [SerializeField] DataSO data;
    Level curLevel;
    int _move;

    public void InitLevel()
    {
        if(curLevel != null)
        {
            DestroyCurLevel();
        }
        curLevel = Instantiate(data.levelDatas[PrefData.CurLevel].level, transform);
        GameCtrl.I.SetMove(data.levelDatas[PrefData.CurLevel].move);
        Board.I.CurLevel = curLevel;   
    }

    public void CheckInCreaseLevel()
    {
        if(PrefData.CurLevel < data.levelDatas.Count - 1)
        {
            PrefData.CurLevel++;
            PrefData.LevelUnlocked = PrefData.CurLevel;
        }
        else
        {
            PrefData.CurLevel = 0;
        }
    }

    public void DestroyCurLevel()
    {
        if (curLevel == null)
            return;
        Board.I.CurLevel = null;
        curLevel.Destroy();
        curLevel = null;
    }
}
