using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : BaseUI
{
    [SerializeField] Button _btnPlay;
    [SerializeField] Button _btnHowToPlay;

    private void Awake()
    {
        _btnPlay.onClick.AddListener(OnClickPlay);
        _btnHowToPlay.onClick.AddListener(OnClickHowToPlay);
    }

    public void OnClickPlay()
    {

    }

    public void OnClickHowToPlay()
    {

    }
}
