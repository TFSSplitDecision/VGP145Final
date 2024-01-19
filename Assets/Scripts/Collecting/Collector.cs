using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Attach this script on characters that should be able to collect objects (collectibles)
/// </summary>
[RequireComponent(typeof(InventoryManager))]
public class Collector : MonoBehaviour
{
    protected HashSet<Collectible> collectibles;

    [Header("Variables")]
    [SerializeField, ReadOnly]
    protected bool doCollect;
    private InventoryManager im;

    private void Start()
    {
        im = GetComponent<InventoryManager>();
    }

    /// <summary>
    /// Let's the collector know that there's an item in grab range.
    /// </summary>
    /// <param name="collectible"></param>
    public void Notify(Collectible collectible)
    {
        if (collectibles == null) collectibles = new HashSet<Collectible>();
        collectibles.Add(collectible);
    }

    /// <summary>
    /// Notifies the collector to forget the item, since it is out of range
    /// </summary>
    /// <param name="collectible"></param>
    public void Forget(Collectible collectible)
    {
        if (collectibles == null) return;
        if (collectibles.Contains(collectible) == false) return;
        collectibles.Remove(collectible);
    }

    /// <summary>
    /// Decides if the collector should collect an object
    /// </summary>
    /// <returns></returns>
    public bool ShouldCollect()
    {
        // TODO: Use player input to collect?
        return (collectibles != null) && (collectibles.Count > 0) && Input.GetKeyDown(KeyCode.P); //I added an input line here
    }

    protected void Update()
    {
        doCollect = ShouldCollect();
        if (doCollect)
        {
            doCollect = false;

            var collectible = collectibles.FirstOrDefault<Collectible>();
            if (collectible != null)
            {
                bool canCollect = collectible.CanCollect(); 
                if(canCollect)
                {
                    im.Pickup(collectible.equipment);
                    collectibles.Remove(collectible);
                    Destroy(collectible.gameObject);
                }
            }
        }
    }
}
