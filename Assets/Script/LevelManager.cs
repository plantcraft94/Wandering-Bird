using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public bool HasFruit = false;
	Animator TransitionAnimator;
	Coroutine coroutine;
	private void Awake()
	{
		TransitionAnimator = GameObject.Find("Transition").GetComponent<Animator>();
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		HasFruit = false;
		coroutine = null;
	}
	
	public void ReloadScene()
	{
		if(coroutine == null)
		{
			coroutine = StartCoroutine(CurrentLevel());
		}
	}
	
	public void LoadNextLevel()
	{
		if(coroutine == null)
		{
			coroutine = StartCoroutine(NextLevel());
		}
	}
	
	IEnumerator CurrentLevel()
	{
		yield return new WaitForSeconds(1f);
		TransitionAnimator.SetTrigger("Close");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		coroutine = null;
	}
	
	IEnumerator NextLevel()
	{
		TransitionAnimator.SetTrigger("Close");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		coroutine = null;
	}
	

}
