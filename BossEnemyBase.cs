namespace WarriorGame
{
    public abstract class BossEnemy
    {
        protected string Name { get; set; } = "Enemy";
        protected string? description { get; set; } = null;
        protected int AtkDmg { get; set; } = 15;
        public int HP { get; set; }
        public int MaxBlock { get; set; }

        public BossEnemy(string name)
        {
            Name = name;
            HP = 100;
        }
        //public abstract void MakeSound();
    }
    public class Giant : BossEnemy
    {
        public Giant() : base("The Massive Giant")
        {
            HP = 300;
            AtkDmg = 40;
        }

        public void AbilityOne()
        {
            //Slår ner i marken och skadar spelaren
        }

    }
    public class Dragon : BossEnemy
    {
        Random rand = new Random();
        public Dragon() : base("The Ancient Dragon")
        {
            HP = 250;
            AtkDmg = 50;
        }

        public void BasicAbility(Character character)
        {
            int Dmg = rand.Next(25, AtkDmg);
            character.HP -= Dmg;
            Console.WriteLine($"{this.Name} swipes his tail and deals {Dmg} damage to you.");
            //Slår spelare ned sin svans
        }

        public void SpecialAbility(Character character)
        {
            //Fireblast, sprutar eld på spelaren 
        }
    }

    public class DarthVader : BossEnemy
    {
        public DarthVader() : base("Darth Vader")
        {
            HP = 300;
            AtkDmg = 60;
        }
        public void Defence(Character character)
        {
            //Push back using force, ignorerar nästa attack från spelaren

        }

        public void BasicAbility(Character character)
        {
            //Sword throw, skadar 25% av spelarens HP
        }

        public void SpecialAttack(Character character)
        {
            //Choke, skadar 50% av spelarens HP

        }

    }
}
