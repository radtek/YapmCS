using Microsoft.VisualBasic;
using System;

[Serializable()]
public class SerializableException
{


    // ========================================
    // Private constants
    // ========================================


    // ========================================
    // Private attributes
    // ========================================

    // All error fields
    private string _customMessage;
    private string _message;
    // Private _helpL As String
    // Private _source As String
    // Private _stack As String


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

    // Normal message
    public string Message
    {
        get
        {
            return _message;
        }
    }


    // ========================================
    // Other public
    // ========================================


    // ========================================
    // Public functions
    // ========================================

    // Constructors
    public SerializableException(cError exception)
    {
        _customMessage = exception.CustomMessage;
        _message = exception.Message;
    }
    public SerializableException(Exception exception)
    {
        _customMessage = null;
        _message = exception.Message;
    }

    // Return a standard exception
    public Exception GetException()
    {
        return new Exception(_message + Constants.vbNewLine + _customMessage);
    }
}

