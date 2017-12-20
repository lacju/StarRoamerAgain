using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GlobalGameManager))]
public class GlobalGameManagerEditor : Editor
{
    GlobalGameManager gb;

    private void OnEnable()
    {
        gb = (GlobalGameManager)target;
    }

    protected static bool showWeaponSettings = true;
    protected static bool showShieldSettings = true;
    protected static bool showArmorSettings = true;
    protected static bool showEngineSettings = true;
    protected static bool showReactorSettings = true;
    protected static bool showLocationInfo = true;
    protected static bool showPlayerInfo = true;
    protected static bool showShipSettings = true;
    protected static bool showStarterEquipment = true;
    protected static bool showUISettings = true;
    protected static bool showPersistentObjectsSettings = true;
    protected static bool showDebugOptions = true;

    public override void OnInspectorGUI()
    {
        // This is where the magic happens.

        GUIStyle titleStyles = new GUIStyle(EditorStyles.boldLabel);
        titleStyles.fontStyle = FontStyle.Bold;
        titleStyles.fontSize = 12;
        GUIStyle titleStylesFoldout = new GUIStyle(EditorStyles.foldout);
        titleStylesFoldout.fontStyle = FontStyle.Bold;
        titleStylesFoldout.fontSize = 12;
        GUIStyle titleStylesFoldoutSubFoldout = new GUIStyle(EditorStyles.foldout);
        titleStylesFoldoutSubFoldout.fontStyle = FontStyle.Bold;

        showLocationInfo = EditorGUILayout.Foldout(showLocationInfo, "Location Info", titleStylesFoldout);
        if (showLocationInfo)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Current Scene: ", gb.currentScene);
            gb.locationInScene = EditorGUILayout.Vector3Field("Location in scene: ", gb.locationInScene);
            gb.playerStartingLocationFirstScene = EditorGUILayout.Vector3Field("Player starting location: ", gb.playerStartingLocationFirstScene);
            EditorGUI.indentLevel--;
        }

        showPlayerInfo = EditorGUILayout.Foldout(showPlayerInfo, "Player Info", titleStylesFoldout);
        if (showPlayerInfo)
        {
            EditorGUI.indentLevel++;
            gb.playerName = EditorGUILayout.TextField("Player name: ", gb.playerName);
            gb.playerAvater = (Sprite)EditorGUILayout.ObjectField("Player avatar: ", gb.playerAvater, typeof(Sprite), true);
            gb.playerLevel = EditorGUILayout.FloatField("Player level: ", gb.playerLevel);
            gb.experiencePoints = EditorGUILayout.FloatField("Available experience: ", gb.experiencePoints);
            gb.totalExperiencePointsEarned = EditorGUILayout.FloatField("Total earned experience: ", gb.totalExperiencePointsEarned);
            gb.availableSkillPoints = EditorGUILayout.FloatField("Available skill points: ", gb.availableSkillPoints);
            gb.totalSkillPointsEarned = EditorGUILayout.FloatField("Total earned skill points: ", gb.totalSkillPointsEarned);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("playerSkills"), true);
            gb.playerShip = (Hull)EditorGUILayout.ObjectField("Player ship: ", gb.playerShip, typeof(Hull), true);
            gb.playerObject = (PlayerObject)EditorGUILayout.ObjectField("PlayerObject: ", gb.playerObject, typeof(PlayerObject), true);


