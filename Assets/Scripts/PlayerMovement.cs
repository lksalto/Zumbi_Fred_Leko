using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float fJumpForce = 5.0f;
    public bool bCanJump = true;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    [SerializeField] float comp;
    [SerializeField] float rayX;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debugger();
        if (Input.GetKey(KeyCode.W) && bCanJump)
        {
            bCanJump = false;
            Jump();
        }
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
        
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * fJumpForce, ForceMode2D.Impulse);
        }
        
    }

    void Debugger()
    {
        RaycastHit2D[] hits;
        RaycastHit2D[] hitsL;
        RaycastHit2D[] hitsR;
        hits = Physics2D.RaycastAll(transform.position, -transform.up, comp);
        hitsL = Physics2D.RaycastAll(new Vector2(transform.position.x - 0.8f, transform.position.y), -transform.up, comp);
        hitsR = Physics2D.RaycastAll(new Vector2(transform.position.x + 0.7f, transform.position.y), -transform.up, comp);
        bool isGrounded = false;
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -transform.up * comp);
        Debug.DrawRay(new Vector2(transform.position.x - 0.8f, transform.position.y), - transform.up * comp);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y), -transform.up * comp);

        // For each object that the raycast hits.
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if(hit.collider.CompareTag("Floor"))
            {
                bCanJump = true;
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
            RaycastHit2D hitR = hits[i];
            if (hitR.collider.CompareTag("Floor"))
            {
                bCanJump = true;
                isGrounded = true;
            }
        }
        bCanJump = isGrounded;
    }
    
}
