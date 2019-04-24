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
using System;
using Native.Api;

public partial class frmFindWindow
{
    private bool Selecting; // Amd I currently selecting a window?
    private bool BorderDrawn; // Is there a border currently drawn that needs To be undrawn?
    private IntPtr Myhwnd;  // The current hWnd that has a border drawn on it
    private IntPtr SelectedHwnd;  // The selecte hWnd


    private void Draw()
    {
        NativeStructs.PointApi Cursor;  // Cursor position
        IntPtr RetVal;  // Dummy returnvalue
        IntPtr hdc;  // hDC that we're going To be using
        IntPtr Pen; // Handle To a GDI Pen object
        IntPtr Brush; // Handle To a GDI Brush object
        IntPtr OldPen; // Handle To previous Pen object (to restore it)
        IntPtr OldBrush; // Handle To previous brush object (to restore it)
        NativeEnums.GdiBlendMode OldROP;  // Value of the previous ROP
        IntPtr Region;  // Handle To a GDI Region object that I create
        IntPtr OldRegion;  // Handle To previous Region object For the hDC
        Native.Api.NativeStructs.Rect FullWind; // the bounding rectangle of the window in screen coords
        Native.Api.NativeStructs.Rect Draw; // The drawing rectangle

        // Get the cursor
        NativeFunctions.GetCursorPos(out Cursor);
        // Get the window
        RetVal = NativeFunctions.WindowFromPoint(new Point(Cursor.X, Cursor.Y));
        // If the new hWnd is the same as the old
        // one, skip drawing it, so to avoid flicker
        if (RetVal == Myhwnd)
            return;
        // New hWnd. If there is currently a border drawn, undraw it.
        if (BorderDrawn == true)
            UnDraw();
        // Set the BorderDrawn property to true, as we're just about to draw it.
        BorderDrawn = true;
        // And set the hWnd to the new value.
        // Note, I didn't do it before, because the UnDraw routine uses the Myhwnd variable
        Myhwnd = RetVal;
        // You could extract other information from the window, such as window title,
        // class name, parent, etc., and print it here, too.
        // Get the full Rect of the window in screen co-ords
        NativeFunctions.GetWindowRect(Myhwnd, out FullWind);
        // Create a region with width and height of the window
        Region = NativeFunctions.CreateRectRgn(0, 0, FullWind.Right - FullWind.Left, FullWind.Bottom - FullWind.Top);
        // Create an hDC for the hWnd
        // Note: GetDC retrieves the CLIENT AREA hDC. We want the WHOLE WINDOW, including Non-Client
        // stuff like title bar, menu, border, etc.
        hdc = NativeFunctions.GetWindowDC(Myhwnd);
        // Save the old region
        NativeFunctions.GetClipRgn(hdc, OldRegion);
        // Retval = 0: no region 1: Region copied -1: error
        // Select the new region
        RetVal = NativeFunctions.SelectObject(hdc, Region);
        // Create a pen
        Pen = NativeFunctions.CreatePen(0, 6, IntPtr.Zero); // Draw Solid lines, width 6, and color black
        // Select the pen
        // A pen draws the lines
        OldPen = NativeFunctions.SelectObject(hdc, Pen);
        // Create a brush
        // A brush is the filling for a shape
        // I need to set it to a null brush so th
        // at it doesn't edit anything
        Brush = NativeFunctions.GetStockObject(NativeEnums.GdiStockObject.NullBrush);
        // Select the brush
        OldBrush = NativeFunctions.SelectObject(hdc, Brush);
        // Select the ROP
        OldROP = NativeFunctions.SetROP2(hdc, NativeEnums.GdiBlendMode.Not); // vbInvert means, whatever is draw,
        // invert those pixels. This means that I can undraw it by doing the same.
        // 
        // The Drawing Bits
        // 
        // Put a box around the outside of the window, using the current hDC.
        // These coords are in device co-ordinates, i.e., of the hDC.


        {
            var withBlock = Draw;
            withBlock.Left = 0;
            withBlock.Top = 0;
            withBlock.Bottom = FullWind.Bottom - FullWind.Top;
            withBlock.Right = FullWind.Right - FullWind.Left;
            NativeFunctions.Rectangle(hdc, withBlock.Left, withBlock.Top, withBlock.Right, withBlock.Bottom); // Really easy to understand - draw a rectangle, hDC, and coordinates
        }

        // 
        // The Washing Up bits
        // 
        // This is a very important part, as it releases memory that has been taken up.
        // If we don't do this, windows crashes due to a memory leak.
        // You probably get a blue screen (altohugh I'm not sure)
        // 
        // Get back the old region


        NativeFunctions.SelectObject(hdc, OldRegion);
        // Return the previous ROP
        NativeFunctions.SetROP2(hdc, OldROP);
        // Return to the previous brush


        NativeFunctions.SelectObject(hdc, OldBrush);
        // Return the previous pen


        NativeFunctions.SelectObject(hdc, OldPen);
        // Delete the Brush I created
        NativeFunctions.DeleteObject(Brush);
        // Delete the Pen I created
        NativeFunctions.DeleteObject(Pen);
        // Delete the region I created
        NativeFunctions.DeleteObject(Region);
        // Release the hDC back to window's resource pool
        NativeFunctions.ReleaseDC(Myhwnd, hdc);
    }



