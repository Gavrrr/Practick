using carservice.controller.admin.Create;
using carservice.controller.admin.Update;
using carservice.controller.admin.Delete;

using carservices.controller.admin.Read;
//using carservices.controller.admin.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using carservice.model;
using carservice.service.worker;
using static System.Collections.Specialized.BitVector32;

namespace carservice.controller.admin
{
    public partial class StartForm : Form
    {
        WorkerServiceImpl workerService = new WorkerServiceImpl();
        public StartForm()
        {
            InitializeComponent();
            table.Items.Add("Работники фабрики");

            Create.Enabled = false;
            Read.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.Session.FormLogin.Visible = true;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Login.Session.TableForAdmin = table.Text;

            if (Login.Session.TableForAdmin == "Работники фабрики")
            {
                CreateWorker form = new CreateWorker();
                form.ShowDialog();
            }

        }

        private void table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Create.Text.Length > 0 && Read.Text.Length > 0 && Update.Text.Length > 0 && Delete.Text.Length > 0)
            {
                Create.Enabled = true;
                Read.Enabled = true;
                Update.Enabled = true;
                Delete.Enabled = true;
            }
            else
            {
                Create.Enabled = false;
                Read.Enabled = false;
                Update.Enabled = false;
                Delete.Enabled = false;
            }
        }

        private void table_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = '\0';
        }

        private void Read_Click(object sender, EventArgs e)
        {
            Login.Session.TableForAdmin = table.Text;


            if (Login.Session.TableForAdmin == "Работники фабрики")
            {
                ReadWorkersForm form = new ReadWorkersForm();
                form.ShowDialog();
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Login.Session.TableForDelete = table.Text;
            DeleteForm form = new DeleteForm();
            form.ShowDialog();
        }

        private void wellcome_Click(object sender, EventArgs e)
        {

        }
        private void Update_Click(object sender, EventArgs e)
        {
            Login.Session.TableForAdmin = table.Text;

            if (Login.Session.TableForAdmin == "Работники фабрики")
            {
                UpdateWorkerForm form = new UpdateWorkerForm();
                form.ShowDialog();
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
