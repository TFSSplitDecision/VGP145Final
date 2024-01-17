using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Equipment : ScriptableObject
{
    public GameObject player;
    protected Shooting shooting;
    protected MeleeHit

    public Sprite icon;

    [SerializeField]
    private float healthMod;

    public void Pickup( GameObject player )
    {
        this.player = player;
        shooting = player.GetComponent<Shooting>();
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
        Debug.Log("Pew!");

        // figure start
        // figure end
        // 

        MeleeSword.Slash()
        // Logic 
    }
}

public class Gun : Arm1
{

    [Header("Variables")]
    public float lastshot;
    public UnityEvent test;

    public override void primaryFire()
    {
        
        shooting.shoot1();
        // Logic 
    }
}
public class ReversePistol : Gun
{

    [Header("Variables")]
    public float lastshot;
    public UnityEvent test;

    public override void primaryFire()
    {

        shooting.shoot2();
        // Logic 
    }
}

// On the player
public class Shooting : MonoBehaviour
{

    public void ShootMulti()
    {
        // Spawns 3 bullets
    }

    public void Shoot1()
    {
        // Spawn 1 bullet that use
        // Spawns effect
        // Plays sound seffecf
    }

    public void Update()
    {
        // Check the input
        // direction = transform.forward
    }

}

public class Looking : MonoBehaviour
{

}