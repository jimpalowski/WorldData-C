using System.Collections.Generic;
using MySql.Data.MySqlClient;
//using WorldData;
using System;

namespace WorldData.Models
{
  public class Country
  {
    //private int _id;
    private string _name;
    private string _continent;
    private int _population;

    public Country(string name, string continent, int population)
    {
      _name = name;
      _continent = continent;
      _population = population;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetContinent()
    {
      return _continent;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public static List<Country> GetAll()
      {
        List<Country> allCountries = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string Name = rdr.GetString(1);
          string Continent = rdr.GetString(2);
          int Population = rdr.GetInt32(6);
          Country newCountry = new Country(Name, Continent, Population);
          allCountries.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCountries;
    }
  }
}
