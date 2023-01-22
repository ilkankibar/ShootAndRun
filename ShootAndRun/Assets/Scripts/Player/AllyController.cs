using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    private Transform player;
    private Animator anim;
    private GameManager gm;
    public float speed;
    public USP weapon;
    private bool canFire;
    private bool isInControl;
    public GameObject deadFX;
    private void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            //Karakterin altýndaki stand yok olduktan sonra oyuncu objesinin yanýna gider ve ateþ etmeye baþlar.
            anim.SetBool("Running", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,player.position) <= 1)
            {
                weapon.GetComponent<USP>().canFire = true;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 1));
                transform.SetParent(player);
                canFire = true;
            }
        }
        else
        {
            //Karakter oyuncu objesinin kontrolünde mi deðil mi?
            if (transform.parent.name == "Player")
            {
                print(transform.parent.name);
                isInControl = true;
            }
            else
            {
                isInControl = false;
            }
            if (isInControl && gm.isGameStarted)
            {
                //Oyun baþladýysa ve karakter kontrol oyuncu objesinin altýndaysa
                anim.SetBool("Running", true);
                if (Vector3.Distance(transform.position,player.position) >= 2)
                {
                    //Oyuncu objesinden uzaklaþýrsa tekrar yakýnýna gelmesini saðlar.
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else
                {
                    //Oyuncu objesinin yakýnýndaysa ateþ eder.
                    weapon.GetComponent<USP>().canFire = true;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 1));
                    transform.SetParent(player);
                    canFire = true;
                }
            }
            else
            {
                anim.SetBool("Running", false);
            }
            //Karakterin sað ve sol menzilini kýsýtlar.
            if (transform.position.x > 1)
            {
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -1)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Belirli objeler ile temas ederse partikül efekti çýkarýr ve yok olur.
        if (other.CompareTag("Stand") || other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
