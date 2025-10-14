using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroQuest.Gameplay.MiniGame
{
    public class MiniPlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2;
        [SerializeField]
        private PlayerInput _playerInput;

        private Rigidbody2D _rigidbody;
        private Vector2 _currentInput;
        private InputAction _moveAction;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            var map = _playerInput.actions.FindActionMap("MiniGame", true);
            _moveAction = map.FindAction("Move", true);
        }

        private void Update()
        {
            _currentInput = _moveAction.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector2 position = _rigidbody.position;

            position = position + _currentInput * _speed * Time.deltaTime;

            _rigidbody.MovePosition(position);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<MiniEnemy>(out var enemy))
            {
                var miniGame = FindFirstObjectByType<MiniGameController>();
                if (miniGame != null)
                {
                    miniGame.EndGame(false);
                }
            }
        }
    }
}

