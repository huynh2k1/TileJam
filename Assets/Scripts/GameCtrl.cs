using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl I;
    public GameState CurState;

    public UICtrl uiCtrl;
    public LevelCtrl levelCtrl;
    int _move;

    private void Awake()
    {
        I = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        GameHome();
    }
    public void ChangeState(GameState newState) => CurState = newState;

    public void GameHome()
    {
        ChangeState(GameState.NONE);
        levelCtrl.DestroyCurLevel();
        uiCtrl.ShowHome(true);
    }

    public void GameStart()
    {
        ChangeState(GameState.PLAYING);
        uiCtrl.ShowHome(false);
        uiCtrl.UpdateTextLevel();
        levelCtrl.InitLevel();
    }

    public void GamePause()
    {
        ChangeState(GameState.NONE);
        uiCtrl.ShowSetting(true);
    }

    public void GameWin()
    {
        SoundManager.I.PlaySoundByType(TypeSound.WIN);
        ChangeState(GameState.NONE);
        levelCtrl.CheckInCreaseLevel();
        uiCtrl.ShowWin(true);

        PrefData.Coin += 900;
        CoinCtrl.I.UpdateTextCoin();
    }

    public void GameLose()
    {
        SoundManager.I.PlaySoundByType(TypeSound.LOSE);
        ChangeState(GameState.NONE);
        uiCtrl.ShowLose(true);
    }

    public void GameContinue()
    {
        _move += 2;
        uiCtrl.UpdateTxtMove(_move);
        ChangeState(GameState.PLAYING);
    }

    public void SetMove(int move)
    {
        _move = move;
        uiCtrl.UpdateTxtMove(move); 
    }


    public void CountMove()
    {
        _move--;
        uiCtrl.UpdateTxtMove(_move);
        if (_move <= 0)
        {
            GameLose();
        }
    }
}
