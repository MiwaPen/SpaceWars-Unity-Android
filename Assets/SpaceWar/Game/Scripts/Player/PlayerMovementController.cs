using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private Transform LeftBorder;
    [SerializeField] private Transform RightBorder;
    private Camera mainCamera;
    private new Rigidbody rigidbody;
    private Vector3 mousePos;
    private Vector3 bodyPos;
    private bool canMove = false;
    
    void Awake()
    {
        mainCamera = Camera.main;
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y = rigidbody.transform.position.y;
            canMove = true;
        }
        else { canMove = false; }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {   
            bodyPos = rigidbody.transform.position;
            if (Math.Round( mousePos.x,1) != Math.Round(bodyPos.x,1))
            {
              
                if (mousePos.x > bodyPos.x && Math.Round(bodyPos.x, 1) < Math.Round(RightBorder.position.x, 1) )
                {
                    /*rigidbody.transform.position = bodyPos + new Vector3(Speed * Time.deltaTime, 0, 0);*/
                    rigidbody.MovePosition(bodyPos + new Vector3(Speed * Time.deltaTime, 0, 0));
                }
                if (mousePos.x < bodyPos.x && Math.Round(bodyPos.x, 1) > Math.Round(LeftBorder.position.x, 1))
                {
                   /* rigidbody.transform.position = bodyPos + new Vector3(-Speed * Time.deltaTime, 0, 0);*/
                    rigidbody.MovePosition(bodyPos + new Vector3(-Speed * Time.deltaTime, 0, 0));
                }
            }
        }
    }
}
