using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {



    public enum QuestType
    {
        KillXofY, KillNamed, Explore, Delivery, CollectXofY, Escort, Defend, 
    }

    public QuestType questType;
    public QuestItem requiredItem;
    public int quanitityRequired; //number of items to collect or enemies to kill depending on quest type
    public string questName;
    public string questDescription;
    public NPC.NPCType questTarget; //Kill target, Escort target, Defense target to be spawned
  //  public NPC.Faction targetFaction; //Faction to apply to the spawned target
    bool questAccepted; //if true the targets are spawned;
    public float creditReward;
    public float expReward;
    public Item itemReward; 

    public void InitializeQuestKillXofY(string questname, string questdesc, int quantToKill, NPC.NPCType typeToKill, float expreward = 0, float creditreward = 0, Item itemreward = null)
    {
        questName = questname;
        questDescription = questdesc;
        quanitityRequired = quantToKill;
        questTarget = typeToKill;
        expReward = expreward;
        creditReward = creditreward;
        itemreward = itemReward;
    }




}
