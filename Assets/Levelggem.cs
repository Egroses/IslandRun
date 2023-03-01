using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Levelggem: MonoBehaviour
{
	private float distancex=100f;
	[SerializeField]private List<Transform> Levels;
	public GameObject player;
	private Vector3 lastEnd;

	private void Awake() {
		lastEnd=Levels[2].Find("EndPosition").position;
	}

	public void Update() {
		if(Vector3.Distance(player.transform.position, lastEnd)<distancex){
			SpawnLevel();
		}
	}

	public void SpawnLevel(){
		Transform random=Levels[Random.Range(0,Levels.Count)];
		Transform leveltrans= SpawnLevel(random,lastEnd);
		lastEnd=leveltrans.Find("EndPosition").position;
	}
	Transform SpawnLevel(Transform transform,Vector3 spawnposition){
		Transform leveltrans= Instantiate(transform,spawnposition,Quaternion.identity);
		return leveltrans;
	}
}
