using System;

namespace WEGGG_555.ShapeMaking
{
	public class ShapeMakingTest
	{
		public ShapeMakingTest ()
		{
			Console.WriteLine (this.RectangularInCircleTest());
			Console.WriteLine (this.RectangularInRectangularTest());
		}

		private string RectangularInCircleTest()
		{
			// Initialize Circle
			var circle01 = new ShapeMaking.CircleShape () {
				Diameter = 5,
				Points = new ShapeMaking.Point[]
				{
					new WEGGG_555.ShapeMaking.Point(0, 0)
				},
			};

			// Initialize RectangularShape
			var rectangular = new RectangularShape () {
				Points = new ShapeMaking.Point[] {
					new WEGGG_555.ShapeMaking.Point (x: 0, y: 0),
					new WEGGG_555.ShapeMaking.Point (x: 6, y: 0),
					new WEGGG_555.ShapeMaking.Point (x: 6, y: 2),
					new WEGGG_555.ShapeMaking.Point (x: 0, y: 2)
				},
			};

			return $"{circle01.ToString()} - {circle01.IsInside (rectangular)}";
		}

		private string RectangularInRectangularTest()
		{

			// Initialize RectangularPoint
			var rectangularPoint = new RectangularShape () {
				Points = new ShapeMaking.Point[] {
					new WEGGG_555.ShapeMaking.Point (x: 4, y: 2)
				}
			};

			// Initialize RectangularShape
			var rectangular = new RectangularShape () {
				Points = new ShapeMaking.Point[] {
					new WEGGG_555.ShapeMaking.Point (x: 3, y: 3),
					new WEGGG_555.ShapeMaking.Point (x: 5, y: 3),
					new WEGGG_555.ShapeMaking.Point (x: 5, y: 1),
					new WEGGG_555.ShapeMaking.Point (x: 3, y: 1)
				},
			};

			return $"{rectangular.ToString()} - {rectangular.IsInside (rectangularPoint)}";
		}
	}
}

