﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GarageManager.UI.Views
{
    /// <summary>
    /// Interaction logic for EditServiceView.xaml
    /// </summary>
    public partial class EditServiceView : UserControl
    {
        public EditServiceView()
        {
            InitializeComponent();
        }

        private void CostPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9.,]+$");
        }
    }
}
