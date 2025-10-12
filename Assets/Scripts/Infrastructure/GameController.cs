using NeuroQuest.UI.Presentation;
using UnityEngine;

namespace NeuroQuest.Infrastructure
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private WindowManager _windowManager;
        [SerializeField]
        [TextArea]
        private string _tutorualInfo;

        private void Start()
        {
            _windowManager.ShowInfoWindow(_tutorualInfo);
        }
    }
}

