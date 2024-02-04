using UnityEngine;


/// <summary>
/// A self-destruction script: It destroys the gameobject after a certain amount of time passes.
/// This is useful for cleaning up entities to prevent scene cluttering. Especially for things like:
/// bullets and visual effects.
/// </summary>
public class DestroyAfter : MonoBehaviour
{
    [SerializeField, SceneEditOnly] private float m_delay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_delay);
    }
}
