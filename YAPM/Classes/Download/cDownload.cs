using System;
using System.Net;

public delegate void DownloadCompleteHandler(object sender, DownloadDataCompletedEventArgs e);

public delegate void DownloadProgressChangeHandler(object sender, DownloadProgressChangedEventArgs e);

public class cDownload
{

    // ========================================
    // Private attributes
    // ========================================
    private System.Net.WebClient _WebClient;
    private string _destination;
    private string _DownloadURL;
    private bool bStoped;

    // ========================================
    // Public events
    // ========================================
    public event CompleteCallbackEventHandler CompleteCallback;

    public delegate void CompleteCallbackEventHandler(System.ComponentModel.AsyncCompletedEventArgs e);

    public event DownloadProgressChangeHandler ProgressCallback;


    // ========================================
    // Properties
    // ========================================
    public string DownloadURL
    {
        get
        {
            return this._DownloadURL;
        }
        set
        {
            this._DownloadURL = value;
        }
    }
    public string Destination
    {
        get
        {
            return this._destination;
        }
        set
        {
            this._destination = value;
        }
    }

    // ========================================
    // Public functions
    // ========================================
    public cDownload(string downloadURL, string destination)
    {
        _WebClient = new WebClient();
        _destination = destination;
        _DownloadURL = downloadURL;
        bStoped = false;

        _WebClient.DownloadFileCompleted += DownloadCompleteHandler;
        _WebClient.DownloadProgressChanged += DownloadProgressChangedHandler;
    }

    public void StartDownload()
    {
        _WebClient.DownloadFileAsync(new Uri(_DownloadURL), _destination);
    }

    public void Cancel()
    {
        _WebClient.CancelAsync();
        _WebClient = null;
        bStoped = true;
    }


    // ========================================
    // Public events
    // ========================================
    public void DownloadCompleteHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (!(bStoped))
            CompleteCallback?.Invoke(e);
    }

    public void DownloadProgressChangedHandler(object sender, System.Net.DownloadProgressChangedEventArgs e)
    {
        if (!(bStoped))
            ProgressCallback?.Invoke(sender, e);
    }
}
