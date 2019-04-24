﻿' =======================================================
' Yet Another (remote) Process Monitor (YAPM)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yaprocmon/
' =======================================================


' YAPM is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' YAPM is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with YAPM; if not, see http://www.gnu.org/licenses/.

Option Strict On

Namespace Async


    ' Some async and threaf safe functions for the Listview control
    Public Class ListView
        Inherits System.Windows.Forms.ListView

        Private Delegate Function degAddItem(lv As ListView, text As String) As ListViewItem
        Public Shared Function AddItem(lv As System.Windows.Forms.ListView, text As String) As System.Windows.Forms.ListViewItem
            If lv.InvokeRequired Then
                Dim d As New degAddItem(AddressOf AddItem)
                Return CType(lv.Invoke(d, lv, text), ListViewItem)
            Else
                Dim it As ListViewItem = lv.Items.Add(text)
                Return it
            End If
        End Function

        Private Delegate Sub degChangeVirtualListSize(lv As System.Windows.Forms.ListView, value As Integer)
        Public Shared Sub ChangeVirtualListSize(lv As System.Windows.Forms.ListView, value As Integer)
            If lv.InvokeRequired Then
                Dim d As New degChangeVirtualListSize(AddressOf ChangeVirtualListSize)
                lv.Invoke(d, lv, value)
            Else
                lv.VirtualListSize = value
            End If
        End Sub

        Private Delegate Function degEnsureItemVisible(lv As System.Windows.Forms.ListView, text As String) As System.Windows.Forms.ListViewItem
        Public Shared Function EnsureItemVisible(lv As System.Windows.Forms.ListView, text As String) As System.Windows.Forms.ListViewItem
            If lv.InvokeRequired Then
                Dim d As New degEnsureItemVisible(AddressOf EnsureItemVisible)
                Return CType(lv.Invoke(d, lv, text), ListViewItem)
            Else
                Dim it As ListViewItem = lv.FindItemWithText(text)
                If it IsNot Nothing Then
                    it.Selected = True
                    it.EnsureVisible()
                End If
                Return it
            End If
        End Function

    End Class



    ' Some async and threaf safe functions for the ProgressBar control
    Public Class ProgressBar

        Private Delegate Sub degChangeValue(pgb As System.Windows.Forms.ProgressBar, value As Integer)
        Public Shared Sub ChangeValue(pgb As System.Windows.Forms.ProgressBar, value As Integer)
            If pgb.InvokeRequired Then
                Dim d As New degChangeValue(AddressOf ChangeValue)
                pgb.Invoke(d, pgb, value)
            Else
                pgb.Value = value
            End If
        End Sub

        Private Delegate Sub degChangeMaximum(pgb As System.Windows.Forms.ProgressBar, value As Integer)
        Public Shared Sub ChangeMaximum(pgb As System.Windows.Forms.ProgressBar, value As Integer)
            If pgb.InvokeRequired Then
                Dim d As New degChangeMaximum(AddressOf ChangeMaximum)
                pgb.Invoke(d, pgb, value)
            Else
                pgb.Maximum = value
            End If
        End Sub

    End Class



    ' Some async and threaf safe functions for the SplitContainer control
    Public Class SplitContainer

        Private Delegate Sub degChangeEnabled(tb As System.Windows.Forms.SplitContainer, value As Boolean)
        Public Shared Sub ChangeEnabled(tb As System.Windows.Forms.SplitContainer, value As Boolean)
            If tb.InvokeRequired Then
                Dim d As New degChangeEnabled(AddressOf ChangeEnabled)
                tb.Invoke(d, tb, value)
            Else
                tb.Enabled = value
            End If
        End Sub

    End Class


    ' Some async and threaf safe functions for the Form control
    Public Class Form

        Private Delegate Sub degChangeEnabled(frm As System.Windows.Forms.Form, value As Boolean)
        Public Shared Sub ChangeEnabled(frm As System.Windows.Forms.Form, value As Boolean)
            If frm.InvokeRequired Then
                Dim d As New degChangeEnabled(AddressOf ChangeEnabled)
                frm.Invoke(d, frm, value)
            Else
                frm.Enabled = value
            End If
        End Sub

    End Class

End Namespace
