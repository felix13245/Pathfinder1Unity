using NUnit.Framework;

namespace PathfinderKata.Tests
{
	public class PathfinderTests
	{
		[Test]
		public void sampleTests()
		{
			var field = @"
.......W.W
.......W.W
.......W.W
.......W.W
.......W.W
.......W.W
.......W.W
..........
..........
..........";
				
			Assert.That(new UnitScript().PathFinder(field),Has.Count.EqualTo(19));
		}
	}
}