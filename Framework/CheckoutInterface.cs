using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Framework.Models;

namespace Framework
{
    public class CheckoutInterface
    {
        public static List<OrderDto> GetOrders(string urlTargetSite)
        {
            var url = $"{urlTargetSite}/api/Orders";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;

                        var model = JsonConvert.DeserializeObject<List<OrderDto>>(json);

                        return model;
                    }
                }
            }
        }

        public static List<Customer> GetCustomers(string urlTargetSite)
        {
            var url = $"{urlTargetSite}/api/Customers";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;

                        var model = JsonConvert.DeserializeObject<List<Customer>>(json);

                        return model;
                    }
                }
            }
        }

        public static List<Item> GetItems(string urlTargetSite)
        {
            var url = $"{urlTargetSite}/api/Items";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;

                        var model = JsonConvert.DeserializeObject<List<Item>>(json);

                        return model;
                    }
                }
            }
        }

        public static OrderDto GetOrder(string urlTargetSite, int id)
        {
            var url = $"{urlTargetSite}/api/Orders/{id}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;

                        var model = JsonConvert.DeserializeObject<OrderDto>(json);

                        return model;
                    }
                }
            }
        }

        public static OrderDto ClearOrder(string urlTargetSite, int id)
        {
            var order = GetOrder(urlTargetSite, id);

            foreach (var orderItem in order.OrderItems)
            {
                DeleteOrderItem(urlTargetSite, orderItem.Id);
            }

            return GetOrder(urlTargetSite, id);
        }

        public static OrderItemDto CreteOrderItem(string urlTargetSite, int orderId, int itemId, int quantity)
        {
            var url = $"{urlTargetSite}/api/OrderItems";

            var oOrderItemDto = new OrderItemDto
            {
                OrderId = orderId,
                ItemId = itemId,
                Quantity = quantity
            };

            var jsonString = JsonConvert.SerializeObject(oOrderItemDto);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;

                        var model = JsonConvert.DeserializeObject<OrderItemDto>(json);

                        return model;
                    }
                }
            }
        }

        public static HttpStatusCode DeleteOrderItem(string urlTargetSite, int id)
        {
            var url = $"{urlTargetSite}/api/OrderItems/{id}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.DeleteAsync(url).Result)
                {
                    return response.StatusCode;
                }
            }
        }

        public static HttpStatusCode UpdateOrderItem(string urlTargetSite, int id, int quantity)
        {
            var url = $"{urlTargetSite}/api/OrderItems/{id}";

            var oOrderItemDto = new OrderItemDto
            {
                Quantity = quantity
            };

            var jsonString = JsonConvert.SerializeObject(oOrderItemDto);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    return response.StatusCode;
                }
            }
        }

        public static HttpStatusCode CloseOrder(string urlTargetSite, int id)
        {
            var url = $"{urlTargetSite}/api/Orders/{id}";
            var jsonString = "{\"closed\":\"true\"}";
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    return response.StatusCode;
                }
            }
        }

        public static HttpStatusCode OpenOrder(string urlTargetSite, int id)
        {
            var url = $"{urlTargetSite}/api/Orders/{id}";
            var jsonString = "{\"closed\":\"false\"}";
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    return response.StatusCode;
                }
            }
        }
    }
}
