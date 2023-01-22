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
        //Her mermi �arpmas�nda can�n� d���yor. Can� s�f�r�n alt�na d��erse kendini yok eder.
        anim.SetTrigger("Impact");
        health -= value;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            //Kendini yok etmeden �nce �zerindeki karakterin �zelliklerini a�ar ve parent�n� s�f�rlar.
            allyObject.GetComponent<Rigidbody>().useGravity = true;
            allyObject.GetComponent<CapsuleCollider>().enabled = true;
            allyObject.transform.SetParent(null);
            Destroy(this.gameObject);
        }
    }
}
