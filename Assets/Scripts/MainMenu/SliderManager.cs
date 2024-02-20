using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour, IPointerUpHandler {
    private Slider focus;
    public readonly UnityEvent<float> myEvent = new UnityEvent<float>();

    void Start() {
        focus = GetComponent<Slider>();
    }
    public void OnPointerUp(PointerEventData eventData) {
        myEvent.Invoke(focus.value);
    }
    public void SetSlideValue(float val) {
        focus.value = val;
    }
}
