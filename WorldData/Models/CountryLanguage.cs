using System.Collections.Generic;
using MySql.Data.MySqlClient;
//using WorldData;
using System;

namespace WorldData.Models
{
  public class CountryLanguage
  {
    //private int _id;
    private string _code;
    private string _language;
    private float _percentage;

    public CountryLanguage(string code, string language, float percentage)
    {
      _code = code;
      _language = language;
      _percentage = percentage;
    }
    public string GetCode()
    {
      return _code;
    }
    public string GetLanguage()
    {
      return _language;
    }
    public float GetPercentage()
    {
      return _percentage;
    }
    public static List<CountryLanguage> GetAll()
      {
        List<CountryLanguage> allLanguages = new List<CountryLanguage> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM countrylanguage;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string Code = rdr.GetString(0);
          string Language = rdr.GetString(1);
          float Percentage = rdr.GetFloat(3);
          CountryLanguage newLanguage = new CountryLanguage(Code, Language, Percentage);
          allLanguages.Add(newLanguage);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allLanguages;
    }
  }
}
