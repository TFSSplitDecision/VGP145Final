using UnityEngine;

public class MeleeInput : MonoBehaviour
{
    void Update()
    {
        // Check for right-click input
        if (Input.GetMouseButtonDown(1))
        {
            // Perform melee action (you can replace this with your own logic)
            PerformMeleeAction();

            // Debug a message
            Debug.Log("Melee action performed!");
        }
    }

    void PerformMeleeAction()
    {
        // Replace this with your actual melee action logic
        // For example, you might want to play an animation, deal damage, etc.
        Debug.Log("Melee action logic executed!");
    }
}