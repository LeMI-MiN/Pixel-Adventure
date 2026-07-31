using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // UI
    [Header("UI")]
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private GameObject gameOverPanel;

    // Life
    [Header("Life")]
    [SerializeField] private int maxLife = 3;
    private int currentLife;

    // Life UI
    [SerializeField] private GameObject[] lifeUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Clear / Over
        Time.timeScale = 1f;

        clearPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        // Life
        currentLife = maxLife;

        // Life UI
        UpdateLifeUI();
    }

    public void Clear()
    {
        clearPanel.SetActive(true);
        Time.timeScale = 0f;

        SoundManager.Instance.PlayClear();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage()    // 1Loss
    {
        currentLife--;

        Debug.Log("Life : " + currentLife);

        UpdateLifeUI();

        if (currentLife <= 0)
        {
            GameOver();
        }
    }

    public void AddLife()   // 1UP
    {
        if (currentLife < maxLife)
        {
            currentLife++;
        }
        Debug.Log("Life : " + currentLife);

        UpdateLifeUI();
    }

    public bool IsGameOver()
    {
        return currentLife <= 0;
    }

    private void UpdateLifeUI()
    {
        for (int i = 0; i < lifeUI.Length; i++)
        {
            lifeUI[i].SetActive(i < currentLife);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}