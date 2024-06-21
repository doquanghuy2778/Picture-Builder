using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }
    public bool IsOver, IsWin;
    public int CountTarget;
    public AudioClip BGSound;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 144;
    }

    private void Update()
    {
        CheckGameOver();
        CheckGameWin();
    }
    
    private void CheckGameOver()
    {
        if (GameUI.Instance.Timer < 0)
        {
            IsOver = true;
        }
    }

    private void CheckGameWin()
    {
        if (CountTarget == PictureManager.Instance.Pictures.Count)
        {
            IsWin = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
