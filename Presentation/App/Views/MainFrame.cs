using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Core.Domain;
using App.Service.Business;

namespace App.Views {

    //[TypeDescriptionProvider(typeof(AbstractCommunicatorProvider))]
    public partial class MainFrame : Form {

        private readonly IChatLieuService chatLieuService;

        public MainFrame(IChatLieuService chatlieuService){
            this.chatLieuService = chatlieuService;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){

            var source = new BindingSource{DataSource = chatLieuService.GetAll()};
            dataGridView1.DataSource = source;

            ////var a = chatLieuService.GetAll();
            //textBox1.Text = "wait please";

            //var t = Task.Factory.StartNew(() => chatLieuService.GetAll());
            //var firstOrDefault = t.Result.FirstOrDefault();
            //if (firstOrDefault != null) 
            //    textBox1.Text = firstOrDefault.MaChatLieu;
        }

    }
}
