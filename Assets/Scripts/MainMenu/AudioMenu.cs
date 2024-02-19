using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour, IPointerUpHandler {
    [SerializeField]
    private Slider master;
    [SerializeField]
    private Slider music;
    [SerializeField]
    private Slider sound_fx;

    void Start() {
        master.on.AddListener(OnPointerUp);
    }

    // Needs to be invoked when the value of the slider changes.
    public void OnPointerUp(PointerEventData data) {
        
    }
}
