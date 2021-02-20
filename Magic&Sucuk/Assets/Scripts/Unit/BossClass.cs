using UnityEngine;
using Managers;

namespace Unit
{
    public class BossClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD enemyHUD;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("pinkcloyd").GetComponent<Unit>();
            unit.SetUnit("Pink Cloyd",20,20, 600, 600,1,0,1,1);
            enemyHUD = GameObject.FindGameObjectWithTag("enemyHUD").GetComponent<BattleHUD>();
            enemyHUD.SetHUD(unit);                  
        }
    }
}
