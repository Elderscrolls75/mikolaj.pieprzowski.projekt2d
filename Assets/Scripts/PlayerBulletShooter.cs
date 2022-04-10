using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShooter : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField] InputManager inputManager;
    [SerializeField] Bullet normalBulletPrefab;
    [SerializeField] Transform[] bulletsPositions;

    bool areWeaponsDisabled = true;

    private void PlayerController_OnPlayerDied()
    {
        areWeaponsDisabled = true;
    }

    private void PlayerController_OnPlayerRespawned()
    {
        areWeaponsDisabled = false;
    } 

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
