using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    //Attach the camera to this in the inspector
    Camera mainCamera;

    //Change these values in the inspector to represent the proper bounds of the level
    //Values are temporary for the given test scene
    public float minXClamp;
    public float maxXClamp;
    public float minZClamp;
    public float maxZClamp;

    //This is for camera smoothness
    public float cameraSpeed;

    //Attach player object in inspector
    public GameObject playerObject;

    private bool shake;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (playerObject == null) return;
        Vector3 cameraPos;

        cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(playerObject.transform.position.x, minXClamp, maxXClamp);
        cameraPos.z = Mathf.Clamp(playerObject.transform.position.z, minZClamp, maxZClamp);
        transform.position = Vector3.Lerp(transform.position, cameraPos, cameraSpeed * Time.deltaTime);
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            shake = true;
            float x = UnityEngine.Random.Range(-1.0f, 1.0f) * magnitude;
            float y = UnityEngine.Random.Range(-1.0f, 1.0f) * magnitude;
            float z = UnityEngine.Random.Range(-1.0f, 1.0f) * magnitude;

            Vector3 shakePosition = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
            transform.position = shakePosition;

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = Vector3.Lerp(transform.position, originalPosition, 0.1f);
        shake = false;
    }
}
