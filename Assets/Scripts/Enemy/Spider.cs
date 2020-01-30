using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    
    public int Health { get; set; }
    public GameObject spiderAcidPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (Isdead == true)
            return; // stop the function 

        Health--;
        if(Health < 1)
        {
            Isdead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }
    public override void Movement()
    {
        //stay in position
    }

    public void Attack()
    {
        Instantiate(spiderAcidPrefab, transform.position, Quaternion.identity);
    }

}
