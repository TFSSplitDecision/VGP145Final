using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/MeleeSword", order = 1)]
public class MeleeSword : Arm1 {
    protected override void primaryFireScript() {
        Debug.Log("Slash!");
    }
}