using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple test script.
/// Click to play given sound clip.
/// </summary>
public class SFXTester : MonoBehaviour
{

    public SFXClip sfxTest;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Fire1") )
        {
            SFXManager.Play(sfxTest);
        }
    }
}
