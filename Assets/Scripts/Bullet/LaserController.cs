using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] private Transform hurtboxOrigin;
    [SerializeField] private Hurtbox hurtbox;


    [SerializeField, ReadOnly] private float lifetime = 0.0f;
    public bool laserActive => lifetime > 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 2;
    }

    public void Shoot(float damage)
    { 

        if (lineRenderer.enabled == false)
            lineRenderer.enabled = true;

        lifetime = 0.25f;
        hurtbox.damage = damage;


    }


    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lineRenderer.enabled && !laserActive)
            lineRenderer.enabled = false;

        if (laserActive)
        {
            UpdateLaserPosition();
        }

        // Turn laser hurtbox on and off each frame to cause OnTriggerEnter continuous damage
        hurtboxOrigin.gameObject.SetActive(laserActive && (Time.frameCount % 2 == 0));
    }

    void UpdateLaserPosition()
    {

        Vector3 groundPoint = InputUtils.groundPoint;

        Vector3 laserStartPoint = transform.position;
        Vector3 laserTargetPoint = groundPoint;
        laserTargetPoint.y = laserStartPoint.y;

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
