using LOP.Core;
using LOP.Entities;

namespace LOP.Cards
{
    public abstract class Card : IUpdatable
    {   
        public float Energy { get; private set; }
        public float InitialEnergy;
        public float EnergyGrowthRate;
        public Card() {}
        public virtual void Update()
        {
            Energy += Time.DeltaTime * EnergyGrowthRate;
            if(Energy > 100) Energy = 100;
        }
        public virtual void OnEquipped()
        {
            Energy = InitialEnergy;
        }
        public virtual void OnOccur(Entity target) {}
    }
    public abstract class SkillCard : Card
    {
        public Entity Entity { get; private set; }
        public SkillCard(Entity entity)
        {
            Entity = entity;
        }
    }
}
