using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : BaseUI
{
    [SerializeField] Button _btnPause;
    [SerializeField] Button _btnReplay;


    private void Awake()
    {
        _btnPause.onClick.AddListener(OnClickPause);
        _btnReplay.onClick.AddListener(OnClickReplay);
    }

    public void OnClickPause()
    {

    }

    public void OnClickReplay()
    {

    }
}
