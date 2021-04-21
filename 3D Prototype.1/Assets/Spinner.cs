using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    Transform transformSpin;

    private void Awake()
    {
        transformSpin = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        transformSpin.Rotate(Vector3.down, 360 * Time.deltaTime * 0.5f);
    }
}
