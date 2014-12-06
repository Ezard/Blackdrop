using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	int jumpCount = 0;


	[SerializeField] float speed = 0.05f;
	[SerializeField] int jumpHeight = 5;
	[SerializeField] LayerMask whatIsGround;

	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Animator anim;										// Reference to the player's animator component.


	void Awake()
	{
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(-speed, 0, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(speed, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) {
			rigidbody2D.velocity = new Vector2(0, jumpHeight);
			jumpCount++;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.position.y <= collider2D.bounds.min.y) {
			jumpCount = 0;
		}
	}
}
