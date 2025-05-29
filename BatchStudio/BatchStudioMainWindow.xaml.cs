using BatchStudio.ViewModels;
using System.Windows;

namespace BatchStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BatchStudioMainWindow : Window
    {
        private BatchStudioViewModel m_BatchStudioVM = BatchStudioViewModel.Instance;

        public BatchStudioMainWindow()
        {
            InitializeComponent();
            DataContext = m_BatchStudioVM;
        }
    }
}
