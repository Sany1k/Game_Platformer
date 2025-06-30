using Platformer.Components;
using UnityEngine;

namespace Platformer
{
    public class Hero : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float damageJumpPower;
        [SerializeField] private float interactionRadius;
        [SerializeField] private LayerCheck groundCheck;
        [SerializeField] private LayerMask interactionLayer;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private SpriteRenderer _sprite;
        private Collider2D[] interactionResult = new Collider2D[1];

        private bool _isGrounded;
        private bool _allowDoubleJump;

        private static readonly int isGroundKey = Animator.StringToHash("is-ground");
        private static readonly int isRunning = Animator.StringToHash("is-running");
        private static readonly int verticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int hit = Animator.StringToHash("hit");
        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            _isGrounded = groundCheck.isTouchingLayer;

        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * speed;
            var yVelocity = CalculateVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            _animator.SetBool(isGroundKey, _isGrounded);
            _animator.SetFloat(verticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(isRunning, _direction.x != 0);

            UpdateSpriteDirection();
        }

        private float CalculateVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumping = _direction.y > 0;

            if (_isGrounded) _allowDoubleJump = true;

            if (isJumping)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            if (_rigidbody.velocity.y > 0) return yVelocity;

            if (_isGrounded)
            {
                yVelocity += jumpPower;
            } 
            else if (_allowDoubleJump)
            {
                yVelocity = jumpPower;
                _allowDoubleJump = false;
            }

            return yVelocity;
        }

        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)
            {
                _sprite.flipX = false;
            }
            else if (_direction.x < 0)
            {
                _sprite.flipX = true;
            }
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(hit);
            transform.position = new Vector2(transform.position.x, transform.position.y + damageJumpPower);
        }

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, interactionRadius, interactionResult, interactionLayer);

            for (int i = 0; i < size; i++)
            {
                var interactable = interactionResult[i].GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                    FindObjectOfType<AudioManager>().Play("Wheel");
                }
            }
        }
    }
}
