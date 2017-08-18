﻿using System.Windows;
using v1336.Model;

namespace v1336.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var db = new DBContext();
            var manager = new Manager { };
            //db.Managers.Add(manager);
            db.SaveChanges();
        }

        private void BtnManagersClick(object sender, RoutedEventArgs e)
        {
            Managers win = new Managers {Owner = this};
            win.Show();
        }

        private void BtnCustomersClick(object sender, RoutedEventArgs e)
        {
            Customers win = new Customers { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Customers(object sender, RoutedEventArgs e)
        {
            Customers win = new Customers { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Managers(object sender, RoutedEventArgs e)
        {
            Managers win = new Managers { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Departments(object sender, RoutedEventArgs e)
        {
            Departments win = new Departments { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Nomenclatures(object sender, RoutedEventArgs e)
        {
            Nomenclatures win = new Nomenclatures { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Employees(object sender, RoutedEventArgs e)
        {
            Employees win = new Employees { Owner = this };
            win.Show();
        }
    }
}