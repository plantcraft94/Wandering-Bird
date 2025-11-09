using SmallHedge.SoundManager;
using UnityEngine;

public class PileOfFruit : MonoBehaviour
{
	LevelManager LM;
	private void Awake()
	{
		LM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			SoundManager.PlaySound(SoundType.GrabFood, volume: 1f);
			LM.HasFruit = true;
		}
	}
}
