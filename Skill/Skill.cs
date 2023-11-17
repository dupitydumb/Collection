using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    Attack,
    Magic,
    
    Defance,
}

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class Skill : ScriptableObject
{
    public SkillType skillType;

    public Sprite skillIcon;
    public string SkillName;
    [TextArea(3, 10)]
    public string SkillDescription;

    public int Cost;
    public float AttackModifier;
    public float MagicModifier;
    public float DefanceModifier;

    public bool isUnlocked;


    void Start()
    {
        
    }



    

    
}
