using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField] protected int health;
    [SerializeField] protected int gems;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform pointA, pointB;



    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool ishit = false;
    protected Player player;
    protected bool Isdead = false;

    public virtual void Init()
    {

        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }


    public virtual void Update()
    {

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (Isdead == false)
        {
            Movement();
        }

        //     if(_switch == false)
        //     {
        //       transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);  //move Right
        //     }
        //     if (_switch == true)
        //     {
        //     transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed);  //move left
        //  }
    }

    public virtual void Movement()
    {

        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }

        if (currentTarget == pointB.position)
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }

        if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if (ishit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        //check the distance between the player and enemy
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if( distance > 2.0f)
        {
            ishit = false;
            anim.SetBool("InCombat", false); 
        }

       

        //flip the enemy according to player
        Vector3 direction = player.transform.localPosition - transform.position;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }
}
