using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ScriptableObject
{

    private GameObject player;
    
    [SerializeField]
    private Sprite icon;
    public Sprite getSprite() => icon;

    public virtual void Init(GameObject player)
    {
        this.player = player;
    }

}

