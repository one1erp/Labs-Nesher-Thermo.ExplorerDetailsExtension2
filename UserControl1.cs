using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using DAL;
using LSExtensionExplorer;
using LSSERVICEPROVIDERLib;

namespace Thermo.ExplorerDetailsExtension2
{
    public partial class UserControl1 : UserControl, ILSXplDetailsControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public event ExceptionThrownEventHandler ExceptionThrown;

        public void PreDisplay()
        {
            Utils.CreateConstring(ntlCon);
            dal = new DataLayer();
            dal.Connect();
        }

        public void SelectionChanged(System.Collections.ArrayList[] selectionList)
        {

            var cn = selectionList[0][0].ToString();
            var client = dal.GetClientByName(cn);
            var q = (from item in client.Samples select item.Product.Name).Distinct();
            listBox1.DataSource = q.ToList();
          
        }
        private INautilusDBConnection ntlCon;

        public void SetServiceProvider(object sp)
        {
            serviceProvider = (NautilusServiceProvider)sp;


             ntlCon = Utils.GetNtlsCon(serviceProvider);


        }
        private void splitPanel1_Resize(object sender, EventArgs e)
        {
            
        }
        private NautilusServiceProvider serviceProvider;
        private IDataLayer dal;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(Width / 2 - label1.Width / 2, label1.Location.Y);

        }
    }
}
