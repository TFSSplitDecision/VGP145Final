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


    protected List<Collectible> markRemoval;

    private void Start()
    {
        im = GetComponent<InventoryManager>();

        markRemoval = new List<Collectible>();
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

    protected void Update()
    {
        // Guard condition to prevent null checks
        if (collectibles == null) return;

        foreach ( Collectible collectible in collectibles )
        {
            // TODO: Clear null stuff somehow
            if (collectible == null) continue;

            bool autoCollect = collectible.getAutoCollect;
            bool buttonPress = Input.GetKeyDown(KeyCode.P);
            bool canCollect = collectible.CanCollect();

            bool doCollect = (autoCollect | buttonPress) & canCollect;
            if ( doCollect )
            {
                im.Pickup(collectible.getItem);
                
                // Mark collectible for removal. Since we can't remove
                // items while we're iterating (I think..)
                markRemoval.Add(collectible);

                Destroy(collectible.gameObject);
            }
        }

        // Remove any marked collectibles from the hashset
        if( markRemoval.Count > 0 )
        {
            foreach (Collectible collectible in markRemoval)
            {
                collectibles.Remove(collectible);
            }
            markRemoval.Clear();
        }

    }
}
