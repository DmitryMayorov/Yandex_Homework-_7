using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
	[SerializeField] private ChangingPlayerAnimation _changingPlayerAnimation;

	public AudioSource _jump;

	public KeyCode leftButton = KeyCode.A;

	public KeyCode rightButton = KeyCode.D;

	public KeyCode addForceButton = KeyCode.Space;

	public bool isFacingRight = true;

	public float addForce = 10;

	private Rigidbody2D body;

	private bool jump;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKey(leftButton) && isFacingRight)
		{
			Flip();
		}
		else if (Input.GetKey(rightButton) && !isFacingRight)
		{
			Flip();
		}

		if (Input.GetKey(addForceButton) && jump)
		{
			body.velocity = new Vector2(0, addForce);

			_changingPlayerAnimation.ChangPlayerAnimation(2);

			_jump.Play();

			_changingPlayerAnimation.Invoke("FinishAnimationJump", 1f);
		}
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 10;

			jump = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "Ground")
		{
			body.drag = 0;

			jump = false;
		}
	}
}
