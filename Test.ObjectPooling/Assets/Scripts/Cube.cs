using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    bool isCoroutineStarted = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-3, 3), Random.Range(50, 100), Random.Range(-3, 3), ForceMode.VelocityChange);
    }

    IEnumerator WaitAndDeactivate()
    {
        isCoroutineStarted = true;
        yield return new WaitForSeconds(40);
        gameObject.SetActive(false);
        isCoroutineStarted = false;
    }


    // Update is called once per frame
    void Update()
    {
       if (gameObject == isActiveAndEnabled && !isCoroutineStarted) StartCoroutine(WaitAndDeactivate());
    }
}
