using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    public enum SpecialType { Dash = 0, Blink = 1 }

    private CharacterController m_charController;
    public float moveSpeed = 1f;
    public bool isMoving => m_charController.velocity.magnitude > 0.0f;


    [SerializeField] private SpecialType m_SpecialType;
    public SpecialType specialType => m_SpecialType;


    [SerializeField] private Dash dash;
    [SerializeField] private Blink blink;


    private void Start()
    {
        //Movement
        m_charController = GetComponent<CharacterController>();
        //movementManager = GetComponent<MovementManager>();

        // Initialize dash ability
        dash.Init(gameObject);
        blink.Init(gameObject);
    }



    private void Update()
    {
        // Movement mechanics

        transform.LookAt(GetScreenToWorld(), Vector3.up);
        if (!dash.isDashing)
        {
            MovePlayer();
        }

        bool buttonPress = Input.GetButtonDown("Fire1");
        switch (specialType)
        {
            case SpecialType.Dash:

                if (buttonPress)
                    dash.Begin();

                // Update dash logic
                dash.Update();
                break;

            case SpecialType.Blink:

                if (dash.isDashing)
                    dash.Cancel();

                if (buttonPress)
                    blink.Begin();

                // Update blink logic
                blink.Update();
                break;
        }

    }

    private void MovePlayer()
    {
        // TODO: Use Input utils after this is merged with main branch
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        m_charController.Move(movement * Time.deltaTime);
    }
   
    //Player look
    private Vector3 GetScreenToWorld()
    {
        Camera camera = Camera.main;
        Vector3 inputMouse = Input.mousePosition;
        Vector3 mousePos = camera.ScreenToWorldPoint(new Vector3(inputMouse.x, inputMouse.y, camera.transform.position.y));
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

        if( specialType == SpecialType.Blink )
        {
            Gizmos.color = blink.checkHit ? Color.red : Color.green;
            Gizmos.DrawCube(blink.checkPoint, Vector3.one);
        }
    }
#endif
}

