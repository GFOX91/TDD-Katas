using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Katas.Katas;

namespace UnitTests;
public class CitySearchTests
{

    private readonly CitySearch _sut = new CitySearch();

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
}
