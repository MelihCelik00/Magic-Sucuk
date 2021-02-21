using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unit;
using Random = UnityEngine.Random;

namespace Managers
{
    public enum BattleState { START, FIRST_PLAYERTURN, SECOND_PLAYERTURN, THIRD_PLAYERTURN, FOURTHPLAYER_TURN, ENEMYTURN, WON, LOST }

    public class BattleSystem : MonoBehaviour
    {

        public GameObject havaiPrefab;
        public GameObject pinkCloydPrefab;
        public GameObject atadamPrefab;
        public GameObject kardanadamPrefab;
        public GameObject zombiePrefab;
        
        public Transform playerBattleStation1;
        [SerializeField] public Transform playerBattleStation2;
        [SerializeField] public Transform playerBattleStation3;
        [SerializeField] public Transform playerBattleStation4;
        public Transform enemyBattleStation;

        private bool key;
        
        // Primary Unit object declarations
        public BalancedClass firstPlayer;
        public TankClass secondPlayer;
        public DamageClass thirdPlayer;
        public SupportClass fourthPlayer;
        public BossClass pinkCloyd;
        
        
        
        public Text dialogueText;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;
        
        public BattleState state;

        public Unit.Skills skills;

        private bool choiceTime;
        
        private bool choiceA;
        private bool choiceS;
        private bool choiceD;
        private bool choiceF;
        private bool choiceG;
        
        private void Start()
        {
            state = BattleState.START;
            StartCoroutine(SetupBattle());
        }

