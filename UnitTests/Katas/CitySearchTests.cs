﻿using TDD_Katas.Katas;

namespace UnitTests.Katas;
public class CitySearchTests
{

    private readonly CitySearch _sut = new CitySearch();

    /// <summary>
    /// 1. If the search text is fewer than 2 characters, then should return no results. (It is an optimization feature of the search functionality.)
    /// </summary>
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    public void FindMatchingCities_ReturnsNoResults_WhenStringFewerThan2Characters(string searchText)
    {
        // Act
        var result = _sut.FindMatchingCities(searchText);

        // Assert
        result.Should().BeEmpty();
    }

    
    public static IEnumerable<object[]> GetSearchTextAndCorrospondingCities()
    {
        yield return new object[]
        {
            "Ba",
            new List<string>(){ "Bangkok", "Dubai" }
        };
        yield return new object[]
        {
            "Ro",
            new List<string>(){ "Rome", "Rotterdam" }
        };
    }

    /// <summary>
    /// 2. If the search text is equal to or more than 2 characters, then it should return all the city names starting with the exact search text.
    /// </summary>
    [Theory]
    [MemberData(nameof(GetSearchTextAndCorrospondingCities))]
    public void FindMatchingCities_ReturnsMatchingCities_WhenSearchTextStartsWithSameText(string searchText, List<string> matchingCities)
    {
        // Act
        var result = _sut.FindMatchingCities(searchText);

        // Assert
        result.Should().BeEquivalentTo(matchingCities);
    }

    public static IEnumerable<object[]> GetLowercaseSearchTextAndCorrospondingCities()
    {
        yield return new object[]
        {
            "ba",
            new List<string>(){ "Bangkok", "Dubai"}
        };
        yield return new object[]
        {
            "ro",
            new List<string>(){ "Rome", "Rotterdam" }
        };
    }

    /// <summary>
    /// 3. The search functionality should be case insensitive
    /// </summary>
    [Theory]
    [MemberData(nameof(GetLowercaseSearchTextAndCorrospondingCities))]
    public void FindMatchingCities_ReturnsMatchingCities_WhenSearchTextIsLowerCase(string searchText, List<string> matchingCities)
    {
        // Act
        var result = _sut.FindMatchingCities(searchText);

        // Assert
        result.Should().BeEquivalentTo(matchingCities);
    }

    /// <summary>
    /// 4. The search functionality should work also when the search 
    /// text is just a part of a city name
    /// </summary>
    [Fact]
    public void FindMatchingCities_ReturnsMatchingCities_WhenCityNameContainsSearchText()
    {
        // Arrange
        string searchText = "ape";

        List<string> matchingCities = new List<string>() { "Budapest" };

        // Act
        var result = _sut.FindMatchingCities(searchText);

        // Assert
        result.Should().BeEquivalentTo(matchingCities);
    }

    /// <summary>
    /// 5. If the search text is a “*” (asterisk), then it should return all the city names.
    /// </summary>
    [Fact]
    public void FindMatchingCities_ReturnsAllCities_WhenSearchTextAsterix()
    {
        // Arrange
        string searchText = "*";

        var fullCityList = _sut.CityList;

        // Act
        var result = _sut.FindMatchingCities(searchText);

        // Assert
        result.Should().BeEquivalentTo(fullCityList);
    }
}
