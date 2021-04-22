using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float speed = 2f;
    [SerializeField] float rotateSpeed = 30f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketController();
        RocketRotation();
    }

    void RocketController()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            audioSource.Stop();
        }
    }

    void RocketRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            rb.freezeRotation = false;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
}