        private void Update()
        {
            if (choiceTime)
            { // Debug.Log("A");
                if (Input.GetKey(KeyCode.A))
                {
                    choiceA = true;
                    choiceS = false;
                    choiceD = false;
                    choiceF = false;
                    choiceG = false;
                    Debug.Log("A");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    choiceA = false;
                    choiceS = true;
                    choiceD = false;
                    choiceF = false;
                    choiceG = false;
                    Debug.Log("S");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = true;
                    choiceF = false;
                    choiceG = false;
                    Debug.Log("D");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = false;
                    choiceF = true;
                    choiceG = false;
                    Debug.Log("F");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.G))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = false;
                    choiceF = false;
                    choiceG = true;
                    Debug.Log("G");
                    choiceTime = false;
                }
            }
            
        }

        private IEnumerator SetupBattle()
        {
            GameObject pinkcloydGO = Instantiate(pinkCloydPrefab, enemyBattleStation);
            pinkCloyd = pinkcloydGO.GetComponent<BossClass>();
            /*GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation);
            firstPlayer = havaiGO.GetComponent<BalancedClass>();
            */
            int havai = PlayerPrefs.GetInt("havalikorna");
            int atadam = PlayerPrefs.GetInt("atadam");
            int kardanadam = PlayerPrefs.GetInt("madanadrak");
            int zombi = PlayerPrefs.GetInt("zombi");
            
            int[] arr = { havai, atadam, kardanadam, zombi };
            Debug.Log("Array: \nHavai: " + arr[0]+ "\nAtadam: "+ arr[1]+"\nMadanadrak: "+ arr[2]+"\nZombi: "+ arr[3]);
            Array.Sort(arr);
            
            // Havai 1
            if (havai == 1 && atadam == 2 && kardanadam == 3)
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                        
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            } 
            else if (havai == 1 && kardanadam == 2 && atadam == 3 )
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass secondPlayer;
                secondPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            }
            else if (havai == 1 && atadam == 2 && zombi == 3)
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                        
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (havai == 1 && zombi == 2 && atadam == 3)
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (havai == 1 && zombi == 2 && kardanadam == 3)
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                DamageClass thirdPlayer;
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }
            else if (havai == 1 && kardanadam == 2 && zombi == 3)
            {
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation1);
                firstPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass secondPlayer;
                secondPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek

                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }
            // kardanadam 1
            else if(kardanadam == 1 && zombi == 2 && havai == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }
            else if(kardanadam == 1 && zombi == 2 && atadam == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass fourthPlayer;
                fourthPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if(kardanadam == 1 && havai == 2 && zombi == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }
            else if (kardanadam == 1 && havai == 2 && atadam == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                SupportClass fourthPlayer;
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            }
            else if (kardanadam == 1 && atadam == 2 && havai == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                TankClass secondPlayer;
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();

                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                SupportClass fourthPlayer;
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            }
            else if (kardanadam == 1 && atadam == 2 && zombi == 3)
            {
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation1);
                DamageClass firstPlayer;
                firstPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                TankClass secondPlayer;
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass fourthPlayer;
                fourthPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if (atadam == 1 && zombi == 2 && kardanadam == 3)
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                DamageClass thirdPlayer;
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass fourthPlayer;
                fourthPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if (atadam == 1 && kardanadam == 2 && zombi == 3 )
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass secondPlayer;
                secondPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass fourthPlayer;
                fourthPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if (atadam == 1 && kardanadam == 2 && havai == 3 )
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass secondPlayer;
                secondPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                SupportClass fourthPlayer;
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            }
            else if (atadam == 1 && zombi == 2 && havai == 3 )
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation2);
                SupportClass secondPlayer;
                secondPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (atadam == 1 && havai == 2 && zombi == 3 )
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation3);
                SupportClass thirdPlayer;
                thirdPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek

                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (atadam == 1 && havai == 2 && kardanadam == 3 )
            {
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation1);
                TankClass firstPlayer;
                firstPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                DamageClass thirdPlayer;
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation4);
                SupportClass fourthPlayer;
                fourthPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
            }
            else if (zombi == 1 && atadam == 2 && kardanadam == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                TankClass secondPlayer;
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                DamageClass thirdPlayer;
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass fourthPlayer;
                fourthPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if (zombi == 1 && atadam == 2 && havai == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation2);
                TankClass secondPlayer;
                secondPlayer = atGO.GetComponent<TankClass>(); // Class değişecek

                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (zombi == 1 && havai == 2 && kardanadam == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation3);
                DamageClass thirdPlayer;
                thirdPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }
            else if (zombi == 1 && havai == 2 && atadam == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (zombi == 1 && havai == 2 && atadam == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation2);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation4);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
            }
            else if (zombi == 1 && kardanadam == 2 && atadam == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass fourthPlayer;
                fourthPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation3);
                TankClass thirdPlayer;
                thirdPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation4);
                BalancedClass secondPlayer;
                secondPlayer = havaiGO.GetComponent<BalancedClass>();
            }
            else if (zombi == 1 && kardanadam == 2 && havai == 3 )
            {
                GameObject zombie = Instantiate(zombiePrefab, playerBattleStation1);
                SupportClass firstPlayer;
                firstPlayer = zombie.GetComponent<SupportClass>(); // Class değişecek
                
                GameObject kaGO = Instantiate(kardanadamPrefab, playerBattleStation2);
                DamageClass secondPlayer;
                secondPlayer = kaGO.GetComponent<DamageClass>(); // Class değişecek
                
                GameObject havaiGO = Instantiate(havaiPrefab, playerBattleStation3);
                BalancedClass thirdPlayer;
                thirdPlayer = havaiGO.GetComponent<BalancedClass>();
                
                GameObject atGO = Instantiate(atadamPrefab, playerBattleStation4);
                TankClass fourthPlayer;
                fourthPlayer = atGO.GetComponent<TankClass>(); // Class değişecek
            }

            skills = GetComponent<Skills>();

            dialogueText.text = "A wild " + pinkCloyd.unit.unitName + " approaches...";
            
            //playerHUD.SetHUD(playerUnit);
            //enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(2f);

            state = BattleState.FIRST_PLAYERTURN;
            StartCoroutine(FirstPlayerTurn());
        }

        IEnumerator PlayerAttack()
        {
            // Damage the enemy
            bool isDead = pinkCloyd.unit.TakeDamage(firstPlayer.unit.damage);
            
            enemyHUD.SetHP(pinkCloyd.unit.currentHP);
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
            dialogueText.text = pinkCloyd.unit.unitName + " attacks!";
            
            yield return new WaitForSeconds(1f);
            int randomSkill = Random.Range(1, 5); // Roll a random skill
            Debug.Log(randomSkill);
            int toWhom = Random.Range(1, 4); // Roll a random enemy
            if (randomSkill==1)
            {
                pinkCloyd.FirstSkill(firstPlayer.unit);
                Debug.Log("1den cikti");
            }
            else if (randomSkill == 2)
            {
                pinkCloyd.SecondSkill(firstPlayer.unit);
                Debug.Log("2den cikti");
            }
            else if (randomSkill == 3)
            {
                pinkCloyd.ThirdSkill(firstPlayer.unit);
                Debug.Log("3den cikti");
            }
            else if (randomSkill == 4)
            {
                pinkCloyd.FourthSkill(firstPlayer.unit);
                Debug.Log("4den cikti");
            }
            else if (randomSkill == 5)
            {
                pinkCloyd.FifthSkill();
                Debug.Log("5den cikti");
            }
            
            playerHUD.SetHP(firstPlayer.unit.currentHP);
            
            yield return new WaitForSeconds(1f);
            bool isDead = firstPlayer.unit.ProcessDeath(firstPlayer.unit);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.FIRST_PLAYERTURN;
                StartCoroutine(FirstPlayerTurn());
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
        
        IEnumerator FirstPlayerTurn() ////////////////////////////////////////
        {
            dialogueText.text = "Choose an action for " + firstPlayer.unit.unitName;

            if (state == BattleState.FIRST_PLAYERTURN)
            {
                choiceTime = true;
                Debug.Log("SEÇ");

                while (choiceTime)
                {
                    yield return new WaitForSeconds(1f);
                }
                if (choiceA)
                {
                    firstPlayer.FirstSkill();
                }
                else if (choiceS)
                {
                    
                    firstPlayer.SecondSkill(pinkCloyd.unit);
                    Debug.Log("Second choice");
                }
                else if (choiceD)
                {
                    firstPlayer.ThirdSkill(pinkCloyd.unit);
                }
                else if (choiceF)
                {
                    firstPlayer.FourthSkill();
                }
                else if (choiceG)
                {
                    firstPlayer.FifthSkill();
                }
                enemyHUD.SetHP(pinkCloyd.unit.currentHP);

                bool isDead = pinkCloyd.unit.ProcessDeath(pinkCloyd.unit);
                if (isDead)
                {
                    // End battle
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    // Enemy turn
                    state = BattleState.SECOND_PLAYERTURN;
                    StartCoroutine(EnemyTurn()); // enemy'e degil second playera gececek
                }
            }
        }

        /// <summary>
        /// Temporary methods, can be deleted after deleting buttons on the GUI
        /// </summary>
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