            EditorGUI.indentLevel--;
        }

        showShipSettings = EditorGUILayout.Foldout(showShipSettings, "Ship Settings", titleStylesFoldout);
        if (showShipSettings)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("hullListTierOne"), true);
            EditorGUI.indentLevel++;
            gb.persistentObjectToAdd = (GameObject)EditorGUILayout.ObjectField("Hull to Add to Tier One: ", gb.persistentObjectToAdd, typeof(GameObject), true);
            if (GUILayout.Button("Add to List"))
            {
                gb.AddHullToTierOneList();
            }
            if (GUILayout.Button("Clear List"))
            {
                gb.ClearHullToTierOneList();
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("hullListTierTwo"), true);
            EditorGUI.indentLevel++;
            gb.persistentObjectToAdd = (GameObject)EditorGUILayout.ObjectField("Hull to Add to Tier Two: ", gb.persistentObjectToAdd, typeof(GameObject), true);
            if (GUILayout.Button("Add to List"))
            {
                gb.AddHullToTierTwoList();
            }
            if (GUILayout.Button("Clear List"))
            {
                gb.ClearHullToTierTwoList();
            }
            EditorGUI.indentLevel--;
            EditorGUI.indentLevel--;

        }

        showStarterEquipment = EditorGUILayout.Foldout(showStarterEquipment, "Starting Equipment Settings", titleStylesFoldout);
        if (showStarterEquipment)
        {
            EditorGUI.indentLevel ++;
            showWeaponSettings = EditorGUILayout.Foldout(showWeaponSettings, "Weapon Stats", titleStylesFoldoutSubFoldout);
            if (showWeaponSettings)
            {
                EditorGUI.indentLevel++;
                gb.starterWeaponMaxDmg = EditorGUILayout.Slider("Maximum damage: ", gb.starterWeaponMaxDmg, 0, 120);
                gb.starterWeaponMinDmg = EditorGUILayout.Slider("Minimum damage: ", gb.starterWeaponMinDmg, 0, 80);
                gb.starterWeaponRefireRate = EditorGUILayout.Slider("Fire rate: ", gb.starterWeaponRefireRate, 0, 15);
                gb.starterWeaponEnergyCost = EditorGUILayout.Slider("Energy per shot: ", gb.starterWeaponEnergyCost, 0, 40);
                gb.starterWeaponProjectileVelocity = EditorGUILayout.Slider("Projectile velocity: ", gb.starterWeaponProjectileVelocity, 0, 1500);
                gb.starterWeaponProjectile = (Projectile)EditorGUILayout.ObjectField("Projectile: ", gb.starterWeaponProjectile, typeof(Projectile), true);
                gb.starterWeaponIcon = (Sprite)EditorGUILayout.ObjectField("Inventory icon: ", gb.starterWeaponIcon, typeof(Sprite), true);
                EditorGUI.indentLevel--;
            }
            showShieldSettings = EditorGUILayout.Foldout(showShieldSettings, "Shield Stats", titleStylesFoldoutSubFoldout);
            if (showShieldSettings)
            {
                EditorGUI.indentLevel++;
                gb.starterShieldMaxCapacity = EditorGUILayout.Slider("Maximum capacity: ", gb.starterShieldMaxCapacity, 0, 1000);
                gb.starterShieldRechargeRate = EditorGUILayout.Slider("Recharge rate: ", gb.starterShieldRechargeRate, 0, 50);
                gb.starterRechargeDelay = EditorGUILayout.Slider("Recharge delay: ", gb.starterRechargeDelay, 0, 25);
                gb.starterShieldDmgTypeResistRate = EditorGUILayout.Slider("Damage type resistance %: ", gb.starterShieldDmgTypeResistRate, 0, 1);
                gb.starterShieldDmgTypeWeaknessRate = EditorGUILayout.Slider("Damage type weakness %: ", gb.starterShieldDmgTypeWeaknessRate, 0, 1);
                gb.starterShieldIcon = (Sprite)EditorGUILayout.ObjectField("Inventory icon: ", gb.starterShieldIcon, typeof(Sprite), true);
                EditorGUI.indentLevel--;
            }
            showArmorSettings = EditorGUILayout.Foldout(showArmorSettings, "Armor Stats", titleStylesFoldoutSubFoldout);
            if (showArmorSettings)
            {
                EditorGUI.indentLevel++;
                gb.starterArmorLevel = EditorGUILayout.Slider("Armor level: ", gb.starterArmorLevel, 0, 1);
                gb.starterArmorDmgTypeResistRate = EditorGUILayout.Slider("Damage type resistance %: ", gb.starterArmorDmgTypeResistRate, 0, 1);
                gb.starterArmorDmgTypeWeaknessRate = EditorGUILayout.Slider("Damage type weakness %: ", gb.starterArmorDmgTypeWeaknessRate, 0, 1);
                gb.starterArmorIcon = (Sprite)EditorGUILayout.ObjectField("Inventory icon: ", gb.starterArmorIcon, typeof(Sprite), true);
                EditorGUI.indentLevel--;
            }
            showEngineSettings = EditorGUILayout.Foldout(showEngineSettings, "Engine Stats", titleStylesFoldoutSubFoldout);
            if (showEngineSettings)
            {
                EditorGUI.indentLevel++;
                gb.starterEngineSpeed = EditorGUILayout.Slider("Maximum speed: ", gb.starterEngineSpeed, 0, 3000);
                gb.starterEngineTurnSpeed = EditorGUILayout.Slider("Rotation speed: ", gb.starterEngineTurnSpeed, 0, 3);
                gb.starterEngineBoostSpeed = EditorGUILayout.Slider("Boost speed: ", gb.starterEngineBoostSpeed, 0, 1500);
                gb.starterEngineBoostCost = EditorGUILayout.Slider("Boost cost: ", gb.starterEngineBoostCost, 0, 125);
                gb.starterEngineBoostCooldown = EditorGUILayout.Slider("Boost cooldown: ", gb.starterEngineBoostCooldown, 0, 25);
                gb.starterEngineIcon = (Sprite)EditorGUILayout.ObjectField("Inventory icon: ", gb.starterEngineIcon, typeof(Sprite), true);
                EditorGUI.indentLevel--;
            }
            showReactorSettings = EditorGUILayout.Foldout(showReactorSettings, "Reactor Stats", titleStylesFoldoutSubFoldout);
            if (showReactorSettings)
            {
                EditorGUI.indentLevel++;
                gb.starterReactorMaxEnergy = EditorGUILayout.Slider("Maximum energy: ", gb.starterReactorMaxEnergy, 0, 500);
                gb.starterReactorRechargeRate = EditorGUILayout.Slider("Recharge rate: ", gb.starterReactorRechargeRate, 0, 35);
                gb.starterReactorIcon = (Sprite)EditorGUILayout.ObjectField("Inventory icon: ", gb.starterReactorIcon, typeof(Sprite), true);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        showUISettings = EditorGUILayout.Foldout(showUISettings, "UI Settings", titleStylesFoldout);
        if (showUISettings)
        {
            EditorGUI.indentLevel++;
            gb.playerInvWindow = (GameObject)EditorGUILayout.ObjectField("Inventory Window:", gb.playerInvWindow, typeof(GameObject), true);
            gb.playerEqWindow = (GameObject)EditorGUILayout.ObjectField("Equipment Window:", gb.playerEqWindow, typeof(GameObject), true);
            gb.menuBar = (GameObject)EditorGUILayout.ObjectField("Menu Bar:", gb.menuBar, typeof(GameObject), true);
            gb.vitalsBar = (GameObject)EditorGUILayout.ObjectField("Vitals Bar:", gb.vitalsBar, typeof(GameObject), true);
            gb.cameraZoom = (GameObject)EditorGUILayout.ObjectField("Camera Zoom Control:", gb.cameraZoom, typeof(GameObject), true);
            EditorGUI.indentLevel--;
        }

        showPersistentObjectsSettings = EditorGUILayout.Foldout(showPersistentObjectsSettings, "Persistent Objects", titleStylesFoldout);
        if (showPersistentObjectsSettings)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("persistentObjects"), true);
            EditorGUI.indentLevel++;
            EditorGUI.indentLevel++;
            gb.persistentObjectToAdd = (GameObject)EditorGUILayout.ObjectField("Persistent object to add: ", gb.persistentObjectToAdd, typeof(GameObject), true);
            if (GUILayout.Button("Add to List"))
            {
                gb.AddPersistentObjectToList();
            }
            if (GUILayout.Button("Clear List"))
            {
                gb.ClearPersistentObjectList();
            }
            EditorGUI.indentLevel--;
            EditorGUI.indentLevel--;
            EditorGUI.indentLevel--;
        }

        showDebugOptions = EditorGUILayout.Foldout(showDebugOptions, "Debug Options", titleStylesFoldout);
        if (showDebugOptions)
        {
            EditorGUI.indentLevel++;
            gb.locationToMovePlayerTo = EditorGUILayout.Vector3Field("Move PlayerObject here: ", gb.locationToMovePlayerTo);
            EditorGUI.indentLevel++;
            if (GUILayout.Button("Move Player"))
            {
                gb.MovePlayerObjectToLocation();
            }
            if (GUILayout.Button("Start Game (Debug)"))
            {
                gb.StartNewGameTesting();
                Debug.Log("start button pressed");
            }

        }

    }
}



//GUIStyle myFoldoutStyle = new GUIStyle(EditorStyles.foldout);
//myFoldoutStyle.fontStyle = FontStyle.Bold;
//myFoldoutStyle.fontSize = 14;
//Color myStyleColor = Color.red;
//myFoldoutStyle.normal.textColor = myStyleColor;
//myFoldoutStyle.onNormal.textColor = myStyleColor;
//myFoldoutStyle.hover.textColor = myStyleColor;
//myFoldoutStyle.onHover.textColor = myStyleColor;
//myFoldoutStyle.focused.textColor = myStyleColor;
//myFoldoutStyle.onFocused.textColor = myStyleColor;
//myFoldoutStyle.active.textColor = myStyleColor;
//myFoldoutStyle.onActive.textColor = myStyleColor;