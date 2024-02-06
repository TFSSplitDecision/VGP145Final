using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides an interface for all types of shots.
/// </summary>
public interface IShot
{

    /// <summary>
    /// Initiates the shooting mechanics
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="damage"></param>
    public void Shoot(ShotData shotData, GameObject bullet, float damage);



    /// <summary>
    /// Immediately stops shooting.
    /// (In case of continuous firing weapons like laser)
    /// </summary>
    public void Stop();
}
