using System.Windows.Forms;
using Common;
using System;
using Microsoft.Samples;


public class cError : Exception
{


    // ========================================
    // Private constants
    // ========================================


    // ========================================
    // Private attributes
    // ========================================

    // Custom message
    private string _customMessage;


    // ========================================
    // Public properties
    // ========================================

    // Custom message
    public string CustomMessage
    {
        get
        {
            return _customMessage;
        }
    }


    // ========================================
    // Other public
    // ========================================
    [Serializable()]
    public class SerializableException
    {
        public SerializableException(cError ex)
        {
        }
    }

    // ========================================
    // Public functions
    // ========================================

    // Constructor
    public cError(string message, Exception exception) : base(exception.Message, exception)
    {
        _customMessage = message;
    }
    public cError(string message) : base(message)
    {
        _customMessage = null;
    }

    // Show message
    public void ShowMessage(bool forceClassical = false)
    {
        if (Program.Parameters.ModeServer == false)
            // The we have to display our error as a message box
            Misc.ShowMsg("An handled error occured", CustomMessage, "Detailed information : " + Message, MessageBoxButtons.OK, TaskDialogIcon.Error, forceClassical: forceClassical);
        else
            // Then we have to send the error to the client
            Program._frmServer.SendErrorToClient(this);
    }
}

