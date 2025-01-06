using System;
using QualityExam.TestClasses;
using QualityExam.TestClasses.Be;

namespace qodoTests;

public class CalculateStandardDeviationTests
{
    [Fact]
public void calculate_standard_deviation_for_positive_numbers()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var returns = new List<double> { 2.0, 4.0, 6.0, 8.0, 10.0 };
    var expected = 2.828427125; // sqrt of 8

    // Act
    var result = analyzer.CalculateStandardDeviation(returns);

    // Assert
    Assert.Equal(expected, result, 6);
}

    // Calculate standard deviation for empty list
[Fact]
public void calculate_standard_deviation_for_empty_list_throws_exception()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var returns = new List<double>();

    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => analyzer.CalculateStandardDeviation(returns));
}

}
