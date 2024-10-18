namespace Core
{
    public abstract class GameStateBase
    {
        protected GameStateMachine GameStateMachine { get; private set; }

        public void Init(GameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
            OnInit();
        }

        public abstract void OnInit();
        public abstract void Process();
        public abstract void Deinit();
    }
}
