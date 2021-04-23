using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    // set the camera position
    private Vector3 offset = new Vector3(22.0f, 1.0f, 9.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // camera follows the plane
        transform.position = plane.transform.position + offset;
    }
}
