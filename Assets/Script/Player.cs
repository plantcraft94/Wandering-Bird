using UnityEngine;

public class Player : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
	PlayerMovement PM;
	const string ISMOVING = "IsMoving";
	const string ISGLIDING = "IsGliding";
	const string VELOCITyY = "VelocityY";
	const string ISAIRBORN = "IsAirborn";
	
	private void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		PM = GetComponent<PlayerMovement>();
	}
	private void Update()
	{
		Animation();
	}
	void Animation()
	{
		anim.SetBool(ISMOVING, PM.movement != 0);
		anim.SetBool(ISAIRBORN, !PM.IsGrounded);
		anim.SetBool(ISGLIDING, PM.isGlide);
		anim.SetFloat(VELOCITyY, rb.linearVelocityY);
	}
}
