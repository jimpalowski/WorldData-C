using System.Collections.Generic;
using MySql.Data.MySqlClient;
//using WorldData;
using System;

namespace WorldData.Models
{
  public class Data
  {
    //private int _id;
    private string _city;
    private string _country;
    private string _countrylanguage;

    public Data(string country, string city, string countryLanguage)
    {
      _country = country;
      _city = city;
      _countrylanguage = countryLanguage;
    }
    public string GetCountryLanguage()
    {
      return _countrylanguage;
    }
    public string GetCity()
    {
      return _city;
    }
    public string GetCountry()
    {
      return _country;
    }
    public static List<Data> GetAll()
      {
        List<Data> allDatas = new List<Data> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city, countrylanguage, country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string Country = rdr.GetString(2);
          string City = rdr.GetString(1);
          string CountryLanguage = rdr.GetString(1);
          Data newData = new Data(Country, City, CountryLanguage);
          allDatas.Add(newData);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allDatas;
    }
  }
}
