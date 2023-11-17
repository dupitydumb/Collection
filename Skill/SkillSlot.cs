using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillSlot", menuName = "ScriptableObjects/SkillSlot", order = 1)]
public class SkillSlot : ScriptableObject
{
    // Start is called before the first frame update
    public List<Skill> skillsAttack;
    public List<Skill> skillsMagic;
    public List<Skill> skillsDefance;




}
