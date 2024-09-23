using System.Runtime.Serialization;

namespace TelemetryPrometheus
{
    public class Product
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Price of the product
        /// <value>1.99</value>
        /// </summary>
        decimal Price { get; set; }
    }

}
