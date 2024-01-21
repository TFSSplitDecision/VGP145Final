using System.Collections;
using UnityEngine;

public class PlayerDashDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDistance = 5f;
    public float dashCooldownTime = 2f;
    public int maxDashCharges = 3;
    public bool isDashing;
    private Vector3 dashDirection;
    private Vector3 dashStartPosition;
    private CharacterController charController;
    private MovementManager movementManager;
    

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        movementManager = GetComponent<MovementManager>();
        movementManager.currentDashCharges = maxDashCharges;
    }

    private void Update()
    {
        if (isDashing == false)
        {
            dashStartPosition = transform.position;
            // Debug.Log("Dash Position: " + transform.position);
        }

        if (Input.GetButtonDown("Fire1") && movementManager.currentDashCharges > 0 && !movementManager.isDashing)
        {
            var mousePosition = GetMouseWorldPosition();
            mousePosition.y = transform.position.y;
            dashDirection = (mousePosition - transform.position).normalized;
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        movementManager.isDashing = true;
        movementManager.currentDashCharges--;

        float dashTimer = 2f;
        float initialDistance = Vector3.Distance(dashStartPosition, transform.position);

        while (dashTimer < dashCooldownTime)
        {
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

        isDashing = false;

        if (movementManager.currentDashCharges < maxDashCharges)
            movementManager.currentDashCharges++;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}