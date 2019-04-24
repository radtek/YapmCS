using Microsoft.VisualBasic;
using System;

[Serializable()]
public class windowInfos : generalInfos
{
    protected string _procName;
    protected int _processId;
    protected IntPtr _handle;
    protected bool _isTask;
    protected Native.Api.NativeStructs.Rect _positions;
    protected bool _enabled;
    protected bool _visible;
    protected int _threadId;
    protected int _height;
    protected int _width;
    protected int _top;
    protected int _left;
    protected byte _opacity;
    protected string _caption;



    internal string Caption
    {
        get
        {
            return _caption;
        }
    }
    public int ProcessId
    {
        get
        {
            return _processId;
        }
    }
    public bool IsTask
    {
        get
        {
            return _isTask;
        }
    }
    public bool Enabled
    {
        get
        {
            return _enabled;
        }
    }
    public bool Visible
    {
        get
        {
            return _visible;
        }
    }
    public int ThreadId
    {
        get
        {
            return _threadId;
        }
    }
    public int Height
    {
        get
        {
            return _height;
        }
    }
    public int Width
    {
        get
        {
            return _width;
        }
    }
    public int Top
    {
        get
        {
            return _top;
        }
    }
    public int Left
    {
        get
        {
            return _left;
        }
    }
    public byte Opacity
    {
        get
        {
            return _opacity;
        }
    }
    public IntPtr Handle
    {
        get
        {
            return _handle;
        }
    }
    public string ProcessName
    {
        get
        {
            if (_procName == Constants.vbNullString)
            {
                _procName = cProcess.GetProcessName(this.ProcessId);
                if (_procName == Constants.vbNullString)
                    _procName = Program.NO_INFO_RETRIEVED;
            }
            return _procName;
        }
    }
    public Native.Api.NativeStructs.Rect Positions
    {
        get
        {
            return _positions;
        }
    }


    // ========================================
    // Public
    // ========================================
    public windowInfos()
    {
    }
    public windowInfos(ref windowInfos window)
    {
        {
            var withBlock = window;
            _processId = withBlock.ProcessId;
            _threadId = withBlock.ThreadId;
            _handle = withBlock.Handle;
            _caption = withBlock.Caption;
            _procName = withBlock.ProcessName;
            _isTask = withBlock.IsTask;
            _positions = withBlock.Positions;
            _enabled = withBlock.Enabled;
            _visible = withBlock.Visible;
            _height = withBlock.Height;
            _width = withBlock.Width;
            _top = withBlock.Top;
            _left = withBlock.Left;
            _opacity = withBlock.Opacity;
        }
    }
    public windowInfos(int pid, int tid, IntPtr handle, string caption)
    {
        _processId = pid;
        _threadId = tid;
        _handle = handle;
        _caption = caption;
    }

    internal void SetNonFixedInfos(ref asyncCallbackWindowGetNonFixedInfos.TheseInfos infos)
    {
        {
            var withBlock = infos;
            _enabled = withBlock.enabled;
            _height = withBlock.height;
            _isTask = withBlock.isTask;
            _left = withBlock.left;
            _opacity = withBlock.opacity;
            _positions = withBlock.theRect;
            _top = withBlock.top;
            _visible = withBlock.visible;
            _width = withBlock.width;
            _caption = withBlock.caption;
        }
    }

    // Retrieve all information's names availables
    public static string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false)
    {
        string[] s = new string[11];

        s[0] = "Caption";
        s[1] = "Process";
        s[2] = "IsTask";
        s[3] = "Enabled";
        s[4] = "Visible";
        s[5] = "ThreadId";
        s[6] = "Height";
        s[7] = "Width";
        s[8] = "Top";
        s[9] = "Left";
        s[10] = "Opacity";

        if (includeFirstProp)
        {
            string[] s2 = new string[s.Length + 1];
            Array.Copy(s, 0, s2, 1, s.Length);
            s2[0] = "Id";
            s = s2;
        }

        if (sorted)
            Array.Sort(s);

        return s;
    }
}

