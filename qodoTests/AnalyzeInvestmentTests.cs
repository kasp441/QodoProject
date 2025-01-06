using System;
using QualityExam.TestClasses;
using QualityExam.TestClasses.Be;

namespace qodoTests;

public class AnalyzeInvestmentTests
{

    
    // Returns investment option with highest score when valid options and risk tolerance provided
[Fact]
public void analyze_investment_returns_best_option_when_valid_input()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>
    {
        new() { HistoricalReturns = new List<double> { 10, 12, 8 }, Name = "Option 1" },
        new() { HistoricalReturns = new List<double> { 15, 14, 16 }, Name = "Option 2" },
        new() { HistoricalReturns = new List<double> { 5, 6, 4 }, Name = "Option 3" }
    };
    var riskTolerance = 5;

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(options[1], result);
}

    // Returns null when empty options list provided
[Fact]
public void analyze_investment_returns_null_for_empty_options()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>();
    var riskTolerance = 5;

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.Null(result);
}

    // Handles single investment option in the list
[Fact]
public void analyze_investment_returns_single_option_correctly()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>
    {
        new() { HistoricalReturns = new List<double> { 10, 12, 8 }, Name = "Single Option" }
    };
    var riskTolerance = 5;

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(options[0], result);
}

    // Handles negative historical returns values
[Fact]
public void analyze_investment_handles_negative_returns()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>
    {
        new() { HistoricalReturns = new List<double> { -5, -3, -4 }, Name = "Option 1" },
        new() { HistoricalReturns = new List<double> { -2, -1, -3 }, Name = "Option 2" },
        new() { HistoricalReturns = new List<double> { -6, -7, -5 }, Name = "Option 3" }
    };
    var riskTolerance = 5;

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(options[1], result);
}

    // Handles case when all options have standard deviation above risk tolerance
[Fact]
public void analyze_investment_returns_null_when_all_options_above_risk_tolerance()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>
    {
        new() { HistoricalReturns = new List<double> { 10, 12, 8 }, Name = "Option 1" },
        new() { HistoricalReturns = new List<double> { 15, 14, 16 }, Name = "Option 2" },
        new() { HistoricalReturns = new List<double> { 5, 6, 4 }, Name = "Option 3" }
    };

    // Qodo gen wrongful assertion for options. might be a limitation of riskTolerance is int
    var riskTolerance = 1; // All options have standard deviation above this value

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.Null(result);
}

    // Handles zero standard deviation case
[Fact]
public void analyze_investment_handles_zero_standard_deviation()
{
    // Arrange
    var analyzer = new FinancialAnalyzer();
    var options = new List<InvestmentOption>
    {
        new() { HistoricalReturns = new List<double> { 10, 10, 10 }, Name = "Option 1" },
        new() { HistoricalReturns = new List<double> { 15, 15, 15 }, Name = "Option 2" }
    };
    var riskTolerance = 0;

    // Act
    var result = analyzer.AnalyzeInvestment(options, riskTolerance);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(options[0], result);
}

//     // Handles very large historical return values
// [Fact]
// public void analyze_investment_handles_large_historical_returns()
// {
//     // Arrange
//     var analyzer = new FinancialAnalyzer();
//     var options = new List<InvestmentOption>
//     {
//         new() { HistoricalReturns = new List<double> { 1e10, 1e10, 1e10 }, Name = "Option 1" },
//         new() { HistoricalReturns = new List<double> { 1e12, 1e12, 1e12 }, Name = "Option 2" },
//         new() { HistoricalReturns = new List<double> { 1e11, 1e11, 1e11 }, Name = "Option 3" }
//     };
//     var riskTolerance = 1e9;

//     // Act
//     var result = analyzer.AnalyzeInvestment(options, riskTolerance);

//     // Assert
//     Assert.NotNull(result);
//     Assert.Equal(options[1], result);
// }

}
