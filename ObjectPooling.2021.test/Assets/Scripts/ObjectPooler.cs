using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject instantiator;
    [SerializeField] GameObject ballPrefab;

    public static ObjectPool<Ball> BallPool;
    
    private void Awake()
    {
        BallPool = new ObjectPool<Ball>(CreateBall, OnGetBall, OnReleaseBall, OnDestroyBall, false, 10, 10);
    }

    Ball CreateBall()
    {
        Ball ball = Instantiate(ballPrefab, transform.position, Quaternion.identity, instantiator.transform);
        ball.SetPool(BallPool);
        return ball;
    }

    void OnGetBall (Ball ball)
    {
        gameObject.SetActive(true);
    }

    void OnReleaseBall(Ball ball)
    {
        gameObject.SetActive(false);
    }

    void OnDestroyBall(Ball ball)
    {
        Debug.Log("Ball got destroyed!");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) BallPool.Get();
    }
}
