using UnityEngine;

public class Hitbox : MonoBehaviour
{
    HealthManager hm;

    // Start is called before the first frame update
    void Start()
    {
        hm = GetComponent<HealthManager>();
    }

    private void OnTriggerEnter(Collider h)
    {
        Hurtbox hurtbox = h.GetComponent<Hurtbox>();

        //if (h.gameObject.CompareTag("HealthGainCollectible"))
        //{

        //}

        if (hurtbox != null && !h.gameObject.CompareTag(gameObject.tag))
        {
            hm.LoseHealth(hurtbox.damage);
        }
    }
}
