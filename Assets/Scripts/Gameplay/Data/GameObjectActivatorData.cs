using System;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    [CreateAssetMenu(menuName = "NeuroQuest/ChestActions/ActivateGameObject", fileName = "NewActivateGameObjectAction")]
    public class GameObjectActivatorData : ChestActionData
    {
        [SerializeField] private string _objectName;

        public override void Execute(Action onComplete = null)
        {
            if (string.IsNullOrEmpty(_objectName))
                return;

            var gameObjectActivator = FindFirstObjectByType<SceneObjectActivator>();
            gameObjectActivator.ActivateObject(_objectName);

            onComplete?.Invoke();
        }
    }
}