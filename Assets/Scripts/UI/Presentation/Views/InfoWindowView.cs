using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NeuroQuest.UI.Presentation
{
    public class InfoWindowView : BaseWindowView
    {
        [SerializeField] private TextMeshProUGUI _infoText;
        [SerializeField] private Button _okButton;

        public void SetText(string text) => _infoText.text = text;  
        public void SetButtonAction(Action onClick)
        {
            _okButton.onClick.RemoveAllListeners();
            _okButton.onClick.AddListener(() =>
            {
                Debug.Log("Info window OK button clicked");
                onClick?.Invoke();
            });
        }
    }
}

