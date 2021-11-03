using UnityEngine;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private StatusBar _HealthBar;
    [SerializeField] private StatusBar _LvlBar;
    [SerializeField] private TMP_Text _scoreLaber;
    private PlayerStats _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerStats>();
        _player.OnHPChange += UpdateHealthBar;
        _player.OnXpChange += UpdateXPInfo;
    }

    public void ResetToDefault(int maxHp,int maxXp, int currLvlXp)
    {
        _HealthBar.setMaxValue(maxHp);
        _LvlBar.setMaxValue(maxXp, currLvlXp);
        _scoreLaber.text = "SCR: " + currLvlXp;
    }

    private void UpdateHealthBar()
    {
        _HealthBar.UpdateValue(_player.GetHp());
    }

    private void UpdateXPInfo()
    {
        _LvlBar.UpdateValue(_player.GetLvlXp());
        _scoreLaber.text = "SCR: " + _player.GetTotalXp();
    }
}
