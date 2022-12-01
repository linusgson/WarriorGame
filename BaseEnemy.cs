using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorGame;
namespace WarriorGame
{   
    public abstract class BaseEnemy
    {
        public string Name { get; protected set; } = "Enemy";
        public string? Description { get; set; } = "Nothing is known about this creature";
        public string? Message { get; set; } = "No message";
        public int AtkDmg { get; set; } 
        public int HP { get; set; }
        public int MaxBlock { get; set; }
        public Random rand = new();

        
        public BaseEnemy(string? name)
        {
            Name = name;
        }
        public abstract void BackgroundColor();
        public void Attack(Character character, BaseEnemy enemy)
        {
            int Dmg = enemy.rand.Next(character.MaxBlock + 1, enemy.AtkDmg + 1) - character.rand.Next(2, character.MaxBlock + 1);
            character.HP -= Dmg;
            enemy.BackgroundColor();
            Console.WriteLine(enemy.Message);
            Thread.Sleep(1000);
            if (character.HP < 0) character.HP = 0;
            Console.WriteLine($"\n{enemy.Name} hits you for {Dmg} damage, you now have {character.HP} HP left.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------------\n");

        }
    }


    public class Vampire : BaseEnemy
    {
       
        public Vampire() : base("Vampire")
        {
            HP = 100;
            MaxBlock = 10;
            AtkDmg = 40;
            Message = "Give me your blood\n";
        }
        public override void BackgroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }

    public class Orc : BaseEnemy
    {
        public Orc() : base("Orc")
        {
            HP = 100;
            MaxBlock = 10;
            AtkDmg = 40;
            Message = "I will feast on your skull\n";
        }
        public override void BackgroundColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
    }

    public class Goblin : BaseEnemy
    {
        public Goblin() : base("Goblin")
        {
            HP = 100;
            MaxBlock = 10;
            AtkDmg = 40;
            Message = "I will kill you\n";
        }
        public override void BackgroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }

}
