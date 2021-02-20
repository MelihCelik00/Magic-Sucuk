using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


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
        public Unit.BalancedClass firstPlayer;
        public Unit.Unit secondPlayer;
        public Unit.Unit thirdPlayer;
        public Unit.Unit fourthPlayer;
        public Unit.Unit pinkCloyd;

        public Text dialogueText;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;
        
        public BattleState state;

        public Unit.Skills skills;
        private void Start()
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }

        private IEnumerator SetupBattle()
        {
            GameObject playerGO = Instantiate(havaiPrefab, playerBattleStation);
            firstPlayer = playerGO.GetComponent<Unit.BalancedClass>();
            
            GameObject enemyGO = Instantiate(pinkCloydPrefab, enemyBattleStation);
            pinkCloyd = enemyGO.GetComponent<Unit.Unit>();

            dialogueText.text = "A wild " + pinkCloyd.unitName + " approaches...";
            
            //playerHUD.SetHUD(playerUnit);
            //enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(2f);

            state = BattleState.FIRST_PLAYERTURN;
            FirstPlayerTurn();
        }

        IEnumerator PlayerAttack()
        {
            // Damage the enemy
            bool isDead = pinkCloyd.TakeDamage(firstPlayer.unit.damage);
            
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
            firstPlayer.unit.Heal(5);
            playerHUD.SetHP(firstPlayer.unit.currentHP);
            dialogueText.text = "You feel renewed strength!";
            
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }

        IEnumerator EnemyTurn()
        {
            dialogueText.text = pinkCloyd.unitName + " attacks!";
            
            yield return new WaitForSeconds(1f);

            bool isDead = firstPlayer.unit.TakeDamage(pinkCloyd.damage);
            
            playerHUD.SetHP(firstPlayer.unit.currentHP);
            
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.FIRST_PLAYERTURN;
                FirstPlayerTurn();
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
        
        void FirstPlayerTurn() ////////////////////////////////////////
        {
            dialogueText.text = "Choose an action for " + firstPlayer.unit.unitName;

            if (state == BattleState.FIRST_PLAYERTURN)
            {
                if (Input.GetKey(KeyCode.A)) // Guard
                {
                    skills.Guard(firstPlayer.unit);
                }
                else if (Input.GetKey(KeyCode.S)) // Wind
                {
                    skills.WindStrike(firstPlayer.unit);
                }
                else if (Input.GetKey(KeyCode.D)) // Stream 
                {
                    skills.StreamStrike(firstPlayer.unit);
                }
                else if (Input.GetKey(KeyCode.F)) // Expose
                {
                    skills.Expose(firstPlayer.unit);
                }
                else if (Input.GetKey(KeyCode.G)) // Attack Buff
                {
                    skills.AttackBuff(firstPlayer.unit);
                }
                else
                {
                    
                }
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
