using carservice.service.worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carservices.controller.admin.Read
{
    public partial class ReadWorkersForm : Form
    {
        WorkerServiceImpl workersService = new WorkerServiceImpl();
        public ReadWorkersForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            dataGridView1.RowCount = workersService.getAll().Count == 0 ? 1 : workersService.getAll().Count;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "ФИО";
            dataGridView1.Columns[2].Name = "Возраст";
            dataGridView1.Columns[3].Name = "Стаж";
            


            int i = 0;
            foreach (var worker in workersService.getAll())
            {
                dataGridView1.Rows[i].Cells[0].Value = worker.Id;
                dataGridView1.Rows[i].Cells[1].Value = worker.Name;
                dataGridView1.Rows[i].Cells[2].Value = worker.Category;
                dataGridView1.Rows[i].Cells[3].Value = worker.Speciality;

                i++;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReadWorkersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
