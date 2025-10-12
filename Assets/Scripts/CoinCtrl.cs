using UnityEngine;
using UnityEngine.UI;

public class CoinCtrl : MonoBehaviour
{
    public static CoinCtrl I;
    [SerializeField] Text _txtCoin;

    private void Awake()
    {
        I = this;
    }

    public void UpdateTextCoin()
    {
        _txtCoin.text = PrefData.Coin.ToString();
    }
}
