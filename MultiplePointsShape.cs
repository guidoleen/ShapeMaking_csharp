using System;

namespace WEGGG_555.ShapeMaking
{
	public class MultiplePointsShape : ShapeMaking.Shape
	{
		private Point[] _highestLowestPoints => this.HighestLowestPoints ();

		public override bool IsInside (Shape shape)
		{
			if (_highestLowestPoints == null)
				return false;
			
			for (int i = 0; i < shape.Points.Length; i++) 
			{
				var shapePoint = shape.Points [i];

				// Is Inside square shape
				if (shapePoint.X >= _highestLowestPoints [0].X &&
				    shapePoint.Y >= _highestLowestPoints [0].Y &&
				    shapePoint.X <= _highestLowestPoints [1].X &&
				    shapePoint.Y <= _highestLowestPoints [1].Y) {

					// Within square shape but within points?
					if (this.IsInsideMultiplePointsShape (shapePoint)) {
						continue;
					} else {
						return false;
					}

				} else
					return false;
			}

			return true;
		}

		public override bool HasOverlap (Shape shape)
		{
			return false;
		}

		// Is Inside shape
		private bool IsInsideMultiplePointsShape(Point shapePoint)
		{
			for (int i = 1; i < Points.Length; i++) 
			{
				var pointA = Points [i-1];
				var pointB = Points [i];

				// x is Inbetween?
				if(!this.IsInbetween(pointA.X, pointB.X, shapePoint.X)) 
					continue;

				var maximumY = this.CalculateMaximumY(pointA, pointB, shapePoint);

				// Go Right => shapePoint Y must be smaller than maximumY
				if (pointA.X < pointB.X) {
					return shapePoint.Y <= maximumY;
				}

				// Go Left => shapePoint Y must be larger than maximumY
				if (pointA.X > pointB.X) {
					return shapePoint.Y >= maximumY;
				}
			}
			return false;
		}

		// Is x inbetween?
		private bool IsInbetween(double pointAX, double pointBX, double shapePointX)
		{
			double aX = pointAX, bX = pointBX;

			if (pointAX > pointBX) {
				aX = pointBX;
				bX = pointAX;
			}

			return shapePointX >= aX && shapePointX <= bX;
		}

		// Calculate maximum of Y based on the A, B and shapePoint
		private double CalculateMaximumY(Point pointA, Point pointB, Point shapePoint)
		{
			var xDifference = pointB.X - pointA.X;
			var yDifference = pointB.Y - pointA.Y;

			// Determin the difference xy => y / x
			var relatedYX = yDifference/xDifference;

			// Determine maximum Y based on relation between XY difference
			var maximumY = ((shapePoint.X - pointA.X) * relatedYX);

			// Get always positive number
			maximumY = (maximumY < 0) ? maximumY * -1 : maximumY;

			// Add minimum Y from A and B with maximum calculated Y
			maximumY = this.MinimumValueTwoPoints(pointA.Y, pointB.Y) + maximumY;

			return maximumY;
		}

		// Get minimum value two points eg. between x1 and x2
		private double MinimumValueTwoPoints(double pointA, double pointB)
		{
			return (pointA >= pointB) ? pointB : pointA;
		}

		// GetHighest and lowest values from multiple point shape // Array 0 == lowest, Array 1 == highest
		private Point[] HighestLowestPoints()
		{
			if (Points.Length < 2)
				return null;
			
			var lowestX = Points [0].X;
			var lowestY = Points [0].Y;
			var highestX = Points [0].X;
			var highestY = Points [0].Y;

			for (int i = 1; i < Points.Length; i++) {
				if (Points [i].X < lowestX) {
					lowestX = Points [i].X;
				}
				if (Points [i].X > highestX) {
					highestX = Points [i].X;
				}
				if (Points [i].Y < lowestY) {
					lowestY = Points [i].Y;
				}
				if (Points [i].Y > highestY) {
					highestY = Points [i].Y;
				}
			}

			return new Point[] {
				new Point (lowestX, lowestY),
				new Point (highestX, highestY)
			};
		}
	}
}

