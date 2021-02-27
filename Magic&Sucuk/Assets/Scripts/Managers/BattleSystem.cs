using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Unit;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Managers
{
    public enum BattleState { START, FIRST_PLAYERTURN, SECOND_PLAYERTURN, THIRD_PLAYERTURN, FOURTHPLAYER_TURN, ENEMYTURN, WON, LOST }

    public class BattleSystem : MonoBehaviour
    {

        public GameObject kornaPrefab;
        public GameObject pinkPrefab;
        public GameObject atPrefab;
        public GameObject karPrefab;
        public GameObject zombiPrefab;
        
        public Transform playerBattleStation1;
        [SerializeField] public Transform playerBattleStation2;
        [SerializeField] public Transform playerBattleStation3;
        [SerializeField] public Transform playerBattleStation4;
        public Transform enemyBattleStation;

        private bool key;
        
        // Primary Unit object declarations
        public BalancedClass kornaChar;
        public TankClass atChar;
        public DamageClass karChar;
        public SupportClass zombiChar;
        public BossClass pinkChar;

        public Text dialogueText;

        // HUDs
        public BattleHUD enemyHUD;
        public BattleHUD kornaHUD;
        public BattleHUD atHUD;
        public BattleHUD karHUD;
        public BattleHUD zombiHUD;
        
        // Skill UIs
        public GameObject kornaUI;
        public GameObject atUI;
        public GameObject karUI;
        public GameObject zombiUI;
        
        public BattleState state;

        private bool choiceTime;

        public GameObject atAnim;
        public GameObject karAnim;
        public GameObject zombiAnim;
        public GameObject kornaAnim;
        public GameObject pinkAnim;

        private bool kornaGuardUsed;
        private bool atGuardUsed;
        private bool zombiGuardUsed;
        private bool karGuardUsed;
        private bool firstTurnPassed;
        
        private bool choiceA;
        private bool choiceS;
        private bool choiceD;
        private bool choiceF;
        private bool choiceSpace;

        private bool atUsedProvoke;

        public bool kornaDead, karDead, zombiDead, atDead, isDead;

        private GameObject kornaObj;
        private GameObject atObj;
        private GameObject karObj;
        private GameObject zombiObj;
        private GameObject pinkObj;

        [SerializeField] private GameObject normalBackground;
        [SerializeField] private GameObject animBackground;

        #region audio
        public GameObject kornaAtkAudio;
        public GameObject kornaDefAudio;
        public GameObject kornaSupAudio;

        public GameObject atAtkAudio;
        public GameObject atDefAudio;
        public GameObject atSupAudio;

        public GameObject karAtkAudio;
        public GameObject karDefAudio;
        public GameObject karSupAudio;

        public GameObject zombiAtkAudio;
        public GameObject zombiDefAudio;
        public GameObject zombiSupAudio;

        public GameObject pinkAtkAudio;
        public GameObject pinkDefAudio;
        public GameObject pinkSupAudio;

        public GameObject guardAudio;
        #endregion

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
                    choiceSpace = false;
                    Debug.Log("A");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    choiceA = false;
                    choiceS = true;
                    choiceD = false;
                    choiceF = false;
                    choiceSpace = false;
                    Debug.Log("S");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = true;
                    choiceF = false;
                    choiceSpace = false;
                    Debug.Log("D");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = false;
                    choiceF = true;
                    choiceSpace = false;
                    Debug.Log("F");
                    choiceTime = false;
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    choiceA = false;
                    choiceS = false;
                    choiceD = false;
                    choiceF = false;
                    choiceSpace = true;
                    Debug.Log("Space");
                    choiceTime = false;
                }
            }
        }

        private IEnumerator SetupBattle()
        {
            GameObject pinkGO = Instantiate(pinkPrefab, enemyBattleStation);
            pinkChar = pinkGO.GetComponent<BossClass>();
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
            kornaObj = Instantiate(kornaPrefab, playerBattleStation1);
            kornaChar = kornaObj.GetComponent<BalancedClass>();
            
            atObj = Instantiate(atPrefab, playerBattleStation2);
            atChar = atObj.GetComponent<TankClass>(); // Class değişecek

            karObj = Instantiate(karPrefab, playerBattleStation3);
            karChar = karObj.GetComponent<DamageClass>(); // Class değişecek
                    
            zombiObj = Instantiate(zombiPrefab, playerBattleStation4);
            zombiChar = zombiObj.GetComponent<SupportClass>(); // Class değişecek
                
            //skills = GetComponent<Skills>();
            
            kornaHUD = GameObject.FindGameObjectWithTag("kornaHUD").GetComponent<BattleHUD>();
            atHUD  = GameObject.FindGameObjectWithTag("atHUD").GetComponent<BattleHUD>();
            karHUD  = GameObject.FindGameObjectWithTag("karHUD").GetComponent<BattleHUD>();
            zombiHUD  = GameObject.FindGameObjectWithTag("zombiHUD").GetComponent<BattleHUD>();

            // kornaUI = GameObject.FindGameObjectWithTag("kornaSkillUI");
            // atUI = GameObject.FindGameObjectWithTag("atSkillUI");
            // karUI = GameObject.FindGameObjectWithTag("karSkillUI");
            // zombiUI = GameObject.FindGameObjectWithTag("zombiSkillUI");
            
            dialogueText.text = "A wild " + pinkChar.unit.unitName + " approaches...";
            
            yield return new WaitForSeconds(2f);
            Debug.Log("First player: " + kornaChar.unit.unitName);
            Debug.Log("Second player: " + atChar.unit.unitName);
            Debug.Log("Third player: " + karChar.unit.unitName);
            Debug.Log("Fourth player: " + zombiChar.unit.unitName);
            state = BattleState.FIRST_PLAYERTURN;
            StartCoroutine(KornaTurn());
        }

        IEnumerator EnemyTurn()
        {
            dialogueText.text = pinkChar.unit.unitName + " attacks!";
            
            yield return new WaitForSeconds(1f);
            int randomSkill = Random.Range(1, 5); // Roll a random skill
            Unit.Unit randUnit = null;
            GameObject randObj = null;
            GameObject randAnim = null;
            BattleHUD playerHUD = null;
            String str = null;
            int toWhom = Random.Range(1, 4);
            
            // TODO: dead boolu kontrol edilsin ve sayidaki oluyse 1 arttirsin

            if (toWhom == 1 && kornaDead)
            {
                toWhom = 2;
            }
            if (toWhom==2 && atDead)
            {
                toWhom = 3;
            }
            if (toWhom == 3 && karDead)
            {
                toWhom = 4;
            }
            if (toWhom == 4 && zombiDead)
            {
                toWhom = 1;
            }

            if (!atUsedProvoke)
            {
                if (toWhom == 1)
                {
                    randUnit = kornaChar.unit;
                    randObj = kornaObj;
                    randObj = GameObject.FindGameObjectWithTag(kornaObj.tag);
                    randAnim = kornaAnim;
                    playerHUD = GameObject.FindGameObjectWithTag("kornaHUD").GetComponent<BattleHUD>();
                    str = "Korna-Defans";
                }
                else if (toWhom == 2)
                {
                    randUnit = atChar.unit;
                    randObj = atObj;
                    randObj = GameObject.FindGameObjectWithTag(atObj.tag);
                    randAnim = atAnim;
                    playerHUD = GameObject.FindGameObjectWithTag("atHUD").GetComponent<BattleHUD>();
                    str = "At-Defans";
                }
                else if (toWhom == 3)
                {
                    randUnit = karChar.unit;
                    randObj = karObj;
                    randObj = GameObject.FindGameObjectWithTag(karObj.tag);
                    randAnim = karAnim;
                    playerHUD = GameObject.FindGameObjectWithTag("karHUD").GetComponent<BattleHUD>();
                    str = "Kar-Defans";
                }
                else if (toWhom == 4)
                {
                    randUnit = zombiChar.unit;
                    randObj = zombiObj;
                    randObj = GameObject.FindGameObjectWithTag(zombiObj.tag);
                    randAnim = zombiAnim;
                    playerHUD = GameObject.FindGameObjectWithTag("zombiHUD").GetComponent<BattleHUD>();
                    str = "Zombi-Defans";
                }
            }
            else
            {
                randUnit = atChar.unit;
                    randObj = atObj;
                    randObj = GameObject.FindGameObjectWithTag(atObj.tag);
                    randAnim = atAnim;
                    playerHUD = GameObject.FindGameObjectWithTag("atHUD").GetComponent<BattleHUD>();
                    str = "At-Defans";
            }
            
            randAnim.SetActive(true);
            Debug.Log(randUnit);
            // Roll a random enemy
            if (randomSkill==1) // Physical Strike
            {
                pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Attack");
                randAnim.GetComponent<Animator>().SetTrigger(str);
                pinkAtkAudio.GetComponent<AudioSource>().Play();
                animBackground.SetActive(true);
                pinkChar.FirstSkill(randUnit);
                Debug.Log("1den cikti");
                yield return new WaitForSeconds(1f);
            }
            else if (randomSkill == 2) // Water Strike
            {
                pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Attack");
                randAnim.GetComponent<Animator>().SetTrigger(str);
                pinkAtkAudio.GetComponent<AudioSource>().Play();
                animBackground.SetActive(true);
                pinkChar.SecondSkill(randUnit);
                Debug.Log("2den cikti");
                yield return new WaitForSeconds(1f);
            }
            else if (randomSkill == 3) // Stream Strike
            {
                pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Attack");
                randAnim.GetComponent<Animator>().SetTrigger(str);
                pinkAtkAudio.GetComponent<AudioSource>().Play();
                animBackground.SetActive(true);
                pinkChar.ThirdSkill(randUnit);
                Debug.Log("3den cikti");
                yield return new WaitForSeconds(1f);
            }
            else if (randomSkill == 4) // Wind Strike
            {
                pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Attack");
                randAnim.GetComponent<Animator>().SetTrigger(str);
                pinkAtkAudio.GetComponent<AudioSource>().Play();
                animBackground.SetActive(true);
                pinkChar.FourthSkill(randUnit);
                Debug.Log("4den cikti");
                yield return new WaitForSeconds(1f);
            }
            else if (randomSkill == 5) // Guard
            {
                pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Defans");
                
                pinkChar.FifthSkill();
                Debug.Log("5den cikti");
                yield return new WaitForSeconds(1f);
            }
            
            // check if chosen unit is dead and destroy its GO and close the anim
            if (randUnit.currentHP <= 0)
            {
                if (toWhom == 1 && !kornaDead) // korna
                {
                    kornaDead = true;
                }
                else if (toWhom == 2 && !atDead) // at
                {
                    atDead = true;
                }
                else if (toWhom == 3 && !karDead) // kar
                {
                    karDead = true;
                }
                else if (toWhom == 4 && !zombiDead) // zombi
                {
                    zombiDead = true;
                }
                //randObj.SetActive(false); // BURASI PATLIYOR
                Destroy(randObj);
                Destroy(randAnim);
            }
            else
            {
                randObj.SetActive(true);
            }
            randAnim.SetActive(false);
            animBackground.SetActive(false);
            playerHUD.SetHUD(randUnit);
            atUsedProvoke = false;
            yield return new WaitForSeconds(2f);

            if (atDead && kornaDead && zombiDead && karDead)
                isDead = true;

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.FIRST_PLAYERTURN;
                StartCoroutine(KornaTurn());
            }
        }

        private void EndBattle()
        {
            if (state == BattleState.WON)
            {
                dialogueText.text = "You won the battle!";
            }
            else if (state == BattleState.LOST)
            {
                dialogueText.text = "You were defeated";
            }
        }
        
        IEnumerator KornaTurn() /////////
        {
            dialogueText.text = "Choose an action for " + kornaChar.unit.unitName;
            kornaHUD.SetHUD(kornaChar.unit);
            if (state == BattleState.FIRST_PLAYERTURN && !kornaDead )
            {
                kornaAnim.SetActive(true);
                kornaObj.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                kornaUI.SetActive(true);
                choiceTime = true;
                Debug.Log("SEÇ");
                
                // Skill UI acilsin

                if (kornaGuardUsed)
                {
                    kornaChar.unit.CoefficientNerf();
                    kornaGuardUsed = false;
                }
                
                while (choiceTime)
                {
                    yield return new WaitForSeconds(1f);
                }
                
                if (choiceSpace)
                {
                    kornaUI.SetActive(false);
                    SetAnimsAndAudio(kornaObj,kornaAnim,"Korna","g",0);
                    kornaChar.Guard();
                    kornaGuardUsed = true;
                }
                else if (choiceA)
                {
                    kornaUI.SetActive(false);
                    SetAnimsAndAudio(kornaObj,kornaAnim,"Korna","atk",0);
                    kornaChar.WindStrike(pinkChar.unit);
                    yield return new WaitForSeconds(1f);
                    Debug.Log("Second choice");
                }
                else if (choiceS)
                {
                    kornaUI.SetActive(false);
                    SetAnimsAndAudio(kornaObj,kornaAnim,"Korna","atk",0);
                    kornaChar.StreamStrike(pinkChar.unit);
                    yield return new WaitForSeconds(1f);
                }
                else if (choiceD)
                {
                    kornaUI.SetActive(false);
                    SetAnimsAndAudio(kornaObj,kornaAnim,"Korna","osup",0);
                    kornaChar.Expose(pinkChar.unit);
                    yield return new WaitForSeconds(1f);
                }
                else if (choiceF)
                {
                    kornaUI.SetActive(false);
                    // Destek anim
                    SetAnimsAndAudio(kornaObj,kornaAnim,"Korna","sup",0);
                    kornaChar.AtkBuff();
                    yield return new WaitForSeconds(1f);
                }
                enemyHUD.SetHP(pinkChar.unit.currentHP);
                kornaObj.SetActive(true);
                kornaAnim.SetActive(false);
                animBackground.SetActive(false);
                bool isDead = pinkChar.unit.ProcessDeath(pinkChar.unit);
                if (isDead)
                {
                    // End battle
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.SECOND_PLAYERTURN;
                    StartCoroutine(AtTurn()); // enemy'e degil second playera gececek
                }
            }
            else
            {
                state = BattleState.SECOND_PLAYERTURN;
                StartCoroutine(AtTurn()); // enemy'e degil second playera gececek
            }
        }

        IEnumerator AtTurn()
        {
            //GameObject backUI = GameObject.FindGameObjectWithTag("atSkillUI");
            dialogueText.text = atChar.unit.unitName + " attacks!";
            atHUD.SetHUD(atChar.unit);
            yield return new WaitForSeconds(1);
            if (state == BattleState.SECOND_PLAYERTURN && !atDead)
            {
                atAnim.SetActive(true);
                atObj.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                atUI.SetActive(true);
                choiceTime = true;
                Debug.Log("SEÇ");
                
                if (atGuardUsed)
                {
                    atChar.unit.CoefficientNerf();
                    atGuardUsed = false;
                }


                while (choiceTime)
                {
                    yield return new WaitForSeconds(1f);
                }
                if (choiceSpace) // Guard
                {
                    atUI.SetActive(false);
                    SetAnimsAndAudio(atObj,atAnim,"At","g",0);
                    atChar.FirstSkill();
                    atGuardUsed = true;
                }
                else if (choiceA) // physical strike
                {
                    atUI.SetActive(false);
                    SetAnimsAndAudio(atObj,atAnim,"At","atk",0);
                    yield return new WaitForSeconds(1f);
                    atChar.SecondSkill(pinkChar.unit);
                }
                else if (choiceS) // attack buff
                {
                    atUI.SetActive(false);
                    SetAnimsAndAudio(atObj,atAnim,"At","osup",0);
                    yield return new WaitForSeconds(1f);
                    atChar.ThirdSkill(atChar.unit);
                }
                else if (choiceD) // provoke
                {
                    atUI.SetActive(false);
                    SetAnimsAndAudio(atObj,atAnim,"At","osup",0);
                    yield return new WaitForSeconds(1f);
                    atUsedProvoke = atChar.FourthSkill();
                }
                else if (choiceF) // expose
                {
                    atUI.SetActive(false);
                    SetAnimsAndAudio(atObj,atAnim,"At","osup",0);
                    yield return new WaitForSeconds(1f);
                    atChar.FifthSkill();
                }
                enemyHUD.SetHP(pinkChar.unit.currentHP);
                atObj.SetActive(true);
                atAnim.SetActive(false);
                animBackground.SetActive(false);
                bool isDead = pinkChar.unit.ProcessDeath(pinkChar.unit);
                if (isDead)
                {
                    // End battle
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    // Enemy turn
                    state = BattleState.THIRD_PLAYERTURN;
                    StartCoroutine(KarTurn()); 
                }
            }
            else
            {
                state = BattleState.THIRD_PLAYERTURN;
                StartCoroutine(KarTurn()); // enem
            }
        }

        IEnumerator KarTurn()
        {
            dialogueText.text = karChar.unit.unitName + " attacks!";
            karHUD.SetHUD(karChar.unit);
            yield return new WaitForSeconds(1);
            if (state == BattleState.THIRD_PLAYERTURN && !karDead)
            { 
                karAnim.SetActive(true);
                karObj.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                karUI.SetActive(true);
                choiceTime = true;
                Debug.Log("SEÇ");

                if (karGuardUsed)
                {
                    karChar.unit.CoefficientNerf();
                    karGuardUsed = false;
                }

                while (choiceTime)
                {
                    yield return new WaitForSeconds(1f);
                }
                if (choiceSpace) 
                {
                    karUI.SetActive(false);
                    SetAnimsAndAudio(karObj, karAnim, "Kar", "g", 0);  //g=guard, atk, osup=provoke,expose,invetigate, sup= heal,crit chance.... 
                    karChar.FirstSkill();
                }
                else if (choiceA)
                {
                    karUI.SetActive(false);
                    SetAnimsAndAudio(karObj, karAnim, "Kar", "atk", 0);
                    yield return new WaitForSeconds(1f);
                    karChar.SecondSkill(pinkChar.unit);
                    Debug.Log("Second choice");
                }
                else if (choiceS)
                {
                    karUI.SetActive(false);
                    SetAnimsAndAudio(karObj, karAnim, "Kar", "atk", 0); 
                    yield return new WaitForSeconds(1f);
                    karChar.ThirdSkill(pinkChar.unit);
                }
                else if (choiceD)
                {
                    karUI.SetActive(false);
                    SetAnimsAndAudio(karObj, karAnim, "Kar", "osup", 0); 
                    yield return new WaitForSeconds(1f);
                    karChar.FourthSkill();
                }
                else if (choiceF)
                {
                    karUI.SetActive(false);
                    SetAnimsAndAudio(karObj, karAnim, "Kar", "sup", 0);
                    yield return new WaitForSeconds(1f);
                    karChar.FifthSkill();
                }
                enemyHUD.SetHP(pinkChar.unit.currentHP);
                karObj.SetActive(true);
                karAnim.SetActive(false);
                animBackground.SetActive(false);
                bool isDead = pinkChar.unit.ProcessDeath(pinkChar.unit);
                if (isDead)
                {
                    // End battle
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.FOURTHPLAYER_TURN;
                    StartCoroutine(ZombiTurn());
                }
            }
            else
            {
                state = BattleState.FOURTHPLAYER_TURN;
                StartCoroutine(ZombiTurn()); 
            }
        }

        IEnumerator ZombiTurn()
        {
            dialogueText.text = zombiChar.unit.unitName + " attacks!";
            zombiHUD.SetHUD(zombiChar.unit);
            yield return new WaitForSeconds(1);
            if (state == BattleState.FOURTHPLAYER_TURN && !zombiDead)
            {
                zombiAnim.SetActive(true);
                zombiObj.SetActive(false);
                choiceTime = true;
                Debug.Log("SEÇ");
                yield return new WaitForSeconds(0.3f);
                zombiUI.SetActive(true);
                
                if (zombiGuardUsed)
                {
                    zombiChar.unit.CoefficientNerf();
                    zombiGuardUsed = false;
                }

                while (choiceTime)
                {
                    yield return new WaitForSeconds(1f);
                }
                if (choiceSpace)
                {
                    zombiUI.SetActive(false);
                    SetAnimsAndAudio(zombiObj, zombiAnim, "Zombi", "g", 0);  //g=guard, atk, osup=provoke,expose,invetigate, sup= heal,crit chance.... 
                    yield return new WaitForSeconds(1f);
                    zombiChar.FirstSkill();
                }
                else if (choiceA)
                {
                    zombiUI.SetActive(false);
                    SetAnimsAndAudio(zombiObj, zombiAnim, "Zombi", "sup", 0);  
                    yield return new WaitForSeconds(1f);
                    zombiChar.SecondSkill(atChar.unit);
                    zombiChar.SecondSkill(karChar.unit);
                    zombiChar.SecondSkill(kornaChar.unit);
                    zombiChar.SecondSkill(zombiChar.unit);
                    Debug.Log("Second choice");
                }
                else if (choiceS)
                {
                    zombiUI.SetActive(false);
                    SetAnimsAndAudio(zombiObj, zombiAnim, "Zombi", "sup", 0);
                    yield return new WaitForSeconds(1f);
                    zombiChar.ThirdSkill(pinkChar.unit);
                }
                else if (choiceD)
                {
                    zombiUI.SetActive(false);
                    SetAnimsAndAudio(zombiObj, zombiAnim, "Zombi", "atk", 0);
                    yield return new WaitForSeconds(1f);
                    zombiChar.FourthSkill(pinkChar.unit);
                }
                else if (choiceF)
                {
                    zombiUI.SetActive(false);
                    SetAnimsAndAudio(zombiObj, zombiAnim, "Zombi", "atk", 0);
                    yield return new WaitForSeconds(1f);
                    zombiChar.FifthSkill(pinkChar.unit);
                }
                enemyHUD.SetHP(pinkChar.unit.currentHP);
                zombiObj.SetActive(true);
                zombiAnim.SetActive(false);
                animBackground.SetActive(false);
                bool isDead = pinkChar.unit.ProcessDeath(pinkChar.unit);
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
            }
            else
            {
                // Enemy turn
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn()); 
            }
        }

        public void SetAnimsAndAudio(GameObject charObj, GameObject charAnim, string charName, string animType, int team)
        {
            GameObject _audioAtk = null;
            GameObject _audioDef = null;
            GameObject _audioSup = null;
            GameObject _guard = null;
            
            if (charName == "At")
            {
                _audioAtk = atAtkAudio;
                _audioDef = atDefAudio;
                _audioSup = atSupAudio;
            }
            else if (charName == "Kar")
            {
                _audioAtk = karAtkAudio;
                _audioDef = karDefAudio;
                _audioSup = karSupAudio;
            }
            else if (charName == "Korna")
            {
                _audioAtk = kornaAtkAudio;
                _audioDef = kornaDefAudio;
                _audioSup = kornaSupAudio;
            }
            else if (charName == "Zombi")
            {
                _audioAtk = zombiAtkAudio;
                _audioDef = zombiDefAudio;
                _audioSup = zombiSupAudio;
            }

           
            _guard = guardAudio;
            if (team == 0) // Our chars
            {
                if (animType=="g")
                {
                    guardAudio.GetComponent<AudioSource>().Play();
                }
                else if (animType=="atk")
                {
                    charAnim.GetComponent<Animator>().SetTrigger(charName+"-Attack");
                    pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Defans");
                    _audioAtk.GetComponent<AudioSource>().Play();
                    pinkDefAudio.GetComponent<AudioSource>().Play();
                    animBackground.SetActive(true);
                }
                else if (animType == "osup")
                {
                    charAnim.GetComponent<Animator>().SetTrigger(charName+"-Destek");
                    pinkAnim.GetComponent<Animator>().SetTrigger("Pink-Defans");
                    _audioSup.GetComponent<AudioSource>().Play();
                    animBackground.SetActive(true);
                }
                else if (animType == "sup")
                {
                    charAnim.GetComponent<Animator>().SetTrigger(charName+"-Destek");
                    _audioSup.GetComponent<AudioSource>().Play();
                }
            }
            else if(team == 1) // Pink bela
            {
                
            }
        }
        
    }
}