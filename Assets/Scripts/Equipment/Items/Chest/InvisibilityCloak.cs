using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/InvisibilityCloak", order = 9)]
public class InvisibilityCloak : Chest {
    private Coroutine cor;
    [Header("Invisiblity Cloak"),SerializeField]
    private float invisibleTime = 4f;
    [SerializeField]
    private float cooldown = 10f;
    private bool _isInvisible = false;
    private bool isInvisible {
        set => im.SendMessage("setInvisible", _isInvisible = value);
        get => _isInvisible;
    }
    public override void onEquip() {
        if (cor != null)
            im.StopCoroutine(cor);
        cor = im.StartCoroutine(coroutine());
    }

    public override void onUnequip() {
        if (cor != null)
            im.StopCoroutine(cor);
        if (isInvisible)
            isInvisible = false;
    }

    private IEnumerator coroutine() {
        while (true) {
            yield return new WaitForSeconds(cooldown);
            isInvisible = true;
            yield return new WaitForSeconds(invisibleTime);
            isInvisible = false;
        }
    }
}
