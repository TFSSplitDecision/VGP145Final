using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    public float blinkDistance = 5f;
    public LayerMask enemyLayer; // Added a public variable to hold the enemy layer
    public GameObject player;
    private Vector3 playerLocation;
    private MovementManager movementManager;

    void Start()
    {
        player = gameObject;
        playerLocation = player.transform.position;
        movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && movementManager.canBlink) // left mouse button
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

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject);
            return new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
        return Vector3.zero;
    }
}