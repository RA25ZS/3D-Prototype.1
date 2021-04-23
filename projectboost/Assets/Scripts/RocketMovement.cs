using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] AudioClip rocketEngine;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem sideEngineRight;
    [SerializeField] ParticleSystem sideEngineLeft;
    [SerializeField] float speed = 2f;
    [SerializeField] float rotateSpeed = 30f;

    Rigidbody rb;
    AudioSource audioSource;
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
            MoveRocket();

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(rocketEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void MoveRocket()
    {
        rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
        mainEngine.Play();
        sideEngineLeft.Play();
        sideEngineRight.Play();
    }

    void RocketRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    private void RotateRight()
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }

    private void RotateLeft()
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
