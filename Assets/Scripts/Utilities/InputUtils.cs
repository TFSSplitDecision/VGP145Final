using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

/// <summary>
/// Input Utilities. A core system that stores input name constants.
/// That way, fixes to input names are constrained within this script.
/// It also has helper functions for checking game actions.
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
    /// Private Constructor: Disallows the creation of instances of this script.
    /// InputUtils is meant to be used as a public static class after all
    /// </summary>
    private InputUtils() { }

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


    public static bool primaryFired => Input.GetButtonDown(primaryFire);
    public static bool primaryFiring => Input.GetButton(primaryFire);
    public static bool primaryReleased => Input.GetButtonUp(primaryFire);
    public static bool secondaryFired => Input.GetButtonDown(secondaryFire);
    public static bool secondaryFiring => Input.GetButton(secondaryFire);
    public static bool secondaryReleased => Input.GetButtonUp(secondaryFire);
    public static bool pickedUp => Input.GetButtonDown(pickup);
    public static bool dashed => Input.GetButtonDown(dash);
    public static bool dashing => Input.GetButton(dash);



    /// <summary>
    /// Simply returns the mouse position in screen space
    /// </summary>
    public static Vector2 mousePos => Input.mousePosition;


    /// <summary>
    /// Borrowed from Parker's 'PlayerLookScript' code.
    /// It returns a point around the player somehow projected by the mouse.
    /// This seems to be a very efficient type of code that runs under the restrictions
    /// of our camera system.
    /// </summary>
    /// <param name="ypos"></param>
    /// <returns></returns>
    public static Vector3 ScreenToWorld( float ypos = 0.0f )
    {
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        Vector3 screenPos = InputUtils.mousePos;
        Vector3 point = new Vector3(screenPos.x, screenPos.y, cameraPos.y);

        Vector3 worldPos = camera.ScreenToWorldPoint(point);
        worldPos.y = ypos;
        return worldPos;
    }

    /// <summary>
    /// Projects the mouse position onto the infinite ground plane,
    /// and returns that point in world space.
    /// </summary>
    public static Vector3 groundPoint
    {
        get
        {
            Camera camera = Camera.main;
            Vector3 cameraPos = camera.transform.position;
            Vector3 screenPos = InputUtils.mousePos;

            Ray ray = camera.ScreenPointToRay(screenPos);
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            float t = 0.0f;
            if( plane.Raycast( ray, out t ) )
            {
                Vector3 worldPos = ray.GetPoint(t);
                return worldPos;
            }

            // fallback in case the mouse is pointed above the horizon
            return ScreenToWorld();
        }
    }




}
