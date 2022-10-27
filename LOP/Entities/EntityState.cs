using LOP.Core;

namespace LOP.Entities
{
    public class EntityStateController : IUpdatable
    {
        public Entity Entity { get; private set; }
        public EntityState State { get; private set; }
        public EntityStateController(Entity entity)
        {
            Entity = entity;
            State = new AttackState(this);
        }
        public void Update()
        {
            State.Update();
        }
        public void ChangeState(EntityState state)
        {
            State.OnExit();
            State = state;
            State.OnEnter();
        }
    }
    public abstract class EntityState : IUpdatable
    {
        public String Name { get; protected set; }
        public EntityStateController Controller { get; private set; }
        public EntityState(EntityStateController controller)
        {
            Name = "";
            Controller = controller;
        }
        public virtual void OnEnter() { }
        public virtual void Update() { }
        public virtual void OnExit() { }
    }
    public class DefaultEntityState : EntityState
    {
        public DefaultEntityState(EntityStateController controller) : base(controller)
        {
            Name = "DefaultState";
        }
    }
    public class AttackState : EntityState
    {
        public float CoolDown;
        public AttackState(EntityStateController controller) : base(controller)
        {
            Name = "NormalAttack";
            CoolDown = 0;
        }
        public override void Update()
        {
            CoolDown -= Time.DeltaTime;
            if (CoolDown <= 0)
            {
                Controller.Entity.NormalAttack();
                CoolDown = Controller.Entity.EntityData.AttackInterval;
            }
        }
    }
    public class SkillState : EntityState
    {
        public float duration;
        public float delay;
        public Entity Target;
        public SkillState(EntityStateController controller, Entity target) : base(controller)
        {
            Name = "Skill";
            duration = controller.Entity.SkillCard.Duration;
            delay = controller.Entity.SkillCard.TimeDelay;
            Target = target;
        }
        public override void Update()
        {
            duration -= Time.DeltaTime;
            delay -= Time.DeltaTime;
            if(delay <= 0)
            {
                Controller.Entity.SkillCard.OnOccur(Target);
            }
            if (duration <= 0)
            {
                Controller.ChangeState(new AttackState(Controller));
            }
        }
    }
}
