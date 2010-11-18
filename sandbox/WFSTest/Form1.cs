﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace WFSTest
{
    public partial class Form1 : Form
    {
        List<WFSServiceInfo> _wfsList;
       
        int _hitsCount;
       
        string _bboxField = "Shape";
        string _siteCodeField = "SiteCode";
        string _conceptField = "Concept";
        string _valueCountField = "ValueCount";
        
        BackgroundWorker bgWorker;

        public Form1()
        {
            InitializeComponent();
            _wfsList = new List<WFSServiceInfo>();

            pgbQuery.Style = ProgressBarStyle.Marquee;
            pgbQuery.MarqueeAnimationSpeed = 30;
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(performWFSGetFeatures);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!chkHits.Checked)
                displayResults();
            else
                MessageBox.Show("This request will return "+_hitsCount.ToString()+(_hitsCount != 1?" hits.":" hit."),"Information");
            
            btnQuery.Enabled = true;
            btnExport.Enabled = !chkHits.Checked;
            btnGetRecords.Enabled = true;
            pgbQuery.Visible = false;
            setFilterChecksEnabled(true);
        }

        private void performWFSGetFeatures(object sender, DoWorkEventArgs e)
        {
            _hitsCount = 0;
            foreach (WFSServiceInfo wfsService in _wfsList)
            {
                string typeName = wfsService.Namespace + ':' + wfsService.TypeName;

                string resultType = chkHits.Checked ? "hits" : "results";

                HttpGetRequest wfsGetFeatureRequest = new HttpGetRequest(wfsService.WFSEndpoint);
                wfsGetFeatureRequest.paramTable = new Hashtable();

                wfsGetFeatureRequest.paramTable.Add("request", "GetFeature");
                wfsGetFeatureRequest.paramTable.Add("service", "WFS");
                wfsGetFeatureRequest.paramTable.Add("resultType", resultType);
                wfsGetFeatureRequest.paramTable.Add("typeName", typeName);

                if (isAFilterChecked())
                {
                    string filterString = buildGetFeatureFilters(wfsService);
                    wfsGetFeatureRequest.paramTable.Add("filter", filterString);
                }

                using (HttpWebResponse response = wfsGetFeatureRequest.IssueRequest())
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    if (chkHits.Checked) //Just get the number of hits from each one and sum
                    {
                        XPathDocument docNav = new XPathDocument(reader);
                        XPathNavigator nav = docNav.CreateNavigator();
                        XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                        manager.AddNamespace("wfs", "http://www.opengis.net/wfs");
                        XPathNodeIterator NodeIter = nav.Select("//wfs:FeatureCollection", manager);
                        while (NodeIter.MoveNext())
                        {
                            _hitsCount += int.Parse(NodeIter.Current.GetAttribute("numberOfFeatures", ""));
                        }
                    }
                    else //Then display all the results 
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(reader);
                        if (ds.Tables[wfsService.TypeName] != null)
                        {
                            DataTable temp = ds.Tables[wfsService.TypeName];
                            if (chkDateRange.Checked)
                            {
                                temp = FilterDates(temp);
                            }
                            wfsService.Data = temp;
                        }
                        else
                        {
                            wfsService.Data = new DataTable();
                        }
                    }
                }

            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            tcResults.TabPages.Clear();
            pgbQuery.Visible = true;
            btnQuery.Enabled = false;
            btnExport.Enabled = false;
            btnGetRecords.Enabled = false;
            setFilterChecksEnabled(false);
            bgWorker.RunWorkerAsync();
        }

        private void displayResults()
        {
            foreach (WFSServiceInfo wfs in _wfsList)
            {
                TabPage newTabPage = new TabPage(wfs.TypeName + " : " + wfs.Data.Rows.Count);
                DataGridView newDgv = new DataGridView();
                newDgv.Size = new Size(832, 444);
                newDgv.Location = new Point(6, 6);
                newDgv.DataSource = wfs.Data;
                newDgv.ReadOnly = true;
                

                newTabPage.Controls.Add(newDgv);
                tcResults.TabPages.Add(newTabPage);
            }
        }

        private DataTable FilterDates(DataTable dtc)
        {
            DateTime startDate = DateTime.Parse(dtpStartDate.Text);
            DateTime endDate = DateTime.Parse(dtpEndDate.Text);

            List<DataRow> rowsToRemove = new List<DataRow>();

            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                DataRow row = dtc.Rows[i];
                DateTime currStartDate = DateTime.Parse(row["StartDate"].ToString());
                DateTime currEndDate = DateTime.Parse(row["EndDate"].ToString());

                if (startDate.CompareTo(currStartDate) > 0 && endDate.CompareTo(currEndDate) > 0)
                {
                    rowsToRemove.Add(row);
                }
            }

            foreach (DataRow row in rowsToRemove)
            {
                dtc.Rows.Remove(row);
            }

            return dtc;
        }

        private string buildGetFeatureFilters(WFSServiceInfo wfsService)
        {
            XmlDocument doc = new XmlDocument();
            string ogcns = "http://www.opengis.net/ogc";
            string gmlns = "http://www.opengis.net/gml";

            XmlElement elRoot = (XmlElement)doc.AppendChild(doc.CreateElement("ogc:Filter", ogcns));

            if (areMultipleFiltersChecked())
                elRoot = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:And", ogcns));

            if (chkBBox.Checked)
            {
                XmlElement elBBOX = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:BBOX", ogcns));
                XmlElement elBboxPropertyName = (XmlElement)elBBOX.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns));
                elBboxPropertyName.InnerText = wfsService.Namespace + ':' + _bboxField;

                XmlElement elEnvelope = (XmlElement)elBBOX.AppendChild(doc.CreateElement("gml:Envelope", gmlns));
                elEnvelope.SetAttribute("srsName", "EPSG:4326");
                elEnvelope.AppendChild(doc.CreateElement("gml:lowerCorner", gmlns)).InnerText = bboxSouth.Text + ' ' + bboxWest.Text;
                elEnvelope.AppendChild(doc.CreateElement("gml:upperCorner", gmlns)).InnerText = bboxNorth.Text + ' ' + bboxEast.Text;
            }

            if (chkSiteCode.Checked)
            {
                XmlElement elPropertyIsEqual = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:PropertyIsEqualTo", ogcns));
                elPropertyIsEqual.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns)).InnerText = wfsService.Namespace + ':' + _siteCodeField;
                elPropertyIsEqual.AppendChild(doc.CreateElement("ogc:Literal", ogcns)).InnerText = txtSiteCode.Text;
            }

            if (chkConcept.Checked)
            {
                //XmlElement elPropertyIsEqual = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:PropertyIsEqualTo", ogcns));
                //elPropertyIsEqual.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns)).InnerText = wfsService.Namespace + ':' + _conceptField;
                //elPropertyIsEqual.AppendChild(doc.CreateElement("ogc:Literal", ogcns)).InnerText = txtConcept.Text;

                XmlElement elPropertyIsLike = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:PropertyIsLike", ogcns));
                elPropertyIsLike.SetAttribute("escape", "\\");
                elPropertyIsLike.SetAttribute("singleChar", "_");
                elPropertyIsLike.SetAttribute("wildCard", "*");
                elPropertyIsLike.SetAttribute("matchCase", "false"); //Note: this doesn't seem to work
                elPropertyIsLike.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns)).InnerText = wfsService.Namespace + ':' + _conceptField;
                elPropertyIsLike.AppendChild(doc.CreateElement("ogc:Literal", ogcns)).InnerText = txtConcept.Text;

            }

            if (chkValCount.Checked)
            {
                XmlElement elPropIsGreater = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:PropertyIsGreaterThan", ogcns));
                elPropIsGreater.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns)).InnerText = wfsService.Namespace + ':' + _valueCountField;
                elPropIsGreater.AppendChild(doc.CreateElement("ogc:Literal", ogcns)).InnerText = txtValCount.Text;
            }

            return doc.OuterXml;
        }

        private void btnGetRecords_Click(object sender, EventArgs e)
        {
            btnQuery.Enabled = false;
            btnExport.Enabled = false;
            setFilterChecksEnabled(false);
            _wfsList.Clear();

            //https://hydroportal.crwr.utexas.edu/geoportal/csw/discovery?Request=GetRecords&Service=CSW&Version=2.0.2&resultType=results&CONSTRAINTLANGUAGE=Filter&CONSTRAINT=%3Cogc:Filter%3E%3Cogc:PropertyIsLike%20escape=%22\%22%20singleChar=%22_%22%20wildCard=%22*%22%3E%3Cogc:PropertyName%3Edct:Abstract%3C/ogc:PropertyName%3E%3Cogc:Literal%3EDataCart*%3C/ogc:Literal%3E%3C/ogc:PropertyIsLike%3E%3C/ogc:Filter%3E
            string wfsReferenceScheme = "urn:x-esri:specification:ServiceType:ArcIMS:Metadata:Server";

            HttpGetRequest cswGetRecordsRequest = new HttpGetRequest(txtCSWUrl.Text);
            cswGetRecordsRequest.paramTable = new Hashtable();

            cswGetRecordsRequest.paramTable.Add("Request", "GetRecords");
            cswGetRecordsRequest.paramTable.Add("Service", "CSW");
            cswGetRecordsRequest.paramTable.Add("Version", "2.0.2");
            cswGetRecordsRequest.paramTable.Add("resultType", "results");
            cswGetRecordsRequest.paramTable.Add("CONSTRAINTLANGUAGE", "Filter");


            //Build DataCart Filter

            // <ogc:Filter><ogc:PropertyIsLike escape="\" singleChar="_" wildCard="*"><ogc:PropertyName>dct:Abstract</ogc:PropertyName><ogc:Literal>*DataCart*</ogc:Literal></ogc:PropertyIsLike></ogc:Filter>
            XmlDocument doc = new XmlDocument();
            string ogcns = "http://www.opengis.net/ogc";

            XmlElement elRoot = (XmlElement)doc.AppendChild(doc.CreateElement("ogc:Filter", ogcns));
            XmlElement elPropertyIsLike = (XmlElement)elRoot.AppendChild(doc.CreateElement("ogc:PropertyIsLike", ogcns));
            elPropertyIsLike.SetAttribute("escape", "\\");
            elPropertyIsLike.SetAttribute("singleChar", "_");
            elPropertyIsLike.SetAttribute("wildCard", "*");
            elPropertyIsLike.AppendChild(doc.CreateElement("ogc:PropertyName", ogcns)).InnerText = "dct:Abstract";
            elPropertyIsLike.AppendChild(doc.CreateElement("ogc:Literal", ogcns)).InnerText = "DataCart*";

            string dataCartFilter = doc.OuterXml;

            cswGetRecordsRequest.paramTable.Add("Constraint", dataCartFilter);

            using (HttpWebResponse response = cswGetRecordsRequest.IssueRequest())
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                XPathDocument docNav = new XPathDocument(reader);
                XPathNavigator nav = docNav.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                manager.AddNamespace("df", "http://www.opengis.net/cat/csw/2.0.2");
                manager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
                manager.AddNamespace("dct", "http://purl.org/dc/terms/");

                XPathNodeIterator NodeIter = nav.Select("//dct:references", manager);
                while (NodeIter.MoveNext())
                {
                    string schemeAttr = NodeIter.Current.GetAttribute("scheme", "");
                    if (wfsReferenceScheme.Equals(schemeAttr))
                    {
                        WFSServiceInfo newServiceInfo = new WFSServiceInfo(NodeIter.Current.Value.ToString());
                        _wfsList.Add(newServiceInfo);
                    }

                }

                lblFound.Text = "Found and loaded " + _wfsList.Count + " DataCart service" + (_wfsList.Count != 1 ? "s:" : ":");
                lblNames.Text = "";
                foreach (WFSServiceInfo wfs in _wfsList)
                {
                    lblNames.Text += wfs.TypeName + ", ";

                }
                lblNames.Text = lblNames.Text.TrimEnd(',', ' ');
                btnQuery.Enabled = true;
                
                setFilterChecksEnabled(true);
            }

        }

        private void setFilterChecksEnabled(bool isEnabled)
        {
            chkBBox.Enabled = isEnabled;
            chkConcept.Enabled = isEnabled;
            chkDateRange.Enabled = isEnabled;
            chkSiteCode.Enabled = isEnabled;
            chkValCount.Enabled = isEnabled;
            chkHits.Enabled = isEnabled;
        }
        private void chkBBox_CheckedChanged(object sender, EventArgs e)
        {
            bboxEast.Enabled = chkBBox.Checked;
            bboxNorth.Enabled = chkBBox.Checked;
            bboxSouth.Enabled = chkBBox.Checked;
            bboxWest.Enabled = chkBBox.Checked;
        }

        private void chkConcept_CheckedChanged(object sender, EventArgs e)
        {
            txtConcept.Enabled = chkConcept.Checked;
        }

        private void chkSiteCode_CheckedChanged(object sender, EventArgs e)
        {
            txtSiteCode.Enabled = chkSiteCode.Checked;
        }

        private bool isAFilterChecked()
        {
            return (chkBBox.Checked || chkSiteCode.Checked || chkConcept.Checked || chkValCount.Checked);
        }

        private void chkValCount_CheckedChanged(object sender, EventArgs e)
        {
            txtValCount.Enabled = chkValCount.Checked;
        }

        private bool areMultipleFiltersChecked()
        {
            return (chkBBox.Checked && chkSiteCode.Checked || chkBBox.Checked && chkConcept.Checked || chkBBox.Checked && chkValCount.Checked ||
                chkSiteCode.Checked && chkConcept.Checked || chkSiteCode.Checked && chkValCount.Checked || chkConcept.Checked && chkValCount.Checked);
        }

        private void chkDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = chkDateRange.Checked;
            dtpStartDate.Enabled = chkDateRange.Checked;
        }

        private void ExportToCSV(DataTable dt, string fileName)
        {
            var sw = new StreamWriter(fileName, false);

            // Write the headers.
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1) sw.Write(",");
            }

            sw.Write(sw.NewLine);

            // Write rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }

                    if (i < iColCount - 1) sw.Write(",");
                }
                sw.Write(sw.NewLine);
            }

            sw.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int index = tcResults.SelectedIndex;
            DataTable dt = _wfsList.ElementAt<WFSServiceInfo>(index).Data;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog().Equals(DialogResult.OK))
            {
                ExportToCSV(dt,sfd.FileName);
                MessageBox.Show("Export completed", "Information");
            }

        } 


    }
}
