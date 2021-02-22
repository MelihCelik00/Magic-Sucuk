using Managers;
using UnityEngine;

namespace Unit
{
    public class TankClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        private Skills _skills;

        private BattleSystem _battleSystem;

        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("horsapien").GetComponent<Unit>();
            unit.SetUnit("Horsapien", 10, 10, 200, 200, 1, 1, 3, 2);
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
            PhysicalStrike(targetUnit, unit.damage);
        }

        public void ThirdSkill(Unit targetUnit)
        {
            StreamStrike(targetUnit, unit.magicDamage);
        }

        public void FourthSkill()
        {
            Provoke(unit);
        }

        public void FifthSkill()
        {
            Expose(unit);
        }

        public void Guard(Unit unit)
        {
            unit.CoefficientBuff();
        }

        public void PhysicalStrike(Unit unit, int dmg)
        {
            unit.TakeDamage(dmg * unit.strikeCoefficient);
        }

        public void StreamStrike(Unit unit, int magicDmg)
        {
            unit.TakeDamage(magicDmg * unit.streamCoefficient);
        }

        public void Expose(Unit unit)
        {
            // Çarpanların 1ini random 1 arttır
        }

        public void Provoke(Unit unit)
        {
            // saldiriyi ustune cekecek
        }
    }
}