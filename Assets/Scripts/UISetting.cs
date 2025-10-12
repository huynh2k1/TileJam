using UnityEngine;
using UnityEngine.UI;

public class UISetting : Popup
{
    [SerializeField] Button _btnClose;
    [SerializeField] Button _btnHome;

    [SerializeField] Slider _sliderMusic;
    [SerializeField] Slider _sliderSound;

    private void Awake()
    {
        _btnClose.onClick.AddListener(OnClickClose);
        _btnHome.onClick.AddListener(OnClickHome);
        _sliderMusic.onValueChanged.AddListener((v) =>
        {
            OnVolumeMusicChange(v);
        });
        _sliderSound.onValueChanged.AddListener((v) =>
        {
            OnVolumeSoundChange(v);
        });
    }

    private void OnEnable()
    {
        _sliderMusic.value = PrefData.Music;
        _sliderSound.value = PrefData.Sound;
    }

    void OnClickClose()
    {
        Show(false);
        GameCtrl.I.ChangeState(GameState.PLAYING);
    }

    void OnClickHome()
    {
        Show(false);
        GameCtrl.I.GameHome();
    }

    void OnVolumeSoundChange(float value)
    {
        PrefData.Sound = value;
        SoundManager.I.UpdateVolumeSounds();
    }

    void OnVolumeMusicChange(float value)
    {
        PrefData.Music = value;
        SoundManager.I.UpdateVolumeMusic();
    }
}
