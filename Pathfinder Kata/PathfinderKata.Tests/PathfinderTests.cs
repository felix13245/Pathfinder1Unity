using NUnit.Framework;
using UnityEngine;

namespace PathfinderKata.Tests
{
	public sealed class PathfinderTests
	{
		[Test]
		public void CheckStartTargetAndPathLength()
		{
			// ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
			var path = new Pathfinder().GetPath(Pathfinder.Map);
			Assert.That(path![0], Is.EqualTo(new Vector2(9, 8)));
			Assert.That(path[^1], Is.EqualTo(new Vector2(3, 6)));
			Assert.That(path, Has.Count!.EqualTo(19));
		}
	}
}