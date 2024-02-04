using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input Utilities.
/// Stores input name constants and input utilities.
/// Will be adding more functions later on.
/// </summary>
public class InputUtils
{
    private static readonly string horizontal = "Horizontal";
    private static readonly string vertical = "Vertical";
    private static readonly string primaryFire = "Fire1";
    private static readonly string secondaryFire = "Fire2";
    private static readonly string dash = "Jump";
    private static readonly string pickup = "Enter";

    /// <summary>
    /// Gets movement input. 
    /// Ensures that the vector doesn't have length greater than 1.
    /// </summary>
    public static Vector3 move3d
    {
        get
        {
            float haxis = Input.GetAxis(horizontal);
            float vaxis = Input.GetAxis(vertical);
            Vector3 movement = new Vector3(haxis, 0.0f, vaxis);
            if (movement.magnitude > 1.0f) movement.Normalize();
            return movement;
        }
    }

}
