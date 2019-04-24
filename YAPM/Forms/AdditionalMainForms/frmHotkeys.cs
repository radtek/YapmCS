// =======================================================
// Yet Another (remote) Process Monitor (YAPM)
// Copyright (c) 2008-2009 Alain Descotes (violent_ken)
// https://sourceforge.net/projects/yaprocmon/
// =======================================================


// YAPM is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// YAPM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YAPM; if not, see http://www.gnu.org/licenses/.


using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Common;
using System.Xml;
using System;

public partial class frmHotkeys
{
    public const string HOTKEYS_SAVE_FILE = "hotkeys.xml";
    private int atxtKey = -1;

    private void frmHotkeys_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        // Save to XML
        writeXML();
    }

    private void frmWindowsList_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);

        Native.Functions.Misc.SetTheme(this.lv.Handle);

        Misc.SetToolTip(this.chkAlt, "Use Alt key");
        Misc.SetToolTip(this.chkCtrl, "Use Control key");
        Misc.SetToolTip(this.chkShift, "Use Shift key");
        Misc.SetToolTip(this.txtKey, "Press the desired key on your keyboard for the shortcut");
        Misc.SetToolTip(this.cmdAdd, "Add the shortcut");
        Misc.SetToolTip(this.cmdKO, "Do not add the shortcut");
        Misc.SetToolTip(this.cbAction, "Action to raise when the keys of the shortcut are pressed");


        this.cbAction.Items.Clear();
        foreach (string i in Program.Hotkeys.ActionsAvailable)
        {
            if (i != null)
                this.cbAction.Items.Add(i);
        }

        // Read collection and add items
        foreach (cShortcut ht in Program.Hotkeys.HotKeysCollection)
        {
            // Add hotkey
            string skeys = ((cShortcut.ShorcutKeys)ht.Key1).ToString() + " + " + ((cShortcut.ShorcutKeys)ht.Key2).ToString() + " + " + ((cShortcut.ShorcutKeys)ht.Key3).ToString();
            ListViewItem it = new ListViewItem(skeys);
            it.Tag = ht;
            if (ht.Enabled == false)
                it.ForeColor = Color.Gray;
            it.SubItems.Add(this.cbAction.Items[ht.Action - 1].ToString());
            it.ImageKey = "default";
            this.lv.Items.Add(it);
        }
    }

    private void cmdKO_Click(System.Object sender, System.EventArgs e)
    {
        gp.Visible = false;
    }

    private void cmdAdd_Click(System.Object sender, System.EventArgs e)
    {
        gp.Visible = false;

        // Add shortcut
        int i = this.cbAction.SelectedIndex + 1;

        if (i <= 0)
            return;

        int k1 = -1;
        int k2 = -1;
        int k3 = atxtKey;

        if (this.chkCtrl.Checked)
        {
            k1 = cShortcut.ShorcutKeys.VK_CONTROL;
            if (this.chkShift.Checked)
                k2 = cShortcut.ShorcutKeys.VK_SHIFT;
            else if (this.chkAlt.Checked)
                k2 = cShortcut.ShorcutKeys.VK_MENU;
        }
        else if (this.chkShift.Checked)
        {
            k1 = cShortcut.ShorcutKeys.VK_SHIFT;
            if (this.chkAlt.Checked)
                k2 = cShortcut.ShorcutKeys.VK_MENU;
        }
        else if (this.chkAlt.Checked)
            k1 = cShortcut.ShorcutKeys.VK_MENU;

        if (k1 + k2 + k3 == -3)
            return;

        cShortcut ht = new cShortcut(i, k1, k2, k3);
        if (Program.Hotkeys.AddHotkey(ht))
        {
            // Add hotkey
            string skeys = ((cShortcut.ShorcutKeys)k1).ToString() + " + " + ((cShortcut.ShorcutKeys)k2).ToString() + " + " + ((cShortcut.ShorcutKeys)k3).ToString();
            ListViewItem it = new ListViewItem(skeys);
            it.Tag = ht;
            it.SubItems.Add(this.cbAction.Text);
            it.ImageKey = "default";
            this.lv.Items.Add(it);
        }
    }

    private void txtKey_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        atxtKey = e.KeyCode;
        this.lblKey.Text = ((cShortcut.ShorcutKeys)atxtKey).ToString();
    }

    // Can't check more than 2 boxes
    private void chkCtrl_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkCtrl.Checked)
        {
            if (chkAlt.Checked & chkShift.Checked)
                chkAlt.Checked = false;
        }
    }
    private void chkShift_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkShift.Checked)
        {
            if (chkCtrl.Checked & chkAlt.Checked)
                chkAlt.Checked = false;
        }
    }
    private void chkAlt_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        if (chkAlt.Checked)
        {
            if (chkCtrl.Checked & chkShift.Checked)
                chkShift.Checked = false;
        }
    }

    // Read from XML file
    public void readHotkeysFromXML()
    {
        XmlDocument XmlDoc = new XmlDocument();
        XmlNodeList element;
        XmlNode noeud, noeudEnf;

        // <hotkeys>
        // <key>
        // <enabled>true</enabled>
        // <key1>65</key1>
        // <key2>16</key2>
        // <key3>17</key3>
        // <action>2</action>
        // </key>
        // </hotkeys>

        try
        {
            XmlDoc.Load(My.MyProject.Application.Info.DirectoryPath + @"\" + HOTKEYS_SAVE_FILE);
            element = XmlDoc.DocumentElement.GetElementsByTagName("key");

            foreach (var noeud in element)
            {
                int key1;
                int key2;
                int key3;
                int action;
                bool enabled;

                foreach (var noeudEnf in noeud.ChildNodes)
                {
                    if (noeudEnf.LocalName == "enabled")
                        enabled = System.Convert.ToBoolean(noeudEnf.InnerText);
                    else if (noeudEnf.LocalName == "key1")
                        key1 = System.Convert.ToInt32(noeudEnf.InnerText);
                    else if (noeudEnf.LocalName == "key2")
                        key2 = System.Convert.ToInt32(noeudEnf.InnerText);
                    else if (noeudEnf.LocalName == "key3")
                        key3 = System.Convert.ToInt32(noeudEnf.InnerText);
                    else if (noeudEnf.LocalName == "action")
                        action = System.Convert.ToInt32(noeudEnf.InnerText);
                }

                cShortcut ht = new cShortcut(action, key1, key2, key3);
                ht.Enabled = enabled;

                Program.Hotkeys.AddHotkey(ht);
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine("XML loading failed : " + ex.Message);
        }
    }

    // Write to XML file
    private void writeXML()
    {

        // <hotkeys>
        // <key>
        // <enabled>true</enabled>
        // <key1>65</key1>
        // <key2>16</key2>
        // <key3>17</key3>
        // <action>2</action>
        // </key>
        // </hotkeys>

        XmlDocument XmlDoc = new XmlDocument();
        XmlDoc.LoadXml("<hotkeys></hotkeys>");

        foreach (ListViewItem it in this.lv.Items)
        {
            cShortcut cs = (cShortcut)it.Tag;

            XmlElement elemConfig = XmlDoc.CreateElement("key");

            XmlElement elemEnabled;
            elemEnabled = XmlDoc.CreateElement("enabled");
            elemEnabled.InnerText = System.Convert.ToString(cs.Enabled);
            elemConfig.AppendChild(elemEnabled);

            XmlElement elemKey1;
            elemKey1 = XmlDoc.CreateElement("key1");
            elemKey1.InnerText = System.Convert.ToString(cs.Key1);
            elemConfig.AppendChild(elemKey1);

            XmlElement elemKey2;
            elemKey2 = XmlDoc.CreateElement("key2");
            elemKey2.InnerText = System.Convert.ToString(cs.Key2);
            elemConfig.AppendChild(elemKey2);

            XmlElement elemKey3;
            elemKey3 = XmlDoc.CreateElement("key3");
            elemKey3.InnerText = System.Convert.ToString(cs.Key3);
            elemConfig.AppendChild(elemKey3);

            XmlElement elemAction;
            elemAction = XmlDoc.CreateElement("action");
            elemAction.InnerText = System.Convert.ToString(cs.Action);
            elemConfig.AppendChild(elemAction);

            XmlDoc.DocumentElement.AppendChild(elemConfig);
        }

        XmlDoc.Save(My.MyProject.Application.Info.DirectoryPath + @"\" + HOTKEYS_SAVE_FILE);
    }

    private void lv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
            this.TheContextMenu.Show(this.lv, e.Location);
    }

    private void MenuItem_Click(System.Object sender, System.EventArgs e)
    {
        gp.Visible = true;
    }

    private void mnuRemoveFolder_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            if (it.Selected)
            {
                // Remove or ?
                string sKey = ((cShortcut)it.Tag).Key;
                if (Program.Hotkeys.RemoveHotKey(sKey))
                    it.Remove();
            }
        }
    }

    private void MenuItem2_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            if (it.Selected)
            {
                ((cShortcut)it.Tag).Enabled = true;
                it.ForeColor = Color.Black;
            }
        }
    }

    private void MenuItem3_Click(System.Object sender, System.EventArgs e)
    {
        foreach (ListViewItem it in this.lv.SelectedItems)
        {
            if (it.Selected)
            {
                ((cShortcut)it.Tag).Enabled = false;
                it.ForeColor = Color.Gray;
            }
        }
    }
}
