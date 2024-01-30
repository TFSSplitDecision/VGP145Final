using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/AbsorptionArmour", order = 8)]
public class AbsorptionArmour : Chest {
    private Coroutine cor;
    [Header("Absorption Armor"),SerializeField]
    private float absorbChance = 0.5f;
    /// <summary>
    /// Absorbtion armor will set it's absorbtion value at the frame of hit (and reset it back to normal)
    /// </summary>
    /// <returns></returns>
    public override void onHit() {
        if (cor == null)
            cor = im.StartCoroutine(onHitCoroutine());
    }
    public override void onUnequip() {
        if (cor != null)
            im.StopCoroutine(cor);
    }
    private IEnumerator onHitCoroutine() {
        float dmgNorm = damageReductionMultiply;
        if (Random.value <= absorbChance) {
            damageReductionMultiply = 0;
            im.gainAmmo(1);
        }
        yield return new WaitForEndOfFrame();
        cor = null;
        damageReductionMultiply = dmgNorm;
    }
}
