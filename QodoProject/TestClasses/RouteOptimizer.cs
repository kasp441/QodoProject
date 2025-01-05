using System;
using QualityExam.TestClasses.Be;

namespace QualityExam.TestClasses;

public class RouteOptimizer
{
    public List<DeliveryPoint> OptimizeRoute(List<DeliveryPoint> deliveryPoints, int vehicleCapacity)
    {
        var optimizedRoute = new List<DeliveryPoint>();
        var remainingPoints = new List<DeliveryPoint>(deliveryPoints);

        while (remainingPoints.Any())
        {
            var currentLoad = 0;
            var currentRoute = new List<DeliveryPoint>();

            foreach (var point in remainingPoints)
            {
                if (currentLoad + point.PackageWeight <= vehicleCapacity)
                {
                    currentRoute.Add(point);
                    currentLoad += point.PackageWeight;
                }
            }

            optimizedRoute.AddRange(currentRoute);
            remainingPoints.RemoveAll(point => currentRoute.Contains(point));
        }

        return optimizedRoute;
    }
}