    private void UnDraw()
    {

        // 
        // Note, this sub is almost identical to the other one, except it doesn't go looking
        // for the hWnd, it accesses the old one. Also, it doesn't clear the form.
        // Otherwise, it just draws on top of the old one with an invert pen.
        // 2 inverts = original
        // 
        // If there hasn't been a border drawn, then get out of here.
        if (BorderDrawn == false)
            return;
        // Now set it
        BorderDrawn = false;
        // If there isn't a current hWnd, then exit.
        // That's why in the mouseup event we get out, because otherwise a border would be draw
        // around the old window
        if (Myhwnd.IsNull())
            return;
        IntPtr RetVal; // Dummy returnvalue
        IntPtr hdc; // hDC that we're going To be using
        IntPtr Pen; // Handle To a GDI Pen object
        IntPtr Brush; // Handle To a GDI Brush object
        IntPtr OldPen; // Handle To previous Pen object (to restore it)
        IntPtr OldBrush;  // Handle To previous brush object (to restore it)
        NativeEnums.GdiBlendMode OldROP;   // Value of the previous ROP
        IntPtr Region;  // Handle To a GDI Region object that I create
        IntPtr OldRegion;  // Handle To previous Region object For the hDC
        Native.Api.NativeStructs.Rect FullWind;  // the bounding rectangle of the window in screen coords
        Native.Api.NativeStructs.Rect Draw; // The drawing rectangle
        // 
        // Getting all of the ingredients ready
        // 
        // Get the full Rect of the window in screen co-ords
        NativeFunctions.GetWindowRect(Myhwnd, out FullWind);
        // Create a region with width and height of the window
        Region = NativeFunctions.CreateRectRgn(0, 0, FullWind.Right - FullWind.Left, FullWind.Bottom - FullWind.Top);
        // Create an hDC for the hWnd
        // Note: GetDC retrieves the CLIENT AREA hDC. We want the WHOLE WINDOW, including Non-Client
        // stuff like title bar, menu, border, etc.
        hdc = NativeFunctions.GetWindowDC(Myhwnd);
        // Save the old region
        NativeFunctions.GetClipRgn(hdc, OldRegion);
        // Retval = 0: no region 1: Region copied -1: error
        // Select the new region
        RetVal = NativeFunctions.SelectObject(hdc, Region);
        // Create a pen
        Pen = NativeFunctions.CreatePen(0, 6, IntPtr.Zero); // Draw Solid lines, width 6, and color black
        // Select the pen
        // A pen draws the lines
        OldPen = NativeFunctions.SelectObject(hdc, Pen);
        // Create a brush
        // A brush is the filling for a shape
        // I need to set it to a null brush so that it doesn't edit anything
        Brush = NativeFunctions.GetStockObject(NativeEnums.GdiStockObject.NullBrush);
        // Select the brush
        OldBrush = NativeFunctions.SelectObject(hdc, Brush);
        // Select the ROP
        OldROP = NativeFunctions.SetROP2(hdc, NativeEnums.GdiBlendMode.Not); // vbInvert means, whatever is draw,
        // invert those pixels. This means that I can undraw it by doing the same.
        // 
        // The Drawing Bits
        // 
        // Put a box around the outside of the window, using the current hDC.
        // These coords are in device co-ordinates, i.e., of the hDC.


        {
            var withBlock = Draw;
            withBlock.Left = 0;
            withBlock.Top = 0;
            withBlock.Bottom = FullWind.Bottom - FullWind.Top;
            withBlock.Right = FullWind.Right - FullWind.Left;
            NativeFunctions.Rectangle(hdc, withBlock.Left, withBlock.Top, withBlock.Right, withBlock.Bottom); // Really easy to understand - draw a rectangle, hDC, and coordinates
        }

        // 
        // The Washing Up bits
        // 
        // This is a very important part, as it releases memory that has been taken up.
        // If we don't do this, windows crashes due to a memory leak.
        // You probably get a blue screen (altohugh I'm not sure)
        // 
        // Get back the old region


        NativeFunctions.SelectObject(hdc, OldRegion);
        // Return the previous ROP
        NativeFunctions.SetROP2(hdc, OldROP);
        // Return to the previous brush


        NativeFunctions.SelectObject(hdc, OldBrush);
        // Return the previous pen


        NativeFunctions.SelectObject(hdc, OldPen);
        // Delete the Brush I created
        NativeFunctions.DeleteObject(Brush);
        // Delete the Pen I created
        NativeFunctions.DeleteObject(Pen);
        // Delete the region I created
        NativeFunctions.DeleteObject(Region);
        // Release the hDC back to window's resource pool
        NativeFunctions.ReleaseDC(Myhwnd, hdc);
    }

