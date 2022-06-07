using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{    
             
    void Awake ()
    {
        float r = Random.Range(0, 255f) / 255;
        float g = Random.Range(0, 255f) / 255;
        float b = Random.Range(0, 255f) / 255;

        GetComponent<Renderer>().material.color = new Color (r, g, b);
    }

    void Start ()
    {
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(5);
        ObjectPooler.BallPool.Release(this);
    }

    public void SetPool(ObjectPool<Ball> pool) => ObjectPooler.BallPool = pool;
}
