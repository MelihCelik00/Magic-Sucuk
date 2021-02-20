using UnityEngine;

namespace Unit
{
    public class Skills : MonoBehaviour
    {
        
        // Physical Hit
        public void PhysicalStrike(Unit unit, int dmg)
        {
               unit.TakeDamage(dmg);
        }
        
        // Magical Damages
        public void WaterStrike()
        {
            
        }

        public void WindStrike()
        {
            
        }

        public void FireStrike()
        {
            
        }
        
        // Deffensive
        public void Guard()
        {
            
        }
        
        // Support
        public void Heal()
        {
            
        }

        public void CritHit()
        {
            
        }

        public void AttackBuff()
        {
            
        }

        public void Investigate()
        {
            
        }

        public void Expose()
        {
            
        }

        public void ZombieBite()
        {
            
        }
        
    }
}