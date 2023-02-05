using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    //base values for PlayerMovement
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerType input;
    [SerializeField] private AbilityDecorator deco;
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
    public Action OnPassive;

    // Start is called before the first frame update
    void Start()
    {
        PlayerType type = Instantiate(input);
        AbilityDecorator a = Instantiate(deco);
        xforce = type.xforce;
        yforce = type.yforce;
        jumpBuffer = type.jumpBuffer;
        dampSpeed = type.dampSpeed;
        OnPassive += a.MoveSkill;
        OnPassive += a.InheritedSkill;
        OnPassive.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jumping();
        UseSkills();
    }

    public void HorizontalMovement()
    {
        //Moving along x axis
        xI = Input.GetAxis("Horizontal");

        //Here is where some force is added to the ridged body (player)
        //Moving left or right on x axis
        if (xI > 0f)
        {
            rb.velocity = new Vector2(xI * xforce, rb.velocity.y);
            transform.localScale = new Vector2(1.047133f, 0.9223106f);
        }
        else if (xI < 0f)
        {
            rb.velocity = new Vector2(xI * xforce, rb.velocity.y);
            transform.localScale = new Vector2(-1.047133f, 0.9223106f); //Flip player sprite
        }
        else
        { //not moving
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Jumping()
    {
        //find position of groundCheck object, use players radius(circle around players feet), check for overlap of ground to be true/false
        surfaced = Physics2D.OverlapCircle(groundCheck.position, jumpBuffer, groundLayer);

        //Detect if the space key is pressed down and player is in contact with ground
        //If both are true, the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && surfaced)
        {
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
            input.MainSkill(input.charType);
        }
    }
<<<<<<< Updated upstream
=======

    public void GetCharacterStatistics(PlayerType input)
    {
        PlayerType type = Instantiate(input);
        OnPassive += input.setCharType;
        OnPassive += type.MoveSkill;
        OnPassive += type.InheritedSkill;
        OnPassive.Invoke();
        OnPassive -= input.setCharType;
        OnPassive -= type.MoveSkill;
        OnPassive -= type.InheritedSkill;
        xforce = type.xforce;
        yforce = type.yforce;
        jumpBuffer = type.jumpBuffer;
        dampSpeed = type.dampSpeed;
    }
>>>>>>> Stashed changes
}
