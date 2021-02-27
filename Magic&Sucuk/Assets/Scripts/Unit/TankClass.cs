using Managers;
using UnityEngine;

namespace Unit
{
    public class TankClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        public Skills _skills;

        private BattleSystem _battleSystem;
        
        

        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("horsapien").GetComponent<Unit>();
            unit.SetUnit("Horsapien", 10, 10, 200, 200, 1, 1, 3, 2, 4);
            playerHUD = GameObject.FindGameObjectWithTag("atHUD").GetComponent<BattleHUD>();
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
            _skills.PhysicalStrike(targetUnit, unit);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            _skills.AttackBuff(targetUnit);
        }

        public bool FourthSkill()
        {
            _skills.Provoke(unit);
            return true;
        }

        public void FifthSkill()
        {
            _skills.Expose(unit);
        }

    }
}