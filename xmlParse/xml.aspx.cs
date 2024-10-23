using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace xmlParse
{
    public partial class xml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your XML string
            string xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""><soapenv:Body><ns1:syncOrderRelation xmlns:ns1=""http://www.csapi.org/schema/parlayx/data/sync/v1_0/local""><ns1:userID><ID>8801892809862</ID><type>0</type></ns1:userID><ns1:spID>200007</ns1:spID><ns1:productID>0304001002</ns1:productID><ns1:serviceID>0304000002</ns1:serviceID><ns1:serviceList>0304000002</ns1:serviceList><ns1:updateType>1</ns1:updateType><ns1:updateTime>20241023203034</ns1:updateTime><ns1:updateDesc>Addition</ns1:updateDesc><ns1:effectiveTime>20241023203034</ns1:effectiveTime><ns1:expiryTime>20241123180000</ns1:expiryTime><ns1:extensionInfo><item><key>accessCode</key><value>27000</value></item><item><key>fee</key><value>0</value></item><item><key>cycleStartTime</key><value>20241023203034</value></item><item><key>nextChargeTime</key><value>20241123180000</value></item><item><key>objectType</key><value>1</value></item><item><key>chargeMode</key><value>0</value></item><item><key>MDSPSUBEXPMODE</key><value>1</value></item><item><key>payType</key><value>1</value></item><item><key>transactionID</key><value>1729715434622</value></item><item><key>TraceUniqueID</key><value>208501003132410232030340040001</value></item><item><key>updateDesc</key><value>Addition</value></item><item><key>isFreePeriod</key><value>false</value></item><item><key>try</key><value>false</value></item><item><key>durationOfGracePeriod</key><value>-1</value></item><item><key>rentSuccess</key><value>true</value></item><item><key>serviceAvailability</key><value>-1</value></item><item><key>channelID</key><value>2</value></item><item><key>orderKey</key><value>10642539</value></item><item><key>cycleEndTime</key><value>20241123180000</value></item><item><key>status</key><value>0</value></item><item><key>servicePayType</key><value>0</value></item><item><key>isAutoExtend</key><value>1</value></item><item><key>shortCode</key><value>27000</value></item><item><key>keyword</key><value>Y</value></item><item><key>Starttime</key><value>20241023203034</value></item></ns1:extensionInfo></ns1:syncOrderRelation></soapenv:Body></soapenv:Envelope>";

            // Load the XML string into an XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            // Extract data using XPath
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsmgr.AddNamespace("ns1", "http://www.csapi.org/schema/parlayx/data/sync/v1_0/local");

            // Retrieve specific node values
            string userID = xmlDoc.SelectSingleNode("//ns1:userID/ID", nsmgr)?.InnerText;
            string spID = xmlDoc.SelectSingleNode("//ns1:spID", nsmgr)?.InnerText;
            string productID = xmlDoc.SelectSingleNode("//ns1:productID", nsmgr)?.InnerText;
            string serviceID = xmlDoc.SelectSingleNode("//ns1:serviceID", nsmgr)?.InnerText;
            string type = xmlDoc.SelectSingleNode("//ns1:userID/type", nsmgr)?.InnerText;
            string updateType = xmlDoc.SelectSingleNode("//ns1:updateType", nsmgr)?.InnerText;
            string updateTime = xmlDoc.SelectSingleNode("//ns1:updateTime", nsmgr)?.InnerText;
            string expiryTime = xmlDoc.SelectSingleNode("//ns1:expiryTime", nsmgr)?.InnerText;
            string updateDesc = xmlDoc.SelectSingleNode("//ns1:updateDesc", nsmgr)?.InnerText;
            string effectiveTime = xmlDoc.SelectSingleNode("//ns1:effectiveTime", nsmgr)?.InnerText;
            //string effectiveTime = xmlDoc.SelectSingleNode("//ns1:effectiveTime", nsmgr)?.InnerText;

            string transactionID = xmlDoc.SelectSingleNode("//ns1:extensionInfo/item[key='transactionID']/value", nsmgr)?.InnerText;

            // Display the extracted values
            Response.Write($"User ID: {userID}<br/>");
            Response.Write($"SP ID: {spID}<br/>");
            Response.Write($"Product ID: {productID}<br/>");
            Response.Write($"Transaction ID: {transactionID}<br/>");


            Response.End();
        }
    }
}