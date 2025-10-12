using System;

namespace NeuroQuest.UI.Presentation
{
    public class NotificationWindowPresenter : BaseWindowPresenter<NotificationWindowView>
    {
        public NotificationWindowPresenter(NotificationWindowView view) : base(view) { }

        public void ShowMessage(string text, Action onOkClick = null)
        {
            _view.ShowWithButton(text, onOkClick);
        }

        public void ShowTimedMessage(string text, float duration)
        {
            _view.ShowWithTimer(text, duration);
        }
    }
}

