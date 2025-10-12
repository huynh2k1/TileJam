using UnityEngine;

public class PrefData
{
    public static int CurLevel
    {
        get => PlayerPrefs.GetInt("Cur_Level", 0);
        set => PlayerPrefs.SetInt("Cur_Level", value);
    }

    public static int LevelUnlocked
    {
        get => PlayerPrefs.GetInt("LevelUnlocked", 0);
        set => PlayerPrefs.SetInt("LevelUnlocked", value);
    }

    public static int Coin
    {
        get => PlayerPrefs.GetInt("Coin", 0);
        set => PlayerPrefs.SetInt("Coin", value);
    }

    public static float Sound
    {
        get => PlayerPrefs.GetFloat("Sound", 1);
        set => PlayerPrefs.SetFloat("Sound", value);
    }

    public static float Music
    {
        get => PlayerPrefs.GetFloat("Music", 1);
        set => PlayerPrefs.SetFloat("Music", value);
    }
}
