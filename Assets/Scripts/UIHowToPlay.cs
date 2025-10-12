using UnityEngine;
using UnityEngine.UI;

public class UIHowToPlay : Popup
{
    [SerializeField] Button btnClose;

    private void Awake()
    {
        btnClose.onClick.AddListener(OnClickClose);
    }

    void OnClickClose()
    {
        Show(false);
    }
}
