using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerupIndicator;
    public Vector3 powerupOffset;
    private Rigidbody playerRb;
    private GameObject focalPoint;

    public float speed = 5.0f;
    public bool hasPowerup = false;
    private float fwdInput;
    private float powerupStrength = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        fwdInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * fwdInput * speed);

        powerupIndicator.transform.position = transform.position + powerupOffset;
    }

    void FixedUpdate()
    {
        playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
        }
    }

    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("Collided with: " + other.gameObject.name + "with Powerup set to " + hasPowerup);
        }
    }
}
