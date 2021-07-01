using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Pathfinder : MonoBehaviour
{
	void Update()
	{
		var path = GetPath(Map);
		if (Time.time < path!.Count)
			transform.position = path[(int)Time.time];
	}

	public const string Map = @"
.......W..
.......WS.
.......W..
..T....W..
.......W..
.......W..
.......W..
..........
..........
..........";
	public List<Vector2> GetPath(string map) => new List<Vector2>();
}
