using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/AbsorptionArmour", order = 8)]
public class AbsorptionArmour : Chest {
    private Coroutine cor;
    [SerializeField]
    private float absorbPercent = 0.5f;
    /// <summary>
    /// Absorbtion armor will set it's absorbtion value at the frame of hit (and reset it back to normal)
    /// </summary>
    /// <returns></returns>
    protected override void onHit() {
        if (cor == null)
            cor = im.StartCoroutine(onHitCoroutine());
    }
    private IEnumerator onHitCoroutine() {
        float dmgNorm = damageReductionMultiply;
        if (Random.value > absorbPercent) {
            damageReductionMultiply = 0;
            im.gainAmmo(1);
        }
        yield return new WaitForEndOfFrame();
        cor = null;
        damageReductionMultiply = dmgNorm;
    }
}
