using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    private float moveZ;
    public float speed;
    public float moveRange = 1;

    private GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            //Game Over
        }
        if (gm.isGameStarted)
        {
            Movement();
        }
    }
    //Karakterin hareket kontrolleri
    private void Movement()
    {
        moveX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveX = Mathf.Clamp(moveX, -moveRange, moveRange);

        moveZ += speed * Time.deltaTime;

        transform.position = new Vector3(moveX * 2, transform.position.y, moveZ);
    }
}
