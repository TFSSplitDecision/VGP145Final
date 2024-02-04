using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    private MovementManager movementManager;
    public float moveSpeed = 1f;
    public bool isMoving;

    private void Start()
    {
        //Movement
        charController = GetComponent<CharacterController>();
        movementManager = GetComponent<MovementManager>();
        //Player look
        mainCamera = Camera.main;
        //Dashing
        movementManager.currentDashCharges = maxDashCharges;

        StartCoroutine(Recovery());
    }

    private void Update()
    {
        CheckIfMoving();
        transform.LookAt(GetScreenToWorld(), Vector3.up);
        if(!movementManager.isDashing)
        {
            MovePlayer();
        }

        if (movementManager.isDashing == false)
        {
            dashStartPosition = transform.position;
            // Debug.Log("Dash Position: " + transform.position);
        }

        bool buttonPressed = Input.GetButtonDown("Fire1");
        bool hasRemainingDashes = movementManager.currentDashCharges > 0;
        bool notDashing = !movementManager.isDashing;
        if( buttonPressed )
        {
            Debug.Log("HasRemainingDashes: " + hasRemainingDashes);
            Debug.Log("notDashing: " + notDashing);
            if (hasRemainingDashes && notDashing)
            {
                var mousePosition = GetMouseWorldPosition();
                mousePosition.y = transform.position.y;
                dashDirection = (mousePosition - transform.position).normalized;
                StartCoroutine(Dash());
            }
        }

        
        if(notDashing)
        {
            // Recovery
        }
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        charController.Move(movement * Time.deltaTime);
    }
    //Movement
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
    //Dash
    private IEnumerator Dash()
    {
        movementManager.isDashing = true;
        movementManager.currentDashCharges--;

        float dashTimer = 0f;
        float initialDistance = Vector3.Distance(dashStartPosition, transform.position);

        while (dashTimer < dashCooldownTime)
        {
            Debug.Log("Entered dash loop");
            charController.Move(dashDirection * dashSpeed * Time.deltaTime);

            // Check if the player has reached or exceeded the dash distance
            float currentDistance = Vector3.Distance(dashStartPosition, transform.position);
            if (currentDistance >= initialDistance + dashDistance)
            {
                break;
            }

            dashTimer += Time.deltaTime;
            yield return null;
        }

        movementManager.isDashing = false;

        //if (movementManager.currentDashCharges < maxDashCharges)
         //   movementManager.currentDashCharges++;
        // StartCoroutine(Recovery() );
    }

    private IEnumerator Recovery( )
    {

        while (true)
        {
            if (movementManager.currentDashCharges >= maxDashCharges)
            {
                yield return null;
                continue;
            }

            float delay = 3;
            yield return new WaitForSeconds(delay);

            movementManager.currentDashCharges++;
        }

    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject);
            return hit.point;
        }
        return Vector3.zero;
    }
    //Player look
    private Vector3 GetScreenToWorld()
    {
        Vector3 inputMouse = Input.mousePosition;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(new Vector3(inputMouse.x, inputMouse.y, mainCamera.transform.position.y));
        mousePos.y = transform.position.y;
        return mousePos;
    }

    #if UNITY_EDITOR
    // Test code. Delete on production.
    private void OnDrawGizmos()
    {
        Vector3 point = GetScreenToWorld();
        Gizmos.color = Color.green;
        Gizmos.DrawCube(point, Vector3.one * 0.1f);
    }
#endif
}

