using UnityEngine;
using UnityEngine.UI;

public class UIWin : Popup
{
    [SerializeField] Button _btnContinue;

    private void Awake()
    {
        _btnContinue.onClick.AddListener(OnClickContinue);
    }

    void OnClickContinue()
    {
        Show(false);
        GameCtrl.I.GameStart();
    }
}
