//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Linq;

//public class NewGameMenuController : MonoBehaviour
//{

//    private float availableSP;
//    private float pilot;
//    private float charisma;
//    private float engineering;
//    private float tactical;
//    private float mechanic;
//    private float totalSPSpent;
//    private List<PlayerSkill> playerSkills = new List<PlayerSkill>();

//    // private Text[] skillTitles = new Text[] {skill0Title, }

//    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
//    public Text[] skillTitles = new Text[] { };
//    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
//    public Text[] skillDesc = new Text[] { };
//    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
//    public Text[] skillSPCostTitle = new Text[] { };
//    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
//    public Text[] skillSPCostNum = new Text[] { };



    //void Awake()
    //{
    //    playerSkills.Add(new PlayerSkill("Piloting", "Affects the handling of your ship. Improves accelaration and maneuverability.", 0, 4, true));
    //    playerSkills.Add(new PlayerSkill("Engineering", "Improves effectiveness of ship subsystems.", 0, 4, true));
    //    playerSkills.Add(new PlayerSkill("Plasma Weapons", "Increases effectiveness of plasma weapons.", 8, 10));
    //    playerSkills.Add(new PlayerSkill("EM Weapons", "Increases effectiveness of EM weapons.", 8, 10));
    //    playerSkills.Add(new PlayerSkill("Radiation Weapons", "Increases effectiveness of radiation weapons.", 8, 10));
    //    playerSkills.Add(new PlayerSkill("Kinetic Weapons", "Increases effectiveness of kinetic weapons.", 8, 10));
    //    playerSkills.Add(new PlayerSkill("Sensor Operation", "Increases sensor sensitivity allowing your radar to display objects at further distances.", 0, 4, true));
    //    playerSkills.Add(new PlayerSkill("Weapon Systems", "Improves effectiveness of all weapon types. ", 0, 10, true));
    //    playerSkills.Add(new PlayerSkill("Shield Mastery", "Your extensive study into the field of directed energy barriers allows you to further improve your ship's shield systems.", 8, 6));
    //    playerSkills.Add(new PlayerSkill("Mechanics", "Having spent countless hours patching micro-fissures and hull fractures you've picked up a few tricks to help your hull last a little longer before exposing you to space. ", 0, 4, true));
    //    playerSkills.Add(new PlayerSkill("Armor Mastery", "The standard in early space combat, advanced space craft armor is starting to make a comeback. You've also know how to make it as efficient as possible. ", 8, 6));
    //    playerSkills.Add(new PlayerSkill("Master Merchant", "The golden tongue runs in the family, or so you say. Regardless, you never have a problem getting the best deals. ", 8, 10));
    //    playerSkills.Add(new PlayerSkill("Reactor Calibration", "Well versed in the operation of self-contained reators you have no issues squeezing the most out of your power plant. ", 6, 4));
    //    playerSkills.Add(new PlayerSkill("Weight Optimization", "Through somewhat questionable methods you've managed to increase the amount cargo weight your ship can carry. ", 6, 4));
    //    playerSkills.Add(new PlayerSkill("Sensor Dampening", "Using various techniques you've picked up over the years you're able to reduce your ships sensor signature effectively masking you from other ships. ", 10, 12));
    //    playerSkills.Add(new PlayerSkill("Repair Bot Operation", "Repair bots can be a real life saver sometimes and they're also something you're way too familiar with. ", 6, 4));
//    //    playerSkills.Add(new PlayerSkill("Engine Operation", "Those early days racing with your friends and running from docking control really paid off, no one is as good at squeezing a little more from their engines than you. ", 8, 6));

//    //    playerSkills.OrderBy(s => s.skillTrained).ToList();
//    //    playerSkills.OrderBy(s => s.skillTrained).ToList();
//    //}

//    //private void Start()
//    //{

//    //}

//    //public void UpdateSkillList()
//    //{
//    //    int index = 0;

//    //    foreach (var i in playerSkills)
//    //    {
//            skillTitles[index].text = i.skillName;
//            skillDesc[index].text = i.skillName;

//            if (i.skillTrained)
//            {
//                skillSPCostTitle[index].text = "Skill Credits to Specialize: ";
//                skillSPCostNum[index].text = i.skillPointSpecializationCost.ToString();
//            }
//            if (i.skillSpecialized)
//            {
//                skillSPCostTitle[index].text = "";
//                skillSPCostNum[index].text = "";
//            }
//            else
//            {
//                skillSPCostTitle[index].text = "Skill Credits to Train: ";
//                skillSPCostNum[index].text = i.skillPointTrainCost.ToString();
//            }

//            index++;
//        }
//    }
//}


   // private void Update()
   // {
   //     totalSPSpent = pilot + charisma + engineering + mechanic + tactical;
   //     if (totalSPSpent < 16)
   //     {
   //         availableSP = 16 - totalSPSpent;
   //     }

   //     //pilot = float.Parse(GameObject.Find("PilotSkillLevel").GetComponent<Text>().text);
   //     //charisma = float.Parse(GameObject.Find("CharismaSkillLevel").GetComponent<Text>().text);
   //     //engineering = float.Parse(GameObject.Find("EngineeringSkillLevel").GetComponent<Text>().text);
   //     //tactical = float.Parse(GameObject.Find("TacticalSkillLevel").GetComponent<Text>().text);
   //     //mechanic = float.Parse(GameObject.Find("MechanicSkillLevel").GetComponent<Text>().text);
   //     //availableSP = float.Parse(GameObject.Find("AvailSP").GetComponent<Text>().text);

   //     GameObject.Find("PilotSkillLevel").GetComponent<Text>().text = pilot.ToString();
   //     GameObject.Find("CharismaSkillLevel").GetComponent<Text>().text = charisma.ToString();
   //     GameObject.Find("EngineeringSkillLevel").GetComponent<Text>().text = engineering.ToString();
   //     GameObject.Find("TacticalSkillLevel").GetComponent<Text>().text = tactical.ToString();
   //     GameObject.Find("MechanicSkillLevel").GetComponent<Text>().text = mechanic.ToString();
   //     GameObject.Find("AvailSP").GetComponent<Text>().text = availableSP.ToString();
   // }

        

   // public void NameEntered()
   // {
   ////     GameManager.Instance.SetName(GetComponent<InputField>().text);
   // }

   // public void StartGame(string scene)
   // {
   //     if (!(availableSP > 0))
   //     {
   //         Debug.Log("loop penetrated");
   //         GameManager.Instance.SetCharismaSkill(charisma);
   //         GameManager.Instance.SetCredits(100);
   //         GameManager.Instance.SetEngineeringSkill(engineering);
   //         GameManager.Instance.SetMechanicSkill(mechanic);
   //   //      GameManager.Instance.SetName(GetComponent<InputField>().text);
   //         GameManager.Instance.SetPilotSkill(pilot);
   //         GameManager.Instance.SetTacticalSkill(tactical);
   //         Debug.Log("props set");
   //         DontDestroyOnLoad(GameManager.Instance);
   //         SceneManager.LoadScene(scene);
   //         Debug.Log("scene loaded");
   //     }
   // }

