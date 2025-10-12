using UnityEngine;
using UnityEngine.UI;

public class UISelectLevel : Popup
{
    [SerializeField] Transform lvlTransform;
    [SerializeField] Button _btnClose;
    [SerializeField] ButtonLevel[] buttonLevels;

    private void Awake()
    {
        _btnClose.onClick.AddListener(OnClickClose);
        buttonLevels = lvlTransform.GetComponentsInChildren<ButtonLevel>();
        Initialize();
    }

    private void OnEnable()
    {
        for (var i = 0; i < buttonLevels.Length; i++)
        {
            buttonLevels[i].CheckUnlock();
        }
    }

    private void OnDestroy()
    {
        for (var i = 0; i < buttonLevels.Length; i++)
        {
            buttonLevels[i].OnClickEvent -= Hide;
        }
    }

    void Initialize()
    {
        for(var i = 0; i < buttonLevels.Length; i++)
        {
            buttonLevels[i].Initialize(i);
            buttonLevels[i].OnClickEvent += Hide;
        }
    }

    void OnClickClose()
    {
        Show(false);
    }

    void Hide()
    {
        Show(false);
    }
}
