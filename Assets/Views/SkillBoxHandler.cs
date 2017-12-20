using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBoxHandler : MonoBehaviour {

    private List<PlayerSkill> playerSkills = new List<PlayerSkill>();
    public Text specSkillsTitle;
    public Text trainedSkillsTitle;
    public Text unTrainedSkillsTitle;
    public float distanceBetweenElements;
    public float specSkillsTitleLocation; //used
    public float distanceFromSpecTitle; //used
    public float trainedTitleOffsetFromSpecList; //used
    public float distanceFromTrainedTitle; //used
    public float untrainedTitleOffsetFromTrainedList; //used
    public float distanceFromUntrainedTitle; //used
    private int totalSpecializedSkills;
    private int availableSkillPoints;
    [Header("Skill Box Lower Skill Buttons")]
    public List<GameObject> lowerSkillButtons;
    [Header("Skill Box Rasie Skill Buttons")]
    public List<GameObject> raiseSkillButtons;
    private int specSkillsCount;
    private int trainedSkillsCount;
    private int untrainedSkillsCount;
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
    private PlayerObject _POC;
    private bool allowSkillSpecialization;

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
    }
    private void OnEnable()
    {
        playerSkills = _POC.playerSkills;
        availableSkillPoints = _POC.availableSkillPoints;
    }
    private void Update()
    {
        UpdateSkillList();
        SetButtonStatus();
    }
    private void OnDisable()
    {
        _POC.SetAvailableSkillPoints(availableSkillPoints);
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
    } //Sorts the skills in the list. Specialized -> Trained -> Untrained.
    public void UpdateSkillList() //Called on click, updates the skill list UI placing specialized skills at the top, followed by trained skills, followed finally by untrained skills
    {
        int index = 0;



        
        SortListBySpecialzedSkill();

        float previousElementYPosition = 0;

        specSkillsTitle.transform.localPosition = new Vector3(-213, specSkillsTitleLocation, 0);
        previousElementYPosition = specSkillsTitle.transform.localPosition.y - distanceFromSpecTitle;
        for (int i = 0; i < specSkillsCount; i++)
        {
            skillBoxList[i].transform.localPosition = new Vector3(0, (previousElementYPosition - distanceBetweenElements), 0);
            previousElementYPosition = skillBoxList[i].transform.localPosition.y;

        }


        trainedSkillsTitle.transform.localPosition = new Vector3(-213, (previousElementYPosition - trainedTitleOffsetFromSpecList), 0);

        previousElementYPosition = trainedSkillsTitle.transform.localPosition.y - distanceFromTrainedTitle;
        for (int i = specSkillsCount; i < trainedSkillsCount + specSkillsCount; i++)
        {

            skillBoxList[i].transform.localPosition = new Vector3(0, (previousElementYPosition - distanceBetweenElements), 0);
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
                if (!allowSkillSpecialization)
                {
                    skillSPCostTitle[playerSkills.IndexOf(skill)].text = "Experience cost to raise: ";
                    skillSPCostNum[playerSkills.IndexOf(skill)].text = skill.expToRaise.ToString();
                    skillSPCostNum[playerSkills.IndexOf(skill)].alignment = TextAnchor.MiddleCenter;
                }
                else
                {
                    skillSPCostTitle[playerSkills.IndexOf(skill)].text = "Skill Credits to Specialize: ";
                    skillSPCostNum[playerSkills.IndexOf(skill)].text = skill.skillPointSpecializationCost.ToString();
                    skillSPCostNum[playerSkills.IndexOf(skill)].alignment = TextAnchor.MiddleCenter;
                }
            }
            if (skill.skillSpecialized)
            {
                if (allowSkillSpecialization)
                {
                    skillSPCostTitle[playerSkills.IndexOf(skill)].text = "";
                    skillSPCostNum[playerSkills.IndexOf(skill)].text = "";
                }
                else
                {
                    skillSPCostTitle[playerSkills.IndexOf(skill)].text = "Experience cost to raise: ";
                    skillSPCostNum[playerSkills.IndexOf(skill)].text = skill.expToRaise.ToString();
                }

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
    private void SetButtonStatus()
    {
        foreach (PlayerSkill skill in playerSkills)
        {
            if (skill.skillTrained)
            {

                if (skill.canBeUntrained && allowSkillSpecialization)
                {
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }
                else
                {
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                }
                if (availableSkillPoints >= skill.skillPointSpecializationCost || !allowSkillSpecialization)
                {
                    raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }

            }

            if (skill.skillSpecialized)
            {
                if (allowSkillSpecialization)
                {
                    raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                }
                else
                {
                    raiseSkillButtons[playerSkills.IndexOf(skill)].SetActive(true);
                    lowerSkillButtons[playerSkills.IndexOf(skill)].SetActive(false);
                }

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
    } //Toggles the visibility of skillbox buttons based on availablity of skill points and experience points.
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
    } //Called by button to lower a skill from it's current training level to the previous, only available during character creation.
    public void RaiseSkill(int skillSlot)
    {
        if (playerSkills[skillSlot].skillTrained && availableSkillPoints >= playerSkills[skillSlot].skillPointSpecializationCost && allowSkillSpecialization)
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
        if (playerSkills[skillSlot].skillTrained && !allowSkillSpecialization)
        {
            RaisSkillLevel(skillSlot);
        }
        UpdateSkillList();
    } //Called by button to raise a skill from it's current training level to the next, assuming available skill points.
    public void RaisSkillLevel(int skillSlot)
    {
        playerSkills[skillSlot].RaiseSkill();
    }
}
