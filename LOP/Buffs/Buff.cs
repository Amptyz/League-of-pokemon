using LOP.Entities;
using LOP.Skills;

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
        public Skill OriginSkill { get; private set; }
        public String Name { get; protected set; }
        public BuffType Type { get; protected set; }
        public Buff(Entity entity,Entity originEntity, Skill originSkill)
        {
            Name = "Default Buff";
            Type = BuffType.Others;
            Entity = entity;
            OriginEntity = originEntity;
            OriginSkill = originSkill;
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
