using System.Collections.Generic;
using UnityEngine;

public class PlayerGunsController : MonoBehaviour
{
    [SerializeField] private List<BulletCreator> _gun;

    private void Awake()
    {
        foreach(BulletCreator gun in _gun)
        {
            gun.SetRotation(BulletRotation.Up);
        }
    }
    public void StartShooting()
    {
        foreach (BulletCreator gun in _gun)
        {
            gun.StartShooting();
        }
    }

    public void StopShooting()
    {
        foreach (BulletCreator gun in _gun)
        {
            gun.StopShooting();
        }
    }
}
