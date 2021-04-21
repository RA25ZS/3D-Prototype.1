using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToDrop = 5f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if (Time.time > timeToDrop)
        {
            rb.useGravity = true;
        }
    }
}
