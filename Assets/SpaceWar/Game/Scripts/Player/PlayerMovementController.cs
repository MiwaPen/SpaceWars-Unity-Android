using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    private Camera _mainCamera;
    private  Rigidbody _rigidbody;
    private Vector3 _mousePos;
    private Vector3 _bodyPos;
    private bool _canMove = false;
    
    void Awake()
    {
        _mainCamera = Camera.main;
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0f;
            _mousePos.y = _rigidbody.transform.position.y;
            _canMove = true;
        }
        else { _canMove = false; }
        if (_canMove)
        {
            _bodyPos = _rigidbody.transform.position;
            if (Math.Round(_mousePos.x, 1) != Math.Round(_bodyPos.x, 1))
            {
                if (_mousePos.x > _bodyPos.x && Math.Round(_bodyPos.x, 1) < Math.Round(_rightBorder.position.x, 1))
                {
                    _rigidbody.MovePosition(_bodyPos + new Vector3(_speed * Time.deltaTime, 0, 0));
                }
                if (_mousePos.x < _bodyPos.x && Math.Round(_bodyPos.x, 1) > Math.Round(_leftBorder.position.x, 1))
                {
                    _rigidbody.MovePosition(_bodyPos + new Vector3(-_speed * Time.deltaTime, 0, 0));
                }
            }
        }
    }
}
