using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform playerTransform;
    public LayerMask obstacleLayerMask;

    public Transform hurtboxOrigin;
    public Hurtbox hurtbox;

    private bool laserActive => laserLifetime > 0.0f;

    private float laserLifetime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 2;
    }

    public void Shoot(float damage)
    {
        laserLifetime = 0.1f;
        hurtbox.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        laserLifetime -= Time.deltaTime;
        lineRenderer.enabled = laserActive;

        if (laserActive)
        {
            UpdateLaserPosition();
        }

        // Turn laser hurtbox on and off each frame to cause OnTriggerEnter continuous damage
        hurtboxOrigin.gameObject.SetActive( laserActive && (Time.frameCount % 2 == 0) );
    }

    void UpdateLaserPosition()
    {

        Vector3 groundPoint = InputUtils.groundPoint;

        Vector3 playerPos = playerTransform.position;
        Vector3 laserStartPoint = playerPos + Vector3.up;
        Vector3 laserTargetPoint = groundPoint + Vector3.up;

        Vector3 laserDirection = laserTargetPoint - laserStartPoint;    
        RaycastHit hit;

        if (Physics.Raycast(laserStartPoint, laserDirection, out hit, Mathf.Infinity, obstacleLayerMask))
        {
            laserTargetPoint = hit.point;
        }
        lineRenderer.SetPosition(0, laserStartPoint);
        lineRenderer.SetPosition(1, laserTargetPoint);

        float laserLength = Vector3.Distance(laserStartPoint, laserTargetPoint);
        laserLength = Mathf.Clamp(laserLength, 0.0f, 1000.0f);

        // Scale the hurt box so that it matches with the laser
        hurtboxOrigin.transform.localScale = new Vector3(1, 1, laserLength);
    }

}
