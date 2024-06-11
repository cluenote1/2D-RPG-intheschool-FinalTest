using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float BaseAttackDamage = 5f;
    private float strongAttackBonus;
    

    void Start()
    {
        BaseAttackDamage = BaseAttackDamage;
    }

    public void EatStrongAttackItem(float bonusDamage)
    {
        BaseAttackDamage = BaseAttackDamage + strongAttackBonus;
        Debug.Log("Warrior's attack increased to: " + BaseAttackDamage);
    }

    public void AttackTarget(GameObject target)
    {
        
        Debug.Log("Attacking target with damage: " + BaseAttackDamage);
    }
}
