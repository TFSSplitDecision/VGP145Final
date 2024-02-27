using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Attach the camera to this in the inspector
    Camera mainCamera;

    //Change these values in the inspector to represent the proper bounds of the level
    //Values are temporary for the given test scene
    public float minXClamp;
    public float maxXClamp;
    public float minZClamp;
    public float maxZClamp;

    //cameraZ is for the distance away from the player
    public float cameraZ;

    //This is to get the correct height of the camera
    public float cameraHeight;

    //This is to get the correct angle of the camera, I initially set this to be 45
    public float cameraAngle;

    //This is for camera smoothness
    public float cameraSpeed;

    //Attach player object in inspector
    public GameObject playerObject;

    private bool shake;
    private MapCamera mapCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mapCamera = FindObjectOfType<MapCamera>();

        if (!mapCamera) Debug.Log("Map Camera Not Found");
    }

    private void LateUpdate()
    {
        if (playerObject == null) return;
        Vector3 cameraPos;

        cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(playerObject.transform.position.x, minXClamp, maxXClamp);
        cameraPos.y = cameraHeight;
        cameraPos.z = Mathf.Clamp(playerObject.transform.position.z + cameraZ, minZClamp, maxZClamp);
        transform.position = Vector3.Lerp(transform.position, cameraPos, cameraSpeed * Time.deltaTime);

        Quaternion newRotation = Quaternion.Euler(cameraAngle, 0.0f, 0.0f);
        if (!shake) transform.rotation = newRotation;
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        mapCamera.StartCoroutine(Shake(duration, magnitude));
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
