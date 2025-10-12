using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    [SerializeField] UIHome _uiHome;
    [SerializeField] UIGame _uiGame;
    [SerializeField] UISetting _uiSetting;
    [SerializeField] UIWin _uiWin;
    [SerializeField] UILose _uiLose;

    public void ShowHome(bool isShow)
    {
        _uiHome.Show(isShow);
        _uiGame.Show(!isShow);
    }

    public void ShowSetting(bool isShow)
    {
        _uiSetting.Show(isShow);
    }

    public void ShowWin(bool isShow)
    {
        _uiWin.Show(isShow);
    }

    public void ShowLose(bool isShow)
    {
        _uiLose.Show(isShow);
    }

    public void UpdateTxtMove(int move)
    {
        _uiGame.UpdateTxtMove(move);
    }

    public void UpdateTextLevel()
    {
        _uiGame.UpdateTextLevel();
    }
}
