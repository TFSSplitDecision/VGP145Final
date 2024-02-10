using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testplayercont : MonoBehaviour
{
    public float speed;
    CharacterController cc;

    public float gravity = 9.81f;
    public float jumpSpeed = 11.0f;
    public float YVelocity;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            cc = GetComponent<CharacterController>();
            if (speed < 0)
            {
                speed = 30f;
                throw new ArgumentException("Default Value has been set for scene.");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.ToString());
        }
        catch (ArgumentException e)
        {
            Debug.Log(e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {


        float hinput = Input.GetAxisRaw("Horizontal");
        float fInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(hinput, 0, fInput).normalized;
        moveInput *= speed * Time.deltaTime;
        if (!cc.isGrounded) YVelocity -= gravity * Time.deltaTime;

        if (cc.isGrounded && Input.GetButtonDown("Jump")) { YVelocity = jumpSpeed; }

        moveInput.y = YVelocity;
        cc.Move(moveInput);

    }
}
