namespace GunGame.Core
{
    public abstract class Enemy
    {
        protected Enemy(string name, int hp)
        {
            Name = name;
            HP = hp;
        }

        public string Name { get; }
        public int HP { get; set; }
        public bool IsDefeated => HP <= 0;
    }

    public class Goblin : Enemy
    {
        public Goblin() : base("goblin", 60) { }
    }

    public class Blob : Enemy
    {
        public Blob() : base("blob", 70) { }
    }

    public class Goomba : Enemy
    {
        public Goomba() : base("goomba", 80) { }
    }

    public class ShadowClone : Enemy
    {
        public ShadowClone() : base("SHADOW", 200) { }
    }
}
