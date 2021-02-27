using Managers;
using UnityEngine;

namespace Unit
{
    public class BalancedClass : MonoBehaviour, Skills
    {
        public Unit unit;
        public BattleHUD playerHUD;
        private Skills _skills;
        private BattleSystem _battleSystem;
 
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("havai").GetComponent<Unit>();
            unit.SetUnit("Hava-i", 0, 15, 100, 100, 3, 1, 1, 2);
            playerHUD = GameObject.FindGameObjectWithTag("playerHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
            _skills = this.gameObject.GetComponent<Skills>();
        }

        public void Guard()
        {
            _skills.Guard(unit);
        }

        public void WindStrike(Unit targetUnit)
        {
            _skills.WindStrike(targetUnit, unit.magicDamage);
        }

        public void StreamStrike(Unit targetUnit)
        {
            _skills.StreamStrike(targetUnit, unit.magicDamage);
        }

        public void Expose(Unit targetUnit)
        {

            _skills.Expose(targetUnit);
        }

        public void AtkBuff()
        {
            _skills.AttackBuff(unit);
        }
        /*
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
        }*/
    }
}