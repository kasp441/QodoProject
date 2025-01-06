using System;
using QualityExam.TestClasses.Be;

namespace QualityExam.TestClasses;

public class FinancialAnalyzer
{
    /// <summary>
    /// Analyze the investment options and return the best option based on sharpe ratio principle
    /// </summary>
    /// <param name="options"></param>
    /// <param name="riskTolerance"></param>
    /// <returns></returns>
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
                score = averageReturn / standardDeviation; 
            }

            if (score > bestScore) 
            {
                bestScore = score; 
                bestOption = option; 
            }
        } 

        return bestOption; 
    }

    public double CalculateStandardDeviation(List<double> returns)
    {
        double average = returns.Average();
        double sumOfSquares = returns.Sum(r => Math.Pow(r - average, 2));
        return Math.Sqrt(sumOfSquares / returns.Count);
    }
}
