using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace My
{
    sealed partial class MainPage : Page
    {
        ProtocolForResultsOperation _operation = null;

        public MainPage() => InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var protocolForResultsArgs = e.Parameter as ProtocolForResultsActivatedEventArgs;

            _operation = protocolForResultsArgs.ProtocolForResultsOperation;

            RequestBox.Text = protocolForResultsArgs.Data.GetRequestMessage();
        }

        void Reply()
        {
            _operation.ReportCompleted(new ValueSet()
                .SetResponseMessage(ResponseBox.Text)
                );
        }
    }
}
