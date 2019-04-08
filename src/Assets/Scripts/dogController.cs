using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogController : MonoBehaviour
{
   
    private Rigidbody2D myRigidBody;
    public float jumpForce = 500f;
    private Animator myAinm;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAinm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Jump"))
        {
            myRigidBody.AddForce(transform.up * jumpForce);
        }

        myAinm.SetFloat("vVelocity", myRigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Application.LoadLevel(Application.loadedLevel);

        }
    }
}
