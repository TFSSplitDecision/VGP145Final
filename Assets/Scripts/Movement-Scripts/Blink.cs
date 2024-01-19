using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkDistance = 5f;
    public LayerMask enemyLayer; // Added a public variable to hold the enemy layer
    public bool canBlink = true;
    public GameObject player;
    private Vector3 playerLocation;

    void Start()
    {
        player = gameObject; // Changed to "gameObject" to get the reference to the GameObject this script is attached to
        playerLocation = player.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canBlink) // left mouse button
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3 direction = (mousePosition - transform.position).normalized;

            Vector3 newPosition = transform.position + direction * blinkDistance;

            // Don't allow overshooting the target.
            if (Vector3.Distance(newPosition, transform.position) > Vector3.Distance(mousePosition, transform.position))
            {
                newPosition = mousePosition;
            }

            transform.position = newPosition;
        }
    }

    public Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            return new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
        return Vector3.zero;
    }
}