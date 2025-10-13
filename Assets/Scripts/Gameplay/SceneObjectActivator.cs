using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Gameplay
{
    public class SceneObjectActivator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objectsToActivate;

        public void ActivateObject(string objectName)
        {
            var objectToActivate = _objectsToActivate.Find(go =>  go.name == objectName);
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}

