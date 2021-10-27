using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int enemyHP;
    [SerializeField] private int enemyXP;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float destroyDelay = 1f;
    [SerializeField] private List<BulletCreator> Guns;
    private new Rigidbody rigidbody;
    private PlayerStats player;
    private SoundController soundController;
    private bool canDie = false;
    private TagsHolder tagsHolder = new TagsHolder();

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        soundController = FindObjectOfType<SoundController>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        for (int i = 0; i < Guns.Count; i++)
        {
            Guns[i].SetRotation(tagsHolder.tags[1]);
            Guns[i].StopShooting();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagsHolder.tags[7])
        {
            if (canDie == true)
            {
                soundController.DamageSoundPlay();
                int DMG = other.gameObject.GetComponent<BulletController>().GetBulletDMG();
                UpdateHP(DMG);
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == tagsHolder.tags[4])
        {
            MakeEnemyAlive();
        }

        if (other.gameObject.tag == tagsHolder.tags[5])
        {
            Invoke("EnemyDestroy",destroyDelay);
        }
    }

    private void UpdateHP(int DMG)
    {
        if (enemyHP > 0)
        {
            enemyHP -= DMG;
            if (enemyHP <= 0)
            {
                soundController.explosionPlay();
                player.UpdateXP(enemyXP);
                EnemyDestroy();
            }
        }
    }

    private void MakeEnemyAlive()
    {
        canDie = true;

        for (int i = 0; i < Guns.Count; i++)
        {
            Guns[i].StartShooting();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.transform.position = rigidbody.transform.position + new Vector3(0, -speed*Time.deltaTime, 0);
    }

    private void EnemyDestroy()
    {
        Destroy(this.gameObject);
    }

    public int GetEnemyHP()
    {
        return enemyHP;
    }
}
