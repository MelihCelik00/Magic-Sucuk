using Managers;
using UnityEngine;

namespace Unit
{
    public class DamageClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        private Skills _skills;

        private BattleSystem _battleSystem;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("kardanadam").GetComponent<Unit>();
            unit.SetUnit("Karl Adams", 12, 30, 60, 60, 2, 1, 1, 3);
            playerHUD = GameObject.FindGameObjectWithTag("playerHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            //_skills = GameObject.FindGameObjectWithTag("battleManager").GetComponent<Skills>();
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
        }

        public void FirstSkill()
        {
            Guard(unit);
        }

        public void SecondSkill(Unit targetUnit)
        {
            Debug.Log(targetUnit.unitName);
            WindStrike(targetUnit, unit.magicDamage);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            WaterStrike(targetUnit, unit.magicDamage);
        }

        public void FourthSkill()
        {
            Investigate(unit);
        }

        public void FifthSkill()
        {
            AttackBuff(unit);
        }

        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }
        public void WindStrike(Unit unit, int magicDmg)
        {
            Debug.Log("Winde geldi");
            unit.TakeDamage(magicDmg * unit.windCoefficient);
        }
        public void WaterStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg * unit.waterCoefficient);
        }
        public void Investigate(Unit unit)
        {
            // Dialog paneline bastır

        }
        public void AttackBuff(Unit unit)
        {
            unit.IncreaseAttackDmg();
        }
    }
}