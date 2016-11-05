using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TheRealPatient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {
        AzureConnector connector = new AzureConnector();
        public ContentPage()
        {
            this.InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PatientBasicInfo patientInfo = new PatientBasicInfo();
            patientInfo.firstName = "Lalith";
            patientInfo.lastName = "Chinta";
            patientInfo.SSN = SSNValue1.Text + SSNValue2.Text + SSNValue3.Text;
            patientInfo.weight = Decimal.Parse(WeightValue.Text);
            patientInfo.height = Decimal.Parse(HeightValue.Text);

            connector.store(patientInfo);
        }
    }
}
