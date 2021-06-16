using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private bool isOnBuilding = true;
    private Animator playerAnim;
    //private AudioSource audioSource;
    private float leftBound = -6.5f;
    private float rightBound = 3.0f;
    private float horizontalInput;

    public float jumpForce;
    public float gravityModifier;
    public float speed = 5.0f;
    public bool gameOver = false;
    //public AudioClip jumpSound;
    //public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < leftBound)
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
        else if(transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnBuilding && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnBuilding = false;
            playerAnim.SetTrigger("Jump_trig");
            //audioSource.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isOnBuilding = true;
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("Game Over");
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            //audioSource.PlayOneShot(crashSound, 1.0f);
            playerAnim.SetBool("fall_b", true);
            //playerAnim.SetInteger("fall_int", 1);
        }
    }
}
