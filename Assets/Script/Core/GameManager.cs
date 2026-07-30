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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TakeDamage()    // 1Loss
    {
        currentLife--;
        Debug.Log("Life : " + currentLife);

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
    }

    public bool IsGameOver()
    {
        return currentLife <= 0;
    }
}