using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour, IPointerUpHandler {
    private Slider _focus;
    private Slider focus {
        get {
            if (_focus == null) _focus = GetComponent<Slider>();
            return _focus;
        }
    }
    public readonly UnityEvent<float> myEvent = new UnityEvent<float>();
    public void OnPointerUp(PointerEventData eventData) {
        myEvent.Invoke(focus.value);
    }
    public void SetSlideValue(float val) {
        focus.value = val;
    }
}
