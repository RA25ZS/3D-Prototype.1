using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] [Range(0, 1)] float movingFactor;
    [SerializeField] Vector3 movingVector;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        Vector3 offset = movingVector * movingFactor;
        transform.position = startingPos + offset;

        float rawSinWave = Mathf.Sin(cycles * tau);

        movingFactor = (rawSinWave + 1f) / 2f;
    }
}