    private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // Set the selecting flag
        Selecting = true;
        // Capture all mouse events to this window form
        NativeFunctions.SetCapture(this.Handle);
        // Simulate a mouse movement event to draw the border when the mouse button goes down
        Form_MouseMove(null, null);
    }

    private void Form_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // Security catch to make sure that the graphics don't get mucked up when not selecting
        if (Selecting == false)
            return;
        // Call the "Draw" subroutine
        Draw();
        // Refresh infos
        RefreshInfos(Myhwnd);
    }

    private void Form_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // If not selecting, then skip
        if (Selecting == false)
            return;
        // Clean up the graphics drawn
        UnDraw();
        // Release mouse capture
        NativeFunctions.ReleaseCapture();
        // Not selecting
        Selecting = false;
        // Found our handle
        SelectedHwnd = Myhwnd;
        // Reset the variable
        Myhwnd = IntPtr.Zero;
        this.cmdGoToProcess.Enabled = (SelectedHwnd.IsNotNull());
        this.cmdGoToThread.Enabled = this.cmdGoToProcess.Enabled;
    }

    private void Found(IntPtr hWnd, bool selectThread = false)
    {

        // Get process ID
        int pid;
        int tid = NativeFunctions.GetWindowThreadProcessId(hWnd, out pid);
        cProcess cP = null;

        Program._frmMain.lvProcess.SelectedItems.Clear();
        foreach (ListViewItem it in Program._frmMain.lvProcess.Items)
        {
            cP = Program._frmMain.lvProcess.GetItemByKey(it.Name);
            if (cP != null && cP.Infos.ProcessId == pid)
            {
                it.Selected = true;
                it.EnsureVisible();
                break;
            }
        }

        // Select 'process' tab in main form
        Program._frmMain.Ribbon.ActiveTab = Program._frmMain.ProcessTab;
        Program._frmMain.Ribbon_MouseMove(null, null);
        Program._frmMain.Show();
        Program._frmMain.lvProcess.Focus();

        if (selectThread && cP != null)
        {
            // Here we select the thread in detailed window
            frmProcessInfo frm = new frmProcessInfo();
            frm.SetProcess(ref cP);
            frm.TopMost = Program._frmMain.TopMost;
            frm.Show();
            frm.tabProcess.SelectedTab = frm.TabPageThreads;
            // Create a thread which wait for threads to be added in the lvThread
            // and then select the good thread
            System.Threading.ThreadPool.QueueUserWorkItem(selectThreadImp, new contextObj(tid, frm));
        }

        this.Close();
    }


    private struct contextObj
    {
        public int tid;
        public frmProcessInfo frmProcInfo;
        public contextObj(int threadId, frmProcessInfo form)
        {
            tid = threadId;
            frmProcInfo = form;
        }
    }
    private void selectThreadImp(object context)
    {
        contextObj pObj = (contextObj)context;

        // Wait for threads to be added
        while (pObj.frmProcInfo.lvThreads.Items.Count == 0)
            System.Threading.Thread.Sleep(50);

        // Select the good thread
        Async.ListView.EnsureItemVisible(pObj.frmProcInfo.lvThreads, pObj.tid.ToString());
    }


    private void RefreshInfos(IntPtr hWnd)
    {
        // Get thread & process ID
        int pid;
        int tid = NativeFunctions.GetWindowThreadProcessId(hWnd, out pid);
        if (tid > 0)
            this.lblThread.Text = tid.ToString();
        else
            this.lblThread.Text = Program.NO_INFO_RETRIEVED;
        Process cP = Process.GetProcessById(pid);
        if (cP != null)
            this.lblProcess.Text = cP.ProcessName + " (" + cP.Id.ToString() + ")";
        else
            this.lblProcess.Text = Program.NO_INFO_RETRIEVED;
    }

    private void frmFindWindow_Load(System.Object sender, System.EventArgs e)
    {
        Misc.CloseWithEchapKey(ref this);
        Misc.SetToolTip(this.cmdGoToProcess, "Select associated process");
        Misc.SetToolTip(this.cmdGoToThread, "Select associated thread");
    }

    private void cmdGoToProcess_Click(System.Object sender, System.EventArgs e)
    {
        // Found our handle
        Found(SelectedHwnd);
    }

    private void frmFindWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        // Paint an image on our Form (target image)
        Graphics g = e.Graphics;
        g.DrawImage(My.Resources.Resources.target32, new PointF(12, 46));
    }

    private void cmdGoToThread_Click(System.Object sender, System.EventArgs e)
    {
        // Found our handle
        Found(SelectedHwnd, true);
    }
}
