using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour
{
    [SerializeField] private Transform tornadoCenter;
    [SerializeField] private float pullForce;
    [SerializeField] private float refreshRate;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            StartCoroutine(PullObject(other, true));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
        {
            StartCoroutine(PullObject(other, false));
        }

        
    }

    IEnumerator PullObject(Collider x, bool canPull)
    {

        if (canPull)
        {
            Vector3 ForceDirection = tornadoCenter.position - x.transform.position;
            x.GetComponent<Rigidbody>().AddForce(ForceDirection.normalized * pullForce * Time.deltaTime);

            yield return refreshRate;

            StartCoroutine(PullObject(x, canPull));
        }
    }
}
