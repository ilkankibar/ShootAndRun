using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USP : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private GameManager gm;
    public LayerMask target;


    public bool canFire;
    public float fireRate;
    public float damage;
    private float timer;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer = fireRate;
    }
    private void Update()
    {
        //Eðer oyun baþladýysa
        if (gm.isGameStarted && canFire)
        {
            //Iþýn gönderiyor ve ýþýn belirli hedeflere çarparsa ateþ etmeye baþlýyor. Ateþ ettikten sonra zamanlayýcýyý baþa döndürüyor.
            Ray ray = new Ray(firePoint.position,firePoint.forward);
            Debug.DrawRay(firePoint.position, firePoint.forward * 20, Color.black);
            if (Physics.Raycast(ray,20,target))
            {
                if (timer <= 0)
                {
                    GameObject obj = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    obj.GetComponent<Bullet>().speed = 25;
                    obj.GetComponent<Bullet>().damage = damage;
                    timer = fireRate;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }
}
