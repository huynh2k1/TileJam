using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : BaseUI
{
    [SerializeField] Button _btnPause;
    [SerializeField] Button _btnReplay;
    [SerializeField] Text _txtMove;
    [SerializeField] Text _txtLevel;

    private void Awake()
    {
        _btnPause.onClick.AddListener(OnClickPause);
        _btnReplay.onClick.AddListener(OnClickReplay);
    }

    public void OnClickPause()
    {
        if (GameCtrl.I.CurState != GameState.PLAYING)
            return;
        GameCtrl.I.GamePause();
    }

    public void OnClickReplay()
    {
        if (GameCtrl.I.CurState != GameState.PLAYING)
            return;
        GameCtrl.I.GameStart();
    }

    public void UpdateTxtMove(int move)
    {
        _txtMove.text = move.ToString();    
    }

    public void UpdateTextLevel()
    {
        _txtLevel.text = $"Level {PrefData.CurLevel + 1}";
    }
}
