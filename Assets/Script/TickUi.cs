using UnityEngine;
using UnityEngine.UI;

public class TickUi : MonoBehaviour
{
	TickManager TM;
	[SerializeField] Image TickIdicatorPrefab;
	private void Awake()
	{
		TM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<TickManager>();
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		for (int i = 0; i < TM.levelDataSO.MaxTick; i++)
		{
			Instantiate(TickIdicatorPrefab, transform);
		}
	}

	// Update is called once per frame
	void Update()
	{
		int total = transform.childCount;
		for (int i = 0; i < total; i++)
		{
			if (i < TM.currentTick)
			{
				transform.GetChild(i).gameObject.SetActive(true);
			}
			else
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
