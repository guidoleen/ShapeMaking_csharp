using System;

namespace WEGGG_555.ShapeMaking
{
	public class RectangularShape : ShapeMaking.Shape
	{
		public override bool IsInside (Shape shape)
		{
			bool isInside = false;

			var highestLowestX = this.GetHighestLowestX ();
			var highestLowestY = this.GetHighestLowestY ();

			for (int i = 0; i < shape.Points.Length; i++) {
				if (shape.Points [i].X >= highestLowestX [0] &&
				    shape.Points [i].X <= highestLowestX [1] &&
				    shape.Points [i].Y >= highestLowestY [0] &&
				    shape.Points [i].Y <= highestLowestY [1])
					isInside = true;
				else 
				{
					isInside = false;
					break;
				}
			}
			return isInside;
		}

		public override bool HasOverlap (Shape shape)
		{
			return true;
		}

		// Get highest lowest number
		private double[] HighestLowestValue(double[] arrValues)
		{
			if (arrValues.Length <= 0)
				return null;
			
			double highest = arrValues[0];
			double lowest = arrValues[0];

			for (int i = 0; i < arrValues.Length; i++) {
				if (highest < arrValues [i])
					highest = arrValues [i];
				if (lowest > arrValues [i])
					lowest = arrValues [i];
			}

			return new double[]{ lowest, highest };
		}

		// Get HighestLowestX
		private double[] GetHighestLowestX()
		{
			var arrX = new double[this.Points.Length];
			for (int i = 0; i < this.Points.Length; i++) {
				arrX [i] = this.Points [i].X;
			}

			return this.HighestLowestValue(arrX);
		}

		// Get HighestLowestY
		private double[] GetHighestLowestY()
		{
			var arrY = new double[this.Points.Length];
			for (int i = 0; i < this.Points.Length; i++) {
				arrY [i] = this.Points [i].Y;
			}

			return this.HighestLowestValue(arrY);
		}
	}
}

