using NeuroQuest.InteractableObjects;
using NeuroQuest.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroQuest.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 4;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private Vector2 _lookDirection = new(1, 0);
        private Vector2 _currentInput;

        private PlayerInventory _inventory;
        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _interactAction;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _playerInput = GetComponent<PlayerInput>();
            _inventory = GetComponent<PlayerInventory>();
            _inventory.Init();

            var map = _playerInput.actions.FindActionMap("Player", true);
            _moveAction = map.FindAction("Move", true);
            _interactAction = map.FindAction("Interact", true);
        }

        private void Update()
        {
            Vector2 move = _moveAction.ReadValue<Vector2>();

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                _lookDirection.Set(move.x, move.y);
                _lookDirection.Normalize();
            }

            _currentInput = move;

            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Look Y", _lookDirection.y);
            _animator.SetFloat("Speed", move.magnitude);

            if (_interactAction.WasPressedThisFrame())
            {
                Debug.Log("Try interact");
                PlayerInteraction.Instance.TryInteract();
            }
        }

        private void FixedUpdate()
        {
            Vector2 position = _rigidbody.position;

            position = position + _currentInput * _speed * Time.deltaTime;

            _rigidbody.MovePosition(position);
        }
    }
}

