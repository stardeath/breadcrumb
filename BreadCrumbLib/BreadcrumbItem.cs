using System;
using System.Windows;
using System.Windows.Controls;

namespace BreadcrumbLib
{
	public class BreadcrumbItem : HeaderedItemsControl
	{
		public static readonly DependencyProperty IsExpandedProperty =
			DependencyProperty.Register("IsExpanded", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(false));

		public static readonly DependencyProperty IsSelectedProperty =
			DependencyProperty.Register("IsSelected", typeof(bool), typeof(BreadcrumbItem), new UIPropertyMetadata(false));

		public static readonly DependencyProperty ImageProperty =
			DependencyProperty.Register("Image", typeof(object), typeof(BreadcrumbItem), new UIPropertyMetadata(null));

		public static readonly DependencyProperty ParentItemProperty =
			DependencyProperty.Register("ParentItem", typeof(object), typeof(BreadcrumbItem), new UIPropertyMetadata(null));

		public static readonly DependencyProperty IsFirstProperty = DependencyProperty.Register("IsFirst", typeof(bool),
			typeof(BreadcrumbButton), new UIPropertyMetadata(false));

		internal static readonly DependencyProperty ViewProperty =
			DependencyProperty.Register("View", typeof(BreadcrumbView), typeof(BreadcrumbItem), new UIPropertyMetadata(null));


        static BreadcrumbItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbItem), new FrameworkPropertyMetadata(typeof(BreadcrumbItem)));
        }

        public BreadcrumbItem()
            : this(null, null)
        { }

        internal BreadcrumbItem(object parent, BreadcrumbView view)
        {
            View = view;
            ParentItem = parent;
            IsFirst = ParentItem == null;
        }

		#region properties
		internal BreadcrumbView View
		{
			get => (BreadcrumbView)GetValue(ViewProperty);
            set => SetValue(ViewProperty, value);
        }

		public bool IsFirst
		{
			get => (bool)GetValue(IsFirstProperty);
            set => SetValue(IsFirstProperty, value);
        }

		public object ParentItem
		{
			get => GetValue(ParentItemProperty);
            set => SetValue(ParentItemProperty, value);
        }

		public object Image
		{
			get => GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

		public bool IsSelected
		{
			get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

		public bool IsExpanded
		{
			get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        #endregion properties


	}
}