using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public event System.Action OnPlayerDied;
    [SerializeField] InputManager inputManager;
    [SerializeField] HealthSystem healthSystem;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject playerObject;

    [SerializeField] Collider2D[] shipColliders;

    Camera activeCamera;
    Rect cameraBounds;

    Vector3 spawnPosition;

    private void Start() 
    {
        activeCamera = Camera.main;    

        Vector3 bottomLeftPosition = activeCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 uppeerRigthPosition = activeCamera.ScreenToWorldPoint
        (new Vector3(activeCamera.pixelWidth, activeCamera.pixelHeight));

        cameraBounds = new Rect(bottomLeftPosition.x, bottomLeftPosition.y,
        uppeerRigthPosition.x - bottomLeftPosition.x,
        uppeerRigthPosition.y - bottomLeftPosition.y);

        healthSystem.OnZeroHealth += HealthSystem_OnZeroHealth;    
    }
        private void OnDestroy() 
    {
        healthSystem.OnZeroHealth -= HealthSystem_OnZeroHealth;     
    }
    bool isPlayerDead;

    public void Respawn()
    {
        transform.position = spawnPosition;
        healthSystem.ResetHP();
        playerObject.SetActive(true);

        isPlayerDead = false;
        SwitchPlayerCollider(true);
    }


    void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        spawnPosition = transform.position;
    }


    private void HealthSystem_OnZeroHealth()
    {
        OnPlayerDied?.Invoke(); 
        playerObject.SetActive(false);
        isPlayerDead = true;
        SwitchPlayerCollider(false);
    }
    private void FixedUpdate() 
    {
        if(isPlayerDead==true)
        {
            return;
        }

        Vector2 movementVector = new Vector2(inputManager.HorizontalInput * speed,
        inputManager.VerticallInput * speed);

        rb2d.AddForce(movementVector);
    }

    private void LateUpdate() 
    {
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, cameraBounds.xMin, cameraBounds.xMax), 
        Mathf.Clamp(transform.position.y, cameraBounds.yMin, cameraBounds.yMax),
        transform.position.z);    
    }

    void SwitchPlayerCollider(bool state)
    {
        foreach(var collider in shipColliders)
        {
            collider.enabled = state;
        }
    }

}