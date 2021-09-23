using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Speed = 350;

    // Update is called once per frame
    void FixedUpdate() {
        RB.angularVelocity = Speed;
    }
}
