using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CUAHSI = hiscentral_2010.CUAHSI;

public partial class testpage : System.Web.UI.Page
{
    
    CUAHSI.WaterOneFlow m_service = new CUAHSI.WaterOneFlow();


    System.Data.DataTable dt = null;
    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
        ///System.Net.WebProxy proxy = new System.Net.WebProxy();
        //proxy.Address = new Uri("http://localhost:8888");
        //m_service.Proxy = proxy;

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Request.Params.Get("ShowResult")!=null){
        //    Object xmlResult = Session["xmlResult"];
        //    if (xmlResult.ToString() != "")
        //    {
        //        Response.ContentType = "text/xml";
        //        Response.Write((String)(xmlResult));
        //        Response.Close();
        //    }
        //    else {
        //        Response.ContentType = "text/text";
        //        Response.Write("nothing to say");
        //        Response.Close();
        //    }

        //}
        if (Session["NetworkID"] != null)
        {
          this.getNetworkInfo(Session["NetworkID"].ToString());

        }
        else {
            Response.Redirect("default.aspx");
        }
        if (!IsPostBack)
        {




            //string[] keys = appSettings [.AllKeys;
            //string keypair, key, val, prefix;
            //for (int i = 0; i < ConfigurationManager.AppSettings.Count; i++)
            //{
            //    keypair = ConfigurationManager.AppSettings.GetKey(i);
            //    if (keypair.IndexOf('~') > -1)
            //    {
            //        prefix = keypair.Split('~')[0];
            //        key = keypair.Split('~')[1];

            //        if (prefix.Equals("WS"))
            //        {
            //            val = ConfigurationManager.AppSettings[keypair];
            //            ListItem li = new ListItem(key, val);
            //            this.ddlURLS.Items.Add(li);
            //        }
            //        if (prefix.Equals("ID"))
            //        {
            //            val = ConfigurationManager.AppSettings[keypair];
            //            ListItem li = new ListItem(key, val);
            //            this.ddlSiteIDS.Items.Add(li);
            //        }
            //    }
            //}
            ////this.ddlURLS.SelectedIndex = 0;
            //GetVariableList();
            //this.getSiteInfo();
            this.calEnd.SelectedDate = DateTime.Now;
            this.calStart.SelectedDate = DateTime.Now.Add(new TimeSpan(-3, 0, 0, 0));
            this.setVisibleLevel(0);

        }


    }
  private void getNetworkInfo(string netid)
  {
    String sql = "Select ServiceWSDL, NetworkName from HISNetworks where networkid = " + netid;
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(constring);
    //con.Open();
    string netname = "";
    string netwsdl = "";
    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "network");
    }
    con.Close();
    //should be only one
    foreach (DataRow dataRow in ds.Tables["network"].Rows)
    {
      netwsdl = dataRow[0].ToString();
      netname = dataRow[1].ToString();
    }
    this.LabelNetworkname.Text = netname; // Session["NetworkName"].ToString();
    this.LabelNetworkWSDL.Text = netwsdl; // Session["NetworkWSDL"].ToString();
  }
  private void getSeriesForThisService()
  {
    //GetVariableList();
    // this..Text = this.ddlURLS.SelectedValue;
    //Session["serviceURL"] = this.ddlURLS.SelectedValue;
    this.GetSeriesList();
    setVisibleLevel(2);

  }
    protected void ddlURLS_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void GetSeriesList()
    {
        Object sr = Session["siteResponse"];
        if (sr != null)
        {
            SitesResponse sites = (SitesResponse)sr;
            SitesResponse.Series[] serieslist = sites.getSeriesCatalogs()[0].a_series;


            this.ddlVariables.Items.Clear();
            //string txt, val;
            dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Units");
            String code, name, desc, units;
            this.ddlVariables.Items.Clear();
            //System.Data.DataRow row = dt.NewRow();
            for (int i = 0; i < serieslist.Length; i++)
            {
                //CUAHSI.VariableInfoType vit = vrt.variables[i];


                //name = vrt.variables[i].variableName;
                name = serieslist[i].vtype.name;
                desc = serieslist[i].vtype.desc;
                //code = vrt.variables[i].
                code = serieslist[i].vtype.code.Vocabulary;
                code += ":" + serieslist[i].vtype.code.value;
                ddlVariables.Items.Add(code);
                units = serieslist[i].vtype.units.value;// vrt.variables[i].units.Value;
                dt.Rows.Add(code, name, desc, units);

            }
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
    }
    private void GetVariableList()
    {
        //m_service.
        m_service.Url = this.LabelNetworkWSDL.Text;
        m_service.Url = m_service.Url.ToLower().Replace("?wsdl", "");
            //this.lblWebServiceURL.Text = this.ddlURLS.SelectedValue;
        try
        {
            CUAHSI.VariablesResponseType vrt = m_service.GetVariableInfoObject(null, null);
            String xmlResult = TestUtils.ConvertToXml(vrt, typeof(CUAHSI.VariablesResponseType));
            Session["xmlResult"] = xmlResult;

            this.ddlVariables.Items.Clear();
            //string txt, val;
            dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Units");
            String code, name, desc, units;
            this.ddlVariables.Items.Clear();
            //System.Data.DataRow row = dt.NewRow();
            for (int i = 0; i < vrt.variables.Length; i++)
            {
                //CUAHSI.VariableInfoType vit = vrt.variables[i];
                name = vrt.variables[i].variableName;
                desc = vrt.variables[i].variableDescription;
                //code = vrt.variables[i].
                code = vrt.variables[i].variableCode[0].vocabulary;
                code += ":" + vrt.variables[i].variableCode[0].Value;
                ddlVariables.Items.Add(code);
                units = vrt.variables[i].units.Value;
                dt.Rows.Add(code, name, desc, units);

            }

            //this.txtResults.Text = xmlResult;
            //VariableTypes myTypes = new VariableTypes(xmlResult);
            //VariableType vt;
            //VariableType[] vts = myTypes.getVariables();
            //for (int i = 0; i < vts.Length;  i++){
            //    vt = vts[i];
            //    vt.
            //}
            //this.txtResults.Text = xmlResult;
            //this.Literal1.Text = "<Textarea size=20 width=500 height=20 >" + xmlResult + "</textarea>";
            //this.Literal1.Text = "<IFRAME width=100% height=100% src=resultsXML.ashx />";

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
        catch (System.Web.Services.Protocols.SoapException se)
        {
            this.txtResults.Text = se.StackTrace;
        }

    }

    protected void btnGetValues_Click(object sender, EventArgs e)
    {
        try
        {
            String location = this.ddlSiteIDS.SelectedValue;
            String startdate = ((chkStart.Checked) ? TestUtils.getStringFromDate(calStart.SelectedDate) : null);
            String enddate = ((chkEnd.Checked) ? TestUtils.getStringFromDate(calEnd.SelectedDate) : null);
            m_service.Url = this.LabelNetworkWSDL.Text;
            String results = m_service.GetValues(location, this.ddlVariables.SelectedValue, startdate, enddate, null);

            string vresults = System.Web.HttpUtility.HtmlEncode(results);
            vresults = vresults.Replace("&lt;\\", "<br>&gt;\\");
            vresults = vresults.Replace("\\&gt;", "\\&gt;<br>");
            this.txtResults.Text = vresults;
            TimeSeries ts = new TimeSeries(results);
            TimeValue[] tvs = ts.getValues();
            //tvs[0]
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Date_Time");
            dt2.Columns.Add(ts.getVariable().units.value);
            for (int i = 0; i < tvs.Length; i++)
            {
                dt2.Rows.Add(tvs[i].time, tvs[i].val);
            }
            this.GridView2.DataSource = dt2;
            this.GridView2.DataBind();
            setVisibleLevel(4);
        }
        catch (System.Web.Services.Protocols.SoapException se)
        {
            showInputError("SoapException - see trace below");
            this.txtResults.Text = se.Message + "\n\n" + se.StackTrace;
        }
    }
    private void setVisibleLevel(int level)
    {
        this.lblError.Text = "";
        this.lblError.Visible = false;

        //this.lblService.Visible = level > 0;
        //this.ddlURLS.Visible            = level > 0;
        //this.btnShowVariables.Visible   = level > 0;
        //this.Label3.Visible             = level > 0;
        //this.lblWebServiceURL.Visible   = level > 0;




        this.Label7.Visible = level > 1;
        this.GridView1.Visible = level > 1;
        this.Panel1.Visible = level > 1;
        this.lblSiteInfo.Visible = level > 1;
        this.lblGeolocation.Visible = level > 1;

        this.txtResults.Visible = level > 1;
        this.Label5.Visible = level > 1;



        this.lblDateRange.Visible = level > 2;
        this.lblVariable.Visible = level > 2;
        this.chkStart.Visible = level > 2;
        this.chkEnd.Visible = level > 2;
        this.calEnd.Visible = level > 2;
        this.calStart.Visible = level > 2;
        this.btnEnd.Visible = level > 2;
        this.btnStart.Visible = level > 2;
        this.btnGetValues.Visible = level > 2;
        this.txtEnd.Visible = level > 2;
        this.txtStart.Visible = level > 2;
        this.Panel2.Visible = level > 3;

        this.pnl2.Visible = level > 0;
        this.pnl3.Visible = level > 1;
        this.pnl4.Visible = level > 2;

        this.pnl1.BackColor = (level == 0) ? System.Drawing.Color.LightSteelBlue : System.Drawing.Color.Empty;
        this.pnl2.BackColor = (level == 1) ? System.Drawing.Color.LightSteelBlue : System.Drawing.Color.Empty;
        this.pnl3.BackColor = (level == 2) ? System.Drawing.Color.LightSteelBlue : System.Drawing.Color.Empty;
        this.pnl4.BackColor = (level == 3) ? System.Drawing.Color.LightSteelBlue : System.Drawing.Color.Empty;




    }
    private void showInputError(String msg)
    {
        this.lblError.Visible = true;
        this.lblError.Text = msg;
    }
    private void getSites() {
        m_service.Url = this.LabelNetworkWSDL.Text;
        this.ddlSiteIDS.Items.Clear();
        int i;
        try

        {
            string[] sites = new string[0];

            //string siteinfoxml = m_service.GetSitesXml(sites,"");
            CUAHSI.SiteInfoResponseType sirt = m_service.GetSites(sites, "");
            string sitecode, sitename;
            ListItem li;
            for (i = 0; i < sirt.site.Length; i++) {

                sitecode = sirt.site[i].siteInfo.siteCode[0].Value;
                
                sitename = sirt.site[i].siteInfo.siteName.ToString();
                li = new ListItem(sitecode +":"+sitename,this.LabelNetworkname.Text + ":" + sitecode);
                this.ddlSiteIDS.Items.Add(li);
                if (i > 100) break;
            }

        }
        catch (Exception e)
        {
            this.lblError.Text = e.Message;
            this.txtResults.Text = e.StackTrace;
            this.lblError.Visible = true;
            Session["siteResponse"] = null;
        }
    }

    private void getSiteInfo(String id)
    {
        m_service.Url = this.LabelNetworkWSDL.Text;
        try
        {
            string siteinfoxml = m_service.GetSiteInfo(id, null);
            
            string vresults = System.Web.HttpUtility.HtmlEncode(siteinfoxml);
            vresults = vresults.Replace("&lt;\\","<br>&gt;\\");
            vresults = vresults.Replace("\\&gt;","\\&gt;<br>");
            this.txtResults.Text = vresults;
            
            SitesResponse sResponse = new SitesResponse(siteinfoxml);

            //this.ddlURLS.Items.Clear();
            //this.ddlURLS.Enabled = true;
            SitesResponse.SeriesCatalog[] catalogs = sResponse.getSeriesCatalogs();
            Session["siteResponse"] = sResponse;
            //String key,val;
            //for (int i = 0; i < catalogs.Length; i++) {
            //    key = catalogs[i].menuGroupName;
            //    val = catalogs[i].wsdl;
            //    ddlURLS.Items.Add(new ListItem(key, val));

            //}
            //ddlURLS.SelectedIndex = 0;
            //this.lblWebServiceURL.Text = this.ddlURLS.SelectedValue;
            this.lblSiteInfo.Text = sResponse.getSiteInfo().siteName;
            this.lblGeolocation.Text = "" + sResponse.getSiteInfo().loc.lat + "," + sResponse.getSiteInfo().loc.lng;
        }
        catch (Exception e)
        {
            this.lblError.Text = e.Message;
            this.txtResults.Text = e.StackTrace;
            this.lblError.Visible = true;
            Session["siteResponse"] = null;
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlVariables.SelectedIndex = GridView1.SelectedIndex;
        TableCellCollection cells = GridView1.SelectedRow.Cells;

        this.lblVariable.Text = cells[2].Text + ", " + cells[4].Text;
        SitesResponse sResponse = (SitesResponse)Session["siteResponse"];
        SitesResponse.Series series = sResponse.getSeriesCatalogs()[0].a_series[ddlVariables.SelectedIndex];
        if (!series.isRealTime)
        {

            this.calStart.SelectedDate = TestUtils.getDateFromString(series.startDateTime);
            this.calEnd.SelectedDate = TestUtils.getDateFromString(series.endDateTime);

            this.calStart_SelectionChanged(sender, e);
            this.calEnd_SelectionChanged(sender, e);
            calEnd.VisibleDate = calEnd.SelectedDate;
            calStart.VisibleDate = calStart.SelectedDate;
            chkStart.Checked = true;
            chkEnd.Checked = true;
            this.lblDateRange.Text = this.txtStart.Text + " - " + this.txtEnd.Text;
        }
        else
        {
            chkStart.Checked = false;
            chkEnd.Checked = false;
        }
        setVisibleLevel(3);
    }


    protected void btnGetSiteInfo_Click(object sender, EventArgs e)
    {
        String id = "";

            id = this.ddlSiteIDS.SelectedValue;
        
        int colonIdx = id.IndexOf(':');
        this.GridView1.DataSource = null;
        this.GridView1.DataBind();
        if (colonIdx > 2)
        {
            //String prefix = id.Substring(0, colonIdx).ToUpper();
            //switch (prefix)
            //{
            //    case "EPA":
            //        Session["serviceURL"]= "http://water.sdsc.edu/wateroneflow/EPA/cuahsi_1_0.asmx";                    
            //        getSiteInfo(id);
            //        ddlURLS_SelectedIndexChanged(sender, e);
            //        setVisibleLevel(1);
            //        break;
            //    case "NWIS":
            //        Session["serviceURL"] = "http://water.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx";
            //        getSiteInfo(id);
            //        ddlURLS_SelectedIndexChanged(sender, e);
            //        setVisibleLevel(1);
            //        break;
            //    default:
            //        getSiteInfo(id);

            //        //showInputError("Invalid Site ID");
            //        break;
            //}


            getSiteInfo(id);
            getSeriesForThisService();
        }
        else
        {
            showInputError("Site ID must be prefixed with proper Network information. ");
        }



    }



    protected void calStart_SelectionChanged(object sender, EventArgs e)
    {
        this.txtStart.Text = TestUtils.getStringFromDate(calStart.SelectedDate);
        this.lblDateRange.Text = this.txtStart.Text + " - " + this.txtEnd.Text;
        setVisibleLevel(3);
    }
    protected void calEnd_SelectionChanged(object sender, EventArgs e)
    {
        this.txtEnd.Text = TestUtils.getStringFromDate(calEnd.SelectedDate);
        this.lblDateRange.Text = this.txtStart.Text + " - " + this.txtEnd.Text;
        setVisibleLevel(3);
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        DateTime dt = TestUtils.getDateFromString(this.txtStart.Text);
        if (dt != null)
        {
            calStart.SelectedDate = dt;
            calStart.VisibleDate = dt;

        }
        this.lblDateRange.Text = this.txtStart.Text + " - " + this.txtEnd.Text;
        setVisibleLevel(3);

    }
    protected void btnEnd_Click(object sender, EventArgs e)
    {

        DateTime dt = TestUtils.getDateFromString(this.txtEnd.Text);
        if (dt != null)
        {
            calEnd.SelectedDate = dt;
            calEnd.VisibleDate = dt;

        }
        this.lblDateRange.Text = this.txtStart.Text + " - " + this.txtEnd.Text;
        setVisibleLevel(3);
    }
    protected void btnShowVariables_Click(object sender, EventArgs e)
    {
        //getSeriesForThisService();
    }
    protected void ddlVariables_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnConnect_Click(object sender, EventArgs e)
    {
        setVisibleLevel(1);

        this.getSites();


       




    }
    private void PopulateSampleSites(String network)
    {
        string keypair, key, val, prefix, vocab;
        this.ddlSiteIDS.Items.Clear();
        for (int i = 0; i < ConfigurationManager.AppSettings.Count; i++)
        {
            keypair = ConfigurationManager.AppSettings.GetKey(i);
            if (keypair.IndexOf('~') > -1)
            {
                prefix = keypair.Split('~')[0];
                key = keypair.Split('~')[1];



                if (prefix.Equals("ID"))
                {
                    vocab = key.Split(':')[0];
                    if (vocab == network)
                    {
                        val = ConfigurationManager.AppSettings[keypair];
                        ListItem li = new ListItem(val, val);
                        this.ddlSiteIDS.Items.Add(li);

                    }
                }
            }
        }

            this.ddlSiteIDS.Visible = true;

    }

}
