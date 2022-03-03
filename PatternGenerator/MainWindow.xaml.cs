using System.IO;
using System.Windows;


namespace PatternGeneratorApp
{
    public partial class MainWindow : Window
    {
        private PatternGenerator _patternGenerator;

        public MainWindow()
        {
            InitializeComponent();

            var compositePath = Path.Combine("Templates", "CompositePattern.txt");
            var visitorPath = Path.Combine("Templates", "VisitorPattern.txt");
            _patternGenerator = new PatternGenerator(compositePath, visitorPath);
        }

        public void CompGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var componentName = ComponentNameBox.Text;
            var leafName = LeafNameBox.Text;
            var namespaceName = CompNamespaceNameBox.Text;
            var res = _patternGenerator.GenerateComposite(componentName, leafName, namespaceName);
            CompResBlock.Text = res;
        }

        public void VisitGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var iComponentName = IComponentNameBox.Text;
            var iVisitorName = IVisitorNameBox.Text;
            var visitorName = VisitorNameBox.Text;
            var namespaceName = VisitNamespaceNameBox.Text;
            var res = _patternGenerator.GenerateVisitor(iComponentName, iVisitorName, visitorName, namespaceName);
            VisitResBlock.Text = res;
        }
    }
}
