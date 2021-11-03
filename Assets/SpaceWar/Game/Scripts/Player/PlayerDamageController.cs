using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    private PlayerStats _stats;
    private void Awake()
    {
        _stats = this.gameObject.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagsHolder.EnemyBullet)
        {
            int _damage = other.gameObject.GetComponent<BulletController>().GetBulletDMG();
            _stats.UpdateHP(_damage);
        }
        if (other.gameObject.tag == TagsHolder.Enemy)
        {
            int _damage = other.gameObject.GetComponent<EnemyController>().GetEnemyHP();
            _stats.UpdateHP(_damage);
            Destroy(other.gameObject);
        }
    }
}
