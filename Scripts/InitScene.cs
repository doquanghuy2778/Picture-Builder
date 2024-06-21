using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{
    [SerializeField] private Transform loadingFill;
    [SerializeField] private TextMeshProUGUI textPercent;
    [SerializeField] private float loadTime = 1f;
    private int percent = 0;

    private void Start()
    {
        StartCoroutine(LoadSceneAfterWait(1));
    }

    private void Update()
    {
        textPercent.text = percent.ToString();
    }

    private IEnumerator LoadSceneAfterWait(float delaySeconds)
    {
        AsyncOperation sceneAsync;

        //if (!PlayerPrefs.HasKey("Level"))
        //{
        //    sceneAsync = SceneManager.LoadSceneAsync("Lv 1");
        //    PlayerPrefs.SetInt("Level", 1);
        //}
        //else
        //{
        //    sceneAsync = SceneManager.LoadSceneAsync("Lv " + PlayerPrefs.GetInt("Level"));
        //}
        sceneAsync = SceneManager.LoadSceneAsync(1);

        sceneAsync.allowSceneActivation = false;

        DOTween.To(() => 0, value => percent = value, 100, loadTime);
        yield return loadingFill.DOScale(new Vector3(1, 1, 1), loadTime).WaitForCompletion();

        yield return new WaitForSeconds(delaySeconds);
        sceneAsync.allowSceneActivation = true;
    }
}
