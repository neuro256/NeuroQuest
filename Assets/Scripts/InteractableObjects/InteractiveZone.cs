using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class InteractiveZone : MonoBehaviour
    {
        private IInteractable _parent;

        public void Init(IInteractable parent)
        {
            _parent = parent;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                Debug.Log("OnTriggerEnter: Player");
                PlayerInteraction.Instance.SetInteractable(_parent);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("OnTriggerExit: Player");
                PlayerInteraction.Instance.ClearInteractable();
            }
        }
    }
}
