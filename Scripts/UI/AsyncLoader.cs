using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image loadingFill;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private float _loadTime = 1f;
    [SerializeField] private TextMeshProUGUI _percentText;
    private int _percent = 0;

    private void Update()
    {
        _percentText.text = _percent.ToString();    
    }

    public void LoadLeverBtn()
    {
        int levelToLoad = GameSave.Instance.CurrLevel;
        _mainMenu.SetActive(false);
        _loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(int levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        loadOperation.allowSceneActivation = false;
        DOTween.To(() => 0, value => _percent = value, 100, _loadTime).SetEase(Ease.OutQuad);
        yield return loadingFill.DOFillAmount(1, _loadTime).SetEase(Ease.OutQuad).WaitForCompletion();

        yield return new WaitForSeconds(0.2f);
        loadOperation.allowSceneActivation = true;
    }
}
