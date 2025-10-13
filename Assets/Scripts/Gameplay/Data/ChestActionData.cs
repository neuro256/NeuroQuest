using System;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    public abstract class ChestActionData : ScriptableObject
    {
        public abstract void Execute(Action onComplete = null);
    }
}

