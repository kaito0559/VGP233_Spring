using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // propeller rotates at ta constatn rate;
        transform.Rotate(new Vector3(0.0f, 0.0f, speed));
    }
}
