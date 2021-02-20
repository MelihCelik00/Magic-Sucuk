using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unit;

public enum BattleState { START, FIRST_PLAYERTURN, SECOND_PLAYERTURN, THIRD_PLAYERTURN, FOURTHPLAYER_TURN, ENEMYTURN, WON, LOST }

namespace Managers
{
    public class BattleSystem : MonoBehaviour
    {

        public GameObject havaiPrefab;
        public GameObject pinkCloydPrefab;
        public GameObject _horsapienPrefab;
        public GameObject _wholiveseePrefab;
        public GameObject _karladamsPrefab;

        public Transform playerBattleStation;
        public Transform enemyBattleStation;

        // Primary Unit object declarations
        public Unit.Unit firstPlayer;
        public Unit.Unit secondPlayer;
        public Unit.Unit thirdPlayer;
        public Unit.Unit fourthPlayer;
        public Unit.Unit pinkCloyd;

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
            GameObject playerGO = Instantiate(havaiPrefab, playerBattleStation);
            firstPlayer = playerGO.GetComponent<Unit.Unit>();
            
            GameObject enemyGO = Instantiate(pinkCloydPrefab, enemyBattleStation);
            pinkCloyd = enemyGO.GetComponent<Unit.Unit>();

            dialogueText.text = "A wild " + pinkCloyd.unitName + " approaches...";
            
            playerHUD.SetHUD(playerUnit);
            enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(2f);

            state = BattleState.FIRST_PLAYERTURN;
            PlayerTurn();
        }

        IEnumerator PlayerAttack()
        {
            // Damage the enemy
            bool isDead = pinkCloyd.TakeDamage(firstPlayer.damage);
            
            enemyHUD.SetHP(pinkCloyd.currentHP);
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
            firstPlayer.Heal(5);
            playerHUD.SetHP(firstPlayer.currentHP);
            dialogueText.text = "You feel renewed strength!";
            
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }

        IEnumerator EnemyTurn()
        {
            dialogueText.text = pinkCloyd.unitName + " attacks!";
            
            yield return new WaitForSeconds(1f);

            bool isDead = firstPlayer.TakeDamage(pinkCloyd.damage);
            
            playerHUD.SetHP(firstPlayer.currentHP);
            
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.FIRST_PLAYERTURN;
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

            if (state == BattleState.FIRST_PLAYERTURN)
            {
                
            }
        }

        public void OnAttackButton()
        {
            if (state != BattleState.FIRST_PLAYERTURN)
                return;

            StartCoroutine(PlayerAttack());
        }

        public void OnHealButton()
        {
            if (state != BattleState.FIRST_PLAYERTURN)
                return;

            StartCoroutine(PlayerHeal());
        }
        
    }
}
