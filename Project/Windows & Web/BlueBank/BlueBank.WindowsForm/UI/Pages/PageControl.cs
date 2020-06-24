using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBank.WindowsForm.UI.Pages
{
    /// <summary>
    /// Represents a page that will be loaded and used in the Main Form
    /// <parent name="UserControl"></parent>
    /// </summary>
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
        }

        MainForm parentForm; // Main form instance

        public bool HasBeenClosed { get; set; } = false;

        public int Position { get; set; }


        public void Close()
        {

            parentForm = (MainForm)ParentForm;


            if (parentForm.list.Count != 0)
            {
                int i = parentForm.list.IndexOf(this);
                parentForm.selectedPageIndex = i;
            }
            this.Parent.Controls.Remove(this);
            this.HasBeenClosed = true;
            parentForm.ChangeSelectedPage();


        }
    }
}
