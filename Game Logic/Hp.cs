using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Hp component maintains the current hit points of an actor
/// </summary>
public class Hp : MonoBehaviour
{
    [SerializeField] private float maxHp;    // The maximum possible HP value
    [SerializeField] private float hp;       // The current HP value

    private void Awake()
    {
        hp = maxHp;
    }

    /// <summary>
    /// Reduce the current hp
    /// </summary>
    /// <param name="dmg">The damage to be applied</param>
    public void ApplyDamage(float dmg)
    {
        hp -= dmg;
    }

    public float GetHp()
    {
        return hp;
    }
    
    public float GetMaxHp()
    {
        return maxHp;
    }
}
