﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_PickerBorderOutlined.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StandardPickerOutlined : ContentView
    {

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(String), typeof(StandardPickerOutlined), String.Empty);

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(String), typeof(StandardPickerOutlined), String.Empty);

        public static BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(StandardPickerOutlined), Color.Gray);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(StandardPickerOutlined), Color.Gray);

        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(StandardPickerOutlined), 0);

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(StandardPickerOutlined), 0);

        public static BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(String), typeof(StandardPickerOutlined), "FontFamily");

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(Double), typeof(StandardPickerOutlined), 20.0);

        public static BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(StandardPickerOutlined), Color.Black);

        public static BindableProperty BackgroundColorEntryProperty =
            BindableProperty.Create(nameof(BackgroundColorEntry), typeof(Color), typeof(StandardPickerOutlined), Color.Transparent);

        public static BindableProperty PlaceholderBackgroundColorProperty =
            BindableProperty.Create(nameof(PlaceholderBackgroundColor), typeof(Color), typeof(StandardPickerOutlined), Color.Transparent);

        public static BindableProperty NextViewProperty =
            BindableProperty.Create(nameof(NextView), typeof(View), typeof(Entry));

        public static BindableProperty StandardEntryProperty =
            BindableProperty.Create(nameof(Entry), typeof(View), typeof(StandardEntry));

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(StandardEntry));

        public View NextView
        {
            get => (View)GetValue(NextViewProperty);
            set => SetValue(NextViewProperty, value);
        }

        public Color PlaceholderBackgroundColor
        {
            get { return (Color)GetValue(PlaceholderBackgroundColorProperty); }
            set { SetValue(PlaceholderBackgroundColorProperty, value); }
        }

        public Color BackgroundColorEntry
        {
            get { return (Color)GetValue(BackgroundColorEntryProperty); }
            set { SetValue(BackgroundColorEntryProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Double FontSize
        {
            get { return (Double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public String FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public StandardPickerOutlined()
        {
            InitializeComponent();
        }
        public event EventHandler<EventArgs> TextChangedd;

        private void PickerBorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextChangedd?.Invoke(this, e);
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            this.Text = (selectedIndex != -1) ? (String)picker.ItemsSource[selectedIndex] : String.Empty;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PickerBorder.Focus();
        }

        private async void PickerBorder_Focused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToTitle();
        }

        private async void PickerBorder_Unfocused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToPlaceHolder();
        }

        private async Task TranslateLabelToTitle()
        {
            var placeHolder = this.PlaceHolderLabel;
            var distance = GetPlaceholderDistance(placeHolder);

            distance = (distance == -1) ? -19 : distance;

            await placeHolder.TranslateTo(0, -19);
        }

        private async Task TranslateLabelToPlaceHolder()
        {
            if (String.IsNullOrEmpty(this.Text))
            {
                await this.PlaceHolderLabel.TranslateTo(0, 0);
            }
        }

        private Double GetPlaceholderDistance(Label control)
        {
            var distance = 0d;

            distance = control.Height + distance;
            return distance;
        }
    }
}