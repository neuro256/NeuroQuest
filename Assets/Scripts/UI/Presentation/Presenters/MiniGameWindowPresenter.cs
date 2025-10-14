using NeuroQuest.Gameplay;
using NeuroQuest.Gameplay.MiniGame;
using System;

namespace NeuroQuest.UI.Presentation
{
    public class MiniGameWindowPresenter : BaseWindowPresenter<MiniGameWindowView>
    {
        private readonly MiniGameController _minigameController;
        private readonly MiniGameData _gameData;
        private readonly Action _onSuccess;
        private readonly Action _onFail;

        public MiniGameWindowPresenter(MiniGameWindowView view, MiniGameController controller, MiniGameData gameData, Action onSuccess, Action onFail) : base(view)
        {
            _minigameController = controller;
            _gameData = gameData;
            _onSuccess = onSuccess;
            _onFail = onFail;
        }

        public override void Show()
        {
            base.Show();

           _minigameController.StartGame(_gameData, 
               onSuccess: () => 
           {
               Hide();
               _onSuccess?.Invoke();
           }, onFail: () =>
           {
               Hide();
               _onFail?.Invoke();
           });
        }
    }
}

