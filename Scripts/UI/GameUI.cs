using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textTime;
    public float Timer;
    int _minues, _seconds;
    private static GameUI _instance;
    public static GameUI Instance { get => _instance; }
    private bool _isCount;
    public GameObject GameWinPanel, GameOverPanel;
    public Button ReplayGame, NextLevel;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _isCount = true;
        ReplayGame.onClick.AddListener(ReLoadLevel);
        NextLevel.onClick.AddListener(NextLevelFunc);
    }

    private void Update()
    {
        if (!GameManager.Instance.IsWin)
        {
            CountDownTimer(Timer);
        }
        OpenOverPanel();
        OpenWinPanel();
    }

    public void CountDownTimer(float time)
    {
        if (_isCount)
        {
            Timer -= Time.deltaTime;
            _minues = Mathf.FloorToInt(time / 60);
            _seconds = Mathf.FloorToInt(time % 60);
            _textTime.text = string.Format("{0:00}:{1:00}", _minues, _seconds);
        }
        if (Timer <= 0)
        {
            _isCount = false;
        }
    }

    private void OpenWinPanel()
    {
        if (GameManager.Instance.IsWin)
        {
            GameWinPanel.SetActive(true);
        }
    }

    private void OpenOverPanel()
    {
        if (GameManager.Instance.IsOver)
        {
            GameOverPanel.SetActive(true);
        }
    }

    private void ReLoadLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }

    private void NextLevelFunc()
    {
        int level = GameSave.Instance.CurrLevel;
        level++;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene(level);
    }
}
