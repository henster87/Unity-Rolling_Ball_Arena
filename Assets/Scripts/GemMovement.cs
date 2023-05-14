using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float rotationSpeed = 1.0f;
    public float amplitude = 1.0f;
    public float yOffset;

    public AnimationCurve curve;
    public GameObject gemT;

    private Vector3 gemPos;

    private void Start() 
    {
        gemPos = transform.position;
        yOffset = gemT.transform.position.y + 0.5f;
    }

    private void Update() 
    {
        gemPos.y = SinAmount() + yOffset;
        transform.position = gemPos;
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
    }

    public float SinAmount()
    {
        return amplitude * Mathf.Sin(Time.time * curve.Evaluate(speed));
    }

}
