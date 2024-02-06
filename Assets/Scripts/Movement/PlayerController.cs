using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private CharacterController m_charController;
    public enum SpecialType { Dash = 0, Blink = 1 }
    [SerializeField] private SpecialType m_SpecialType;
    public SpecialType specialType => m_SpecialType;

    private Vector3 m_lookTarget;
    public float moveSpeed = 1f;
    public bool isMoving => m_charController.velocity.magnitude > 0.0f;

    [SerializeField] private Dash dash;
    [SerializeField] private Blink blink;
    
    private void Start()
    {
        //Movement
        m_charController = GetComponent<CharacterController>();
        // Initialize dash ability
        dash.Init(gameObject);
        blink.Init(gameObject);
    }

    private void Update()
    {
        // Player Look Mechanics
        m_lookTarget = InputUtils.groundPoint;
        m_lookTarget.y = transform.position.y;
        if (Vector3.Distance(m_lookTarget, transform.position) > 0.1f)
            transform.LookAt(m_lookTarget, Vector3.up);

        // Add some vertical offset
        m_lookTarget += Vector3.up;

        // Movement mechanics
        if (!dash.isDashing)
            MovePlayer();
        
        bool buttonPress = InputUtils.dashed;
        switch (specialType)
        {
            case SpecialType.Dash:

                if (buttonPress)
                    dash.Begin(m_lookTarget);
                // Update dash logic
                dash.Update();
                break;

            case SpecialType.Blink:

                if (dash.isDashing)
                    dash.Cancel();
                if (buttonPress)
                    blink.Begin();
                // Update blink logic
                blink.Update(m_lookTarget);
                break;
        }

    }

    private void MovePlayer()
    {
        Vector3 movement = InputUtils.move3d * moveSpeed;
        m_charController.Move(movement * Time.deltaTime);
    }
    
    #if UNITY_EDITOR
    // Test code. Delete on production.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(m_lookTarget, Vector3.one * 0.1f);
        if( specialType == SpecialType.Blink )
        {
            Gizmos.color = blink.checkHit ? Color.red : Color.green;
            Gizmos.DrawCube(blink.checkPoint, Vector3.one * 0.3f);
        }
    }
#endif
}

