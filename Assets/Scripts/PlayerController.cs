using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;

    [SerializeField]
    private InputAction _moveAction;

    [SerializeField]
    private InputAction _interactionAction;

    [SerializeField]

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _lookDirection = new(1, 0);
    private Vector2 _currentInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveAction.Enable();
        _interactionAction.Enable();
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


    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody.position;

        position = position + _currentInput * _speed * Time.deltaTime;

        _rigidbody.MovePosition(position);
    }
}
