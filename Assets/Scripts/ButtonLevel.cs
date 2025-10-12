using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    public int ID { get; set; }

    [SerializeField] Button button;
    [SerializeField] GameObject LockObj;
    [SerializeField] Text _txtLevel;

    public event Action OnClickEvent;

    private void Awake()
    {
        button.onClick.AddListener(OnClickThis);
    }

    void OnClickThis()
    {
        OnClickEvent?.Invoke();
        PrefData.CurLevel = ID;
        GameCtrl.I.GameStart();
    }

    public void Initialize(int id)
    {
        ID = id;
        _txtLevel.text = (id + 1).ToString();
        CheckUnlock();
    }

    public void CheckUnlock()
    {
        bool isUnlock = (ID <= PrefData.LevelUnlocked);

        LockObj.SetActive(!isUnlock);
        button.interactable = isUnlock;
    }
}
