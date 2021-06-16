using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private bool canJump = false;
    private Animator enemyAnim;
    private float rightBound = -1.0f;
    private float leftBound = -8.0f;

    public float jumpForce;
    public float gravityModifier;
    public float speed = 3.0f;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if (transform.position.x > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }

            if (transform.position.x < leftBound)
            {
                Destroy(gameObject);
            }
        }
        else if(gameOver == true)
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
