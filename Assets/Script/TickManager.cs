using UnityEngine;
using UnityEngine.Events;

public class TickManager : MonoBehaviour
{
	public LevelData levelDataSO;
	public int currentTick { get; private set; }
	public float CurrentTime { get; private set; }
	[SerializeField] UnityEvent OnFinishTick;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Awake()
	{
		currentTick = levelDataSO.MaxTick;
		CurrentTime = levelDataSO.TimePerTick;
	}

	// Update is called once per frame
	void Update()
	{
		Timer();
	}
	void Timer()
	{
		CurrentTime -= Time.deltaTime;
		if(CurrentTime <= 0)
		{
			currentTick--;
			CurrentTime = levelDataSO.TimePerTick;
		}
		if(currentTick <= 0)
		{
			OnFinishTick.Invoke();
			currentTick = levelDataSO.MaxTick;
		}
	}
	public void test()
	{
		Debug.Log("Test");
	}
}
