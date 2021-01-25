using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GarageManager.UI.Infrastructure
{
    public class MessageBoxService : IMessageBoxService
    {
        public bool ShowConfirmationMessageBox(string title, string content)
        {
            MessageBoxResult result = MessageBox.Show(content, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes ? true : false;
        }

        public void ShowErrorMessageBox(string title, string content)
        {
            MessageBox.Show(content, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInformationMessageBox(string title, string content)
        {
            MessageBox.Show(content, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
