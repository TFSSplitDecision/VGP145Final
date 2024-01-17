using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Equipment : ScriptableObject
{
    public GameObject player;
    //protected Shooting shooting;
    //protected MeleeHit

    public Sprite icon;

    [SerializeField]
    private float healthMod;

    public void Pickup( GameObject player )
    {
        Debug.Log("Equipment " + name + " was picked up by " + player);
        this.player = player;
        //shooting = player.GetComponent<Shooting>();
    }

    //protected abstract void secondaryFire();

}

public abstract class Arm1 : Equipment
{

    public abstract void primaryFire();
}

[CreateAssetMenu(fileName = "Data", menuName = "Data/MeleeSword", order = 1)]
public class MeleeSword : Arm1 {
    
    [Header("Variables")]
    public float lastshot;
    public UnityEvent test;

    public override void primaryFire()
    {
        Debug.Log("Slash!");
    }
}

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
