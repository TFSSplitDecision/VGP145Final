using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

[System.Serializable]
public class Blink
{

    private GameObject m_owner;
    private Transform m_transform;
    private CharacterController m_charController;


    [Header("Parameters")]
    [SerializeField] private float m_blinkDistance = 5f;
    [SerializeField] private float m_blinkCooldown = 3.0f;
    [SerializeField] private LayerMask m_solidLayers;


    [Header("Live Variables")]
    [SerializeField, ReadOnly] private float m_lastBlink;
    [SerializeField, ReadOnly] private Vector3 m_blinkPoint;
    [SerializeField, ReadOnly] private bool m_checkHit;


    public Vector3 blinkPoint => m_blinkPoint;
    public bool checkHit => m_checkHit;
    private Vector3 m_checkPoint;
    public Vector3 checkPoint => m_checkPoint;


    /// <summary>
    /// Use this in place of a constructor! 
    /// Serialized classes in the inspector of a Monobehavior are constructed automatically by the engine.
    /// Thus, construction will reset the inspector values of Dash set during editing.
    /// </summary>
    /// <param name="owner"></param>
    public void Init(GameObject owner)
    {
        m_owner = owner;
        m_transform = owner.transform;
        m_charController = owner.GetComponent<CharacterController>();
        m_lastBlink = 100.0f;
    }
    
    /// <summary>
    /// Checks to see if point is occupied by another collider.
    /// Similar to EnemyCheck logic.
    /// TODO: Consider replacing this with an external utility.
    /// </summary>
    /// <param name="point"></param>
    /// <returns>true if there's something in that position </returns>
    private bool Check(Vector3 point, float size)
    {
        bool hit = Physics.CheckSphere(point, size, m_solidLayers, QueryTriggerInteraction.Ignore);
        return hit;
    }
    
    public void Begin()
    {

        // Cool down check and collision check
        if (m_lastBlink < m_blinkCooldown) return;
        if (m_checkHit) return;

        // Update position
        m_lastBlink = 0.0f;
        m_charController.enabled = false;
        m_transform.position = m_blinkPoint;
        m_charController.enabled = true;

    }

    /// <summary>
    /// This should be called by the owner everyframe
    /// </summary>
    public void Update( Vector3 targetPoint )
    {
        m_lastBlink += Time.deltaTime;

        // Calculate blink target position
        Vector3 myPos = m_transform.position;
        Vector3 direction = (targetPoint - myPos).normalized;

        m_blinkPoint = myPos + direction * m_blinkDistance;
        float maxDistance = Vector3.Distance(m_blinkPoint, myPos);
        float actualDistance = Vector3.Distance(targetPoint, myPos);
        if (maxDistance > actualDistance) m_blinkPoint = targetPoint;

        // Check if its possible to blink to that position
        // Raise collider a bit up so that it doesn't accidentally hit the ground
        m_checkPoint = m_blinkPoint + Vector3.up*0.5f;
        m_checkHit = Check(checkPoint, 1.0f);
    }

}
