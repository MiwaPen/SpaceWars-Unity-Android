using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int FrameLimit = 120;
    [SerializeField] private PlayerStats player;
    [SerializeField] private UiSwitcher uiSwitcher;
    [SerializeField] private GameplayUIController gameplayUI;
    [SerializeField] private MenuController menuController;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ReposBase reposBase;
    private Vector3 startPos;

    private void Start()
    { 
        Application.targetFrameRate = FrameLimit;
        startPos = player.gameObject.transform.position;
        menuController.MenuBTNSBindings(this.gameObject.GetComponent<GameManager>());
        menuController.SetScorelabelValue(GetMaxScore());
        ShowMenu();
    }
    private void Awake()
    {
        player.onHPChange += UpdateHealthBar;
        player.onXpChange += UpdateXPInfo;
        player.onLose += ShowMenu;
    }

    public void StartGame()
    {
        enemySpawner.StartEnemySpawn();
        player.gameObject.SetActive(true);
        player.transform.position = startPos;
        player.StartGame();
        uiSwitcher.ShowGameplayUI();
        gameplayUI.ResetToDefault(player.GetMaxHp(), player.GetMaxXp(), player.GetLvlXp());
    }

    private void ShowMenu()
    {
        ResetScene();
        enemySpawner.StopEnemySpawn();
        player.gameObject.SetActive(false);
        uiSwitcher.ShowMenuUI();
        menuController.SetScorelabelValue(GetMaxScore());
    }

    private void ResetScene()
    {
        
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }

        BulletController[] bullets = FindObjectsOfType<BulletController>();
        for (int i = 0; i < bullets.Length ; i++)
        {
            Destroy(bullets[i].gameObject);
        }
    }

    private void UpdateHealthBar()
    {
        int newHp = player.GetHp();
        gameplayUI.UpdateHealthBar(newHp);
    }

    private void UpdateXPInfo()
    {
        int newTotalXp = player.GetTotalXp();
        int newLvlXp = player.GetLvlXp();
        gameplayUI.UpdateXPInfo(newTotalXp,newLvlXp);
    }

    public void GameExit()
    {
        Application.Quit();
    }


    private int  GetMaxScore()
    {
        int score = reposBase.PlayerScoreRepos._maxScore;
        return score;
    }
}
