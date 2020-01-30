using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvevt : MonoBehaviour
{
    private Spider spider;

    private void Start()
    {
        spider = transform.parent.GetComponentInParent<Spider>();
    }
    public void Fire()
    {
     //   Debug.Log("event");
        spider.Attack();
    }
    
}
