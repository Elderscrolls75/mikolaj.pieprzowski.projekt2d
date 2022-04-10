using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] Enemy enemyPrefab;
    float xPosition;
    float yMin;
    float yMax;
    float leftXposition;
    void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        var activeCamera = Camera.main;

        Vector3 bottomLeftPosition = activeCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 uppeerRigthPosition = activeCamera.ScreenToWorldPoint
        (new Vector3(activeCamera.pixelWidth, activeCamera.pixelHeight));

        yMin = bottomLeftPosition.y;
        yMax = uppeerRigthPosition.y;

        leftXposition = bottomLeftPosition.x;

        xPosition = uppeerRigthPosition.x - bottomLeftPosition.x;

    }

    public void SpawnEnemy()
    {
        var enemy = Instantiate<Enemy>(enemyPrefab, new Vector3(xPosition, 
        Random.Range(yMin, yMax), 0), Quaternion.identity);

        enemy.Initialize(leftXposition);
    }
}
