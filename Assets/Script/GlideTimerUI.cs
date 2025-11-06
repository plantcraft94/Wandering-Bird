using UnityEngine;
using UnityEngine.UI;

public class GlideTimerUI : MonoBehaviour
{
	[SerializeField] GameObject GlideTimerIndicator;
	[SerializeField] GameObject GlideTimerMainUI;
	Image image;
	PlayerMovement PM;

	private void Awake()
	{
		image = GlideTimerIndicator.GetComponent<Image>();
		PM = GetComponent<PlayerMovement>();
	}
    private void Start()
    {
        GlideTimerMainUI.SetActive(false);
    }
    private void Update()
	{
		if(PM.IsGrounded)
		{
			GlideTimerMainUI.SetActive(false);
		}
		else if(PM.isGlide)
		{
			GlideTimerMainUI.SetActive(true);
		}
		image.fillAmount = PM.GlideTimer / 2f;
	}
}
