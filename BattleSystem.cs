using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BattleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Army army1 = new Army("Sing", new List<Character> { new Character("Soldier1", 100, 20, 5), new Character("Soldier2", 100, 20, 5) });
        Army army2 = new Army("Ling", new List<Character> { new Character("Enemy1", 80, 15, 3), new Character("Enemy2", 80, 15, 3) });

        Battle battle = new Battle(army1, army2);
        StartCoroutine(battle.StartBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Army
{
    public string Name { get; private set; } // Added name field
    public List<Character> Characters { get; private set; }

    public Army(string name, List<Character> characters) // Updated constructor to include name
    {
        Name = name;
        Characters = characters;
    }

    public bool IsAlive => Characters.Any(c => c.IsAlive);

    public Character GetNextFighter()
    {
        return Characters.FirstOrDefault(c => c.IsAlive);
    }
}

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }

    public Character(string name, int health, int attackPower, int defense)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Defense = defense;
    }

    public bool IsAlive => Health > 0;
}

public class Battle
{
    private Army army1;
    private Army army2;
    private List<string> battleLog = new List<string>();

    public Battle(Army army1, Army army2)
    {
        this.army1 = army1;
        this.army2 = army2;
    }

    public IEnumerator StartBattle()
    {
        LogManager.Instance.AddLog("Battle started!");
        while (army1.IsAlive && army2.IsAlive)
        {
            var fighter1 = army1.GetNextFighter();
            var fighter2 = army2.GetNextFighter();

            if (fighter1 != null && fighter2 != null)
            {
                PerformAttack(fighter1, fighter2);
                if (fighter2.IsAlive) // If fighter2 is still alive, they counter-attack
                {
                    PerformAttack(fighter2, fighter1);
                }
                yield return new WaitForSeconds(1f); // Delay before the next action
            }
        }
        string winner = army1.IsAlive ? "Army 1" : "Army 2";
        LogManager.Instance.AddLog($"{winner} wins the battle!");
    }

    private void PerformAttack(Character attacker, Character defender)
    {
        int damage = attacker.AttackPower - defender.Defense;
        if (damage < 0) damage = 0;
        defender.Health -= damage;
        string attackerNameColored = $"<color=red>{attacker.Name}</color>";
        string defenderNameColored = $"<color=blue>{defender.Name}</color>";
        LogManager.Instance.AddLog($"{attackerNameColored} of {a}attacked {defenderNameColored} for {damage} damage.");
        if (!defender.IsAlive)
        {
            LogManager.Instance.AddLog($"{defender.Name} has been defeated!");
        }
    }
}