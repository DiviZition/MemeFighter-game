using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _jumpImpuls;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private bool _isLeftPartOfKeyboard;
    [SerializeField] private LayerMask _groundedMask;
    [SerializeField] private Vector2 _groundCheckerOffset;
    [SerializeField] private float _radiusOfChecker;
    [SerializeField] private float _additionalJumps = 1;

    private Transform _transform;
    private Rigidbody2D _rbPlayer;

    private Collider2D[] _trash = new Collider2D[2];
    private float _firstJumpCooleDown;
    private float _currentAdditionalJumps;
    private bool _isGrounded;

    public float CurrentSpeed => _defaultSpeed;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _transform = components.Transform;
        _rbPlayer = components.Rigidbody;
    }

    private void Update()
    {
        if (_isLeftPartOfKeyboard == true)
        {
            MovePlayer(KeyCode.D, KeyCode.A);
            JumpPlayer(KeyCode.W);
        }
        else
        {
            MovePlayer(KeyCode.RightArrow, KeyCode.LeftArrow);
            JumpPlayer(KeyCode.UpArrow);
        }
        CheckIsGrounded();
        ModifiGravity();
    }

    private void MovePlayer(KeyCode Right, KeyCode Left)
    {
        sbyte Deirection = 0;
        if (Input.GetKey(Right))
        {
            Deirection = 1;

        }
        if (Input.GetKey(Left))
        {
            Deirection = -1;
        }
        _rbPlayer.velocity = new Vector2(Deirection * _defaultSpeed, _rbPlayer.velocity.y);
        if (Deirection != 0 && Mathf.Sign(_transform.localScale.x) != Mathf.Sign(Deirection))
        {
            _transform.localScale = new Vector3
                   (_transform.localScale.x * -1, _transform.localScale.y, _transform.localScale.z);
        }
    }

    private void JumpPlayer(KeyCode up)
    {

        if (Input.GetKeyDown(up))
        {
            if (_isGrounded == true && _firstJumpCooleDown < Time.time)
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
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    public void ResetJumps() => _currentAdditionalJumps = _additionalJumps;
    public void ChangeSpeed(float newSpeed) => _defaultSpeed = newSpeed;

    private void OnDrawGizmos()
    {
        if (_transform == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere((Vector2)_transform.position + _groundCheckerOffset, _radiusOfChecker);
    }
}
