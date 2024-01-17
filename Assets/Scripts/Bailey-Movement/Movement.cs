using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    public float moveSpeed = 1f;

    private void Awake()
    {
      rb = GetComponent<Rigidbody>();  
    }
     

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        rb.MovePosition(rb.position + movement);
    }
}
