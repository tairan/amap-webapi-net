using System.ComponentModel;

namespace Amap.WebApi
{
    /// <summary>
    /// 错误码说明
    /// ref <https://lbs.amap.com/api/webservice/guide/tools/info>
    /// 最后更新时间: 2018年03月19日
    /// </summary>
    public enum ErrorCodes
    {
        [Description("请求正常")]
        OK = 10000,

        [Description("key不正确或过期")]
        INVALID_USER_KEY = 10001,

        [Description("没有权限使用相应的服务或者请求接口的路径拼写错误")]
        SERVICE_NOT_AVAILABLE = 10002,

        [Description("访问已超出日访问量")]
        DAILY_QUERY_OVER_LIMIT = 10003,

        [Description("单位时间内访问过于频繁")]
        ACCESS_TOO_FREQUENT = 10004,

        [Description("IP白名单出错，发送请求的服务器IP不在IP白名单内")]
        INVALID_USER_IP = 10005,

        [Description("绑定域名无效")]
        INVALID_USER_DOMAIN = 10006,

        [Description("数字签名未通过验证")]
        INVALID_USER_SIGNATURE = 10007,

        [Description("MD5安全码未通过验证")]
        INVALID_USER_SCODE = 10008,

        [Description("请求key与绑定平台不符")]
        USERKEY_PLAT_NOMATCH = 10009,

        [Description("IP访问超限")]
        IP_QUERY_OVER_LIMIT = 10010,

        [Description("服务不支持https请求")]
        NOT_SUPPORT_HTTPS = 10011,

        [Description("权限不足，服务请求被拒绝")]
        INSUFFICIENT_PRIVILEGES = 10012,

        [Description("Key被删除")]
        USER_KEY_RECYCLED = 10013,

        [Description("云图服务QPS超限")]
        QPS_HAS_EXCEEDED_THE_LIMIT = 10014,

        [Description("受单机QPS限流限制")]
        GATEWAY_TIMEOUT = 10015,

        [Description("服务器负载过高")]
        SERVER_IS_BUSY = 10016,

        [Description("所请求的资源不可用")]
        RESOURCE_UNAVAILABLE = 10017,

        [Description("使用的某个服务总QPS超限")]
        CQPS_HAS_EXCEEDED_THE_LIMIT = 10019,

        [Description("某个Key使用某个服务接口QPS超出限制")]
        CKQPS_HAS_EXCEEDED_THE_LIMIT = 10020,

        [Description("来自于同一IP的访问，使用某个服务QPS超出限制")]
        CIQPS_HAS_EXCEEDED_THE_LIMIT = 10021,

        [Description("某个Key，来自于同一IP的访问，使用某个服务QPS超出限制")]
        CIKQPS_HAS_EXCEEDED_THE_LIMIT = 10022,

        [Description("某个KeyQPS超出限制")]
        KQPS_HAS_EXCEEDED_THE_LIMIT = 10023,

        [Description("请求参数非法")]
        INVALID_PARAMS = 20000,

        [Description("缺少必填参数")]
        MISSING_REQUIRED_PARAMS = 20001,

        [Description("请求协议非法")]
        ILLEGAL_REQUEST = 20002,

        [Description("其他未知错误")]
        UNKNOWN_ERROR = 20003,

        [Description("规划点（包括起点、终点、途经点）不在中国陆地范围内")]
        OUT_OF_SERVICE = 20800,

        [Description("划点（起点、终点、途经点）附近搜不到路")]
        NO_ROADS_NEARBY = 20801,

        [Description("路线计算失败，通常是由于道路连通关系导致")]
        ROUTE_FAIL = 20802,

        [Description("起点终点距离过长")]
        OVER_DIRECTION_RANGE = 20803,

        [Description("服务响应失败")]
        ENGINE_RESPONSE_DATA_ERROR = 30000
    }
}
