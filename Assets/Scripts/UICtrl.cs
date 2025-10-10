using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    [SerializeField] UIHome _uiHome;
    [SerializeField] UIGame _uiGame;

    public void ShowHome(bool isShow)
    {
        _uiHome.Show(isShow);
    }

    public void ShowGame(bool isShow)
    {
        _uiGame.Show(isShow);   
    }
}
