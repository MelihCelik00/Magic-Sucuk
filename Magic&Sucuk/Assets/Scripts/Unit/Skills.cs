using UnityEngine;

namespace Unit
{
    public class Skills : MonoBehaviour
    {
        
        // Physical Hit
        public void PhysicalStrike(Unit unit, int dmg)
        {
            unit.TakeDamage(dmg);
        }
        
        // Magical Damages
        public void WaterStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg);
        }

        public void WindStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg);
        }

        public void StreamStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg);
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