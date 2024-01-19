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


    protected float cooldown = 1.0f;


    public GameObject prefabTest;

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
    public bool CanCollect()
    {
        if (cooldown > float.Epsilon) return false;
        return true;
    }

    private void OnDestroy()
    {
        // TODO: Item collection visual effects
        // TODO: Play sound
        Instantiate(prefabTest);
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
        cooldown -= Time.deltaTime;
    }
}
