using UnityEngine;
using System.Collections;

public abstract class Equipment : ScriptableObject {
    public GameObject player;
    //protected Shooting shooting;
    //protected MeleeHit

    public Sprite icon;

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
    public void Pickup( GameObject player ) {
        Debug.Log("Equipment " + name + " was picked up by " + player);
        this.player = player;
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
    private bool readyToUseAbility = false;
    public void ChestAbility()
    {
        if (!readyToUseAbility) return;
        ChestAbilityScript();
    }
    protected abstract void ChestAbilityScript();
}
public abstract class Legs : Equipment {
    private bool readyToUseAbility = false;
    public void LegsAbility()
    {
        if (!readyToUseAbility) return;
        LegsAbilityScript();
    }
    protected abstract void LegsAbilityScript();
}

/*
public class Gun : Arm1
{

    [Header("Variables")]
    public float lastshot;
    public UnityEvent test;

    public override void primaryFire()
    {
        Debug.Log("Pew Pew!");
    }
}
public class ReversePistol : Gun
{

    [Header("Variables")]
    public float lastshot;
    public UnityEvent test;

    public override void primaryFire()
    {

    }
}
*/