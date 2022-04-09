using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooter : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] NormalBullet normalBulletPrefab;
    [SerializeField] Transform[] bulletsPositions;

    private void Update() 
    {
        if(inputManager.ShootInput)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        foreach(var transformPosition in bulletsPositions)
        {
            NormalBullet createBullet = Instantiate<NormalBullet>(normalBulletPrefab, 
            transformPosition.position, Quaternion.identity);
        }

    }

}
