using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooter : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Bullet normalBulletPrefab;
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
            Bullet createBullet = Instantiate<Bullet>(normalBulletPrefab, 
            transformPosition.position, Quaternion.identity);

            createBullet.Shoot(Vector3.right);
        }

    }

}
