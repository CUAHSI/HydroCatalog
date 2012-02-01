using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class manage_Default : System.Web.UI.Page
{
    AdminAccess AdminAccessIns = new AdminAccess();

    protected void Page_Init(object sender, EventArgs e)
    {
        GetCV11PendingSubmissions();
        GetCV10PendingSubmissions();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string CurrentUser = User.Identity.Name;
        string CurrentUserName = Profile.FirstName + " " + Profile.LastName;

        if(Roles.IsUserInRole("Moderator"))
        {

            Label NameLabel = (Label)LoginViewUser.FindControl("NameLabel");
                        
            if (CurrentUserName != " ")
                NameLabel.Text = CurrentUserName;
            else
                NameLabel.Text = CurrentUser;
        }
    }

    protected void GetCV10PendingSubmissions()
    {
        DataTable tableNames = null;
        DataTable myTable = null;
        //DataRow curRow = null;
        DataColumn curCol = null;
        BoundColumn myBoundCol = default(BoundColumn);
        TableRow tblRow = default(TableRow);
        TableCell tblCol = default(TableCell);
        int i_count = 0;
        Label myLbl = default(Label);
        string strColumns = null;
        DataTable columnTable = null;
        //DataRow curColRow = null;

        tableNames = AdminAccessIns.CV10Result("SELECT name, id FROM sysobjects " + "WHERE xtype = 'U' AND name LIKE 'temp_%' AND name <> 'temp_CVTESTER'");
        i_count = 1;

        if (tableNames.Rows.Count > 0)
        {
            foreach (DataRow curRow in tableNames.Rows)
            {
                DataGrid tempDG = default(DataGrid);
                columnTable = AdminAccessIns.CV10Result("SELECT name FROM syscolumns WHERE id = " + Convert.ToString(curRow[1]) + " AND name <> 'status' AND name <> 'action_flag' AND name <> 'time_stamp'");

                strColumns = "status";
                foreach (DataRow curColRowTemp in columnTable.Rows)
                {
                    strColumns = strColumns + "," + Convert.ToString(curColRowTemp[0].ToString());
                }
                DataRow curColRow = columnTable.Rows[0];

                myTable = AdminAccessIns.CV10Result("SELECT " + "'<a href=" + Convert.ToChar(34) + "viewCV.aspx?act=' + action_flag + '&tbl=" + Convert.ToString(curRow[0]) + "&tblid=" + Convert.ToString(curRow[1]) + "&id=' + convert(varchar," + Convert.ToString(curColRow[0]) + ") + '&time=' + " + "convert(varchar,time_stamp,109) + '" + Convert.ToChar(34) + ">' + convert(varchar,time_stamp,109) " + "+ '</a>' as [&nbsp;], " + "name as Submitter, '<a href=" + Convert.ToChar(34) + "mailto:'+email+'" + Convert.ToChar(34) + ">'+email+'</a>' AS [Email Address], reason as Reason, " + "CASE action_flag " + "WHEN 'A' THEN 'Add' " + "WHEN 'O' THEN 'Edit' " + "WHEN 'D' THEN 'Delete' END AS [Requested Change], " + curColRow[0].ToString() + " AS [ID/Term Affected] " + "FROM " + Convert.ToString(curRow[0]) + " WHERE status = 'submitted' AND action_flag <> 'E'");

                if (myTable.Rows.Count > 0)
                {
                    tempDG = new DataGrid();
                    tempDG.ID = "dg" + Convert.ToString(i_count);
                    tempDG.CellPadding = 8;
                    tempDG.CssClass = "CVDataGridStyle";
                    tempDG.HeaderStyle.CssClass = "DGHeader";
                    tempDG.AlternatingItemStyle.CssClass = "DGAltItem";
                    tempDG.AutoGenerateColumns = false;

                    myLbl = new Label();
                    myLbl.Text = "<h4>" + Convert.ToString(curRow[0]).Remove(0,5) + "</h4>";

                    foreach (DataColumn curColTemp in myTable.Columns)
                    {
                        if (curColTemp.ColumnName != "status")
                        {
                            myBoundCol = new BoundColumn();
                            myBoundCol.HeaderText = curColTemp.ColumnName;
                            myBoundCol.DataField = curColTemp.ColumnName;
                            tempDG.Columns.Add(myBoundCol);
                        }
                    }

                    tempDG.DataSource = myTable;
                    tempDG.DataBind();

                    //CV table name:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Controls.Add(myLbl);
                    tblRow.Cells.Add(tblCol);
                    cv10Subs.Rows.Add(tblRow);

                    //CV datagrid:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Controls.Add(tempDG);
                    tblRow.Cells.Add(tblCol);
                    cv10Subs.Rows.Add(tblRow);

                    //Space between tables:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Text = "&nbsp;";
                    tblRow.Cells.Add(tblCol);
                    cv10Subs.Rows.Add(tblRow);

                    i_count = i_count + 1;
                }
            }
        }
    }

    protected void GetCV11PendingSubmissions()
    {
        DataTable tableNames = null;
        DataTable myTable = null;
        //DataRow curRow = null;
        DataColumn curCol = null;
        BoundColumn myBoundCol = default(BoundColumn);
        TableRow tblRow = default(TableRow);
        TableCell tblCol = default(TableCell);
        int i_count = 0;
        Label myLbl = default(Label);
        string strColumns = null;
        DataTable columnTable = null;
        //DataRow curColRow = null;

        tableNames = AdminAccessIns.CV11Result("SELECT name, id FROM sysobjects " + "WHERE xtype = 'U' AND name LIKE 'temp_%' AND name <> 'temp_CVTESTER'");
        i_count = 1;

        if (tableNames.Rows.Count > 0)
        {
            foreach (DataRow curRow in tableNames.Rows)
            {
                DataGrid tempDG = default(DataGrid);
                columnTable = AdminAccessIns.CV11Result("SELECT name FROM syscolumns WHERE id = " + Convert.ToString(curRow[1]) + " AND name <> 'status' AND name <> 'action_flag' AND name <> 'time_stamp'");

                strColumns = "status";
                foreach (DataRow curColRowTemp in columnTable.Rows)
                {
                    strColumns = strColumns + "," + Convert.ToString(curColRowTemp[0].ToString());
                }
                DataRow curColRow = columnTable.Rows[0];

                myTable = AdminAccessIns.CV11Result("SELECT " + "'<a href=" + Convert.ToChar(34) + "viewCV.aspx?act=' + action_flag + '&tbl=" + Convert.ToString(curRow[0]) + "&tblid=" + Convert.ToString(curRow[1]) + "&id=' + convert(varchar," + Convert.ToString(curColRow[0]) + ") + '&time=' + " + "convert(varchar,time_stamp,109) + '" + Convert.ToChar(34) + ">' + convert(varchar,time_stamp,109) " + "+ '</a>' as [&nbsp;], " + "name as Submitter, '<a href=" + Convert.ToChar(34) + "mailto:'+email+'" + Convert.ToChar(34) + ">'+email+'</a>' AS [Email Address], reason as Reason, " + "CASE action_flag " + "WHEN 'A' THEN 'Add' " + "WHEN 'O' THEN 'Edit' " + "WHEN 'D' THEN 'Delete' END AS [Requested Change], " + curColRow[0].ToString() + " AS [ID/Term Affected] " + "FROM " + Convert.ToString(curRow[0]) + " WHERE status = 'submitted' AND action_flag <> 'E'");

                if (myTable.Rows.Count > 0)
                {
                    tempDG = new DataGrid();
                    tempDG.ID = "dg" + Convert.ToString(i_count);
                    tempDG.CellPadding = 8;
                    tempDG.CssClass = "CVDataGridStyle";
                    tempDG.HeaderStyle.CssClass = "DGHeader";
                    tempDG.AlternatingItemStyle.CssClass = "DGAltItem";
                    tempDG.AutoGenerateColumns = false;

                    myLbl = new Label();
                    myLbl.Text = "<h4>" + Convert.ToString(curRow[0]).Remove(0, 5) + "</h4>";


                    foreach (DataColumn curColTemp in myTable.Columns)
                    {
                        if (curColTemp.ColumnName != "status")
                        {
                            myBoundCol = new BoundColumn();
                            myBoundCol.HeaderText = curColTemp.ColumnName;
                            myBoundCol.DataField = curColTemp.ColumnName;
                            tempDG.Columns.Add(myBoundCol);
                        }
                    }

                    tempDG.DataSource = myTable;
                    tempDG.DataBind();

                    //CV table name:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Controls.Add(myLbl);
                    tblRow.Cells.Add(tblCol);
                    cv11Subs.Rows.Add(tblRow);

                    //CV datagrid:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Controls.Add(tempDG);
                    tblRow.Cells.Add(tblCol);
                    cv11Subs.Rows.Add(tblRow);

                    //Space between tables:
                    tblRow = new TableRow();
                    tblCol = new TableCell();
                    tblCol.Text = "&nbsp;";
                    tblRow.Cells.Add(tblCol);
                    cv11Subs.Rows.Add(tblRow);

                    i_count = i_count + 1;
                }
            }
        }            
    }
}
