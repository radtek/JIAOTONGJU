using DYApp.DataObject;
using DYApp.Infrastructure;
using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class Form1 : Form
    {
        private IWorkFlowService workFlowService;

        public Form1()
        {
            InitializeComponent();
            this.workFlowService = ServiceLocator.Instance.GetRef<IWorkFlowService>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<WorkFlowDataObject> list = this.workFlowService.GetList();
        }
    }
}
