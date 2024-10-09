using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/EntityStats", order = 1)]
public class EntityParamsSO : ScriptableObject
{
    public float EntityBaseHealth;
    public float EntityMaxHealth;
    public float EntityCurrentHealth;

    public float EntityBaseAttackDamage;
    public float EntityMaxAttackDamage;
    public float EntityCurrentAttackDamage;
}
