//using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace WorldData.Models
{
  public class Data
  {
    private int _number;

    public Data(int number)
    {
      _number = number;
    }
    public int GetNumber()
    {
      return _number;
    }
    public void SetNumber(int newNumber)
    {
      _number = newNumber;
    }
  }
}
