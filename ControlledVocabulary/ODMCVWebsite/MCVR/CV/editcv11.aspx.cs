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

public partial class CV_editcv11 : System.Web.UI.Page
{
    private cv11Access CV11AccessIns = new cv11Access();
    private static string Action = string.Empty;
    private string CurrentCVName = string.Empty;
    private DataTable CurrentEntry = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["tbl"] != null)
        {
            CurrentCVName = Request.QueryString["tbl"].ToString();
            NameLabel.Text = CurrentCVName + " Values - ";
            DescriptionLabel.Text = CV11AccessIns.GetCVDescription(Request.QueryString["tbl"].ToString());
        }
        else
        {
            NameLabel.Text = "Not a valid Vocabulary selection. Please go back to Controlled Vocabulary list and click on the relevant entry.";
        }

        if (User.Identity.IsAuthenticated)
        {
            txtName.Text = Profile.FirstName + " " + Profile.LastName;
            txtEmail.Text = Membership.GetUser(User.Identity.Name).Email;
        }

    }
    protected void CV10Contents_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TableName = CurrentCVName;
        string SelectedField = "Term";
        string SelectedFieldValue = CV10Contents.SelectedRow.Cells[1].Text.ToString();
        int SelectedValueInteger;

        switch (TableName)
        {
            case "QualityControlLevels":
                SelectedField = "QualityControlLevelID";
                SelectedValueInteger = Convert.ToInt32(SelectedFieldValue);
                CurrentEntry = CV11AccessIns.GetSelectedCV(TableName, SelectedField, SelectedValueInteger);
                break;

            case "SpatialReferences":
                SelectedField = "SpatialReferenceID";
                SelectedValueInteger = Convert.ToInt32(SelectedFieldValue);
                CurrentEntry = CV11AccessIns.GetSelectedCV(TableName, SelectedField, SelectedValueInteger);
                break;

            case "Units":
                SelectedField = "UnitsID";
                SelectedValueInteger = Convert.ToInt32(SelectedFieldValue);
                CurrentEntry = CV11AccessIns.GetSelectedCV(TableName, SelectedField, SelectedValueInteger);
                break;

            default:
                CurrentEntry = CV11AccessIns.GetSelectedCV(TableName, SelectedField, SelectedFieldValue);
                break;
        }

        if (CurrentEntry != null)
        {
            Action = "Edit";
            BindVaribale_EditBox(Action);
        }
    }

    protected void BindVaribale_EditBox(string EditMode)
    {
        Label currentLabel = new Label();
        TextBox currentTextBox = new TextBox();
        Label currentTextLabel = new Label();
        DropDownList currentDDList = new DropDownList();

        if (CurrentEntry.Rows.Count > 0)
        {
            foreach (DataRow currentRow in CurrentEntry.Rows)
            {
                int ControlCount = 1;
                foreach (DataColumn Field in CurrentEntry.Columns)
                {
                    currentLabel = (Label)EditVariablePanel.FindControl("lbl" + Convert.ToString(ControlCount).ToString());

                    if (Field.ColumnName == "IsGeographic")
                    {
                        currentDDList = (DropDownList)EditVariablePanel.FindControl("ddl1");
                        currentDDList.Visible = true;
                        reg1.Enabled = true;

                        currentTextLabel = (Label)EditVariablePanel.FindControl("lblEdit" + Convert.ToString(ControlCount).ToString());

                        if (EditMode != "Add" && EditMode != null)
                        {
                            if (currentRow[Field].ToString() == "True")
                            {
                                currentDDList.SelectedIndex = 0;
                                currentTextLabel.Text = "True";
                            }
                            else
                            {
                                currentDDList.SelectedIndex = 1;
                                currentTextLabel.Text = "False";
                            }
                        }
                    }
                    else
                    {
                        currentTextBox = (TextBox)EditVariablePanel.FindControl("txt" + Convert.ToString(ControlCount).ToString());
                        currentTextLabel = (Label)EditVariablePanel.FindControl("lblEdit" + Convert.ToString(ControlCount).ToString());

                        currentTextBox.MaxLength = Field.MaxLength / 2;
                        if (Field.DataType == System.Type.GetType("System.Int32"))
                            currentTextBox.MaxLength = 14;
                        else if (Field.MaxLength > 100)
                        {
                            currentTextBox.TextMode = TextBoxMode.MultiLine;
                            currentTextBox.Rows = 4;
                        }
                        currentTextBox.Text = "";
                        currentTextBox.ReadOnly = false;
                        currentTextBox.Visible = true;

                        if (ControlCount == 1)
                        {
                            if (Field.DataType == System.Type.GetType("System.Int32"))
                            {
                                if (EditMode == "Add")
                                {
                                    currentTextBox.Text = (CV11AccessIns.GetTableMaxValue(CurrentCVName, Field.ColumnName.ToString())).ToString();
                                }
                                currentTextBox.Enabled = false;
                            }
                        }

                        if (EditMode != "Add" && EditMode != null)
                        {
                            if (currentRow[Field].ToString() != null)
                            {
                                currentTextBox.Text = (currentRow[Field].ToString());
                                currentTextLabel.Text = (currentRow[Field].ToString());
                            }
                        }
                    }
                    currentLabel.Text = Field.ColumnName.ToString();
                    currentLabel.Visible = true;
                    ControlCount++;
                }
            }
        }
        SetUpControls(CurrentCVName);
        CV10Display.Visible = false;
        EditSelectedCV.Visible = true;
    }

    protected void SetUpControls(string TableName)
    {
        req1.Enabled = true;
        txtReason.Text = "";
        pnlMsg.Visible = false;
        pnlReturn.Visible = false;

        switch (TableName)
        {
            case "QualityControlLevels":
                req3.Enabled = true;
                break;

            case "SpatialReferences":
                req2.Enabled = true;
                req3.Enabled = true;
                break;

            case "Units":
                req2.Enabled = true;
                req3.Enabled = true;
                req4.Enabled = true;
                break;

            default:
                break;
        }

        if (Action == "Add")
        {
            CheckDelete.Enabled = false;
            CheckDelete.Visible = false;
        }
        else
        {
            CheckDelete.Enabled = true;
            CheckDelete.Visible = true;
        }

    }

    protected void AddEntryButton_Click(object sender, EventArgs e)
    {
        Action = "Add";
        CurrentEntry = CV11AccessIns.GetSelectedCV_BeginningEntry(CurrentCVName);

        if (CurrentEntry != null)
        {
            BindVaribale_EditBox(Action);
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        EditSelectedCV.Visible = false;
        CV10Display.Visible = true;
    }

    protected void BackToEntryButton_Click(object sender, EventArgs e)
    {
        EditSelectedCV.Visible = false;
        pnlMsg.Visible = false;
        CV10Display.Visible = true;
    }


    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        Label currentLabel = new Label();
        TextBox currentTextBox = new TextBox();
        DropDownList currentDDList = new DropDownList();
        DateTime CurrentTime = DateTime.Now;
        string CurrentAction = Action;

        int ControlCount = 1;
        string UpdateFields = "", EditFields = "";

        if ((CheckDelete.Visible == true) && CheckDelete.Checked)
            CurrentAction = "Delete";
        else
            CurrentAction = Action;

        foreach (Control CurrentControl in EditVariablePanel.Controls)
        {
            string type = CurrentControl.GetType().ToString();
            if ((CurrentControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox") && (CurrentControl.Visible == true))
            {
                currentTextBox = (TextBox)EditVariablePanel.FindControl("txt" + Convert.ToString(ControlCount).ToString());

                if ((currentTextBox != null) && (currentTextBox.Visible == true))
                {
                    currentLabel = (Label)EditVariablePanel.FindControl("lblEdit" + Convert.ToString(ControlCount).ToString());

                    UpdateFields += "'" + CV11AccessIns.FormatForSql(currentTextBox.Text.ToString()) + "',";
                    EditFields += "'" + CV11AccessIns.FormatForSql(currentLabel.Text.ToString()) + "',";
                    ControlCount++;
                }
            }
            else if ((CurrentControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList") && (CurrentControl.Visible == true))
            {
                currentDDList = (DropDownList)EditVariablePanel.FindControl("ddl1");

                if (currentDDList.Visible == true)
                {
                    currentLabel = (Label)EditVariablePanel.FindControl("lblEdit" + Convert.ToString(ControlCount).ToString());

                    UpdateFields += "'" + CV11AccessIns.FormatForSql(currentDDList.SelectedValue.ToString()) + "',";
                    EditFields += "'" + CV11AccessIns.FormatForSql(currentLabel.Text.ToString()) + "',";
                    ControlCount++;

                }
            }
        }

        try
        {
            switch (CurrentAction)
            {
                case "Delete":
                    EditFields += "'submitted','" + "D" + "','" + CurrentTime + "','"
                        + CV11AccessIns.FormatForSql(txtReason.Text.ToString()) + "','" + CV11AccessIns.FormatForSql(txtName.Text.ToString()) + "','"
                        + CV11AccessIns.FormatForSql(txtEmail.Text.ToString()) + "',null";
                    CV11AccessIns.InsertIntoTempCV(CurrentCVName, EditFields);
                    break;
                case "Edit":
                    UpdateFields += "'submitted','" + "E" + "','" + CurrentTime + "','"
                        + CV11AccessIns.FormatForSql(txtReason.Text.ToString()) + "','" + CV11AccessIns.FormatForSql(txtName.Text.ToString()) + "','"
                        + CV11AccessIns.FormatForSql(txtEmail.Text.ToString()) + "',null";
                    CV11AccessIns.InsertIntoTempCV(CurrentCVName, UpdateFields);

                    EditFields += "'submitted','" + "O" + "','" + CurrentTime + "','"
                       + CV11AccessIns.FormatForSql(txtReason.Text.ToString()) + "','" + CV11AccessIns.FormatForSql(txtName.Text.ToString()) + "','"
                       + CV11AccessIns.FormatForSql(txtEmail.Text.ToString()) + "',null";
                    CV11AccessIns.InsertIntoTempCV(CurrentCVName, EditFields);
                    break;
                case "Add":
                    UpdateFields += "'submitted','" + "A" + "','" + CurrentTime + "','"
                       + CV11AccessIns.FormatForSql(txtReason.Text.ToString()) + "','" + CV11AccessIns.FormatForSql(txtName.Text.ToString()) + "','"
                       + CV11AccessIns.FormatForSql(txtEmail.Text.ToString()) + "',null";
                    CV11AccessIns.InsertIntoTempCV(CurrentCVName, UpdateFields);
                    break;
                default:
                    break;
            }

            lblMsg.Text = "Your changes have been submitted successfully. An ODM administrator will need to approve these changes before they take affect.";
            lblMsg.ForeColor = System.Drawing.Color.DarkBlue;
            pnlMsg.Visible = true;
            EditSelectedCV.Visible = false;
            pnlReturn.Visible = true;


        }
        catch (Exception exp)
        {
            lblMsg.Text = "An error occured while updating Controlled Vocabularies. Please check entries and try again";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            pnlMsg.Visible = true;
        }

    }
}
