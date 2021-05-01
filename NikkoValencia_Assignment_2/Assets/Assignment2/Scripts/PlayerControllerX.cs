using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogCooldown = 2.0f;
    public float dogTimer;

    // Update is called once per frame
    void Update()
    {
        // prevents spamming the spacebar
        dogTimer += Time.deltaTime;
        if(dogTimer < dogCooldown)
        {
            return;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dogTimer = 0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
