using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooler : MonoBehaviour
{
    public static ObjPooler Instance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        Instance = this;
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        InvokeRepeating("Instantiator", 1f, 0.0005f);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }


    // Update is called once per frame
    void Instantiator()
    {
        GameObject cube = Instance.GetPooledObject();
        if (cube != null)
        {
            cube.transform.position = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            cube.transform.rotation = transform.rotation;
            cube.SetActive(true);
        }
    }
}
