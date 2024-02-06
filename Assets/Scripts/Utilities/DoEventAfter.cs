using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Allows the devs to add a list of events to be executed after a certain amount of time.
/// After that time has passed the script is destroyed.
/// </summary>
public class DoEventAfter : MonoBehaviour
{

    [SerializeField, SceneEditOnly] private float m_delay = 3.0f;
    [SerializeField] private UnityEvent m_event;
    private float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, m_delay);
    }

    private void OnDestroy()
    {
        m_event.Invoke();
    }
}
