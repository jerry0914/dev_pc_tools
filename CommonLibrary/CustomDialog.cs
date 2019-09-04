using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace dev.jerry_h.pc_tools.CommonLibrary
{
    public partial class CustomDialog : Form
    {
        public String PositiveButtonText
        {
            get
            {
                return btnOK.Text;
            }
            set
            {
                btnOK.Text = value;
                btnOK.AutoSize = true;
            }
        }

        public Color PositiveButtonColor
        {
            get
            {
                return btnOK.BackColor;
            }
            set
            {
                btnOK.BackColor = value;
            }
        }

        public String NegativeButtonText
        {
            get
            {
                return btnCancel.Text;
            }
            set
            {
                btnCancel.Text = value;
                btnCancel.AutoSize = true;
            }
        }

        public Color NegativeButtonColor
        {
            get
            {
                return btnCancel.BackColor;
            }
            set
            {
                btnCancel.BackColor = value;
            }
        }

        public CustomDialog()
        {
            InitializeComponent();
        }
    }
}
