using SmallHedge.SoundManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	SpriteRenderer sr;
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
	public float GlideTimer = 1.5f;
	public bool isGlide{ get;private set; }
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		MoveAction = InputSystem.actions.FindAction("Move");
		GlideAction = InputSystem.actions.FindAction("Glide");
	}

	// Update is called once per frame
	void Update()
	{
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.77f, 0.07f), CapsuleDirection2D.Horizontal, 0f, GroundLayer);
		if (IsGrounded)
		{
			GlideTimer = 1.5f;
		}
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
		SoundManager.PlaySound(SoundType.Fly,volume: 1);
		rb.gravityScale = gravityScale;
		rb.linearVelocityY = JumpForce;
	}
	private void JumpCurve()
	{
		// Không glide
		isGlide = false;
		if (rb.linearVelocityY >= 0.5f)
		{
			//nếu không có cái if này thì game bug, dont judge me :(
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
		// Glide
		if(GlideAction.IsPressed() && rb.linearVelocityY <= 0.5f)
		{
			GlideTimer -= Time.deltaTime;
			if(GlideTimer > 0)
			{
				isGlide = true;
				rb.gravityScale = 0.5f;
				rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -3.5f));
			}
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
			sr.flipX = true;
			IsFacingRight = !IsFacingRight;
		}
		else
		{
			sr.flipX = false;
			IsFacingRight = !IsFacingRight;
		}
	}
}
