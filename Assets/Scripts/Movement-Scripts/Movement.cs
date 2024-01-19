using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    
    public float moveSpeed = 1f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        charController.Move(movement * Time.deltaTime);
    }
}

