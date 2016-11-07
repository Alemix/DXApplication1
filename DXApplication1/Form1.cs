using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace DXApplication1
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            InitTreeListControl();
            InitGrid();

        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        void InitTreeListControl()
        {
            Projects projects = InitData();
            DataBinding(projects);
        }
        Projects InitData()
        {
            Projects projects = new Projects();
            projects.Add(new Project("Project A", false));
            projects.Add(new Project("Project B", false));
            projects[0].Projects.Add(new Project("Task 1", true));
            projects[0].Projects.Add(new Project("Task 2", true));
            projects[0].Projects.Add(new Project("Task 3", true));
            projects[0].Projects.Add(new Project("Task 4", true));
            projects[1].Projects.Add(new Project("Task 1", true));
            projects[1].Projects.Add(new Project("Task 2", true));
            return projects;
        }
        void DataBinding(Projects projects)
        {
            treeList.ExpandAll();
            treeList.DataSource = projects;
            treeList.BestFitColumns();
        }
        BindingList<Person> gridDataList = new BindingList<Person>();
        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = gridDataList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lS_DBF_Для_ПереносаDataSet.spragrt". При необходимости она может быть перемещена или удалена.
            this.spragrtTableAdapter.Fill(this.lS_DBF_Для_ПереносаDataSet.spragrt);

        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }
}