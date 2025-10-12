using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroQuest.UI.Presentation
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private Transform _windowParent;
        [SerializeField] private InfoWindowView _infoWindowPrefab;
        [SerializeField] private PlayerInput _playerInput;

        private readonly Dictionary<WindowType, IWindowView> _windows = new();

        public InfoWindowPresenter ShowInfoWindow(string text, Action onOkClick = null)
        {
            var view = GetOrCreateWindow<InfoWindowView>(WindowType.Info, _infoWindowPrefab);
            var presenter = new InfoWindowPresenter(view);

            _playerInput.SwitchCurrentActionMap("UI");

            presenter.ShowInfo(text, () =>
            {
                _playerInput.SwitchCurrentActionMap("Player");
                onOkClick?.Invoke();
            });

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

