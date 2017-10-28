using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchTerrain : MonoBehaviour
{

	float[,] heightmap;

	[SerializeField]
	int resolution = 129;

	Terrain terrain;

	TerrainCollider terrainCollider;

	TerrainData terrainData;

	private void Awake ()
	{
		terrain = GetComponent <Terrain> ();
		terrainCollider = GetComponent <TerrainCollider> ();

		heightmap = new float[resolution, resolution];
		terrainData = new TerrainData ();

		for (int i = 0; i < resolution; i++) {
			for (int j = 0; j < resolution; j++) {
				heightmap [i, j] = i;
			}
		}

		terrainData.SetHeights (0, 0, heightmap);

		terrain.terrainData = terrainData;

		terrainCollider.terrainData = terrainData;
	}
}
