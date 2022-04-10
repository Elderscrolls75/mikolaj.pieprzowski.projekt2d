using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    float xPosition;
    float yMin;
    float yMax;
    float leftXposition;
    void Awake()
    {
        var activeCamera = Camera.main;

        Vector3 bottomLeftPosition = activeCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 uppeerRigthPosition = activeCamera.ScreenToWorldPoint
        (new Vector3(activeCamera.pixelWidth, activeCamera.pixelHeight));

        yMin = bottomLeftPosition.y;
        yMax = uppeerRigthPosition.y;

        leftXposition = bottomLeftPosition.x;

        xPosition = uppeerRigthPosition.x - bottomLeftPosition.x;
        
        TestSpawn();

    }

    private void TestSpawn()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        var enemy = Instantiate<Enemy>(enemyPrefab, new Vector3(xPosition, 
        Random.Range(yMin, yMax), 0), Quaternion.identity);

        enemy.Initialize(leftXposition);
    }
}
