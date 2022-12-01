using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorGame
{
    public abstract class Character
    {
        public int HP { get; set; } 
        public string? Name { get; set; } 
        public int AtkDmg { get; set; }
        public int MaxBlock { get; set; }
        public Random rand = new();


        public Character(string name)
        {
            Name = name;
        }
        public void BasicAttack(BaseEnemy enemy, Character character)
        {
            int Dmg = rand.Next(enemy.MaxBlock + 1, character.AtkDmg + 1) - rand.Next(2, enemy.MaxBlock + 1);
            enemy.HP -= Dmg;
            Console.WriteLine($"You hit the {enemy.Name} for {Dmg}, he now has {enemy.HP}hp left \n");
        }
        public abstract void SpecialAttack(BaseEnemy enemy, Character character);
    }
    public class Warrior : Character
    {
        
        public Warrior(string name) : base(name)
        {
            AtkDmg = 25;
            HP = 150;
            MaxBlock = 10;
        }

        static int count = 0;

        public override void SpecialAttack(BaseEnemy enemy, Character character)
        {
            if(count > 1)
            {
                Console.WriteLine("You have used the special attack too many times, you can only use the regular one now\n");
                BasicAttack(enemy, character);

            }
            else
            {
                int Dmg = rand.Next(enemy.MaxBlock + 1, character.AtkDmg + 1) - rand.Next(2, enemy.MaxBlock + 1);
                enemy.HP -= Dmg;
                count++;
                Console.WriteLine($"You hit the enemy with your special attack and dealt {Dmg} damage, he now has {enemy.HP}hp left \n");
            }
        }
    }

    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            AtkDmg = 18;
            HP = 170;
            MaxBlock = 12;
        }

        static int count = 0;

        public override void SpecialAttack(BaseEnemy enemy, Character character)
        {
            if (count > 2)
            {
                Console.WriteLine("You are out of fire arrows, you´ll have to use regular ones from now on\n");
                BasicAttack(enemy, character);

            }
            else
            {
                int Dmg = rand.Next(enemy.MaxBlock + 1, character.AtkDmg + 1) - rand.Next(2, enemy.MaxBlock + 1);
                enemy.HP -= Dmg;
                count++;

                Console.WriteLine($"You hit the enemy with a fire arrow and dealt {Dmg} to him, he now has {enemy.HP}hp left\n");
            }
        }
    }

    public class Wizard : Character
    {
        public Wizard(string name) : base(name)
        {
            AtkDmg = 25;
            HP = 110;
            MaxBlock = 7;
        }

        static int count = 0;

        public override void SpecialAttack(BaseEnemy enemy, Character character)
        {

            if(count > 0)
            {
                Console.WriteLine("You have already used the healing ability, so you must use the basic attack\n");
                BasicAttack(enemy, character);
            }
            else
            {
                HP += 50;
                count++;
                Console.WriteLine($"You healed up with 50 extra hp, you now have {HP}hp\n");
            }
        }
    } 
}
