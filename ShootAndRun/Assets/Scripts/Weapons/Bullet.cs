using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject standImpactFX;
    private void Update()
    {
        //Merminin hareket etmesi
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Mermi belirli hedeflere �arparsa hasar veriyor, yok oluyor ve partik�l efekti ��kar�yor
        if (other.CompareTag("Stand"))
        {
            Instantiate(standImpactFX, transform.position, Quaternion.identity);
            other.GetComponent<Stand>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
