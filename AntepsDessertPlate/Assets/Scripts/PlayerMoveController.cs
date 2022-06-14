using System;
using _GameData.Scripts.Managers;
using UnityEngine;

namespace _GameData.Scripts.Controllers
{
    
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier;

        private static readonly int MovementAlpha = Animator.StringToHash("MovementAlpha");
        public Animator _animator;
        private CharacterController _characterController;
        private Action _movementMethod;
        private float _speed;

        private void Awake()
        {
            if (TryGetComponent<CharacterController>(out _characterController))
            {
                _movementMethod = ApplyMovementBySimpleMove;
            }
            else
            {
                _movementMethod = ApplyMovementByTranslating;
            }
        }
        
        private void Update()
        {
            ApplyRotation();
            _movementMethod();
            if (Input.touchCount > 0)
            {
                _animator.SetBool("isRun",true);
            }
            else
            {
                _animator.SetBool("isRun",false);
            }

        }

        private void ApplyMovementByTranslating()
        {
            CalculateSpeed();
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void ApplyMovementBySimpleMove()
        {
            CalculateSpeed();
            _characterController.SimpleMove(_speed * transform.forward);
        }

        private void ApplyRotation()
        {
            var directionTransposed = InputManager.Instance.direction.TransformToXZ().SafeLookRotation();
            transform.rotation = Quaternion.LookRotation(directionTransposed, Vector3.up);
        }

        private void CalculateSpeed()
        {
            var magnitude = InputManager.Instance.magnitude;
            _speed = magnitude * speedMultiplier;
        }
    }
}
