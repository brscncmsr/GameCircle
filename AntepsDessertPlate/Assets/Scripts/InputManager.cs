using UnityEngine;

namespace _GameData.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        public float screenCoverage;
        public static InputManager Instance { get; private set; }
        
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float magnitude;

        private Camera _camera;
        private float _aspect;
        
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        private const float LerpSpeed = 10;
        private bool _isFirstTap;

        private void Awake(){
            Instance = this;
            _camera = Camera.main;
            if (_camera == null) return;
            _aspect = _camera.aspect;
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPosition = Input.mousePosition;
                
            }
            else if (Input.GetMouseButton(0))
            {
                _currentPosition = Input.mousePosition;
                var positionDifference = _currentPosition - _startPosition;
                magnitude = positionDifference.magnitude / _camera.pixelWidth;
                positionDifference.y = _aspect * positionDifference.y;
                direction = positionDifference.normalized;
            }
            else
            {
                magnitude = Mathf.Lerp(magnitude, 0, Time.deltaTime * LerpSpeed);
            }
        }

        
     //       if (_isFirstTap) return;
        //    _isFirstTap = true;
      
        
    }
}
