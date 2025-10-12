namespace NeuroQuest.UI.Presentation
{
    public abstract class BaseWindowPresenter<TView> : IWindowPresenter where TView : IWindowView
    {
        protected readonly TView _view;

        protected BaseWindowPresenter(TView view)
        {
            _view = view;
        }

        public virtual void Hide()
        {
            _view?.Hide();
        }

        public virtual void Show()
        {
            _view?.Show();
        }
    }
}

