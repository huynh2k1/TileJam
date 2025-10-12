using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private Image loadingImage;
    [SerializeField] private Text loadingText;  
    [SerializeField] private float loadingTime = 6f;

    private void Start()
    {
        loadingImage.fillAmount = 0;
        StartCoroutine(FillLoadingBar());
    }

    private IEnumerator FillLoadingBar()
    {
        float elapsed = 0f;

        while (elapsed < loadingTime)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / loadingTime);
            loadingImage.fillAmount = progress;

            int percent = Mathf.RoundToInt(progress * 100);
            loadingText.text = $"Loading {percent}%";

            yield return null;
        }

        loadingText.text = "Loading 100%";
        gameObject.SetActive(false);
    }
}
