using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILose : Popup
{
    [SerializeField] Button _btnReplay;
    [SerializeField] Button _btnContinue;

    [SerializeField] Text _txtLevel;

    [SerializeField] Image _uiBtnContinue;
    [SerializeField] Color _colorInActiveBtnContinue;

    private void Awake()
    {
        _btnReplay.onClick.AddListener(OnClickReplay);
        _btnContinue.onClick.AddListener(OnClickContinue);
    }

    private void OnEnable()
    {
        UpdateStateBtnContinue();
        UpdateTextLevel();
    }

    void OnClickContinue()
    {
        Show(false);
        PrefData.Coin -= 900;
        CoinCtrl.I.UpdateTextCoin();    
        GameCtrl.I.GameContinue();
    }

    void OnClickReplay()
    {
        Show(false);
        GameCtrl.I.GameStart();
    }

    void UpdateStateBtnContinue()
    {
        bool isTrue = (PrefData.Coin >= 900);
        _uiBtnContinue.color = isTrue ? Color.white : _colorInActiveBtnContinue;
        _btnContinue.interactable = isTrue;
    }

    void UpdateTextLevel()
    {
        _txtLevel.text = $"Level {PrefData.CurLevel + 1}";
    }
}
