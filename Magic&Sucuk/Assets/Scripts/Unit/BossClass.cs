using UnityEngine;
using Managers;

namespace Unit
{
    public class BossClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD enemyHUD;
        private Skills _skills;

        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("pinkcloyd").GetComponent<Unit>();
            unit.SetUnit("Pink Cloyd",20,20, 600, 600,1,0,1,1);
            enemyHUD = GameObject.FindGameObjectWithTag("enemyHUD").GetComponent<BattleHUD>();
            enemyHUD.SetHUD(unit);                 
            _skills = FindObjectOfType<Skills>();
        }
        
        public void FirstSkill(Unit _unit)
        {
            PhysicalStrike(_unit, unit.damage);
        }

        public void SecondSkill(Unit _unit)
        {
            WaterStrike(_unit, unit.magicDamage);
        }

        public void ThirdSkill(Unit _unit)
        {
            StreamStrike(_unit, unit.magicDamage);
        }

        public void FourthSkill(Unit _unit)
        {
            WindStrike(_unit, unit.magicDamage);
        }

        public void FifthSkill()
        {
            Guard(unit);
        }
        
        public void PhysicalStrike(Unit unit, int dmg) // Target Unit, base damage points
        {
            unit.TakeDamage(dmg*unit.strikeCoefficient);
        }
        
        public void WaterStrike(Unit unit,int magicDmg)
        {
            unit.TakeDamage(magicDmg*unit.waterCoefficient);
        }
        
        public void StreamStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg*unit.streamCoefficient);
        }
        
        public void WindStrike(Unit unit, int magicDmg)
        {
            Debug.Log("Winde geldi");
            unit.TakeDamage(magicDmg * unit.windCoefficient);
        }
        
        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }
    }
}
