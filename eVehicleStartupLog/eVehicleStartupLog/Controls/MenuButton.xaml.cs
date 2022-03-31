using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace eVehicleStartupLog.Controls
{
    public partial class MenuButton : ContentView
    {
        public MenuButton()
        {
            InitializeComponent();
        }

		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
								propertyName: nameof(ImageSource),
								returnType: typeof(string),
								declaringType: typeof(View),
								defaultValue: default(string),
								defaultBindingMode: BindingMode.TwoWay,
								validateValue: null,
								propertyChanged: null);

		public string ImageSource
		{
			get { return (string)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}

		public static readonly BindableProperty TextProperty = BindableProperty.Create(
								propertyName: nameof(Text),
								returnType: typeof(string),
								declaringType: typeof(View),
								defaultValue: default(string),
								defaultBindingMode: BindingMode.TwoWay,
								validateValue: null,
								propertyChanged: null);

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly BindableProperty CommandProperty = BindableProperty.Create(
								propertyName: nameof(Command),
								returnType: typeof(ICommand),
								declaringType: typeof(View),
								defaultValue: default(Command),
								defaultBindingMode: BindingMode.TwoWay,
								validateValue: null,
								propertyChanged: null);

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
	}
}
