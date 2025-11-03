using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	[SerializeField] float Speed;
	public float Movement{ get; private set; }
	[SerializeField] float JumpForce;
	[Header("Gravity")]
	float gravityScale = 1f;
	float FallMultiplyer = 2f;
	public bool IsGrounded{ get; private set; }
	[SerializeField] Transform GroundCheck;
	[SerializeField] LayerMask GroundLayer;
	public bool IsFacingRight = true;

	InputAction MoveAction;
	InputAction GlideAction;
	public bool isGlide{ get;private set; }
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		MoveAction = InputSystem.actions.FindAction("Move");
		GlideAction = InputSystem.actions.FindAction("Glide");
	}

	// Update is called once per frame
	void Update()
	{
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.77f, 0.07f), CapsuleDirection2D.Horizontal, 0f, GroundLayer);
		Input();
		TurnCheck();
		rb.linearVelocityX = Movement * Speed;
		JumpCurve();


	}
	void Input()
	{
		Movement = MoveAction.ReadValue<float>();
		
	}
	public void Jump()
	{
		rb.gravityScale = gravityScale;
		rb.linearVelocityY = JumpForce;
	}
	private void JumpCurve()
	{
		isGlide = false;
		if (rb.linearVelocityY >= 0.5f)
		{
		}
		else if (rb.linearVelocityY <= 0.5f)
		{
			rb.gravityScale = gravityScale * FallMultiplyer;
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -20f));
		}
		else
		{
			rb.gravityScale = gravityScale;
		}
		if(GlideAction.IsPressed() && rb.linearVelocityY <= 0.5f)
		{
			isGlide = true;
			rb.gravityScale = 0.5f;
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -3.5f));
		}
	}
	void TurnCheck()
	{
		if (Movement > 0 && !IsFacingRight)
		{
			Flip();
		}
		else if (Movement < 0 && IsFacingRight)
		{
			Flip();
		}
	}
	void Flip()
	{
		if (IsFacingRight)
		{
			Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
			transform.rotation = Quaternion.Euler(rotator);
			IsFacingRight = !IsFacingRight;
		}
		else
		{
			Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
			transform.rotation = Quaternion.Euler(rotator);
			IsFacingRight = !IsFacingRight;
		}
	}
}
