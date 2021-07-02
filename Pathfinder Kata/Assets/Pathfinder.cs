using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Pathfinder : MonoBehaviour
{
	private void Update()
	{
		var path = GetPath(Map);
		if (Time.time < path!.Count)
			gameObject.transform.position = path[(int)Time.time];
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

	public List<Vector2> GetPath(string map)
	{
		Find();
		return path;
	}

	public bool Find()
	{
		SetEnvironment();
		return CanReach();
	}

	private void SetEnvironment()
	{
		grid = Map.Split('\n');
		boundaries = grid.Length;
		unCheckedAreas = new bool[boundaries, boundaries];
		path!.Clear();
		path.Add(transform.position);
	}

	private string[] grid = null!;
	private bool[,] unCheckedAreas = null!;
	private int boundaries;
	private readonly List<Vector2> path = new List<Vector2>();

	private bool CanReach()
	{
		var nextMoveIndex = 0;
		while (true)
		{
			var row = path[nextMoveIndex].x;
			var col = path[nextMoveIndex++].y;
			GetNext((int)row, (int)col);
			if (row == boundaries - 1 && col == boundaries - 1)
				return true;
			if (nextMoveIndex >= path.Count)
				return false;
		}
	}

	private void GetNext(int row, int col)
	{
		foreach (var direction in Directions)
		{
			var nextRow = row + direction[0];
			var nextCol = col + direction[1];
			if (nextRow < 0 || nextCol < 0 || nextRow >= boundaries || nextCol >= boundaries)
				continue;
			if (grid[nextRow][nextCol] != '.' || unCheckedAreas[nextRow, nextCol])
				continue;
			unCheckedAreas[nextRow, nextCol] = true;
			path.Add(new Vector2(nextRow, nextCol));
		}
	}

	private static readonly int[][] Directions =
	{
		new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 }
	};
}