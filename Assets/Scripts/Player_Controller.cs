using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
    public float maxSpeed;
    public float jumpHeight;

    bool facingRight;
    bool grounded;

    Rigidbody2D myBody;
    Animator myAnim;


	void Start () {

        myBody = GetComponent<Rigidbody2D> ();

        myAnim = GetComponent<Animator> ();

        facingRight = true;


	}
	
	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(move*maxSpeed,myBody.velocity.y);

        myAnim.SetFloat("Speed", Mathf.Abs(move));
        //change face when move
        if (move > 0 && !facingRight)
        {
            filp();
        }
        else if (move < 0 && facingRight) {
            filp();
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (grounded) {
                grounded = false;//khong cho nhan vat nhay
                //set luc
                myBody.velocity = new Vector2(myBody.velocity.x,jumpHeight);
            }
        }
	}

    void filp() {

        facingRight = !facingRight;

        Vector3 theSacle = transform.localScale;

        theSacle.x *= -1;

        transform.localScale = theSacle;
    }

    //set va cham 2 vat the
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }
}
