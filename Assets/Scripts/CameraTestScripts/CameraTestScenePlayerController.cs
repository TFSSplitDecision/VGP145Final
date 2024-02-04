using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTestScenePlayerController : MonoBehaviour
{
    public CameraController cameraReference;
    public float speed;
    Rigidbody rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float fInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(hInput, 0, fInput).normalized;
        rb.velocity = moveInput * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            StartCoroutine(cameraReference.Shake(0.1f, 2.0f));
    }
}
