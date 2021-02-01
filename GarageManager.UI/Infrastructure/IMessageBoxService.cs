using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.Infrastructure
{
    public interface IMessageBoxService
    {
        void ShowInformationMessageBox(string title, string content);
        bool ShowConfirmationMessageBox(string title, string content);
        void ShowErrorMessageBox(string title, string content);
    }
}
