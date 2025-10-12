using System;

namespace NeuroQuest.UI.Presentation
{
    public abstract class BaseWindowPresenter<TView> : IWindowPresenter, IDisposable where TView : IWindowView
    {
        public event Action onWindowClose;

        protected readonly TView _view;

        protected BaseWindowPresenter(TView view)
        {
            _view = view;
            _view.onWindowClose += OnWindowClose;
        }

        private void OnWindowClose()
        {
            onWindowClose?.Invoke();
        }

        public virtual void Hide()
        {
            _view?.Hide();
        }

        public virtual void Show()
        {
            _view?.Show();
        }

        public void Dispose()
        {
            if(_view != null)
                _view.onWindowClose -= OnWindowClose;
        }
    }
}

