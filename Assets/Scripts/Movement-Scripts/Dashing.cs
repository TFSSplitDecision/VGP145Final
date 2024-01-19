using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDistance = 5f;
    public float dashCooldownTime = 2f;
    public int maxDashCharges = 3;

    private int currentDashCharges;
    private bool isDashing;
    private Vector3 dashDirection;
    private Vector3 dashStartPosition;
    private CharacterController charController;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        currentDashCharges = maxDashCharges;
    }

    private void Update()
    {
        if (isDashing == false)
        {
            dashStartPosition = transform.position;
            Debug.Log("Dash Position: " + transform.position);
        }

        if (Input.GetButtonDown("Fire1") && currentDashCharges > 0 && !isDashing)
        {
            var mousePosition = GetMouseWorldPosition();
            mousePosition.y = transform.position.y;
            dashDirection = (mousePosition - transform.position).normalized;
            StartCoroutine(Dash());
        }
    }

  private IEnumerator Dash()
{
    isDashing = true;
    currentDashCharges--;

    float dashTimer = 0f;
    float initialDistance = Vector3.Distance(dashStartPosition, transform.position);

    while (dashTimer < dashCooldownTime)
    {
        charController.Move(dashDirection * dashSpeed * Time.deltaTime);

        // Check if the player has reached or exceeded the dash distance
        float currentDistance = Vector3.Distance(dashStartPosition, transform.position);
        if (currentDistance >= initialDistance + dashDistance)
        {
            break; // Exit the loop if the dash distance is reached
        }

        dashTimer += Time.deltaTime;
        yield return null;
    }

    isDashing = false;

    if (currentDashCharges < maxDashCharges)
        currentDashCharges++;
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