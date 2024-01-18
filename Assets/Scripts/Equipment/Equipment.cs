using UnityEngine;
using System.Collections;



public abstract class Equipment : ScriptableObject {

    //protected Shooting shooting;
    //protected MeleeHit

    private GameObject player;

    #region Components
    // ..
    #endregion


    public Sprite icon;


    [Tooltip("What object to spawn when the equipment is dropped")]
    public GameObject dropPrefab;

    [Header("Health Modifiers")]
    [SerializeField]
    private float healthMultiply = 1;
    [SerializeField]
    private int healthAdd = 0;

    [Header("Attack Speed (Attack Per Second) Modifiers")]
    [SerializeField]
    private float attackSpeedMultiply = 1;
    [SerializeField]
    private int attackSpeedAdd = 0;

    [Header("Attack Damage Modifiers")]
    [SerializeField]
    private float attackDamageMultiply = 1;
    [SerializeField]
    private int attackDamageAdd = 0;

    [Header("Move Speed Modifiers")]
    [SerializeField]
    protected float moveSpeedMultiply = 1;
    [SerializeField]
    protected int moveSpeedAdd = 0;

    [Header("Damage Reduction")]
    [SerializeField]
    protected float damageReductionMultiply = 1;
    [SerializeField]
    protected int damageReductionAdd = 0;



    private void Awake() {

    }


    public void Init( GameObject player )
    {
        this.player = player;
        // Grab all components
    }

}
public abstract class Helmet : Equipment {
}

public abstract class Arm1 : Equipment {
    [Header("Arm 1 Values")]

    [SerializeField]
    private float attacksPerSecond;

    [SerializeField]
    protected float flatDamage;
    private bool readyToFire => true; // TODO: True represented by cooldown not impeeding
    public void primaryFire() {
        if (!readyToFire) return;
        primaryFireScript();
    }
    protected abstract void primaryFireScript();
}
public abstract class Arm2 : Equipment {
    [Header("Arm 2 Values")]

    [SerializeField]
    private float attacksPerSecond;

    [SerializeField]
    private int maxAmmo;
    private int ammo;

    [SerializeField]
    protected float flatDamage;
    private bool readyToFire => ammo > 0 && true; // TODO: True represented by cooldown not impeeding
    public void secondaryFire() {
        if (!readyToFire) return;
        secondaryFireScript();
        ammo--;
    }
    public void gainAmmo(int extraAmmo) {
        ammo += extraAmmo;
        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }
    protected abstract void secondaryFireScript();
}
public abstract class Chest : Equipment {

}
public abstract class Legs : Equipment {

}
