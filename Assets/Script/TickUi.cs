using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickUi : MonoBehaviour
{
	TickManager TM;
	[SerializeField] GameObject TickIdicatorPrefab;
	List<GameObject> Indicators = new List<GameObject>();
	private void Awake()
	{
		TM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<TickManager>();
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// startui
		for (int i = 0; i < TM.levelDataSO.MaxTick; i++)
		{
			Indicators.Add(Instantiate(TickIdicatorPrefab, transform));
		}
	}

	// Update is called once per frame
	void Update()
	{
		// updateui
		for (int i = 0; i < Indicators.Count; i++)
		{
			if (i < TM.currentTick)
			{
				Indicators[i].SetActive(true);
			}
			else
			{
				Indicators[i].gameObject.SetActive(false);
			}
		}
	}
}
