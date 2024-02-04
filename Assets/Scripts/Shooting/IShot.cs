using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides an interface for all types of shots.
/// </summary>
public interface IShot
{
    /// <summary>
    /// Initializes the object.
    /// </summary>
    /// <param name="owner"></param>
    public void Init(GameObject owner);

    /// <summary>
    /// Initiates the shooting mechanics
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="damage"></param>
    public void Shoot(BulletData bullet, float damage);

    /// <summary>
    /// Immediately stops shooting.
    /// (In case of continuous firing weapons like laser)
    /// </summary>
    public void Stop();
}
