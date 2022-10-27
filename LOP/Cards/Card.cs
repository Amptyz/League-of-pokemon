using LOP.Core;
using LOP.Entities;

namespace LOP.Cards
{
    public abstract class Card : IUpdatable
    {   
        public float Energy { get; private set; }
        public float InitialEnergy;
        public float EnergyGrowthRate;
        public float TimeDelay;
        public Card() {}
        public virtual void Update()
        {
            Energy += Time.DeltaTime * EnergyGrowthRate;
            if(Energy > 100) Energy = 100;
        }
        public virtual void OnEquip()
        {
            Energy = InitialEnergy;
        }
        public virtual void OnOccur(Entity target) {}
        public virtual void OnUse()
        {
            
        }
    }
    public abstract class SkillCard : Card
    {
        public float Duration;
        public Entity Entity { get; private set; }
        public SkillCard(Entity entity)
        {
            Entity = entity;
        }
        public override void OnOccur(Entity target) {}
        public override void OnUse()
        {
            Entity.controller.ChangeState(new SkillState(Entity.controller, GameSystem.GameInfoSystem.Instance.Red.Player));
        }
    }
}
