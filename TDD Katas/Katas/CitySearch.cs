using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;

namespace TDD_Katas.Katas;

/// <summary>
/// Implement a city search functionality. The function takes a string (search text) as input and returns the found cities which corresponds to the search text.
/// 
/// --Prerequisites
/// Create a collection of strings that will act as a database for the city names.
/// City names: Paris, Budapest, Skopje, Rotterdam, Valencia, Vancouver, Amsterdam, Vienna, Sydney, New York City, London, Bangkok, Hong Kong, Dubai, Rome, Istanbul
/// 
/// --Requirements
/// 
/// 1. If the search text is fewer than 2 characters, then should return no results. (It is an optimization feature of the search functionality.)
/// 
/// 2. If the search text is equal to or more than 2 characters, then it should return all the city names starting with the exact search text.
/// 
/// 3. The search functionality should be case insensitive
/// 
/// 4. The search functionality should work also when the search text is just a part of a city name
///     For example “ape” should return “Budapest” city
/// </summary>
///<see cref = "https://tddmanifesto.com/exercises/" />
public class CitySearch
{
    private List<string> _cityList = new List<string>
    {
        "Amsterdam", 
        "Bangkok", 
        "Budapest", 
        "Dubai", 
        "Hong Kong", 
        "Istanbul",
        "New York City", 
        "London", 
        "Paris", 
        "Rome", 
        "Rotterdam", 
        "Skopje", 
        "Sydney", 
        "Vancouver", 
        "Valencia", 
        "Vienna", 
    };
   
    public List<string> FindMatchingCities(string searchText)
    {
        if (string.IsNullOrEmpty(searchText) || searchText.Length < 2 )
            return new List<string>();

        return _cityList
            .Where(x => x.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
