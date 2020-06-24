using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBank.WindowsForm.UI.Component
{
    public partial class EmploymentInfoComponent : UserControl
    {
        public EmploymentInfoComponent()
        {
            InitializeComponent();
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cboStatus.SelectedIndex == 1)
            {
                lblTerminatedDate.Visible = true;
                dtpTerminatedDate.Visible = true;
                lblRetiredDate.Visible = false;
                dtpRetiredDate.Visible = false;
            }
            else if(cboStatus.SelectedIndex == 2)
            {
                lblTerminatedDate.Visible = false;
                dtpTerminatedDate.Visible = false;
                lblRetiredDate.Visible = true;
                dtpRetiredDate.Visible = true;
            }
            else
            {
                lblTerminatedDate.Visible = false;
                dtpTerminatedDate.Visible = false;
                lblRetiredDate.Visible = false;
                dtpRetiredDate.Visible = false;
            }
        }
    }
}
