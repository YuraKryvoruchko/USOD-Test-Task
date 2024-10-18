using Core.UI;

namespace Core
{
    public class GamePlayState : GameStateBase
    {
        private IUISystem _uiSystem;

        private GameUI _gameUI;
        private GameUI _gameUIPrefab;

        private GamePlaySessionTimer _gamePlaySessionTimer;

        public GamePlayState(IUISystem uiSystem, GameUI gameUIPrefab, GamePlaySessionTimer gamePlaySessionTimer)
        {
            _uiSystem = uiSystem;
            _gameUIPrefab = gameUIPrefab;
            _gamePlaySessionTimer = gamePlaySessionTimer;
        }

        public override void OnInit()
        {
            _gamePlaySessionTimer.OnTick += HandleTimerTick;
        }
        public override void Process()
        {
            _gameUI = _uiSystem.ShowWindowFromPrefab(_gameUIPrefab);
            _gamePlaySessionTimer.SetActive(true);
        }
        public override void Deinit()
        {
            _uiSystem.HideLastWindow();
            _gamePlaySessionTimer.SetActive(false);
            _gamePlaySessionTimer.OnTick += HandleTimerTick;
        }

        private void HandleTimerTick(float time)
        {
            _gameUI.UpdateTime(time);
        }
    }
}
