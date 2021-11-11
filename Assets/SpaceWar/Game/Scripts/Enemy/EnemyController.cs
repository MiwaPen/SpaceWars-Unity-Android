using UnityEngine;
using System.Collections.Generic;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _enemyHp;
    [SerializeField] private int _enemyXp;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _destroyDelay = 1f;
    [SerializeField] private List<BulletCreator> _guns;
    private  Rigidbody _rigidbody;
    private PlayerStats _player;
    private SoundController _soundController;
    private bool _canDie = false;

    private void Start()
    {
        _player = FindObjectOfType<PlayerStats>();
        _soundController = FindObjectOfType<SoundController>();
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        for (int i = 0; i < _guns.Count; i++)
        {
            _guns[i].SetRotation(BulletRotation.Down);
            _guns[i].StopShooting();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == TagsHolder.PlayerBullet)
        {
            if (_canDie == true)
            {
                _soundController.DamageSoundPlay();
                int DMG = other.gameObject.GetComponent<BulletController>().GetBulletDMG();
                UpdateHP(DMG);
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == TagsHolder.EnemyUnlockTrigget)
        {
            MakeEnemyAlive();
        }

        if (other.gameObject.tag == TagsHolder.BottomBorder)
        {
            Invoke("EnemyDestroy", _destroyDelay);
        }
    }

    private void UpdateHP(int damage)
    {
        if (_enemyHp > 0)
        {
            _enemyHp -= damage;
            if (_enemyHp <= 0)
            {
                _soundController.explosionPlay();
                _player.UpdateXP(_enemyXp);
                EnemyDestroy();
            }
        }
    }

    private void MakeEnemyAlive()
    {
        _canDie = true;

        for (int i = 0; i < _guns.Count; i++)
        {
            _guns[i].StartShooting();
        }
    }

    private void Update()
    {
        _rigidbody.transform.position = _rigidbody.transform.position + new Vector3(0, -_speed * Time.deltaTime, 0);
    }

    private void EnemyDestroy()
    {
        Destroy(this.gameObject);
    }

    public int GetEnemyHP()
    {
        return _enemyHp;
    }
}
