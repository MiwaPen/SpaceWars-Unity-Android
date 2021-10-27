using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int MAXHP;
    [SerializeField] private int MAXLVLXP;
    [SerializeField] private int LVL;
    [SerializeField] private int LVLXP;
    [SerializeField] private int TOTALXP;
    [SerializeField] private ReposBase reposBase;
    private PlayerGunsController gunsController;
    public Action onHPChange;
    public Action onXpChange;
    public Action onLose;

    void Awake()
    {
        gunsController = this.gameObject.GetComponent<PlayerGunsController>();
    }

    private void LvlUp()
    {
        LVLXP = TOTALXP - (LVL * MAXLVLXP);
        LVL += 1;
        gunsController.ChangeWeapons(LVL);
        SetHPMax();
    }

    public void UpdateXP(int exp)
    {
        LVLXP += exp;
        TOTALXP += exp;
        if (LVLXP >= MAXLVLXP)
        {
            LvlUp();
        }
        onXpChange?.Invoke();
    }

    public void UpdateHP(int DMG)
    {
        HP -= DMG;
        if (HP <= 0)
        {
            Lose();
        }
        onHPChange?.Invoke();
    }

    private void Lose()
    {
        gunsController.StopShooting();
        reposBase.PlayerScoreRepos.SaveScore(TOTALXP);
        onLose?.Invoke();
    }

    private void SetHPMax()
    {
        HP = MAXHP;
        onHPChange?.Invoke();
    }

    public void StartGame()
    {
        MAXHP = 100;
        MAXLVLXP = 100;
        HP = MAXHP;
        LVL = 1;
        LVLXP = 0;
        TOTALXP = 0;
        gunsController.ChangeWeapons(LVL);
        gunsController.StartShooting();
    }

    public int GetMaxHp()
    {
        return MAXHP;
    }
    public int GetMaxXp()
    {
        return MAXLVLXP;
    }
    public int GetHp()
    {
        return HP;
    }

    public int GetTotalXp()
    {
        return TOTALXP;
    }

    public int GetLvlXp()
    {
        return LVLXP;
    }
}
