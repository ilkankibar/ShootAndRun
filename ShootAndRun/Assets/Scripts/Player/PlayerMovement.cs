using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    private float moveZ;
    public float speed;
    private float moveRange = 1;

    private GameManager gm;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (gm.isGameStarted)
        {
            Movement();
        }
    }
    private void Movement()
    {
        moveX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveX = Mathf.Clamp(moveX, -moveRange, moveRange);

        moveZ += speed * Time.deltaTime;
        anim.SetBool("Running", true);

        transform.position = new Vector3(moveX, transform.position.y, moveZ);
    }
}
