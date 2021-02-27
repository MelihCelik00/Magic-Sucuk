using UnityEngine;
using Managers;

namespace Unit
{
    public class SupportClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        public Skills _skills;

        private BattleSystem _battleSystem;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("zombie").GetComponent<Unit>();
            unit.SetUnit("Wholivesee",9,20, 120, 120,1,1,2,2, 3);
            playerHUD = GameObject.FindGameObjectWithTag("zombiHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
            _skills = this.gameObject.GetComponent<Skills>();
        }

        public void FirstSkill()
        {
            _skills.Guard(unit);
        }

        public void SecondSkill(Unit targetUnit)
        {
            _skills.HealByTwenty(targetUnit);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            _skills.ZombieBite(unit);
        }

        public void FourthSkill(Unit targetUnit)  
        {
            _skills.WaterStrike(targetUnit, unit);
        }

        public void FifthSkill(Unit targetUnit) 
        {
            _skills.PhysicalStrike(targetUnit, unit);
        }
        
        
    }
}