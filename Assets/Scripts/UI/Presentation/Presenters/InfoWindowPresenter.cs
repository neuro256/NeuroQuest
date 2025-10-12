using System;

namespace NeuroQuest.UI.Presentation
{
    public class InfoWindowPresenter : BaseWindowPresenter<InfoWindowView>
    {
        public InfoWindowPresenter(InfoWindowView view) : base(view)
        {
        }

        public void ShowInfo(string message, Action onOkClick = null)
        {
            _view.SetText(message);
            _view.SetButtonAction(() =>
            {
                Hide();
                onOkClick?.Invoke();
            });

            Show();
        }
    }
}

