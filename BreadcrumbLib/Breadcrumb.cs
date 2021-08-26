using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace BreadcrumbLib
{
	[TemplatePart(Type = typeof(ItemsControl), Name = PartNameView)]
	public class Breadcrumb : ItemsControl
	{
		protected const string PartNameView = "PART_View";

		protected static readonly DependencyPropertyKey SelectedItemPropertyKey = DependencyProperty.RegisterReadOnly(
			"SelectedItem", typeof(object), typeof(Breadcrumb), new FrameworkPropertyMetadata(null,
				FrameworkPropertyMetadataOptions.AffectsRender));
		public static readonly DependencyProperty SelectedItemProperty = SelectedItemPropertyKey.DependencyProperty;

		public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons",
			typeof(ObservableCollection<ButtonBase>), typeof(Breadcrumb), new UIPropertyMetadata(null));

		private ItemsControl view;

		static Breadcrumb()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Breadcrumb), new FrameworkPropertyMetadata(typeof(Breadcrumb)));
		}

		public object SelectedItem
		{
			get { return GetValue(SelectedItemProperty); }
			private set { SetValue(SelectedItemPropertyKey, value); }
		}

		public ObservableCollection<ButtonBase> Buttons
		{
			get { return (ObservableCollection<ButtonBase>)GetValue(ButtonsProperty); }
			set { SetValue(ButtonsProperty, value); }
		}

		public Breadcrumb()
		{
			Buttons = new ObservableCollection<ButtonBase>();
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			view = GetTemplateChild(PartNameView) as ItemsControl;

			if (!Items.IsEmpty)
				GoTo(Items[0]);
		}

		///<summary>
		///Invoked when the <see cref="P:System.Windows.Controls.ItemsControl.Items" /> property changes.
		///</summary>
		///
		///<returns>
		///
		///</returns>
		///
		///<param name="e">Information about the change.</param>
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			if(view != null && view.Items.IsEmpty && !Items.IsEmpty)
				GoTo(Items[0]);
			base.OnItemsChanged(e);
		}

		internal void AddTrail(object parent, object item)
		{
			if (parent == item)
				return;

			int index = 0;

			ItemCollection items = view.Items;
			if (parent != null)
				index = GetIndex(parent, items);

			for (int i = items.Count - 1; i >= index + 1; i--)
				RemoveItem(items, i);

			AddAndSelect(item, items);
		}

		internal void GoTo(object target)
		{
			ItemCollection items = view.Items;
			int index = GetIndex(target, items);

			for (int i = items.Count - 1; i >= index; i--)
				RemoveItem(items, i);

			AddAndSelect(target, items);
		}

		private void AddAndSelect(object item, IList items)
		{
			if(Items.Contains(item))
				Items.Remove(item);
			items.Add(item);
			SelectedItem = item;

			BreadcrumbItem container = view.ItemContainerGenerator.ContainerFromItem(item) as BreadcrumbItem;
			if (container != null)
				container.IsSelected = true;
		}

		private static int GetIndex(object item, IList items)
		{
			int index = 0;
			for (int i = items.Count - 1; i >= 0; i--)
			{
				if (items[i].Equals(item))
				{
					index = i;
					break;
				}
			}
			return index;
		}

		private void RemoveItem(IList items, int i)
		{
			BreadcrumbItem container = view.ItemContainerGenerator.ContainerFromIndex(i) as BreadcrumbItem;
			if (container != null)
				container.IsSelected = false;
			items.RemoveAt(i);
		}
	}
}