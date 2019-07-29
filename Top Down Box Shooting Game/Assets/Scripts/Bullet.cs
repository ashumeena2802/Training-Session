using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
   
    [SerializeField] private float speed;
    [SerializeField]  private float maxDistance;
    [SerializeField] private float Damage;

    private GameObject triggeringEnemy;

   
    void Update()
    {    
        
        // For movibg the bullet
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        maxDistance += 1 * Time.deltaTime;

        // For destroying
        if(maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= Damage;
            Destroy(this.gameObject);

            
        }
    }

    
}
