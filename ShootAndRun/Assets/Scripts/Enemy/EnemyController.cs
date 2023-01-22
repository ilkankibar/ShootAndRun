using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public USP weapon;
    public LayerMask target;
    private Animator anim;

    public float maxHealth;
    private float health;
    public Image healthImage;

    public GameObject deadFX;
    private void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        weapon.canFire = true;
    }
    private void Update()
    {
        //Karakterin ortasýndan ileriye ýþýn gönderir ve ýþýn belirli bir hedefe deðiyorsa ateþ etmeye baþlar.
        Ray ray = new Ray(transform.position + new Vector3(0, .5f, 0), transform.forward);
        Debug.DrawRay(transform.position + new Vector3(0,.5f,0), transform.forward * 25, Color.black);
        if (Physics.Raycast(ray,10, target))
        {
            anim.SetBool("Firing", true);
            weapon.GetComponent<USP>().canFire = true;
        }
    }
    public void TakeDamage(float value)
    {
        //Her mermi çarpýþýnda canýný düþürür. Caný sýfýrýn altýna düþerse kendini yok eder.
        health -= value;
        healthImage.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
