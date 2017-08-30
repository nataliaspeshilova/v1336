﻿using System;
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
using System.Windows.Shapes;
using v1336.Model;
using v1336.Rep;
using v1336.ViewModel.CRUD;

namespace v1336.View
{
    public partial class EditEmployee : Window
    {
        public int Id { get; set; }
        private EmployeeRep rep { get; set; }

        public Employee SelectedEmployee { get; set; }
        private ItemsListVM ParentWindowVM { get; set; }
        
        public EditEmployee(ItemsListVM parent, int id)
        {
            Id = id;
            rep = new EmployeeRep();
           
            ParentWindowVM = parent;
            if (Id == 0)
            {
                Title = "Добавить сотрудника";
                SelectedEmployee = new Employee();
            }
            else
            {
                Title = "Редактировать сотрудника";
                SelectedEmployee = rep.GetById(id);
            }
            InitializeComponent();
            var items = new DepartmentRep().GetAll();
           
           
            DataContext = SelectedEmployee;
            this.UpdateLayout();
            cmb_Departments.ItemsSource = items;
            cmb_Departments.SelectedValue = SelectedEmployee.DepartmentId;
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Id == 0)
                {
                    rep.Add(SelectedEmployee);
                }
                else
                {
                    rep.Update(SelectedEmployee);
                }
                ParentWindowVM.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_Departments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int val = 0;
            if (cmb_Departments.SelectedValue != null)
                val = (int) cmb_Departments.SelectedValue;
            SelectedEmployee.DepartmentId = val;
        }
    }
}
