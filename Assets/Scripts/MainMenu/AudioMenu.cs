using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour, IPointerUpHandler {
    [SerializeField, ReadOnly]
    private Slider test;
    void Start() {
        test = GetComponent<Slider>();
    }

    // Invoked when the value of the slider changes.
    public void OnPointerUp(PointerEventData data) {
        Debug.Log(test.value);
    }
}
