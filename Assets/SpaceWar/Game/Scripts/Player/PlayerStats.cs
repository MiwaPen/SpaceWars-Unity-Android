using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public Action OnHPChange;
    public Action OnGetDamage;
    public Action OnXpChange;
    public Action OnLose;
    private int _hp;
    private int _maxHp;
    private int _maxLvlXp;
    private int _lvl;
    private int _lvlXp;
    private int _totalXp;
    private ReposBase _reposBase;
    private PlayerGunsController _gun;

    void Awake()
    {
        _reposBase = FindObjectOfType<ReposBase>();
        _gun = this.gameObject.GetComponent<PlayerGunsController>();
    }

    private void LvlUp()
    {
        _lvlXp = _totalXp - (_lvl * _maxLvlXp);
        _lvl += 1;
        SetHPMax();
    }

    public void UpdateXP(int _exp)
    {
        _lvlXp += _exp;
        _totalXp += _exp;
        if (_lvlXp >= _maxLvlXp)
        {
            LvlUp();
        }
        OnXpChange?.Invoke();
    }

    public void UpdateHP(int _damage)
    {
        _hp -= _damage;
        if (_hp <= 0)
        {
            Lose();
        }
        OnGetDamage?.Invoke();
        OnHPChange?.Invoke();
    }

    private void Lose()
    {
        _gun.StopShooting();
        _reposBase.PlayerScoreRepos.SaveScore(_totalXp);
        OnLose?.Invoke();
    }

    private void SetHPMax()
    {
        _hp = _maxHp;
        OnHPChange?.Invoke();
    }

    public void StartGame()
    {
        _maxHp = 100;
        _maxLvlXp = 100;
        _hp = _maxHp;
        _lvl = 1;
        _lvlXp = 0;
        _totalXp = 0;
        _gun.StartShooting();
    }

    public int GetMaxHp()
    {
        return _maxHp;
    }
    public int GetMaxXp()
    {
        return _maxLvlXp;
    }
    public int GetHp()
    {
        return _hp;
    }

    public int GetTotalXp()
    {
        return _totalXp;
    }

    public int GetLvlXp()
    {
        return _lvlXp;
    }
}
