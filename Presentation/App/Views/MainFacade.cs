using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controllers;
using App.Core.Domain;
using App.Service.Business;
using Autofac;

namespace App.Views {

    //[TypeDescriptionProvider(typeof(AbstractCommunicatorProvider))]
    public partial class MainFacade : Form {

        public MainFacade(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){

            var a = App.Container.Resolve<IChatLieuController>();
                 a.View();
            
            //var source = new BindingSource{DataSource = chatLieuService.GetAll()};

            //dataGridView1.DataSource = source;
            //var dataGridViewColumn = dataGridView1.Columns["ID"];
            //if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;

            ////var a = chatLieuService.GetAll();
            //textBox1.Text = "wait please";

            //var t = Task.Factory.StartNew(() => chatLieuService.GetAll());
            //var firstOrDefault = t.Result.FirstOrDefault();
            //if (firstOrDefault != null) 
            //    textBox1.Text = firstOrDefault.MaChatLieu;
        }

    }
}
