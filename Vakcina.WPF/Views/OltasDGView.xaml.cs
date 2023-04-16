using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Vakcina.WPF.ViewModels;

namespace Vakcina.WPF.Views
{
    // TODO: 01. XAML fájl, 56. sortól: Oszlop hozzárendelések javítása
    // TODO: 02.b XAML fájl, 41. sortól: Keresőmező és gomb készítése
    // TODO: 03. XAML fájl, 56. sortól: Sorbarendezés társítása
    // TODO: 05. XAML fájl, 74. sortól: Gombok és parancsok elkészítése

    /// <summary>
    /// Interaction logic for OltasokDGView.xaml
    /// </summary>
    public partial class OltasokDGView : UserControl
    {
        private readonly OltasViewModel viewModel;

        public OltasokDGView()
        {
            InitializeComponent();
            viewModel = App.Current.Services.GetRequiredService<OltasViewModel>();
            DataContext = viewModel;
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            DataGridColumn column = e.Column;
            viewModel.SortBy = column.SortMemberPath;
            column.SortDirection = viewModel.ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        }
    }
}
