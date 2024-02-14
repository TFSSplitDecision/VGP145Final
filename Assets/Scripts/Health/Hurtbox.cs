using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hurtbox : MonoBehaviour
{
    public float damage;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
    }
}
