using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy,IDamageable
{

    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);

        //flip the enemy according to player
        Vector3 direction = player.transform.localPosition - transform.position;

        if(direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if(direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }



    public void Damage()
    {

        if (Isdead == true)
            return;
        Health--;
        anim.SetTrigger("Hit");
        ishit = true;
        anim.SetBool("InCombat", true);
        if(Health < 0)
        {
            Isdead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
