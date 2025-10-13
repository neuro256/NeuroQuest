using NeuroQuest.Infrastructure;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    public abstract class BaseGameData : ScriptableObject
    {
        public abstract GameType GameType { get; }
    }
}

