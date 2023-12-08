using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _jumpImpuls;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private LayerMask _groundedMask;
    [SerializeField] private Vector2 _groundCheckerOffset;
    [SerializeField] private float _radiusOfChecker;
    [SerializeField] private float _additionalJumps = 1;

    private Transform _transform;
    private Rigidbody2D _rbPlayer;

    private Collider2D[] _trash = new Collider2D[2];
    private float _firstJumpCooleDown;
    private float _currentAdditionalJumps;
    private float _currentSpeed;

    public bool IsGrounded { get; private set; }
    public float CurrentSpeed => _currentSpeed;
    public float DefaultSpeed => _defaultSpeed;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _transform = components.Transform;
        _rbPlayer = components.Rigidbody;

        _currentSpeed = _defaultSpeed;
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();

        CheckIsGrounded();
        ModifiGravity();
    }

    private void MovePlayer()
    {
        sbyte Deirection = 0;
        if (Input.GetKey(ControllsConfig.Right))
        {
            Deirection = 1;

        }
        if (Input.GetKey(ControllsConfig.Left))
        {
            Deirection = -1;
        }
        _rbPlayer.velocity = new Vector2(Deirection * _currentSpeed, _rbPlayer.velocity.y);

        if (Deirection != 0 && Mathf.Sign(_transform.localScale.x) != Mathf.Sign(Deirection))
        {
            _transform.localScale = new Vector3
                   (_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
        }
    }

    private void JumpPlayer()
    {

        if (Input.GetKeyDown(ControllsConfig.Jump) || Input.GetKeyDown(ControllsConfig.Up))
        {
            if (IsGrounded == true && _firstJumpCooleDown < Time.time)
            {
                _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _jumpImpuls);
                _firstJumpCooleDown = Time.time + 0.1f;
                
            }
            else if (_currentAdditionalJumps > 0)
            {
                _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _jumpImpuls);
                _currentAdditionalJumps--;
            }
        }
    }

    private void ModifiGravity()
    {
        _rbPlayer.velocity = new Vector2
            (_rbPlayer.velocity.x, _rbPlayer.velocity.y - (Mathf.Abs(_gravityModifier) *
            Time.deltaTime));
    }

    private void CheckIsGrounded()
    {
        if (Physics2D.OverlapCircleNonAlloc
            ((Vector2)_transform.position + _groundCheckerOffset, 
            _radiusOfChecker, _trash, _groundedMask) > 1)
        {
            ResetJumps();
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    public void ResetJumps() => _currentAdditionalJumps = _additionalJumps;
    public void ChangeSpeed(float newSpeed) => _currentSpeed = newSpeed;
}
