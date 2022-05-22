using Microsoft.EntityFrameworkCore;
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
using RealEstateGUI.Models;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        ingatlan_probaContext context = new ingatlan_probaContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Sellers.Load();
            context.Categories.Load();
            context.Realestates.Load();
            lst_Eladok.ItemsSource = (from e in context.Sellers select e).ToList();
        }

        private void btn_Betolt_Click(object sender, RoutedEventArgs e)
        {
            List<Realestates> r = (from s in context.Realestates where s.Seller == ((Sellers)lst_Eladok.SelectedItem) select s).ToList();
            lbl_Count.Content = r.Count;
        }

        private void lst_Eladok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stck_Adatok.DataContext = lst_Eladok.SelectedItem;
        }
    }
}
