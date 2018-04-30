using System.Collections.Generic;
using MySql.Data.MySqlClient;
//using WorldData;
using System;

namespace WorldData.Models
{
  public class Data
  {
    private int _id;
    private string _city;
    private string _countrylanguage;

    public Data(int Id, string city, string countryLanguage)
    {
      _id = Id;
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
    public int GetId()
    {
      return _id;
    }
    public static List<Data> GetAll()
      {
        List<Data> allDatas = new List<Data> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int dataCountry = rdr.GetInt32(1);
          string dataCity = rdr.GetString(0);
          string dataCountrycode= rdr.GetString(2);
          Data newData = new Data(dataCountry, dataCity, dataCountrycode);
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
