using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GetScreenToWorld(), Vector3.up);
    }

    private Vector3 GetScreenToWorld()
    {
        Vector3 inputMouse = Input.mousePosition;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(new Vector3(inputMouse.x, inputMouse.y, mainCamera.transform.position.y));
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
    }
#endif

}
