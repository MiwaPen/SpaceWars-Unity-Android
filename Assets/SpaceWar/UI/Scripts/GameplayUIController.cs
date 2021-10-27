using UnityEngine;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private StatusBar HealthBar;
    [SerializeField] private StatusBar LvlBar;
    [SerializeField] private TMP_Text scoreLaber;

    public void ResetToDefault(int maxHp,int maxXp, int currLvlXp)
    {
        HealthBar.setMaxValue(maxHp);
        LvlBar.setMaxValue(maxXp, currLvlXp);
        scoreLaber.text = "SCR: " + currLvlXp;
    }

    public void UpdateHealthBar(int newHp)
    {
        HealthBar.UpdateValue(newHp);
    }

    public void UpdateXPInfo(int newTotalXp, int newLvlXp)
    {
        LvlBar.UpdateValue(newLvlXp);
        scoreLaber.text = "SCR: " + newTotalXp;
    }
}
