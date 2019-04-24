using System;
using System.Net;

public class BugReporter : WebClient
{

    // Private variables
    private readonly System.Collections.Specialized.NameValueCollection _postValues = new System.Collections.Specialized.NameValueCollection();

    private string _summary;

    // Public properties
    public string ValueSummary
    {
        get
        {
            return _summary;
        }
        set
        {
            _summary = value;
        }
    }
    public string ValueDetails { get; set; }


    // Constructor
    public BugReporter() : base()
    {

        // Add some values to the list of values to send

        // See http://sourceforge.net/tracker/?func=add&group_id=244697&atid=1126635

        // Fixed values for yaprocmon project
        _postValues.Add("group_id", "244697");
        _postValues.Add("atid", "1126635");
        _postValues.Add("func", "postadd");
        _postValues.Add("submit", "Add Artifact");
        _postValues.Add("category_id", "1252941");   // Auto_report category

        // Cateogry, 100 = None
        _postValues.Add("is_private", "0");

        // Private ?
        _postValues.Add("category_id", "100");

        // Group, 100 = None
        _postValues.Add("artifact_group_id", "100");

        // Assigned to me (violent_ken ID) :-)
        _postValues.Add("assigned_to", "1590933");
    }


    // Go async
    public bool GoAsync()
    {
        if (_summary == null || ValueDetails == null)
            return false;

        // Add summary and description informations
        _postValues.Add("summary", Uri.EscapeDataString(_summary));
        _postValues.Add("details", Uri.EscapeDataString(ValueDetails));

        this.QueryString = _postValues;

        // Send request
        this.DownloadStringAsync(new Uri("http://sourceforge.net/tracker/index.php"));
        return true;
    }
}

