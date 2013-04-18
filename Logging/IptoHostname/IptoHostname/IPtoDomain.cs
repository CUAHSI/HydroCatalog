//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static System.Data.SqlTypes.SqlString IPtoDomain(string ipaddr) // this is like T-SQL's CREATE FUNCTION dbo.IPtoHostName  (@strCCode varchar(xx))
    {
        try // This basically means "If the IP resolves properly and doesn't throw an exception, then..."
        {
            string myIP = System.Net.Dns.GetHostEntry(ipaddr.Trim()).HostName.ToString();
            myIP = myIP.Substring(myIP.LastIndexOf(".") + 1);
            return new SqlString(myIP);
        }
        catch // "If it doesn't, just return the IP address"
        {
            return new SqlString("unkown");
        }
    }
}
