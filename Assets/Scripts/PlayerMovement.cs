using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //base values for PlayerMovement
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerType based;
    [SerializeField] private PlayerType player;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private GameObject killBox;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject mine;
    [SerializeField] private GameObject martial;
    [SerializeField] private GameObject offset;
    //derived values from ScriptableObject
    private float xforce;
    private float yforce;
    private float jumpBuffer;
    private float dampSpeed;
    //other values for PlayerMovement
    private float xI = 0f;
    public Transform groundCheck;
    public LayerMask groundLayer; //specify layer "ground"
    private bool surfaced;
    //reference to CharAnimHandler methods
    [SerializeField] public CharAnimHandler animHandler;

    void Awake()
    {
        if(player.health == 0)
        {
            CopyFromBaseStats();
            player.setCharType();
            player.GenerateSkills();
            player.ApplyPassives();
        }
        health.player = player;
        xforce = player.xforce;
        yforce = player.yforce;
        jumpBuffer = player.jumpBuffer;
        dampSpeed = player.dampSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jumping();
        UseSkills();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameOver")
        {
            Debug.Log("death");
            health.Death();
        }

        if(collision.tag == "Damage")
        {
            health.TakeDamage(20);
        }
    }

        public void HorizontalMovement()
    {
        //Moving along x axis
        xI = Input.GetAxis("Horizontal");

        //Here is where some force is added to the ridged body (player)
        //Moving left or right on x axis
        if (xI > 0f)
        {
            animHandler.SetRunning();
            rb.velocity = new Vector2(xI * xforce, rb.velocity.y);
            transform.localScale = new Vector2(1.047133f, 0.9223106f);
        }
        else if (xI < 0f)
        {
            animHandler.SetRunning();
            rb.velocity = new Vector2(xI * xforce, rb.velocity.y);
            transform.localScale = new Vector2(-1.047133f, 0.9223106f); //Flip player sprite
        }
        else
        { //not moving
            animHandler.SetIdle();
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        killBox.transform.position = new Vector2(transform.position.x, killBox.transform.position.y);
    }

    public void Jumping()
    {
        //find position of groundCheck object, use players radius(circle around players feet), check for overlap of ground to be true/false
        surfaced = Physics2D.OverlapCircle(groundCheck.position, jumpBuffer, groundLayer);

        //Detect if the space key is pressed down and player is in contact with ground
        //If both are true, the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && surfaced)
        {
            animHandler.SetJumping();
            rb.velocity = new Vector2(rb.velocity.x, yforce); //Player jump mechanic
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * dampSpeed);
        }
    }

    public void UseSkills()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            switch (player.charType)
            {
                case Char.CARROT: animHandler.SetAttack(); Instantiate(projectile, offset.transform.position, transform.rotation); break;
                case Char.TURNIP: animHandler.SetAttack(); Instantiate(mine, offset.transform.position, transform.rotation); break;
                default: Instantiate(martial, offset.transform.position, transform.rotation); break;
            }
            
        }
    }

    public void CopyFromBaseStats()
    {
        player.health = based.health;
        player.charType = based.charType;
        player.xforce = based.xforce;
        player.yforce = based.yforce;
        player.jumpBuffer = based.jumpBuffer;
        player.dampSpeed = based.dampSpeed;
        player.damage = based.damage;
        player.traits.RemoveAll(t => t >= (Trait) 0);
        player.Inheritable = new List<Trait>(based.Inheritable);
    }
}
