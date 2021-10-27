using System.Collections.Generic;
using UnityEngine;

public class PlayerGunsController : MonoBehaviour
{
    [SerializeField] private List<BulletCreator> Guns;
    private TagsHolder tagsHolder = new TagsHolder();

    private void Awake()
    {
        foreach(BulletCreator gun in Guns)
        {
            gun.SetRotation(tagsHolder.tags[2]);
        }
    }
    public void StartShooting()
    {
        foreach (BulletCreator gun in Guns)
        {
            gun.StartShooting();
        }
    }

    public void StopShooting()
    {
        foreach (BulletCreator gun in Guns)
        {
            gun.StopShooting();
        }
    }

    public void ChangeWeapons(int lvl)
    {
        switch (lvl)
        {
            case 1:
                Debug.Log(lvl);
                break;
            case 2:
                Debug.Log(lvl);
                break;
            case 3:
                Debug.Log(lvl);
                break;
            case 4:
                Debug.Log(lvl);
                break;
            default:
                Debug.Log(lvl);
                break;
        }
    }
}
