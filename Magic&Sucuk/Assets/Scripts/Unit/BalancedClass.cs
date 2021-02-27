using Managers;
using UnityEngine;

namespace Unit
{
    public class BalancedClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        public Skills _skills;

        private BattleSystem _battleSystem;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("havai").GetComponent<Unit>();
            unit.SetUnit("Hava-i",0,15, 100, 100,3,1,1,2,3);
            playerHUD = GameObject.FindGameObjectWithTag("kornaHUD").GetComponent<BattleHUD>();
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
            _skills.WindStrike(targetUnit,unit);
        }

        public void StreamStrike(Unit targetUnit)
        {
            _skills.StreamStrike(targetUnit,unit);
        }

        public void Expose(Unit targetUnit)
        {
            
            _skills.Expose(targetUnit);
        }

        public void AtkBuff()
        {
            _skills.AttackBuff(unit);
        }
        
    }
}