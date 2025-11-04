using UnityEngine;

public class Nest : MonoBehaviour
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
			if(LM.HasFruit)
            {
                Debug.Log("Win Level");
            }
        }
	}
}
