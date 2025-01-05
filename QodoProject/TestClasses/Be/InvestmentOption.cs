using System;

namespace QualityExam.TestClasses.Be;

public class InvestmentOption
{
    public required string Name { get; set; }
    public required List<double> HistoricalReturns { get; set; }
}
