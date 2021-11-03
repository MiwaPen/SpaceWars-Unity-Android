using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _scoreLabel;
    private SoundController _soundController;
    private GameManager _gameManager;
    private ReposBase _reposBase;

    private void Awake()
    {
        _reposBase = FindObjectOfType<ReposBase>();
        _soundController = FindObjectOfType<SoundController>();
        _gameManager = FindObjectOfType<GameManager>();
        _startButton.onClick.AddListener(_gameManager.StartGame);
        _startButton.onClick.AddListener(_soundController.ClickPlay);
        _exitButton.onClick.AddListener(_gameManager.GameExit);
        _exitButton.onClick.AddListener(_soundController.ClickPlay);
    }
    public void SetScorelabelValue()
    {
        _scoreLabel.text = _reposBase.PlayerScoreRepos.maxScore.ToString();
    }

}
