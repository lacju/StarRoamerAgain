using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : ScriptableObject {

    public string skillName;
    public string skillDescription;
    public int currentSkillLevel;
    public float expToRaise = 5000;
    public bool skillTrained;
    public bool skillSpecialized = false;
    public bool canBeUntrained;
    private float totalExpSpent; //holds the total amount of experience points the player has spent on this skill, allows for the ability to off a respec and refund spent xp
    private PlayerObject _POC;
    private float specializationModifier = .3965517241f;
    private float specializationModifierMultiplier = 1.0003f;
    private float expCostModifier = .3965517241f;
    private float expCostModifierMultiplier = 1.0003f;
    public int skillPointTrainCost;
    public int skillPointSpecializationCost;
    private Image skillIcon;


      public void InitializeSkill(string name, string description, int skillPointCostTrain, int skillPointCostSpec,  bool trained = false, bool canbeuntrained = true)
    {
        skillName = name;
        skillDescription = description;
        skillTrained = trained;
        skillPointTrainCost = skillPointCostTrain;
        skillPointSpecializationCost = skillPointCostSpec;
        skillIcon = Resources.Load<Image>("SkillIcons/" + skillName);
        canBeUntrained = canbeuntrained;
    }

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
    }

    public void TrainSkill()
    {
        skillTrained = true;
        currentSkillLevel = 35;
    }

    public void UnTrainSkill()
    {
        skillTrained = false;
        currentSkillLevel = 0;
    }

    public void UnSpecializeSkill()
    {
        skillSpecialized = false;
        skillTrained = true;
        currentSkillLevel = 35;
    }

    public void SpecializeSkill()
    {
        skillSpecialized = true;
        currentSkillLevel = 50;
    }

    public void RaiseSkill()
    {
        if (skillSpecialized && _POC.GetCurrentExperience() >= expToRaise)
        {
            currentSkillLevel++;
            _POC.RemoveExperiencePoints(expToRaise);
            totalExpSpent += expToRaise;
            expToRaise *= specializationModifier;

            if (currentSkillLevel % 5 == 0)
            {
                specializationModifier *= 1.0003f;
            }

            if (currentSkillLevel % 15 == 0)
            {
                specializationModifierMultiplier *= 1.005f;
            }
        }
        else if (_POC.GetCurrentExperience() >= expToRaise)
        {
            currentSkillLevel++;
            _POC.RemoveExperiencePoints(expToRaise);
        }

        if (currentSkillLevel % 4 == 0)
        {
            expCostModifier *= 1.0003f;
        }

        if (currentSkillLevel % 10 == 0)
        {
            expCostModifierMultiplier *= 1.005f;
        }

        expToRaise += (expToRaise * expCostModifier);


    }

}
