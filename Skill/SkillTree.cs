using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{

    public CharacterControl characterControl;


    public SkillSlot skillSlot;

    public Skill Skill;


    public void Start() {
        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
    }

    public void Unlock()
    {
        if (Skill.Cost <= characterControl._Coin && Skill.isUnlocked == false) 
        {
            
            characterControl._Coin -= Skill.Cost;
            Skill.isUnlocked = true;

            switch (Skill.skillType)
            {
                case SkillType.Attack:
                    skillSlot.skillsAttack.Add(Skill);
                    break;
                case SkillType.Magic:
                    skillSlot.skillsMagic.Add(Skill);
                    break;
                case SkillType.Defance:
                    skillSlot.skillsDefance.Add(Skill);
                    break;
            }

            characterControl.ApplySkillsModifier();
            UIManager.UIinstance.SetImage();
        }

        Debug.Log("Unlock");
    }
   
}
