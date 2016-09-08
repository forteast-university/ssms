using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controllers;
using App.Core.Domain;
using App.Core.Infrastructure;
using App.Models;
using App.Service.Business;
using Autofac;

namespace App.Views {

    public partial class MainFacade : Form{
        private readonly Autofac.IContainer app = AppFacade.Container;
        
        public MainFacade(){
            InitializeComponent();
            app = AppFacade.Container;
        }

        private void button1_Click(object sender, EventArgs e){
            app.Resolve <IBaseController<ChatLieuModel>>().View();



            
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
