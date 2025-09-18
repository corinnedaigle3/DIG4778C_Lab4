using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;



public class Player : MonoBehaviour
{
  
    public PlayerInputActions playerInputActions;
    public Camera cam;

    private float speed = 6f;
   

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
      
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    void Movement()
    {
        Vector2 playerInput = playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(playerInput.x, playerInput.y, 0f);
        transform.position += move * speed * Time.deltaTime;

        if (move.magnitude > 0.01f)
        {
            cam.Widangle();
        }
        else
        {
            cam.Original();
        }

    }


}
