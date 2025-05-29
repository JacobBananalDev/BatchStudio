using BatchStudio.Infrastructures;

namespace BatchStudio.ViewModels
{
    public class BatchStudioViewModel : ViewModelBase
    {
        private static BatchStudioViewModel m_instance;
        internal static BatchStudioViewModel Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new BatchStudioViewModel();
                }
                return m_instance;
            }
        }

        private BatchStudioViewModel()
        {
            // Initialize properties or commands here if needed
        }
    }
}
