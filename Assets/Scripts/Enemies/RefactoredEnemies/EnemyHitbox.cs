using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    EnemyManager em;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter(Collider h)
    {
        Hurtbox hurtbox = h.GetComponent<Hurtbox>();

        if (hurtbox != null && !h.gameObject.CompareTag(gameObject.tag))
        {
            em.LoseHealth(hurtbox.damage);
        }
    }

}
