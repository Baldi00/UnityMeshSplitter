using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private List<GameObject> colliding;

    void Start()
    {
        colliding = new List<GameObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        colliding.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        colliding.Remove(other.gameObject);
    }

    public List<GameObject> GetCollidingObjects()
    {
        return new List<GameObject>(colliding);
    }

    public void ClearCollidingObjects()
    {
        colliding.Clear();
    }
}
