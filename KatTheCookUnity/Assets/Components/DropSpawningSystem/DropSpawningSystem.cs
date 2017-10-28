﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawningSystem : MonoBehaviour
{
	[SerializeField]
	Transform basePlane;

	[SerializeField]
	float distanceFromBase = 9.0f;

	float spawnVariantRange = 2.0f;

	[SerializeField]
	List<Drop> dropPrefabs;

	[SerializeField]
	float spawnTimeMin = 2.0f;

	[SerializeField]
	float spawnTimeMax = 4.0f;

	public int spawnCountPerIteration = 2;

	private void Awake ()
	{
		transform.position = basePlane.transform.position + Vector3.up * distanceFromBase;
	}

	private void Start ()
	{
		StartCoroutine (SpawnDrop ());
	}

	IEnumerator SpawnDrop ()
	{
		for (int i = 0; i < spawnCountPerIteration; i++) {

			var randomPrefab = dropPrefabs [Random.Range (0, dropPrefabs.Count)];

			var spawnPos = Random.Range (-spawnVariantRange, spawnVariantRange) * Vector3.up + transform.position;

			Instantiate (randomPrefab, spawnPos, Quaternion.identity, transform);
		}
		
		float waitTime = Random.Range (spawnTimeMin, spawnTimeMax);
		yield return new WaitForSeconds (waitTime);
		StartCoroutine (SpawnDrop ());
	}

}