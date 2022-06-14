using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    
    [SerializeField] private float screenCoverage;
    public float SwerveAlpha;
    public float SwerveAlphaY;
    private Camera _mainCamera;
    private float _shiftAmount;
    private Rigidbody rb;
    public Animator anim;


    private void Awake()
    {
        _mainCamera = Camera.main;
        //rb = GetComponent<Rigidbody>();
        _shiftAmount = (1 - screenCoverage) / 2;
    }

    private void Update()
    {
        var inputX = _mainCamera.ScreenToViewportPoint(Input.mousePosition).x;
        var inputZ = _mainCamera.ScreenToViewportPoint(Input.mousePosition).y;
        
        if (inputZ < 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(transform.rotation.x,-180,transform.rotation.z,0), Time.deltaTime);
        }
        SwerveAlpha = Mathf.Clamp((inputX - _shiftAmount) / screenCoverage, 0, 1);
        SwerveAlphaY = Mathf.Clamp((inputZ - _shiftAmount) / screenCoverage, 0, 1);
        float swipeAmount = Mathf.Lerp(-8.4f, 8.44f, SwerveAlpha);
        float swipeAmountZ = Mathf.Lerp(-30f, 30f, SwerveAlphaY);
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(swipeAmount, position.y, swipeAmountZ);
        transform1.position = position;
       // rb.MovePosition(position);
    }
    
}
