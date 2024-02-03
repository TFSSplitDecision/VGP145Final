using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    private MovementManager movementManager;
    private InventoryManager inventoryManager;
    public float moveSpeed = 1f;
    public bool isMoving;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        movementManager = GetComponent<MovementManager>();
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        CheckIfMoving();

        if(!movementManager.isDashing)
        {
            MovePlayer();
        }

        inventoryManager.getMoveSpeedMultiply();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        charController.Move(movement * Time.deltaTime);
    }
    
    private void CheckIfMoving()
    {
        movementManager.isMoving = charController.velocity.magnitude > 0;

        // if(isMoving)
        // {
        //     Debug.Log("Moving");
        // }
        // else
        // {
        //     Debug.Log("Not moving");
        // }
    }
}

