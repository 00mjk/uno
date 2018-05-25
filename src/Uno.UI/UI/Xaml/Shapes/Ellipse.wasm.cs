﻿using Windows.Foundation;
using Windows.UI.Xaml.Wasm;
using Uno.Extensions;

namespace Windows.UI.Xaml.Shapes
{
	partial class Ellipse
	{
		private readonly SvgElement _ellipse = new SvgElement("ellipse");

		public Ellipse()
		{
			SvgChildren.Add(_ellipse);

			InitCommonShapeProperties();
		}

		protected override SvgElement GetMainSvgElement()
		{
			return _ellipse;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			var cx = finalSize.Width / 2;
			var cy = finalSize.Height / 2;

			_ellipse.SetAttribute(
				("cx", cx.ToStringInvariant()),
				("cy", cy.ToStringInvariant()),
				("rx", (cx - ActualStrokeThickness).ToStringInvariant()),
				("ry", (cy - ActualStrokeThickness).ToStringInvariant()));

			return base.ArrangeOverride(finalSize);
		}
	}
}