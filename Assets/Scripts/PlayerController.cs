using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb2d;

    Camera activeCamera;
    Rect cameraBounds;

    private void Start() 
    {
        activeCamera = Camera.main;    

        Vector3 bottomLeftPosition = activeCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 uppeerRigthPosition = activeCamera.ScreenToWorldPoint
        (new Vector3(activeCamera.pixelWidth, activeCamera.pixelHeight));

        cameraBounds = new Rect(bottomLeftPosition.x, bottomLeftPosition.y,
        uppeerRigthPosition.x - bottomLeftPosition.x,
        uppeerRigthPosition.y - bottomLeftPosition.y);
    }

    private void FixedUpdate() 
    {
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
}
