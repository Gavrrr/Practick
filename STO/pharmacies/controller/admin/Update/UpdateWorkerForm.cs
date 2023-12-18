using carservice.model;

using carservice.service.worker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace carservice.controller.admin.Update
{
    public partial class UpdateWorkerForm : Form
    {


        List<Worker> allWorkers;
        WorkerServiceImpl workerService = new WorkerServiceImpl();
        public UpdateWorkerForm()
        {
            InitializeComponent();
            setWorker();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void saveEnable()
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            saveEnable();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Worker worker = workerService.GetByName(WorkerBox.Text);
            worker.Name = Name.Text;
            worker.Category = Convert.ToInt32(experience.Text);
            worker.Speciality = Post.Text;
            workerService.update(worker);
            Close();

        }



        private void CreateCarservicesForm_Load(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            saveEnable();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void setWorker()
        {
            List<Worker> workers = workerService.getAll();
            foreach (var item in workers)
            {
                WorkerBox.Items.Add(item.Name);
            }
        }

        private void carserviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveEnable();
            Worker worker = workerService.GetByName(WorkerBox.Text);
            Name.Text = worker.Name;
            experience.Text = worker.Category.ToString();
            Post.Text = worker.Speciality;
        }

        private void Name_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
