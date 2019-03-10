using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
public class DBcontrol
{
    // create DB connection
    public OleDbConnection DBcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.mdb;");

    // prepare command
    private OleDbCommand DBcmd;

    // DB Data
    public OleDbDataAdapter DBDA;
    public System.Data.DataTable DBDT;

    public List<OleDbParameter> @params = new List<OleDbParameter>();
    public string path;
    // query
    public int RecordCount;
    public string Exception;

    public void setdatabase(string query)
    {
        try
        {
            if (query != "c")
                DBcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.mdb;");
            else
            {
                path = Directory.GetCurrentDirectory();
                var IndexOf = path.IndexOf("Inventory");
                if (IndexOf != -1)
                {
                    path = path.Insert(IndexOf + 9, " c");
                    DBcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @"\Inventory.mdb;");
                }
                else
                {
                    string path = Interaction.InputBox("Please enter database location (include the database in the path)");
                    DBcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";");
                } // DBcon = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\User\retailcloud\Google Drive\Karkazian Jewelers Inventory c\Data\Inventory.mdb;")
            }
        }
        catch (System.Exception )
        {
            path = Interaction.InputBox("Please enter database location (include the database in the path)");
            DBcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";");
        }
    }

    public void ExcNonQuery(string query)
    {
        Exception = "";
        try
        {
            DBcon.Open();
            DBcmd = new OleDbCommand(query, DBcon);

            // load params into DB command
            @params.ForEach(p => DBcmd.Parameters.Add(p));
            Trace.Write(query);
            // reset params
            @params.Clear();

            DBcmd.ExecuteNonQuery();
            DBcmd.Dispose();
        }
        catch (System.Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }
        
        DBcon.Close();
    }

    public void ExcQuery(string query)
    {
        // reset query stats
        RecordCount = 0;
        Exception = "";

        try
        {
            // open connection
            DBcon.Open();
            // create db command
            DBcmd = new OleDbCommand(query, DBcon);

            // load params into DB command
            @params.ForEach(p => DBcmd.Parameters.Add(p));

            // reset params
            @params.Clear();

            // execute command & fill database
            DBDT = new System.Data.DataTable();
            DBDA = new OleDbDataAdapter(DBcmd);
            RecordCount = DBDA.Fill(DBDT);
        }
        catch (System.Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

        // close your connection
        if (DBcon.State == System.Data.ConnectionState.Closed)
            DBcon.Close();
    }

    public IList<IList<Object>> Google_sheets()
    {
        UserCredential credential;
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string ApplicationName = "Google Sheets API .NET Quickstart";
        using (var stream = new FileStream(".\\credentials.json", FileMode.Open, FileAccess.Read))
        {
            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                System.Threading.CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Console.WriteLine("Credential file saved to: " + credPath);
        }


        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        // Define request parameters.
        String spreadsheetId = "1OK2XHbSFs9dA4U8EEChyOGQuXfNWGXx-hrlaLlzhAAQ";
        String range = "Applicants!A2:G";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);

        // Prints the names and majors of students in a sample spreadsheet:
        // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
        ValueRange response = request.Execute();
        IList<IList<Object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            return values;
        }
        else
        {
            return null;
        }
    }

    // include query & command parameters
    public void Addparam(string name, object value)
    {
        OleDbParameter Newparam = new OleDbParameter(name, value);
        @params.Add(Newparam);
    }
}
