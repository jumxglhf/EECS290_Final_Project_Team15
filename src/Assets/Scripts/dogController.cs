using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dogController : MonoBehaviour
{
   
    private Rigidbody2D myRigidBody;
    public float jumpForce = 500f;
    private Animator myAinm;
    public float energyRemained = 100;
    private bool flag = false;
    public AudioSource jumpSounds;
    // Start is called before the first frame update
    void Start()
    {   
        myRigidBody = GetComponent<Rigidbody2D>();
        myAinm = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Jump") && energyRemained>=10)
        {
            myRigidBody.AddForce(transform.up * jumpForce);
            energyRemained = energyRemained - 10;
            jumpSounds.Play();
        }

        myAinm.SetFloat("vVelocity", myRigidBody.velocity.y);
        if (flag == true)
        {

            transform.position = new Vector3(-3, transform.position.y, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        flag = false;
        Vector3 rot = transform.eulerAngles; ;
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            energyRemained -= 30;
            Destroy(collision.gameObject);
            flag = true;
        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Food1"))
        {
            energyRemained += 30;
            Destroy(collision.gameObject);
            flag = true;

        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Food2"))
        {
            energyRemained += 50;
            Destroy(collision.gameObject);
            flag = true;
        }
        transform.Rotate(new Vector3(360 - rot.x, 360 - rot.y, 360 - rot.z));

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "Energy Remained: "+ energyRemained);
    }
}
