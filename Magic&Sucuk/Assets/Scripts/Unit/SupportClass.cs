using UnityEngine;
using Managers;

namespace Unit
{
    public class SupportClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        private Skills _skills;

        private BattleSystem _battleSystem;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("zombie").GetComponent<Unit>();
            unit.SetUnit("Wholivesee",9,20, 120, 120,1,1,2,2);
            playerHUD = GameObject.FindGameObjectWithTag("playerHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
        }

        public void FirstSkill()
        {
            Guard(unit);
        }

        public void SecondSkill(Unit targetUnit)
        {
            HealByTwenty(unit);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            ZombieBite(unit);
        }

        public void FourthSkill(Unit targetUnit)  
        {
            WaterStrike(targetUnit, unit.magicDamage);
        }

        public void FifthSkill(Unit targetUnit) 
        {
            PhysicalStrike(targetUnit, unit.damage);
        }
        
        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }

        public void HealByTwenty(Unit unit)
        {
            var amount = (unit.maxHP - unit.currentHP) * 20 / 100;
            unit.Heal(amount);
        }

        public void ZombieBite(Unit unit)
        {
            // Revive dead one with %50 health + color that character to green
        }
        public void WaterStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg * unit.waterCoefficient);
        }

        public void PhysicalStrike(Unit unit, int dmg)
        {
            unit.TakeDamage(dmg * unit.strikeCoefficient);
        }
    }
}