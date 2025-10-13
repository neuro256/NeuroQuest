using NeuroQuest.UI.Presentation;
using System;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/ChestActions/ShowMessage", fileName = "NewShowMessageAction")]
    public class ShowMessageActionData : ChestActionData
    {
        [SerializeField, TextArea] private string _message;
        [SerializeField] private float _duration = 2f;

        public override void Execute(Action onComplete = null)
        {
            var windowManager = FindFirstObjectByType<WindowManager>();
            windowManager.ShowNotification(_message, _duration, onComplete);
        }
    }
}

