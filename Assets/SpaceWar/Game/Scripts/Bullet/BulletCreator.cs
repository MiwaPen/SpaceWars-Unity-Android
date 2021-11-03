using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private BulletController _Bullet;
    [SerializeField] private float _spawnDuration = 1f;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private bool _canShoot = false;
    [SerializeField] private CharEnum _whoShooting;
    private BulletRotation _bulletRotation;
    private SoundController _soundController;

    void Start()
    {
        _soundController = FindObjectOfType<SoundController>();
        InvokeRepeating("CreateBullet", _spawnDuration, _spawnRate);
    }

    private void CreateBullet()
    {
        if (_canShoot == true)
        {
            switch (_whoShooting)
            {
                case CharEnum.Player:
                    _soundController.PlayerShootPlay();
                    break;
                case CharEnum.Enemy:
                    _soundController.EnemyShootPlay();
                    break;
                default:
                    break;
            }
            
            GameObject newBullet = Instantiate(_Bullet.gameObject, this.transform.position, this.transform.rotation);
            newBullet.GetComponent<BulletController>().SetRotation(_bulletRotation);
        }
    }           
    public void ChangeBulletType(BulletController newbullet)
    {
        _Bullet = newbullet;
    }

    public void StartShooting()
    {
        _canShoot = true;
    }

    public void StopShooting()
    {
        _canShoot = false;
    }

    public void SetRotation(BulletRotation bulletRotation)
    {
        this._bulletRotation = bulletRotation;
    }
}
