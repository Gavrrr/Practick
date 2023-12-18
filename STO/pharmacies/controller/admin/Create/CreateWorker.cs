using carservice.model;

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

namespace carservice.controller.admin.Create
{
    public partial class CreateWorker : Form
    {
        WorkerServiceImpl workerService = new WorkerServiceImpl();
        public CreateWorker()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        private void save_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.Name = Name.Text;
            worker.Category = Convert.ToInt32(experience.Text);
            worker.Speciality = Post.Text;
            workerService.save(worker);
            Close();
        }
    }
}
