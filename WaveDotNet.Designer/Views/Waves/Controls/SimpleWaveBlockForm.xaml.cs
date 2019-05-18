using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaveDotNet.Designer.Views.Waves.Controls
{
	internal class SimpleWaveBlockFormBase : UserControl<SimpleWaveBlockForm>
	{ }

	[ContentProperty(nameof(Input))]
	internal class SimpleWaveBlockFormField : DependencyObject<SimpleWaveBlockFormField>
	{
		private static readonly DependencyProperty NameProperty = Register<string>(nameof(Name));
		public string Name
		{
			get => GetValue<string>(NameProperty);
			set => SetValue(NameProperty, value);
		}

		private static readonly DependencyProperty DescriptionProperty = Register<string>(nameof(Description));
		public string Description
		{
			get => GetValue<string>(DescriptionProperty);
			set => SetValue(DescriptionProperty, value);
		}

		private static readonly DependencyProperty InputProperty = Register<UIElement>(nameof(Input));
		public UIElement Input
		{
			get => GetValue<UIElement>(InputProperty);
			set => SetValue(InputProperty, value);
		}
	}

	[ContentProperty(nameof(Fields))]
	internal partial class SimpleWaveBlockForm : SimpleWaveBlockFormBase
	{
		public SimpleWaveBlockForm()
		{
			InitializeComponent();

			Fields = new List<SimpleWaveBlockFormField>();
		}

		private static readonly DependencyProperty FieldsProperty = Register<List<SimpleWaveBlockFormField>>(nameof(Fields));
		public List<SimpleWaveBlockFormField> Fields
		{
			get => GetValue<List<SimpleWaveBlockFormField>>(FieldsProperty);
			set => SetValue(FieldsProperty, value);
		}
	}
}
