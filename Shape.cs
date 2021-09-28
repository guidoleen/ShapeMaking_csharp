using System;

namespace WEGGG_555.ShapeMaking
{
	public abstract class Shape
	{
		public abstract bool IsInside (Shape shape);

		public abstract bool HasOverlap (Shape shape);

		public Point[] Points;

		public override String ToString()
		{
			var shapeName = this.GetType ().Name;
			return $"{shapeName}";
		}
	}
}

