using UnityEngine;

namespace Unit
{
    public class Unit : MonoBehaviour
    {
        public string unitName;

        public int damage;
        public int magicDamage;
        
        public int strikeCoefficient;
        public int waterCoefficient;
        public int streamCoefficient;
        public int windCoefficient;
        
        public int maxHP;
        public int currentHP;

        public int crit;

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

        public void CoefficientBuff()
        {
            // for one round
            strikeCoefficient--;
            waterCoefficient--;
            streamCoefficient--;
            fireCoefficient--;
        }

        public void CoefficientNerf()
        {
            strikeCoefficient++;
            waterCoefficient++;
            streamCoefficient++;
            fireCoefficient++;
        }

        public void SetCrit()
        {
            // for two rounds
            crit *= 2;
        }

        public void IncreaseAttackDmg()
        { // for two rounds
            damage += 5;
            magicDamage += 5;
        }
        
    }
}
