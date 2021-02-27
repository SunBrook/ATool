using System;
//using System.Net;
//using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;


namespace ATool.Http
{
    /* 以轻量为目的，尽量不安装Nuget包插件，注释自行实现
     * Nuget 安装：
     * System.Net.Http
     * Newtonsoft.Json
     */

    //public class HttpClientUtil
    //{
    //    public static async Task<Result> PostAsJsonAsync<TModel>(string url, TModel model, Action<HttpStatusCode> httpStatusErrorAction = null)
    //    {
    //        try
    //        {
    //            using (var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip })
    //            {
    //                using (var client = new HttpClient(handler))
    //                {
    //                    var response = await client.PostAsJsonAsync(url, model);
    //                    if (response.StatusCode != HttpStatusCode.OK)
    //                    {
    //                        httpStatusErrorAction?.Invoke(response.StatusCode);
    //                        return Result.Error($"网络请求失败代码:{response.StatusCode}");
    //                    }
    //                    var json = response.Content.ReadAsStringAsync().Result;
    //                    if (string.IsNullOrWhiteSpace(json))
    //                        return Result.Error("返回值不正确");
    //                    var result = JsonConvert.DeserializeObject<Result>(json);
    //                    if (result != null) return result;
    //                    return Result.Error("网络请求返回值序列化异常");
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return Result.Error($"执行过程中发生异常{ex.Message}");
    //        }
    //    }

    //    public static async Task<Result<T>> PostAsync<T>(string url, Action successAction, Action errorAction)
    //    {
    //        try
    //        {
    //            using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) })
    //            {
    //                var response = await client.PostAsync(url, new StringContent(""));
    //                if (response.StatusCode != HttpStatusCode.OK)
    //                {
    //                    return Result<T>.Error("网络请求失败");
    //                }
    //                var json = response.Content.ReadAsStringAsync().Result;
    //                if (string.IsNullOrWhiteSpace(json))
    //                    return Result<T>.Error("返回值为空");
    //                return JsonConvert.DeserializeObject<Result<T>>(json);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return Result<T>.Error(ex.Message);
    //        }
    //    }

    //    public static async Task<Result<T>> GetAsJsonAsync<T>(string url, Action<HttpStatusCode> httpStatusErrorAction = null)
    //    {
    //        try
    //        {
    //            using (var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip })
    //            {
    //                using (var client = new HttpClient(handler))
    //                {
    //                    var response = await client.GetAsync(url);
    //                    if (response.StatusCode != HttpStatusCode.OK)
    //                    {
    //                        httpStatusErrorAction?.Invoke(response.StatusCode);
    //                        return Result<T>.Error($"网络请求失败代码:{response.StatusCode}");
    //                    }
    //                    var json = response.Content.ReadAsStringAsync().Result;
    //                    if (string.IsNullOrWhiteSpace(json))
    //                        return Result<T>.Error("返回值不正确");
    //                    var result = JsonConvert.DeserializeObject<Result<T>>(json);
    //                    if (result != null) return result;
    //                    return Result<T>.Error("网络请求返回值序列化异常");
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return Result<T>.Error($"执行过程中发生异常{ex.Message}");
    //        }
    //    }
    //}

    //public static class HttpClientExtensions
    //{
    //    public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requestUrl, TModel model)
    //    {
    //        var json = JsonConvert.SerializeObject(model);
    //        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
    //        return await client.PostAsync(requestUrl, stringContent);
    //    }

    //}
}
