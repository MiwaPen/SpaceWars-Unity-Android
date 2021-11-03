using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Action OnGameStart;
    [SerializeField] private int _frameLimit = 120;
    [SerializeField] private PlayerStats _player;
    [SerializeField] private UiSwitcher _uiSwitcher;
    [SerializeField] private EnemySpawner _enemySpawner;
    private Vector3 _startPos;

    private void Start()
    {
        Application.targetFrameRate = _frameLimit;
        _startPos = _player.gameObject.transform.position;
        ShowMenu();
        OnGameStart?.Invoke();
    }
    private void Awake()
    {
        _player.OnLose += ShowMenu;
    }

    public void StartGame()
    {
        _enemySpawner.StartEnemySpawn();
        _player.gameObject.SetActive(true);
        _player.transform.position = _startPos;
        _player.StartGame();
        _uiSwitcher.ShowGameplayUI();
    }

    private void ShowMenu()
    {
        ResetScene();
        _enemySpawner.StopEnemySpawn();
        _player.gameObject.SetActive(false);
        _uiSwitcher.ShowMenuUI();
    }

    private void ResetScene()
    {
        EnemyController[] _enemies = FindObjectsOfType<EnemyController>();
        for (int i = 0; i < _enemies.Length; i++)
        {
            Destroy(_enemies[i].gameObject);
        }

        BulletController[] _bullets = FindObjectsOfType<BulletController>();
        for (int i = 0; i < _bullets.Length ; i++)
        {
            Destroy(_bullets[i].gameObject);
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
