using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchTerrain : MonoBehaviour
{

	float[,] heightmap;

	[SerializeField]
	int resolution = 100;

	public Vector3 worldSize = new Vector3 (100, 100, 100);

	Terrain terrain;

	TerrainData terrainData;

	private void Awake ()
	{
		terrain = GetComponent <Terrain> ();

		terrainData = terrain.terrainData;

		heightmap = new float[resolution, resolution];

		terrainData.heightmapResolution = resolution;

		terrainData.size = worldSize;

		for (int i = 0; i < resolution; i++) {
			for (int j = 0; j < resolution; j++) {
				heightmap [i, j] = CalculateHeight (i, j, resolution);
			}
		}

		terrainData.SetHeights (0, 0, heightmap);

		terrain.terrainData = terrainData;

	}

	private float CalculateHeight (int x, int y, int res)
	{
		float xCoord = ScaleRamp (x, res);

		float yCoord = ScaleRamp (y, res);

		float truncatedYCoord = 2f * yCoord - 1f;

		float truncatedXCoord = 2f * xCoord - 1f;

		return truncatedYCoord * truncatedYCoord + truncatedXCoord * truncatedXCoord;
	}

	private float ScaleRamp (int i, int res)
	{
		return (float)i / res;
	}
}
