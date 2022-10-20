#### LOP.Core

- IUpdatable
  - public void Update()

- Script (会被自动加入MainUpdater)
  - public virtual void Start()  (加入MainUpdater时调用)
  - public virtual void Update() (每帧更新时调用)
  - public virtual void OnDestroy() (销毁该脚本对象时调用)
  - public virtual void Destroy() (销毁自己)
  - public static void Destroy(Script script) (销毁script)
  - public static T Instantiate\<T\>() where T : Script , new() (创建新Script实例)