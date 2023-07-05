using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> poolObject;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    private void Awake()
    {
        poolObject = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            poolObject.Enqueue(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        GameObject obj = poolObject.Dequeue();
        obj.SetActive(true);
        poolObject.Enqueue(obj);
        return obj;
    }
    
}
