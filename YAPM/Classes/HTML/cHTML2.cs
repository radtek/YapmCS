using Microsoft.VisualBasic;
using System;
using System.Text;

public class cHTML2
{

    // This class allows to create an HTML file (special array).
    // ---------------------------------------
    // |  C:\Windows\Explorer.exe            |       (bold)
    // ---------------------------------------
    // | Size      | 1245 MB                 |
    // ---------------------------------------
    // | ParentDir | C:\Windows\             |
    // ---------------------------------------
    // | Copyright | (c) Microsoft           |
    // ---------------------------------------

    // This is supposed to be normalized HTML
    // An HTML page produced by this class should successfully be checked as XHTML 1.0 Transitional

    // ========================================
    // Public declarations
    // ========================================
    public struct HtmlColumnStructure
    {
        public int sizePercent;
        public string title;
    }


    // ========================================
    // APIs
    // ========================================


    // ========================================
    // Private attributes
    // ========================================
    private StringBuilder _code;
    private string _file;
    private string _title;
    private int _firstColSize;


    // ========================================
    // Getter & setter
    // ========================================



    // ========================================
    // Public functions
    // ========================================

    public cHTML2(string destination, string title, int firstColSize) : base()
    {
        _firstColSize = firstColSize;
        _file = destination;
        _title = normaliszeISOhtml(title);

        initHTML();
    }

    // Export (create) the HTML file
    public bool ExportHTML()
    {

        // Finalize HTML file
        _code.Capacity += 30;
        _code.AppendLine("</table>");
        _code.AppendLine("</body>");
        _code.AppendLine("</html>");

        try
        {
            System.IO.StreamWriter stream = new System.IO.StreamWriter(_file, false);
            stream.Write(_code.ToString());
            stream.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Reset the HTML code
    public void ResetHTML()
    {
        _code.Remove(0, _code.Length);
    }

    // Append a title (1-column) line
    public void AppendTitleLine(string line)
    {
        try
        {
            _code.AppendLine("<tr class=" + (char)34 + "titlecell" + (char)34 + ">");
            _code.AppendLine("<th class=" + (char)34 + "titlecellbold" + (char)34 + " colspan=" + (char)34 + "2" + (char)34 + ">" + normaliszeISOhtml(line) + "</th>");
            _code.AppendLine("</tr>");
        }
        catch (Exception ex)
        {
            _code.Capacity += _code.Capacity;
            _code.AppendLine("<tr class=" + (char)34 + "titlecell" + (char)34 + ">");
            _code.AppendLine("<th class=" + (char)34 + "titlecellbold" + (char)34 + " colspan=" + (char)34 + "2" + (char)34 + ">" + normaliszeISOhtml(line) + "</th>");
            _code.AppendLine("</tr>");
        }
    }

    // Add a new line (multi columns) in our array
    public void AppendLine(string[] line)
    {
        if (line == null)
            return;
        if (!(line.Length == 2))
            return;

        try
        {
            _code.AppendLine("<tr class=" + (char)34 + "titlecell" + (char)34 + ">");
            var loopTo = line.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                _code.AppendLine("<td class=" + (char)34 + "normalcell" + (char)34 + ">" + normaliszeISOhtml(line[x]) + "</td>");
            _code.AppendLine("</tr>");
        }
        catch (Exception ex)
        {
            _code.Capacity += _code.Capacity;
            _code.AppendLine("<tr class=" + (char)34 + "titlecell" + (char)34 + ">");
            var loopTo = line.Length - 1;
            for (int x = 0; x <= loopTo; x++)
                _code.AppendLine("<td class=" + (char)34 + "normalcell" + (char)34 + ">" + normaliszeISOhtml(line[x]) + "</td>");
            _code.AppendLine("</tr>");
        }
    }


    // ========================================
    // Private functions
    // ========================================
    private void initHTML()
    {

        // Here we add beginning of HTML file
        _code = new StringBuilder();

        _code.AppendLine("<!DOCTYPE html PUBLIC " + (char)34 + "-//W3C//DTD XHTML 1.0 Transitional//EN" + (char)34);
        _code.AppendLine("    " + (char)34 + "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + (char)34 + ">");
        _code.AppendLine("<html xmlns=" + (char)34 + "http://www.w3.org/1999/xhtml" + (char)34 + " xml:lang=" + (char)34 + "en" + (char)34 + " lang=" + (char)34 + "en" + (char)34 + ">");
        _code.AppendLine("	<head>");
        _code.AppendLine("		<title>" + _title + "</title>");
        _code.AppendLine("		<meta http-equiv=" + (char)34 + "content-type" + (char)34 + " content=" + (char)34 + "text/html; charset=UTF-8" + (char)34 + "/>");
        _code.AppendLine("		<style type=" + (char)34 + "text/css" + (char)34 + ">");
        _code.AppendLine("			body {background-color: white; } ");
        _code.AppendLine("			body, table { background-color: #E5E5E5; color: black; font-family: Calibri, Times, courrier ; font-size: 15px; } ");
        _code.AppendLine("			td.normalcell{background-color : white;}");
        _code.AppendLine("			tr.titlecell{background-color : #C5C5C5;}");
        _code.AppendLine("			tr.titlecellbold{background-color : #C5C5C5; font-weight: bold;}");
        _code.AppendLine("			b.title{text-align : center;}");
        _code.AppendLine("		</style>");
        _code.AppendLine("	</head>");
        _code.AppendLine("	<body>");
        _code.AppendLine("		<table width=" + (char)34 + "100%" + (char)34 + " border=" + (char)34 + "0" + (char)34 + " cellspacing=" + (char)34 + "1" + (char)34 + " cellpadding=" + (char)34 + "0" + (char)34 + ">");
        _code.AppendLine("			<tr class=" + (char)34 + "titlecell" + (char)34 + ">");
        _code.AppendLine("              <td width=" + (char)34 + System.Convert.ToString(_firstColSize) + "%" + (char)34 + ">");
        _code.AppendLine("                  <b class=" + (char)34 + " title" + (char)34 + "></b>");
        _code.AppendLine("              </td>");
        _code.AppendLine("              <td width=" + (char)34 + System.Convert.ToString(100 - _firstColSize) + "%" + (char)34 + ">");
        _code.AppendLine("                  <b class=" + (char)34 + " title" + (char)34 + "></b>");
        _code.AppendLine("              </td>");
        _code.AppendLine("          </tr>");
    }

    // Here we format HTML (ISO norm)
    private string normaliszeISOhtml(string innerText)
    {
        if (innerText != null)
        {
            innerText = innerText.Replace("&", "&#38;");
            innerText = innerText.Replace("<", "&#139;");
            innerText = innerText.Replace((char)34, "&#34;");
            innerText = innerText.Replace(">", "&#155;");
            return innerText;
        }
        else
            return Constants.vbNullString;
    }
}

