using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawningSystem : MonoBehaviour
{
	[SerializeField]
	Transform basePlane;

	[SerializeField]
	List<Drop> dropPrefabs;

	[SerializeField]
	float spawnTimeMin = 2.0f;

	[SerializeField]
	float spawnTimeMax = 4.0f;

	public int spawnCountPerIteration = 2;

    [SerializeField]
	private Vector3 resolution = new Vector3(18.0f, 9.0f, 18.0f);

	private void Awake ()
	{
        //transform.position = basePlane.transform.position + basePlane.transform.up * distanceFromBase;
	}

	private void Start ()
	{
		StartCoroutine (SpawnDrop ());
	}

	IEnumerator SpawnDrop ()
	{
		for (int i = 0; i < spawnCountPerIteration; i++) {

			var randomPrefab = dropPrefabs [Random.Range (0, dropPrefabs.Count)];

			var spawnPos = basePlane.position +
                           Vector3.forward * Random.Range(-resolution.z, resolution.z) +
			               Vector3.right * Random.Range (-resolution.x, resolution.x) +
			               Vector3.up * Random.Range (0, resolution.y);

			Instantiate (randomPrefab, spawnPos, Quaternion.identity, transform);
		}
		
		float waitTime = Random.Range (spawnTimeMin, spawnTimeMax);
		yield return new WaitForSeconds (waitTime);
		StartCoroutine (SpawnDrop ());
	}

}
