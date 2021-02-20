using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Unit
{
    public class BalancedClass : MonoBehaviour
    {
        public Unit unit;
        public BattleHUD playerHUD;
        private void Start()
        {
            unit = GameObject.FindGameObjectWithTag("havai").GetComponent<Unit>();
            unit.SetUnit("Hava-i",0,15, 100, 100,3,1,1,2);
            playerHUD = GameObject.FindGameObjectWithTag("playerHUD").GetComponent<BattleHUD>();
            playerHUD.SetHUD(unit);
        }
    }
}