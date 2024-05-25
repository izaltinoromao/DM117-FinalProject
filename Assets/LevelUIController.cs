using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelUiController : MonoBehaviour
{

    [SerializeField] TMP_Text enemyCount;
    [SerializeField] int startingEnemies;
    [SerializeField] GameObject successGamePanel;
    [SerializeField] Button restartButton;

    public static LevelUiController Instance;

    private int deathCount;

    public int DeathCount
    {
        get { return deathCount; }
        set 
        { 
            deathCount = value;
            int alive = startingEnemies - deathCount;
            enemyCount.text = $"Enemies Alive: {alive}";

            if (alive <= 0)
            {
                LevelUiController.Instance.ShowSuccessGamePanel();
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        enemyCount.text = $"Enemies Alive: {startingEnemies}";
    }

    public void ShowSuccessGamePanel()
    {
        Time.timeScale = 0;
        successGamePanel.SetActive(true);
    }

    public void OnClickButtonRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map_v1");
    }

    public void OnClickButtonMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
