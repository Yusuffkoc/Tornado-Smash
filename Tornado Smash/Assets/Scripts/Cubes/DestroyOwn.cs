using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOwn : MonoBehaviour
{
    private float waitTime;
    
    private float time;

    void Start()
    {
        waitTime = 2f;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tornado")
        {
            ScaleIncrease();
            StartCoroutine(DestroyCube());
        }
    }

    

    private void ScaleIncrease()
    {
        transform.localScale /= 2f;
    }

    private IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
        LevelProgress.CubeNumbers--;

    }
}
