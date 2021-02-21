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
            unit.SetUnit("Wholivesee",0,15, 100, 100,3,1,1,2);
            playerHUD = GameObject.FindGameObjectWithTag("playerHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
        }

        public void FirstSkill()
        {
            Guard(unit);
        }

        public void SecondSkill(Unit targetUnit) // Heal
        {
            Debug.Log(targetUnit.unitName);
            WindStrike(targetUnit, unit.magicDamage);
        }

        public void ThirdSkill(Unit targetUnit) // Zombie Bite
        {
            StreamStrike(targetUnit, unit.magicDamage);
        }

        public void FourthSkill() // Water 
        {
            Expose(unit);
        }

        public void FifthSkill() // Strike
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
        
        public void StreamStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg*unit.streamCoefficient);
        }
        
        public void Expose(Unit unit)
        {
            // Çarpanların 1ini random 1 arttır
        }
        
        public void AttackBuff(Unit unit)
        {
            unit.IncreaseAttackDmg();
        }
    }
}
