using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    float spawnInterval = 1.5f;
    float currentTime;
    float spawnedShips = 0;
    public override void EnterState(StateMachine myStateMachine)
    {
        base.EnterState(myStateMachine);

        currentTime = spawnInterval;

        PlayerController.Instance.OnPlayerDied += PlayerInstance_OnPlayerDied;
        PlayerController.Instance.Respawn();

        var enemies = GameObject.FindObjectsOfType<Enemy>();
        var bullets = GameObject.FindObjectsOfType<Bullet>();

        foreach(var enemy in enemies)
        {
            enemy.DestroyEnemy();
        }
        foreach(var bullet in bullets)
        {
            bullet.DestroyBullets();
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();

        currentTime -= Time.deltaTime;

        if(currentTime < 0f)
        {
            EnemySpawner.Instance.SpawnEnemy();
            currentTime = spawnInterval;
            spawnedShips++;

            if(spawnedShips==4)
            {
                myStateMachine.EnterState(new LoseState());
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        PlayerController.Instance.OnPlayerDied -= PlayerInstance_OnPlayerDied;
    }

    private void PlayerInstance_OnPlayerDied()
    {
        myStateMachine.EnterState(new LoseState());
    }




}
