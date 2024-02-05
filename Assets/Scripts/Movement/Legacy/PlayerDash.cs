using System.Collections;
using UnityEngine;

public class PlayerDashDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDistance = 5f;
    public float dashCooldownTime = 2f;
    public int maxDashCharges = 3;
    private Vector3 dashDirection;
    private Vector3 dashStartPosition;
    private CharacterController charController;
    private MovementManager movementManager;
    
    private Coroutine recovery;


    private void Start()
    {
        charController = GetComponent<CharacterController>();
        movementManager = GetComponent<MovementManager>();
        movementManager.currentDashCharges = maxDashCharges;

        StartCoroutine(Recovery());
    }

    private void Update()
    {
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
}