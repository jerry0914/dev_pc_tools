using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dev.jerry_h.pc_tools.CommonLibrary;
using dev.jerry_h.pc_tools.AndroidLibrary;
using dev.jerry_h.pc_tools.InstructionLibrary;
using System.Reflection;

namespace dev.jerry_h.pc_tools.TestApplication
{
    public partial class Form1 : Form
    {
        private clsDevice device1;
        private Dictionary<String, IDevice> dicDevices
        {
            get
            {
                if (cmbDeviceList.Text.Length > 0)
                {
                    device1 = new clsDevice(cmbDeviceList.Text);
                }
                Dictionary<String,IDevice> dic = new Dictionary<String, IDevice>();
                dic.Add("DEV1", device1);
                return (dic);
            }
        }           

        public Form1()
        {
            InitializeComponent();
            refreshDeviceList();
            //typeof(Device).GetMethod("AAA").Invoke(device1,new object[]{"123"});
            //CommandDictiionary cd = new CommandDictiionary();
            //CommandUnit[] ucList = cd.AllCommandList;
            //foreach (CommandUnit ucl in ucList)
            //{
            //    TreeNode tnCategory = new TreeNode(ucl.ClassName);
            //    foreach(MethodInfo mi in ucl.MethodList)
            //    {
            //        TreeNode tnMethod = new TreeNode(mi.ToString());
            //        tnCategory.Nodes.Add(tnMethod);
            //    }
            //    treeView1.Nodes.Add(tnCategory);
            //}
            clsDevice device = new clsDevice("123");
            foreach (KeyValuePair<String, IDeviceComponent> kvp in device.DeviceComponents)
            {
                TreeNode tnCategory = new TreeNode(kvp.Key);
                foreach (MethodInfo mi in kvp.Value.Methods)
                {
                    TreeNode tnMethod = new TreeNode(mi.ToString());
                    tnCategory.Nodes.Add(tnMethod);
                }
                treeView1.Nodes.Add(tnCategory);
            }
            MethodInfo[] ms = typeof(Logger).GetMethods();
            device.DeviceComponents.Count();
        }

        private void refreshDeviceList()
        {
            List<AdbDeviceInfomation> devList = ADB_Process.GetDeivcesList();
            cmbDeviceList.Items.Clear();
            foreach (AdbDeviceInfomation dev in devList)
            {
                cmbDeviceList.Items.Add(dev.ID);
            }
            if (devList.Count > 0)
            {
                cmbDeviceList.SelectedIndex = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (device1 != null)
            {
                //device1.Actions.LongClick(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
        }

        private void btnDeviceListRefresh_Click(object sender, EventArgs e)
        {
            refreshDeviceList();
        }

        private void cmbDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            device1 = new clsDevice(cmbDeviceList.Text);
            lblResolution.Text = device1.Auxiliary.GetScreenResolution_InsLib().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (device1 != null)
            {
                device1.Actions.Click(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text));
            }
        }

        private void btnCmdParse_Click(object sender, EventArgs e)
        {

            clsPackage package = new clsPackage(dicDevices);
            clsScript script = new clsScript(ref package, "");
            for(int i=0;i<txtCmdTest.Lines.Count();i++)
            {
                script.Units.Add(new clsScriptLine(script, i, txtCmdTest.Lines[i]));
            }
            clsLooper looper = new clsLooper(ref script,script.Units.Count());
            script.Units.Add(looper);
            //txtCmdParsedOutput.Text = "Left statement = " + sline.CommandString.Left_Statement + "\r\n" +
            //                          "Right statement = " + sline.rightStatement + "\r\n" +
            //                          "Remark = " + sline.CommandString.Remark;
            txtCmdParsedOutput.Clear();
            foreach (IScriptUnit unit in script.Units)
            {
                if (unit.GetType().Equals(typeof(clsScriptLine)))
                {
                    txtCmdParsedOutput.Text += "Left statement["+unit.LineNumber+"] = " + ((clsScriptLine)unit).LeftStatement + "\r\n" +
                                              "Right statement[" + unit.LineNumber + "] = " + ((clsScriptLine)unit).RightStatement + "\r\n" +
                                              "Remark[" + unit.LineNumber + "] = " + ((clsScriptLine)unit).Remark + "\r\n";
                }
            }
        }
        clsScript script = null;
        private void btnCmdCompiler_Click(object sender, EventArgs e)
        {
            bool compilerResult = true;
            clsPackage package = new clsPackage(dicDevices);
            script = new clsScript(ref package, "");
            for (int i = 0; i < txtCmdTest.Lines.Count(); i++)
            {
                script.Units.Add(new clsScriptLine(script, i, txtCmdTest.Lines[i]));
            }
            clsLooper looper = new clsLooper(ref script, script.Units.Count());
            script.Units.Add(looper);
            foreach (IScriptUnit unit in script.Units)
            {
                if (unit.GetType().Equals(typeof(clsScriptLine)))
                {
                    compilerResult &= unit.Compiler();                    
                }
            }
            txtCmdParsedOutput.Clear();
            if (!compilerResult)
            {
                txtCmdParsedOutput.Text += "Compiler error : \r\n";
               foreach(clsRuntimeErrorMessage sem in script.RuntimeErrorMessages)
               {                   
                   txtCmdParsedOutput.Text += "Line[" + sem.LineNumber + "]  " + sem.Message + "\r\n";
               }
            }
        }

        private void txtCmdTest_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnCmdCompiler_Click(null, null);
            script.Run();
        }
    }
}
