using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private BulletController Bullet;
    [SerializeField] private float spawnDuration = 1f;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canShoot = false;
    [SerializeField] private string rotation = null;
    [SerializeField] private string whoShooting = "";
    private SoundController soundController;

    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        InvokeRepeating("CreateBullet", spawnDuration, spawnRate);
    }

    private void CreateBullet()
    {
        if (canShoot==true)
        {
            switch (whoShooting)
            {
                case "Player":
                    soundController.PlayerShootPlay();
                    break;
                case "Enemy":
                    soundController.EnemyShootPlay();
                    break;
                default:
                    break;
            }
            
            GameObject newBullet = Instantiate(Bullet.gameObject, this.transform.position, this.transform.rotation);
            newBullet.GetComponent<BulletController>().SetRotation(rotation);
        }
    }           
    public void ChangeBulletType(BulletController newbullet)
    {
        Bullet = newbullet;
    }

    public void StartShooting()
    {
        canShoot = true;
    }

    public void StopShooting()
    {
        canShoot = false;
    }

    public void SetRotation(string rot)
    {
        rotation = rot;
    }
}
