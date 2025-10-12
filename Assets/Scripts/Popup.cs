using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Image mask;
    public  Transform main;

    public void Show(bool isShow)
    {
        main.DOKill();
        mask.DOKill();

        if (isShow)
        {
            main.localScale = Vector3.zero;

            Color color = mask.color;
            color.a = 0;
            mask.color = color;

            gameObject.SetActive(true);

            mask.DOFade(0.7f, 0.3f);
            main.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
