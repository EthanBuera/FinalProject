using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    private float Movementx;
    
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WalkAnimation = "Walk";
    

    
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    void PlayerMoveKeyboard() {

        Movementx = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(Movementx, 0f, 0f) * Time.deltaTime * moveForce;
    }
    private void FixedUpdate()
    {
        Jump();
    }
    void AnimatePlayer() {
        if (Movementx > 0)
        {
            anim.SetBool(WalkAnimation, true);
            sr.flipX = false;
        }
        else if (Movementx < 0)
        {
            anim.SetBool(WalkAnimation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WalkAnimation, false);
        }

    }
    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
