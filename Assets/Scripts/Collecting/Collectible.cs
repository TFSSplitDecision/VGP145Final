using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [Tooltip("The attached item data")]
    public Equipment equipment;

    [Tooltip("Target tag. Minimizes uncessasary trigger checks.")]
    [SerializeField]
    protected string targetTag = "Player";




    // Start is called before the first frame update
    void Start()
    {
        // TODO: Ensure there's a rigid body. Make rigid body kinematic
        // TODO: Ensure that all colliders are set to trigger
    }

    /// <summary>
    /// Checks if the item can be collected at the moment
    /// </summary>
    /// <returns></returns>
    protected bool canCollect()
    {
        return true;
    }

    /// <summary>
    /// Finalizes object collection.
    /// </summary>
    /// <param name="owner"></param>
    /// <returns>Returns true if item is collected succesfully. Returns false otherwise.</returns>
    public bool Collect( GameObject owner )
    {
        if (!canCollect()) return false;

        // Success! Collect object
        equipment.Pickup(owner);

        // TODO: Item collection visual effects
        // TODO: Play sound

        Destroy(gameObject);

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collector collector = other.GetComponent<Collector>();
        if (collector == null) return;
        collector.Notify(this);
    }

    private void OnTriggerExit(Collider other)
    {
        Collector collector = other.GetComponent<Collector>();
        if (collector == null) return;
        collector.Forget(this);
    }

    void Update()
    {
        // Item animations go here
    }
}
