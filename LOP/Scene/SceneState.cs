using LOP.Core;

namespace LOP.Scene
{
    public class SceneState : IUpdatable
    {
        public string Name { get; protected set; }
        public SceneManager Manager { get; private set; }
        public SceneState(SceneManager manager)
        {
            Name = "";
            Manager = manager;
        }
        public virtual void Update() { }
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
    }
    public class DefaultSceneState : SceneState
    {
        public DefaultSceneState(SceneManager manager) : base(manager)
        {
            Name = "DefaultScene";
        }
        public override void OnEnter()
        {
            Console.WriteLine("DefaultScene Enter!");
        }
        public override void Update()
        {
            Manager.ChangeState(new MainGameScene(Manager));
        }
    }
}
