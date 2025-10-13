using System;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    public abstract class ChestActionData : ScriptableObject
    {
        [SerializeField]
        private bool _isMainAction;
        public bool IsMainAction => _isMainAction;

        public abstract void Execute(Action onComplete = null);
    }
}

