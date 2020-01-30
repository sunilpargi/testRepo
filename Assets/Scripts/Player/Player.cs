using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody2D rb;
    float horizontalMove;
   [SerializeField] private float jumpforce = 5f;
   [SerializeField] private float speed = 2f;
    private bool grounded = false;
    [SerializeField] private LayerMask groundLayer;
    private bool resetjumpNeeded = false;

    public int diamond;

    private PlayerAnimation Playeranim;
    private SpriteRenderer PlayerSprite;
    private SpriteRenderer swordSprite;

    public int Health { get; set; }

    void Start()
    {
        rb            = GetComponent<Rigidbody2D>();
        Playeranim = GetComponent<PlayerAnimation>();
        PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

   
    void Update()
    {
        movement();

        if(Input.GetMouseButtonDown(0) && Isgrounded() == true)
        {
            Playeranim.Attack();
        }
       
    }

   void movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed ;
        grounded = Isgrounded();

        if (horizontalMove > 0)
        {
            Flip(true);
        }
        else if (horizontalMove < 0)
        {
            Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Isgrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            grounded = false;
            resetjumpNeeded = true;
            StartCoroutine(ResetjumpNeededRoutine());
            Playeranim.Jump(true);
         }

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        Playeranim.Move(horizontalMove);
    }
   

   bool Isgrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if (hitInfo.collider != null)
        {
            if (resetjumpNeeded == false)
                Playeranim.Jump(false);
            return true;
          
        }
        return false;
    }

    void Flip(bool IsFacingRight)
    {
     if(IsFacingRight == true)
        {
            PlayerSprite.flipX = false;
            swordSprite.flipX = false;
            swordSprite.flipY = false;
            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordSprite.transform.position = newPos;
        }
     else if(IsFacingRight == false)
        {
            PlayerSprite.flipX = true;
            swordSprite.flipX = true;
            swordSprite.flipY = true;
            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordSprite.transform.position = newPos;

        }
    }
        

    IEnumerator ResetjumpNeededRoutine()
    {
        resetjumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        resetjumpNeeded = false;
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Debug.Log("player is under atttacking");
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if(Health < 1)
        {
            Playeranim.Death();
        }
    }
    public void AddGems(int amount)
    {
        diamond += amount;
        UIManager.Instance.UpdateGemsCount(diamond);
    }


}
