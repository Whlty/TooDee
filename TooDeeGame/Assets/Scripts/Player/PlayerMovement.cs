using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, scrollSens;
    [SerializeField] private SpriteRenderer model;
    [SerializeField] private Camera playerCamera;
    private float x, y, scroll, zoomLevel;
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDirection;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        zoomLevel = playerCamera.orthographicSize;
    }
    private void Update()
    {
        // set x and y to the direction the player is trying to move
        // y = 1 (w) y = 0 (nothing) y = -1 (s)
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(x,y).normalized;

        scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        if (x > 0)
        {
            model.flipX = false;
        }
        else if (x < 0)
        {
            model.flipX = true;
        }

        if (scroll != 0)
        {
            ZoomCamera(scroll);
        }

    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDirection * moveSpeed;
    }

    private void ZoomCamera(float direction)
    {
        zoomLevel += direction * -scrollSens;
        if (zoomLevel > 20)
        {
            zoomLevel = 20;
        }
        else if (zoomLevel < 1)
        {
            zoomLevel = 1;
        }

        playerCamera.orthographicSize = zoomLevel;

    }

}
