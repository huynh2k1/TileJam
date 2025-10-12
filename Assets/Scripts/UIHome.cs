using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : BaseUI
{
    [SerializeField] Button _btnPlay;
    [SerializeField] Button _btnHowToPlay;
    [SerializeField] UIHowToPlay _uiHTP;
    [SerializeField] UISelectLevel _uISelectLevel;

    private void Awake()
    {
        _btnPlay.onClick.AddListener(OnClickPlay);
        _btnHowToPlay.onClick.AddListener(OnClickHowToPlay);
    }

    public void OnClickPlay()
    {
        _uISelectLevel.Show(true);
    }

    public void OnClickHowToPlay()
    {
        ShowHTP();
    }

    public void ShowHTP()
    {
        _uiHTP.Show(true);
    }
}
