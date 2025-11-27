using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

var routes = new[]
{
    new RouteConfig
    {
        RouteId = "products_route",
        ClusterId = "products_cluster",
        Match = new RouteMatch
        {
            Path = "/api/products/{**catch-all}"
        }
    },
    new RouteConfig
    {
        RouteId = "customers_route",
        ClusterId = "customers_cluster",
        Match = new RouteMatch
        {
            Path = "/api/customers/{**catch-all}"
        }
    },
    new RouteConfig
    {
        RouteId = "orders_route",
        ClusterId = "orders_cluster",
        Match = new RouteMatch
        {
            Path = "/api/orders/{**catch-all}"
        }
    }
};

var clusters = new[]
{
    new ClusterConfig
    {
        ClusterId = "products_cluster",
        Destinations = new Dictionary<string, DestinationConfig>
        {
            ["products_destination"] = new DestinationConfig
            {
                Address = "http://productservice:8080"
            }
        }
    },
    new ClusterConfig
    {
        ClusterId = "customers_cluster",
        Destinations = new Dictionary<string, DestinationConfig>
        {
            ["customers_destination"] = new DestinationConfig
            {
                Address = "http://customerservice:8080"
            }
        }
    },
    new ClusterConfig
    {
        ClusterId = "orders_cluster",
        Destinations = new Dictionary<string, DestinationConfig>
        {
            ["orders_destination"] = new DestinationConfig
            {
                Address = "http://orderservice:8080"
            }
        }
    }
};

builder.Services
    .AddReverseProxy()
    .LoadFromMemory(routes, clusters);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();
