using UnityEngine;

namespace Unit
{
    public class Unit : MonoBehaviour
    {
        public string unitName;
        public int unitLevel;
        
        public int damage;
        public int magicDamage;
        
        public int strikeCoefficient;
        public int waterCoefficient;
        public int streamCoefficient;
        public int fireCoefficient;
        
        public int maxHP;
        public int currentHP;

        public bool TakeDamage(int dmg)
        {
            currentHP -= dmg*strikeCoefficient;

            if (currentHP <= 0)
                return true;
            else
                return false;
        }

        public void Heal(int amount)
        {
            currentHP += amount;
            if (currentHP >= maxHP)
            {
                currentHP = maxHP;
            }
        }
        
        public bool ProcessDeath(Unit unit)
        {
            if (unit.currentHP <= 0)
                return true;
            else
                return false;
        }

        public void SetUnit(string name, int dmg, int magicDmg, int maxHp, int currHp,int strikec, int waterc, int streamc, int firec)
        {
            unitName = name;
            damage = dmg;
            magicDamage = magicDmg;
        
            strikeCoefficient = strikec;
            waterCoefficient = waterc;
            streamCoefficient = streamc;
            fireCoefficient = firec;
        
            maxHP = maxHp;
            currentHP = currHp;
            
        }
        
        
    }
}
