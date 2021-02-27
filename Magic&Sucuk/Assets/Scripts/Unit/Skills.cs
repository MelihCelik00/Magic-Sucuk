using UnityEngine;
using System;
using Random = System.Random;

namespace Unit
{
    public  class Skills : MonoBehaviour
    {
        
        // Physical Hit
        public void PhysicalStrike(Unit targetUnit, Unit unit) // Target Unit, base damage points
        {
            if (CalculateCritProbability(unit))
                unit.TakeDamage(unit.damage * targetUnit.strikeCoefficient * unit.critDamage);
            else
                unit.TakeDamage(unit.damage*targetUnit.strikeCoefficient);
        }
        
        // Magical Damages
        public void WaterStrike(Unit targetUnit, Unit unit)
        {
            if (CalculateCritProbability(unit))
                unit.TakeDamage(unit.magicDamage * targetUnit.strikeCoefficient * unit.critDamage);
            else
                unit.TakeDamage(unit.magicDamage * unit.waterCoefficient);
        }

        public void WindStrike(Unit targetUnit, Unit unit)
        {
            if (CalculateCritProbability(unit))
                unit.TakeDamage(unit.magicDamage * targetUnit.strikeCoefficient * unit.critDamage);
            else
                unit.TakeDamage(unit.magicDamage * unit.windCoefficient);
        }

        public void StreamStrike(Unit targetUnit, Unit unit)
        {
            if (CalculateCritProbability(unit))
                unit.TakeDamage(unit.magicDamage * targetUnit.strikeCoefficient * unit.critDamage);
            else
                unit.TakeDamage(unit.magicDamage * unit.streamCoefficient);
        }
        
        // Deffensive
        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }

        public bool Provoke(Unit targetUnit)
        {
            return true;
        }

        // Support
        public void HealByTwenty(Unit unit)
        {
            var amount = (unit.maxHP - unit.currentHP)*20/100;
            unit.Heal(amount);
        }

        public void CritBuff(Unit unit)
        {
            
            unit.SetCrit(); // for two rounds
        }

        public void AttackBuff(Unit unit)
        {
            unit.IncreaseAttackDmg();
        }

        public void Investigate(Unit unit)
        {
            // Dialog paneline bastır
            
        }

        public void Expose(Unit unit)
        {
            // Çarpanların 1ini random 1 arttır
        }

        public void ZombieBite(Unit unit)
        {
            // Revive dead one with %50 health + color that character to green
        }
        
        public bool CalculateCritProbability(Unit unit)
        {
            var R = new Random();
            int C = R.Next(1, 101);
            if (C <= unit.critPercentage) return true;

            return false;
        }
        
    }
}