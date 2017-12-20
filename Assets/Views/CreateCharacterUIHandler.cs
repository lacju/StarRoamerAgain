using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class CreateCharacterUIHandler : MonoBehaviour
{

    public float startingCredits;
    public int skillPoints;
    public int availableSkillPoints;
    private List<PlayerSkill> playerSkills = new List<PlayerSkill>();
    public Sprite[] avatarPool = new Sprite[] { };
    private int avatarPoolIndex = 0;
    private int totalSpecializedSkills;
    public Image playerImage;
    public Text specSkillsTitle;
    public Text trainedSkillsTitle;
    public Text unTrainedSkillsTitle;
    public float specSkillsYStartLocation = 1617; //used
    public float distanceBetweenElements = 90; //used
    public float distanceFromSpecTitle; //used
    public float trainedTitleOffsetFromSpecList; //used
    public float distanceFromTrainedTitle; //used
    public float untrainedTitleOffsetFromTrainedList; //used
    public float distanceFromUntrainedTitle; //used
    public Text skillPointDisplay;
    public Text playerName;

    [Header("Skill Box Lower Skill Buttons")]
    public List<GameObject> lowerSkillButtons;
    [Header("Skill Box Rasie Skill Buttons")]
    public List<GameObject> raiseSkillButtons;
    private int specSkillsCount;
    private int trainedSkillsCount;
    private int untrainedSkillsCount;
    

    // private Text[] skillTitles = new Text[] {skill0Title, }

    [Header("Skill Title Fields")]
    public List<Text> skillTitles = new List<Text>();
    [Header("Skill Description Fields")]
    public List<Text> skillDesc = new List<Text>();
    [Header("Skill Cost Title Fields")]
    public List<Text> skillSPCostTitle = new List<Text>();
    [Header("Skill Cost Num Fields")]
    public List<Text> skillSPCostNum = new List<Text>();
    [Header("Skill Boxes")]
    public List<GameObject> skillBoxList = new List<GameObject>();

    void Awake()
    {
        availableSkillPoints = (int)GameManager.Instance.availableSkillPoints; 
        avatarPool = Resources.LoadAll<Sprite>("AvatarIcons");
        avatarPoolIndex = avatarPool.Length - 1;
        playerImage.sprite = avatarPool[2];

        PlayerSkill piloting = ScriptableObject.CreateInstance<PlayerSkill>();
        piloting.InitializeSkill("Piloting", "Affects the handling of your ship. Improves accelaration and maneuverability.", 0, 8, true, false);
        playerSkills.Add(piloting);
        PlayerSkill Engineering = ScriptableObject.CreateInstance<PlayerSkill>();
        Engineering.InitializeSkill("Engineering", "Improves effectiveness of ship subsystems.", 0, 6, true, false);
        playerSkills.Add(Engineering);
        PlayerSkill PlasmaWeapons = ScriptableObject.CreateInstance<PlayerSkill>();
        PlasmaWeapons.InitializeSkill("Plasma Weapons", "Increases effectiveness of plasma weapons.", 8, 10);
        playerSkills.Add(PlasmaWeapons);
        PlayerSkill EMWeapons = ScriptableObject.CreateInstance<PlayerSkill>();
        EMWeapons.InitializeSkill("EM Weapons", "Increases effectiveness of EM weapons.", 8, 10);
        playerSkills.Add(EMWeapons);
        PlayerSkill RadiationWeapons = ScriptableObject.CreateInstance<PlayerSkill>();
        RadiationWeapons.InitializeSkill("Radiation Weapons", "Increases effectiveness of radiation weapons.", 8, 10);
        playerSkills.Add(RadiationWeapons);
        PlayerSkill KineticWeapons = ScriptableObject.CreateInstance<PlayerSkill>();
        KineticWeapons.InitializeSkill("Kinetic Weapons", "Increases effectiveness of kinetic weapons.", 8, 10);
        playerSkills.Add(KineticWeapons);
        PlayerSkill SensorOperation = ScriptableObject.CreateInstance<PlayerSkill>();
        SensorOperation.InitializeSkill("Sensor Operation", "Increases sensor sensitivity allowing your radar to display objects at further distances.", 0, 6, true, false);
        playerSkills.Add(SensorOperation);
        PlayerSkill WeaponSystems = ScriptableObject.CreateInstance<PlayerSkill>();
        WeaponSystems.InitializeSkill("Weapon Systems", "Improves effectiveness of all weapon types. ", 12, 14, false);
        playerSkills.Add(WeaponSystems);
        PlayerSkill ShieldMastery = ScriptableObject.CreateInstance<PlayerSkill>();
        ShieldMastery.InitializeSkill("Shield Mastery", "Your extensive study into the field of directed energy barriers allows you to further improve your ship's shield systems.", 8, 10);
        playerSkills.Add(ShieldMastery);
        PlayerSkill Mechanics = ScriptableObject.CreateInstance<PlayerSkill>();
        Mechanics.InitializeSkill("Mechanics", "Having spent countless hours patching micro-fissures and hull fractures you've picked up a few tricks to help your hull last a little longer before exposing you to space. ", 0, 4, true, false);
        playerSkills.Add(Mechanics);
        PlayerSkill ArmorMastery = ScriptableObject.CreateInstance<PlayerSkill>();
        ArmorMastery.InitializeSkill("Armor Mastery", "The standard in early space combat, advanced space craft armor is starting to make a comeback. You've also know how to make it as efficient as possible. ", 8, 10);
        playerSkills.Add(ArmorMastery);
        PlayerSkill MasterMerchant = ScriptableObject.CreateInstance<PlayerSkill>();
        MasterMerchant.InitializeSkill("Master Merchant", "The golden tongue runs in the family, or so you say. Regardless, you never have a problem getting the best deals. \n (0.15% increase to reactor output per skillpoint)", 12, 14);
        playerSkills.Add(MasterMerchant);
        PlayerSkill ReactorCalibration = ScriptableObject.CreateInstance<PlayerSkill>();
        ReactorCalibration.InitializeSkill("Reactor Calibration", "Well versed in the operation of self-contained reators you have no issues squeezing the most out of your power plant. \n (0.15% increase to reactor output per skillpoint)", 6, 8);
        playerSkills.Add(ReactorCalibration);
        PlayerSkill WeightOptimization = ScriptableObject.CreateInstance<PlayerSkill>();
        WeightOptimization.InitializeSkill("Weight Optimization", "Through somewhat questionable methods you've managed to increase the amount cargo weight your ship can carry. \n (0.10% reduction in weight of all goods in cargoh hold per skillpoint)", 8, 10);
        playerSkills.Add(WeightOptimization);
        PlayerSkill SensorDampening = ScriptableObject.CreateInstance<PlayerSkill>();
        SensorDampening.InitializeSkill("Sensor Dampening", "Using various techniques you've picked up over the years you're able to reduce your ships sensor signature effectively masking you from other ships. ", 10, 12);
        playerSkills.Add(SensorDampening);
        PlayerSkill RepairBotOperation = ScriptableObject.CreateInstance<PlayerSkill>();
        RepairBotOperation.InitializeSkill("Repair Bot Operation", "Repair bots can be a real life saver sometimes and they're also something you're way too familiar with. ", 6, 4);
        playerSkills.Add(RepairBotOperation);
        PlayerSkill EngineOperation = ScriptableObject.CreateInstance<PlayerSkill>();
        EngineOperation.InitializeSkill("Engine Operation", "Those early days racing with your friends and running from docking control really paid off, no one is as good at squeezing a little more from their engines than you. \n (+0.05% to Engine speed per skillpoint) ", 0, 6, true, false);
        playerSkills.Add(EngineOperation);
        PlayerSkill EquipmentDealer = ScriptableObject.CreateInstance<PlayerSkill>();
        EquipmentDealer.InitializeSkill("Equipment Dealer", "You've learned a thing or two about moving high-tech merchandise over the years, mostly that it pays. \n (+0.05% to the sell value of any Equipment per skillpoint) ", 10, 12);
        playerSkills.Add(EquipmentDealer);
        PlayerSkill TurretOperator = ScriptableObject.CreateInstance<PlayerSkill>();
        TurretOperator.InitializeSkill("Turret Operation", "Turrets are great for defense, and maybe a little offense with the right gear, but they require a lot of practice and some genuine skill to use", 8, 6);
        playerSkills.Add(TurretOperator);
    }
    private void SortListBySpecialzedSkill()
    {
        List<PlayerSkill> specialzedSkills = new List<PlayerSkill>();
        List<PlayerSkill> trainedSkills = new List<PlayerSkill>();
        List<PlayerSkill> untrainedSkills = new List<PlayerSkill>();
        List<PlayerSkill> tempSkillList = new List<PlayerSkill>();

        foreach (var s in playerSkills)
        {
            if (s.skillSpecialized)
            {
                specialzedSkills.Add(s);
            }
        }

        foreach (var t in playerSkills)
        {
            if (!t.skillSpecialized && t.skillTrained)
            {
                trainedSkills.Add(t);
            }
        }
        foreach (var u in playerSkills)
        {
            if (!u.skillSpecialized && !u.skillTrained)
            {
                untrainedSkills.Add(u);
            }
        }
        foreach (var ss in specialzedSkills)
        {
            tempSkillList.Add(ss);
        }

        foreach (var ts in trainedSkills)
        {
            tempSkillList.Add(ts);
        }

        foreach (var us in untrainedSkills)
        {
            tempSkillList.Add(us);
        }

        specSkillsCount = specialzedSkills.Count;
        trainedSkillsCount = trainedSkills.Count;
        untrainedSkillsCount = untrainedSkills.Count;

        playerSkills = tempSkillList;
    }
    private void Start()
    {
        UpdateSkillList();
    }
    private void Update()
    {
        skillPointDisplay.text = availableSkillPoints.ToString();
        UpdateSkillList();
        SetButtonStatus();
        
    }
    public void LowerSkill(int skillSlot)
    {
        if (playerSkills[skillSlot].skillTrained && playerSkills[skillSlot].canBeUntrained)
        {
            playerSkills[skillSlot].UnTrainSkill();
            availableSkillPoints += playerSkills[skillSlot].skillPointTrainCost;
        }
        if (playerSkills[skillSlot].skillSpecialized)
        {
            playerSkills[skillSlot].UnSpecializeSkill();
            totalSpecializedSkills--;
            availableSkillPoints += playerSkills[skillSlot].skillPointSpecializationCost;
        }
        UpdateSkillList();
    }
    public void RaiseSkill(int skillSlot)
    {
        if (playerSkills[skillSlot].skillTrained && availableSkillPoints >= playerSkills[skillSlot].skillPointSpecializationCost)
        {
            playerSkills[skillSlot].SpecializeSkill();
            totalSpecializedSkills++;
            availableSkillPoints -= playerSkills[skillSlot].skillPointSpecializationCost;
        }
        if (!playerSkills[skillSlot].skillTrained && !playerSkills[skillSlot].skillSpecialized && availableSkillPoints >= playerSkills[skillSlot].skillPointTrainCost)
        {
            playerSkills[skillSlot].TrainSkill();
            availableSkillPoints -= playerSkills[skillSlot].skillPointTrainCost;
        }
        UpdateSkillList();
    }
    public void PreviousAvatar() //Cycles to the previous avatar when the left button is clicked
    {       
        if (avatarPoolIndex == 0)
        {
            avatarPoolIndex = avatarPool.Length - 1;
        }
        else
        {
            avatarPoolIndex--; 
        }
        playerImage.sprite= avatarPool[avatarPoolIndex];
        UpdateSkillList();
    }
    public void NextAvatar() //Cycles to the next avatar when the left button is clicked
    {
        if (avatarPoolIndex == avatarPool.Length - 1 )
        {
            avatarPoolIndex = 0;
        }
        else
        {
            avatarPoolIndex++;
            
        }
        playerImage.sprite= avatarPool[avatarPoolIndex];
        UpdateSkillList();
    }
    //public void MerchantPreset()
    //{
    //    SpecializeSKill("Master Merchant");
    //    SpecializeSKill("Shield Mastery");
    //    SpecializeSKill("Weight Optimization");
    //    TrainSKill("Sensor Dampening");
    //    TrainSKill("Engineering");
    //    TrainSKill("Sensor Operation");
    //    TrainSKill("Mechanics");
    //    TrainSKill("Weapon Systems");
    //    TrainSKill("Piloting");
    //    UpdateSkillList();
    //}
    //public void MercenaryPreset()
    //{
    //    SpecializeSKill("Weapon Systems");
    //    SpecializeSKill("Shield Mastery");
    //    SpecializeSKill("Plasma Weapons");
    //    TrainSKill("EM Weapons");
    //    TrainSKill("Engineering");
    //    TrainSKill("Sensor Operation");
    //    TrainSKill("Mechanics");
    //    TrainSKill("Piloting");
    //    UpdateSkillList();
    //}
    //public void AdventurerPreset()
    //{
    //    foreach (var i in playerSkills)
    //    {
    //        if (i.canBeUntrained)
    //        {
    //            i.skillTrained = false;
    //            i.skillSpecialized = false;
    //        }
    //        if (!i.canBeUntrained)
    //        {
    //            i.skillTrained = true;
    //        }
    //    }
    //    UpdateSkillList();
    //}
    private void SetButtonStatus()
    {
        foreach (PlayerSkill skill in playerSkills)
        {
            if (skill.skillTrained)
            {

                if (skill.canBeUntrained)
                {
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }
                else
                {
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                }
                if (availableSkillPoints >= skill.skillPointSpecializationCost)
                {
                    raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }

            }

            if (skill.skillSpecialized)
            {
                raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
            }
            else if (!skill.skillTrained)
            {
                lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                if (availableSkillPoints >= skill.skillPointTrainCost)
                {
                    raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }
            }
        }
    }
    public void UpdateSkillList() //Called on click, updates the skill list UI placing specialized skills at the top, followed by trained skills, followed finally by untrained skills
    {
        int index = 0;

        SortListBySpecialzedSkill();

        float previousElementYPosition = 0;

            specSkillsTitle.transform.localPosition = new Vector3(-213, specSkillsYStartLocation, 0);
            previousElementYPosition = specSkillsTitle.transform.localPosition.y - distanceFromSpecTitle;
        for (int i = 0; i < specSkillsCount; i++)
        {
            skillBoxList[i].transform.localPosition = new Vector3(0, (previousElementYPosition - distanceBetweenElements) , 0);
            previousElementYPosition = skillBoxList[i].transform.localPosition.y;

        }


            trainedSkillsTitle.transform.localPosition = new Vector3(-213, (previousElementYPosition - trainedTitleOffsetFromSpecList), 0);

        previousElementYPosition = trainedSkillsTitle.transform.localPosition.y - distanceFromTrainedTitle;
        for (int i = specSkillsCount; i < trainedSkillsCount + specSkillsCount; i++)
        {
           
            skillBoxList[i].transform.localPosition = new Vector3(0, (previousElementYPosition - distanceBetweenElements) , 0);
            previousElementYPosition = skillBoxList[i].transform.localPosition.y;
        }

        unTrainedSkillsTitle.transform.localPosition = new Vector3(-213, previousElementYPosition - untrainedTitleOffsetFromTrainedList, 0);
        previousElementYPosition = unTrainedSkillsTitle.transform.localPosition.y - distanceFromUntrainedTitle;
        for (int i = trainedSkillsCount + specSkillsCount; i < skillBoxList.Count; i++)
        {
            skillBoxList[i].transform.localPosition = new Vector3(0, (previousElementYPosition - distanceBetweenElements), 0);
            previousElementYPosition = skillBoxList[i].transform.localPosition.y;

        }



        foreach (var skill in playerSkills)
        {

            skillTitles[playerSkills.IndexOf(skill)].text = skill.skillName;
            skillDesc[playerSkills.IndexOf(skill)].text = skill.skillDescription;

            if (skill.skillTrained)
            {
                skillSPCostTitle[playerSkills.IndexOf(skill)].text = "Skill Credits to Specialize: ";
                skillSPCostNum[playerSkills.IndexOf(skill)].text = skill.skillPointSpecializationCost.ToString();
                skillSPCostNum[playerSkills.IndexOf(skill)].alignment = TextAnchor.MiddleCenter;
               

            }
            if (skill.skillSpecialized)
            {
                skillSPCostTitle[playerSkills.IndexOf(skill)].text = "";
                skillSPCostNum[playerSkills.IndexOf(skill)].text = "";
          
            }
            else if (!skill.skillTrained)
            {
                skillSPCostTitle[playerSkills.IndexOf(skill)].text = "Skill Credits to Train: ";
                skillSPCostNum[playerSkills.IndexOf(skill)].text = skill.skillPointTrainCost.ToString();
                skillSPCostNum[playerSkills.IndexOf(skill)].alignment = TextAnchor.MiddleCenter;
             
            }


            index++;
        }
        index = 0;
    }
    public void SelectShip(string scene)
    {
        
        DontDestroyOnLoad(GameManager.Instance);
       // GameManager.Instance.SetCredits(startingCredits);
        GameManager.Instance.SetName(playerName.text);
        GameManager.Instance.SetPlayerSkills(playerSkills);
        GameManager.Instance.SetPlayerAvatar(playerImage.sprite);
        GameManager.Instance.SetAvailableSkillPoints(availableSkillPoints);
        GameManager.Instance.PopulateStarterEquipment();       
        SceneManager.LoadScene(scene);

        }
    }









