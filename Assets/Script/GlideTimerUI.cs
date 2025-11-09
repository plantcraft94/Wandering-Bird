using UnityEngine;
using UnityEngine.UI;

public class GlideTimerUI : MonoBehaviour
{
	[SerializeField] GameObject GlideTimerIndicator;
	[SerializeField] GameObject GlideTimerMainUI;
	Image image;
	PlayerMovement PM;
	Player player;

	private void Awake()
	{
		image = GlideTimerIndicator.GetComponent<Image>();
		PM = GetComponent<PlayerMovement>();
		player = GetComponent<Player>();
	}
	private void Start()
	{
		GlideTimerMainUI.SetActive(false);
	}
	private void Update()
	{
		if(PM.IsGrounded||player.isDead)
		{
			GlideTimerMainUI.SetActive(false);
		}
		else if(PM.isGlide)
		{
			GlideTimerMainUI.SetActive(true);
		}
		image.fillAmount = PM.GlideTimer / 1.5f;
	}
}
