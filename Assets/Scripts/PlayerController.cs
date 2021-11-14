using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationLeft = 1f;
    [SerializeField] float rotationRight = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rgb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

    }

    
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }else{surfaceEffector2D.speed = baseSpeed;}
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgb2d.AddTorque(rotationLeft);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rgb2d.AddTorque(-rotationRight);
        }
    }
}
