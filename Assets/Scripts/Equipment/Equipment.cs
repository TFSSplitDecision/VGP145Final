using UnityEngine;
using System.Collections;



public abstract class Equipment : BaseItem {

    //protected Shooting shooting;
    //protected MeleeHit


    #region Components
    // ..
    #endregion

    [Tooltip("What object to spawn when the equipment is dropped")]
    public GameObject dropPrefab;

    [Header("Health Modifiers")]
    [SerializeField]
    private float healthMultiply = 1;
    public float getHealthMultiply() => healthMultiply;
    [SerializeField]
    private int healthAdd = 0;
    public int getHealthAdd() => healthAdd;


    [Header("Attack Speed (Attack Per Second) Modifiers")]
    [SerializeField]
    private float attackSpeedMultiply = 1;
    public float getAttackSpeedMultiply() => attackSpeedMultiply;
    [SerializeField]
    private int attackSpeedAdd = 0;
    public int getAttackSpeedAdd() => attackSpeedAdd;

    [Header("Attack Damage Modifiers")]
    [SerializeField]
    private float attackDamageMultiply = 1;
    public float getAttackDamageMultiply() => attackDamageMultiply;
    [SerializeField]
    private int attackDamageAdd = 0;
    public int getAttackDamageAdd() => attackDamageAdd;

    [Header("Move Speed Modifiers")]
    [SerializeField]
    protected float moveSpeedMultiply = 1;
    public float getMoveSpeedMultiply() => moveSpeedMultiply;
    [SerializeField]
    protected int moveSpeedAdd = 0;
    public int getMoveSpeedAdd() => moveSpeedAdd;

    [Header("Damage Reduction")]
    [SerializeField]
    protected float damageReductionMultiply = 1;
    public float getDamageReductionMultiply() => damageReductionMultiply;
    [SerializeField]
    protected int damageReductionAdd = 0;
    public int getDamageReductionAdd() => damageReductionAdd;



    private void Awake() {

    }


    public override void Init(GameObject player)
    {
        base.Init(player);
        // Do Equipment specific stuff here
    }

}
public abstract class Helmet : Equipment 
{
}

public abstract class Weapon : Equipment{


    [SerializeField] private GameObject m_bullet;
    public GameObject bullet => m_bullet;

    [SerializeField] private ShotData m_shotData;
    public ShotData shotData => m_shotData;

    [SerializeField] private float m_flatDamage;

    public float flatDamage => m_flatDamage;

}

public abstract class Arm1 : Weapon {

    private bool readyToFire => true; // TODO: True represented by cooldown not impeeding
    public void primaryFire() {
        if (!readyToFire) return;
        primaryFireScript();
    }
    protected abstract void primaryFireScript();
}
public abstract class Arm2 : Weapon{


    [SerializeField]
    private int m_maxAmmo;
    public int maxAmmo => m_maxAmmo;

    [SerializeField]
    private int m_ammo;
    public int ammo => m_ammo;

    private bool readyToFire => m_ammo > 0 && true; // TODO: True represented by cooldown not impeeding
    public void secondaryFire() {
        if (!readyToFire) return;
        secondaryFireScript();
        m_ammo--;
    }
    public void gainAmmo(int extraAmmo) {
        m_ammo += extraAmmo;
        if (m_ammo > m_maxAmmo)
            m_ammo = m_maxAmmo;
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
