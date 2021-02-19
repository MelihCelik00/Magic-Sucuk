using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

namespace Managers
{
    public class BattleSystem : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        public Transform playerBattleStation;
        public Transform enemyBattleStation;

        private Unit.Unit playerUnit;
        private Unit.Unit enemyUnit;

        public Text dialogueText;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;
        
        public BattleState state;
        private void Start()
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }

        private IEnumerator SetupBattle()
        {
            GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
            playerUnit = playerGO.GetComponent<Unit.Unit>();
            
            GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit.Unit>();

            dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
            
            playerHUD.SetHUD(playerUnit);
            enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(2f);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

        IEnumerator PlayerAttack()
        {
            // Damage the enemy
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
            
            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogueText.text = "The attack is successful!";
                
            yield return new WaitForSeconds(2f);
            
            // Check if the enemy is dead
            if (isDead)
            {
                // End battle
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                // Enemy turn
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            //Change state based on what happened
        }

        IEnumerator PlayerHeal()
        {
            playerUnit.Heal(5);
            playerHUD.SetHP(playerUnit.currentHP);
            dialogueText.text = "You feel renewed strength!";
            
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }

        IEnumerator EnemyTurn()
        {
            dialogueText.text = enemyUnit.unitName + " attacks!";
            
            yield return new WaitForSeconds(1f);

            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
            
            playerHUD.SetHP(playerUnit.currentHP);
            
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }
        }

        private void EndBattle()
        {
            if (state == BattleState.WON)
            {
                dialogueText.text = "You won the battle!";
            }else if (state == BattleState.LOST)
            {
                dialogueText.text = "You were defeated";
            }
        }
        
        void PlayerTurn()
        {
            dialogueText.text = "Choose an action";
        }

        public void OnAttackButton()
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerAttack());
        }

        public void OnHealButton()
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerHeal());
        }
        
    }
}
