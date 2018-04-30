using System.Collections.Generic;
using MySql.Data.MySqlClient;
//using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    //private int _id;
    private string _name;
    private string _code;
    private string _district;

    public City(string name, string code, string district)
    {
      _name = name;
      _code = code;
      _district = district;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetCode()
    {
      return _code;
    }
    public string GetDistrict()
    {
      return _district;
    }
    public static List<City> GetAll()
      {
        List<City> allCities = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string Name = rdr.GetString(1);
          string Code = rdr.GetString(2);
          string District = rdr.GetString(3);
          City newCity = new City(Name, Code, District);
          allCities.Add(newCity);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCities;
    }
  }
}
