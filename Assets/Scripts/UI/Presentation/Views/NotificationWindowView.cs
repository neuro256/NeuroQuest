using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NeuroQuest.UI.Presentation
{
    public class NotificationWindowView : BaseWindowView
    {
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private Button _okButton;

        public void ShowWithButton(string message, Action onOkClick)
        {
            _messageText.text = message;
            _okButton.gameObject.SetActive(true);
            _okButton.onClick.RemoveAllListeners();
            _okButton.onClick.AddListener(() =>
            {
                onOkClick?.Invoke();
                Hide();
            });

            Show();
        }

        public void ShowWithTimer(string message, float duration)
        {
            _messageText.text = message;
            _okButton.gameObject.SetActive(false);
            Show();
            StartCoroutine(AutoClose(duration));
        }

        private IEnumerator AutoClose(float delay)
        {
            yield return new WaitForSeconds(delay);
            Hide();
        }
    }
}

