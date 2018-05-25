namespace Windows.UI.Xaml.Media
{
	public partial class QuadraticBezierSegment : PathSegment
	{
		public QuadraticBezierSegment()
		{
		}

		#region Point1

		public Foundation.Point Point1
		{
			get => (Foundation.Point)this.GetValue(Point1Property);
			set => this.SetValue(Point1Property, value);
		}

		public static DependencyProperty Point1Property { get; } =
			DependencyProperty.Register(
				"Point1", 
				typeof(Foundation.Point),
				typeof(QuadraticBezierSegment),
				new FrameworkPropertyMetadata(
					defaultValue: new Foundation.Point(), 
					options: FrameworkPropertyMetadataOptions.AffectsMeasure
				)
			);

		#endregion

		#region Point2

		public Foundation.Point Point2
		{
			get => (Foundation.Point)this.GetValue(Point2Property);
			set => this.SetValue(Point2Property, value);
		}

		public static DependencyProperty Point2Property { get; } =
			DependencyProperty.Register(
				"Point2", 
				typeof(Foundation.Point),
				typeof(QuadraticBezierSegment),
				new FrameworkPropertyMetadata(
					defaultValue: new Foundation.Point(),
					options: FrameworkPropertyMetadataOptions.AffectsMeasure
				)
			);

		#endregion
	}
}
