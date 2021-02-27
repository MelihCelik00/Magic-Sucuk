using UnityEngine;
using Managers;

namespace Unit
{
    public class BossClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD enemyHUD;
        public BattleHUD playerHUD;
        private Skills _skills;

        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("pinkcloyd").GetComponent<Unit>();
            unit.SetUnit("Pink Cloyd",20,20, 600, 600,1,0,1,1, 3);
            enemyHUD = GameObject.FindGameObjectWithTag("enemyHUD").GetComponent<BattleHUD>();
            enemyHUD.SetHUD(unit);                 
            _skills = FindObjectOfType<Skills>();
        }
        
        public void FirstSkill(Unit _unit)
        {
            _skills.PhysicalStrike(_unit, unit);
            
        }

        public void SecondSkill(Unit _unit)
        {
            _skills.WaterStrike(_unit, unit);
            
        }

        public void ThirdSkill(Unit _unit)
        {
            _skills.StreamStrike(_unit, unit);
            
        }

        public void FourthSkill(Unit _unit)
        {
            _skills.WindStrike(_unit, unit);
        }

        public void FifthSkill()
        {
            _skills.Guard(unit);
        }
        
        
    }
}
