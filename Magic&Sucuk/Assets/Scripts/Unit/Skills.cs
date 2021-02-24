using UnityEngine;

namespace Unit
{
    public  class Skills : MonoBehaviour
    {
        
        // Physical Hit
        public void PhysicalStrike(Unit unit, int dmg) // Target Unit, base damage points
        {
            unit.TakeDamage(dmg*unit.strikeCoefficient);
        }
        
        // Magical Damages
        public void WaterStrike(Unit unit,int magicDmg)
        {
            unit.TakeDamage(magicDmg*unit.waterCoefficient);
        }

        public void WindStrike(Unit unit, int magicDmg)
        {
            Debug.Log("Winde geldi");
            unit.TakeDamage(magicDmg * unit.windCoefficient);
        }

        public void StreamStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg*unit.streamCoefficient);
        }
        
        // Deffensive
        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }

        public void Provoke()
        {
            // saldiriyi ustune cekecek
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
        
    }
}