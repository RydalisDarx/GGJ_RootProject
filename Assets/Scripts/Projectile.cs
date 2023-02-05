using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool isProjectile;
    public bool isMine;
    public float speed = 4.5f;
    public float projectileTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isProjectile)
        {
            transform.position += transform.right * Time.deltaTime * speed;
            Destroy(gameObject, 4);
        } 
        else if (isMine)
        {
            Destroy(gameObject, 3);
        }
            Destroy(gameObject, 1);
    }
}
