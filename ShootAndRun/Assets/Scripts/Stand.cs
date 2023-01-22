using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stand : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public float health;
    private Animator anim;
    public GameObject allyObject;
    private void Start()
    {
        anim = GetComponent<Animator>();
        healthText.text = health.ToString();
    }
    public void TakeDamage(float value)
    {
        //Her mermi çarpmasýnda canýný düþüyor. Caný sýfýrýn altýna düþerse kendini yok eder.
        anim.SetTrigger("Impact");
        health -= value;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            //Kendini yok etmeden önce üzerindeki karakterin özelliklerini açar ve parentýný sýfýrlar.
            allyObject.GetComponent<Rigidbody>().useGravity = true;
            allyObject.GetComponent<CapsuleCollider>().enabled = true;
            allyObject.transform.SetParent(null);
            Destroy(this.gameObject);
        }
    }
}
