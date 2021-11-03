using UnityEngine;

public class UiSwitcher : MonoBehaviour
{
    [SerializeField] private GameplayUIController _gameplayUi;
    [SerializeField] private MenuController _menuUi;
    [SerializeField] private PlayerStats player;
    private void Start()
    {
        _gameplayUi.gameObject.SetActive(false);
        _menuUi.gameObject.SetActive(false);
    }

    public void ShowMenuUI()
    {
        _gameplayUi.gameObject.SetActive(false);
        _menuUi.gameObject.SetActive(true);
        _menuUi.SetScorelabelValue();

    }
    public void ShowGameplayUI()
    {
        _gameplayUi.gameObject.SetActive(true);
        _menuUi.gameObject.SetActive(false);
        _gameplayUi.ResetToDefault(player.GetMaxHp(), player.GetMaxXp(), player.GetLvlXp());
    }
}
