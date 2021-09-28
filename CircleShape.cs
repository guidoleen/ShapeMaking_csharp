using System;

namespace WEGGG_555.ShapeMaking
{
	public class CircleShape : Shape
	{
		public double Diameter {
			get;
			set;
		}
		public override bool IsInside (Shape shape)
		{
			var xCircle = Points[0].X;
			var yCircle = Points[0].Y;

			for (int i = 0; i < shape.Points.Length; i++) {
				var x = xCircle - shape.Points [i].X;
				var y = yCircle - shape.Points [i].Y;

				x = (x < 0) ? x * -1 : x;
				y = (y < 0) ? y * -1 : y;

				if (Math.Sqrt (Math.Pow (x, 2) + Math.Pow (y, 2)) > this.Diameter)
					return false;
			}
			return true;
		}

		public override bool HasOverlap (Shape shape)
		{
			return true;
		}
	}
}

