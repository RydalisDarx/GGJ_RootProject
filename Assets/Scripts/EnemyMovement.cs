using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerType stats;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private float enemyHealth;
    private bool search;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bindingObj;
    [SerializeField] private float binding;



    void Start()
    {
        search = true;
        GameObject.Instantiate(bindingObj, new Vector3(this.transform.position.x + binding, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        GameObject.Instantiate(bindingObj, new Vector3(this.transform.position.x + binding *-1, this.transform.position.y, this.transform.position.z), this.transform.rotation);
    }

    void Update()
    {
        if (search)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime, this.GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime * -1, this.GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Binding")
        {
            if(search == true)
            {
                search = false;
            } else
            {
                search = true;
            }
        }//end binding

        if(collision.gameObject.tag == "PlayerProjectile") {
            enemyHealth -= stats.damage;

            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }//end trigger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.Death();
        }//end killPlayer
        
    }//end collision
}
