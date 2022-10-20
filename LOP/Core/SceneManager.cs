using LOP.Scene;

namespace LOP.Core
{
    public class SceneManager : Script
    {
        public static SceneManager instance;
        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindScript<SceneManager>();
                    if (instance == null)
                    {
                        instance = Instantiate<SceneManager>();
                    }
                }
                return instance;
            }
        }
        public SceneState State { get; private set; }
        public SceneManager()
        {
            State = new SceneState(this);
            ChangeState(new DefaultSceneState(this));
        }
        public override void Update()
        {
            State.Update();
        }
        public virtual void ChangeState(SceneState state)
        {
            State.OnExit();
            State = state;
            State.OnEnter();
        }
    }
}
