using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    float moveDirection;
    Rigidbody2D rb;
    public bool bCanJump = true;
    SpriteRenderer sprite;
    float horizontalInput;
    GameController gameController;
    bool isStuck = true;
    float jumpCooldownCounter;
    Transform cameraPosX;

    [SerializeField] float jumpCooldown = 0.5f;
    [SerializeField] float moveSpeed;
    [SerializeField] Player player;
    [SerializeField] float fJumpForce = 5.0f;
    [SerializeField] float comp;
    [SerializeField] float rayX;
    [SerializeField] GameObject mainCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        cameraPosX = GetComponent<Transform>();

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        jumpCooldownCounter -= Time.deltaTime;
        moveSpeed = gameController.velocidadeParede;
        Debugger();
        CameraMovement();
        if (Input.GetKey(KeyCode.W) && bCanJump)
        {
            Jump();
        }
        Move();
        
        if (!bCanJump)
        {
            sprite.color = Color.red;
        }
        else
        {
            
            sprite.color = Color.green;
        }
    }

    void Jump()
    {
        jumpCooldownCounter = jumpCooldown;
        rb.velocity = new Vector2(0, fJumpForce);        
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed * 3, rb.velocity.y);
            isStuck = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            isStuck = false;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isStuck = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }


    void Debugger()
    {
        RaycastHit2D[] hits;
        RaycastHit2D[] hitsL;
        RaycastHit2D[] hitsR;

        hits = Physics2D.RaycastAll(transform.position, -transform.up, comp);
        hitsL = Physics2D.RaycastAll(new Vector2(transform.position.x - 0.9f, transform.position.y), -transform.up, comp);
        hitsR = Physics2D.RaycastAll(new Vector2(transform.position.x + 0.3f, transform.position.y), -transform.up, comp);

        bool isGrounded = false;
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -transform.up * comp);
        Debug.DrawRay(new Vector2(transform.position.x - 0.9f, transform.position.y), - transform.up * comp);
        Debug.DrawRay(new Vector2(transform.position.x + 0.3f, transform.position.y), -transform.up * comp);

        // For each object that the raycast hits.
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if(hit.collider.CompareTag("Floor"))
            {
                isGrounded = true;
            }

        }
        for (int i = 0; i < hitsL.Length; i++)
        {
            RaycastHit2D hitL = hitsL[i];
            if (hitL.collider.CompareTag("Floor"))
            {
                isGrounded = true;
            }

        }
        for (int i = 0; i < hitsR.Length; i++)
        {
            RaycastHit2D hitR = hitsR[i];
            if (hitR.collider.CompareTag("Floor"))
            {
                isGrounded = true;
            }

        }
        if (isStuck)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        bCanJump = isGrounded && jumpCooldownCounter <= 0;
    }
    void CameraMovement()
    {
        if(this.transform.position.x > 0)
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, 0, -10);
        }
    }
}

