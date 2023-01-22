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
        //E�er oyun ba�lad�ysa
        if (gm.isGameStarted && canFire)
        {
            //I��n g�nderiyor ve ���n belirli hedeflere �arparsa ate� etmeye ba�l�yor. Ate� ettikten sonra zamanlay�c�y� ba�a d�nd�r�yor.
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
