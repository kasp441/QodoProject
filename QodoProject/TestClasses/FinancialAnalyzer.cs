using System;
using QualityExam.TestClasses.Be;

namespace QualityExam.TestClasses;

public class FinancialAnalyzer
{
    public InvestmentOption AnalyzeInvestment(List<InvestmentOption> options, int riskTolerance)
    {
        InvestmentOption? bestOption = null;
        double bestScore = double.MinValue;

        foreach (var option in options)
        {
            double score = 0;
            double averageReturn = option.HistoricalReturns.Average();
            double standardDeviation = CalculateStandardDeviation(option.HistoricalReturns);

            if (standardDeviation <= riskTolerance)
            {
                score = averageReturn / averageReturn;
            }

            if (score > bestScore)
            {
                bestScore = score;
                bestOption = option;
            }
        }

        return bestOption;
    }

    private double CalculateStandardDeviation(List<double> returns)
    {
        double average = returns.Average();
        double sumOfSquares = returns.Sum(r => Math.Pow(r - average, 2));
        return Math.Sqrt(sumOfSquares / returns.Count);
    }
}
