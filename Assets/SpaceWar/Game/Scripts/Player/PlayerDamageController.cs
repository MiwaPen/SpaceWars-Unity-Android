using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    private PlayerStats stats;
    private TagsHolder tagsHolder = new TagsHolder();
    private void Awake()
    {
        stats = this.gameObject.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagsHolder.tags[3])
        {
            int DMG = other.gameObject.GetComponent<BulletController>().GetBulletDMG();
            stats.UpdateHP(DMG);
        }
        if (other.gameObject.tag == tagsHolder.tags[8])
        {
            int DMG = other.gameObject.GetComponent<EnemyController>().GetEnemyHP();
            stats.UpdateHP(DMG);
            Destroy(other.gameObject);
        }
    }
}
