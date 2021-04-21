using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "collided with " + gameObject.name);

        GetComponent<MeshRenderer>().material.color = Color.cyan;
    }
}
