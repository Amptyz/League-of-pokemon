using LOP.Cards;

namespace LOP.Entities
{
    public class FireDragon : Entity
    {
        public FireDragon()
        {
            EntityData.Name = "Fire Dragon";
            EntityData.MaxHealth = 1000;
            EntityData.Health = 1000;
            EntityData.Attack = 120;
            EntityData.AttackSpeed = 24;
        }
    }
    public class FireBall : SkillCard
    {
        public FireBall(Entity entity) : base(entity)
        {
        }
    }
}
