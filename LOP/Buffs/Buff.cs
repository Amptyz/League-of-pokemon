using LOP.Entities;
using LOP.Cards;

namespace LOP.Buffs
{
    public enum BuffType
    {
        Positive,
        Negative,
        Neutral,
        Others
    }
    public class Buff
    {
        public Entity Entity { get; private set; }
        public Entity OriginEntity { get; private set; }
        public Card OriginCard { get; private set; }
        public String Name { get; protected set; }
        public BuffType Type { get; protected set; }
        public Buff(Entity entity,Entity originEntity, Card originCard)
        {
            Name = "Default Buff";
            Type = BuffType.Others;
            Entity = entity;
            OriginEntity = originEntity;
            OriginCard = originCard;
        }
        public virtual void OnCalcDamageAsSource() { }
        public virtual void OnCalcDamageAsTarget() { }
        public virtual void OnObtain() { }
        public virtual void Update() { }
        public virtual void OnLose() { }
        public virtual void OnUseSkill() { }
        public virtual void OnNormalAttack() { }
        public virtual void OnGetBuff(Buff buff) { }
    }
}
