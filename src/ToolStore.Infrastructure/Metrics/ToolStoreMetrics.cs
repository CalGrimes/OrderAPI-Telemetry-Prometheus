using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Configuration;

namespace ToolStore.Infrastructure.Metrics
{
    public class ToolStoreMetrics
    {

        // Tools meters
        private Counter<int> ToolsAddedCounter { get; }
        private Counter<int> ToolsDeletedCounter { get; }
        private Counter<int> ToolsUpdatedCounter { get; }
        private UpDownCounter<int> TotalToolsUpDownCounter { get; }

        // Categories meters
        private Counter<int> CategoriesAddedCounter { get; }
        private Counter<int> CategoriesDeletedCounter { get; }
        private Counter<int> CategoriesUpdatedCounter { get; }

        private ObservableGauge<int> TotalCategoriesGauge { get; }
        private int _totalCategories = 0;

        // Orders meters
        private Histogram<double> OrdersPriceHistogram { get; }
        private Histogram<int> NumberOfToolsPerOrderHistogram { get; }
        private ObservableCounter<int> OrdersCanceledCounter { get; }
        private int _ordersCanceled = 0;
        private Counter<int> TotalOrdersCounter { get; }

        public ToolStoreMetrics(IMeterFactory meterFactory, IConfiguration configuration)
        {
            var meter = meterFactory.Create(configuration["ToolStoreMeterName"] ??
                                        throw new NullReferenceException("ToolStore meter missing a name"));

            ToolsAddedCounter = meter.CreateCounter<int>("tools-added", "Tool");
            ToolsDeletedCounter = meter.CreateCounter<int>("tools-deleted", "Tool");
            ToolsUpdatedCounter = meter.CreateCounter<int>("tools-updated", "Tool");
            TotalToolsUpDownCounter = meter.CreateUpDownCounter<int>("tools-total", "Tool");

            CategoriesAddedCounter = meter.CreateCounter<int>("categories-added", "Category");
            CategoriesDeletedCounter = meter.CreateCounter<int>("categories-deleted", "Category");
            CategoriesUpdatedCounter = meter.CreateCounter<int>("categories-updated", "Category");
            TotalCategoriesGauge = meter.CreateObservableGauge("total-categories", () => _totalCategories);

            OrdersPriceHistogram = meter.CreateHistogram<double>("orders-price", "Euros", "Price distribution of tool orders");
            NumberOfToolsPerOrderHistogram = meter.CreateHistogram<int>("orders-number-of-Tools", "Tools", "Number of tool  per order");
            OrdersCanceledCounter = meter.CreateObservableCounter("orders-canceled", () => _ordersCanceled);
            TotalOrdersCounter = meter.CreateCounter<int>("total-orders", "Orders");

        }

        //Tools meters
        public void AddTool() => ToolsAddedCounter.Add(1);
        public void DeleteTool() => ToolsDeletedCounter.Add(1);
        public void UpdateTool() => ToolsUpdatedCounter.Add(1);
        public void IncreaseTotalTools() => TotalToolsUpDownCounter.Add(1);
        public void DecreaseTotalTools() => TotalToolsUpDownCounter.Add(-1);

        //Categories meters
        public void AddCategory() => CategoriesAddedCounter.Add(1);
        public void DeleteCategory() => CategoriesDeletedCounter.Add(1);
        public void UpdateCategory() => CategoriesUpdatedCounter.Add(1);
        public void IncreaseTotalCategories() => _totalCategories++;
        public void DecreaseTotalCategories() => _totalCategories--;

        //Orders meters
        public void RecordOrderTotalPrice(double price) => OrdersPriceHistogram.Record(price);
        public void RecordNumberOfTools(int amount) => NumberOfToolsPerOrderHistogram.Record(amount);
        public void IncreaseOrdersCanceled() => _ordersCanceled++;
        public void IncreaseTotalOrders(int storeId) => TotalOrdersCounter.Add(1, KeyValuePair.Create<string, object>("storeId", storeId));
    }
}
