using Managers;
using UnityEngine;

namespace Unit
{
    public class DamageClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        public Skills _skills;

        private BattleSystem _battleSystem;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("kardanadam").GetComponent<Unit>();
            unit.SetUnit("Karl Adams", 12, 30, 60, 60, 2, 1, 1, 3,9);
            playerHUD = GameObject.FindGameObjectWithTag("karHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
            //_skills = GameObject.FindGameObjectWithTag("battleManager").GetComponent<Skills>();
            _battleSystem = GameObject.FindGameObjectWithTag("battleManager").GetComponent<BattleSystem>();
            _skills = this.gameObject.GetComponent<Skills>();
        }

        public void FirstSkill()
        {
            _skills.Guard(unit);
        }

        public void SecondSkill(Unit targetUnit)
        {
            Debug.Log(targetUnit.unitName);
            _skills.WindStrike(targetUnit, unit);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            _skills.WaterStrike(targetUnit, unit);
        }

        public void FourthSkill()
        {
            _skills.Investigate(unit);
        }

        public void FifthSkill()
        {
            _skills.CritBuff(unit);
        }
        
    }
}