using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
	PlayerMovement PM;
	const string ISMOVING = "IsMoving";
	const string ISGLIDING = "IsGliding";
	const string VELOCITyY = "VelocityY";
	const string ISAIRBORN = "IsAirborn";
	[SerializeField] UnityEvent OnDeath;
	[SerializeField] VisualEffect vfx;
	SpriteRenderer sr;
	
	private void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		PM = GetComponent<PlayerMovement>();
		sr = GetComponent<SpriteRenderer>();
	}
	private void Update()
	{
		Animation();
	}
	void Animation()
	{
		anim.SetBool(ISMOVING, PM.Movement != 0);
		anim.SetBool(ISAIRBORN, !PM.IsGrounded);
		anim.SetBool(ISGLIDING, PM.isGlide);
		anim.SetFloat(VELOCITyY, rb.linearVelocityY);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Spike"))
		{
			OnDeath.Invoke();
		}
	}
	public void Death()
	{
		rb.bodyType = RigidbodyType2D.Static;
		sr.color = new Color(1.000f, 1.000f, 1.000f, 0.000f);
		vfx.Play();
	}
}
