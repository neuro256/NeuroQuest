using NeuroQuest.Gameplay;
using NeuroQuest.Gameplay.MiniGame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroQuest.UI.Presentation
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private Transform _windowParent;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private MiniGameController _miniGameController;

        [Header("Window views")]
        [SerializeField] private InfoWindowView _infoWindowPrefab;
        [SerializeField] private QuizWindowView _quizWindowPrefab;
        [SerializeField] private MiniGameWindowView _miniGameWindowPrefab;
        [SerializeField] private NotificationWindowView _notificationPrefab;

        private readonly Dictionary<WindowType, IWindowView> _windows = new();

        public InfoWindowPresenter ShowInfoWindow(string text, Action onOkClick = null)
        {
            var view = GetOrCreateWindow<InfoWindowView>(WindowType.Info, _infoWindowPrefab);
            var presenter = new InfoWindowPresenter(view);

            _playerInput.SwitchCurrentActionMap("UI");

            presenter.ShowInfo(text, onOkClick);
            presenter.onWindowClose += () =>
            {
                _playerInput.SwitchCurrentActionMap("Player");
            };

            return presenter;
        }

        public QuizWindowPresenter ShowQuiz(QuestionData data, Action onSuccess, Action onFail)
        {
            _playerInput.SwitchCurrentActionMap("UI");

            var view = GetOrCreateWindow<QuizWindowView>(WindowType.Quiz, _quizWindowPrefab);
            var presenter = new QuizWindowPresenter(view, data, onSuccess, onFail);
            presenter.onWindowClose += () =>
            {
                _playerInput.SwitchCurrentActionMap("Player");
            };

            presenter.Show();
            return presenter;
        }

        public MiniGameWindowPresenter ShowMiniGame(MiniGameData data, Action onSuccess, Action onFail)
        {
            _playerInput.SwitchCurrentActionMap("MiniGame");

            var view = GetOrCreateWindow(WindowType.MiniGame, _miniGameWindowPrefab);
            var presenter = new MiniGameWindowPresenter(view, _miniGameController, data, onSuccess, onFail);
            presenter.onWindowClose += () =>
            {
                _playerInput.SwitchCurrentActionMap("Player");
            };

            presenter.Show();
            return presenter;
        }

        public NotificationWindowPresenter ShowNotification(string message, float duration = 0, Action onComplete = null)
        {
            _playerInput.SwitchCurrentActionMap("UI");

            var view = Instantiate(_notificationPrefab, _windowParent);
            var presenter = new NotificationWindowPresenter(view);

            if (duration > 0)
                presenter.ShowTimedMessage(message, duration, onComplete);
            else
                presenter.ShowMessage(message, onComplete);

            presenter.onWindowClose += () =>
            {
                presenter.Dispose();
                presenter = null;
                Destroy(view.gameObject);

                if(!_windows.Any(window => window.Value.IsActive))
                {
                    _playerInput.SwitchCurrentActionMap("Player");
                }
            };

            return presenter;
        }

        private T GetOrCreateWindow<T>(WindowType type, T prefab) where T : MonoBehaviour, IWindowView
        {
            if (_windows.TryGetValue(type, out var window))
                return (T)window;

            var instance = Instantiate(prefab, _windowParent);
            _windows[type] = instance;
            return instance;
        }
    }
}

