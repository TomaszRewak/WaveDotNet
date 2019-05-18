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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaveDotNet.Designer.Views.Tree.Controls
{
    internal class NodePartControlBase : UserControl<NodePartControl>
	{ }

	internal partial class NodePartControl : NodePartControlBase
	{
		private static readonly DependencyProperty TextPropert = Register<string>(nameof(Text));
		public string Text
		{
			get => GetValue<string>(TextPropert);
			set => SetValue(TextPropert, value);
		}

        public NodePartControl()
        {
            InitializeComponent();
        }
    }
}
