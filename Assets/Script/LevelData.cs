using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
	[field: SerializeField] public int MaxTick { get; private set; }
	[field: SerializeField] public float TimePerTick { get; private set; }
}
