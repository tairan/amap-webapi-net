# 高德地图 WebAPI for .NET

[![Build status](https://ci.appveyor.com/api/projects/status/htebxdkf48yjm75i?svg=true)](https://ci.appveyor.com/project/tairan/amap-webapi-net) | [![Build status](https://ci.appveyor.com/api/projects/status/htebxdkf48yjm75i/branch/master?svg=true)](https://ci.appveyor.com/project/tairan/amap-webapi-net/branch/master)



## Introduction



本项目是用于`.NET`项目的高德地图`WebAPI`封装。

请访问[高德官方网站](https://lbs.amap.com/api/webservice/summary)了解相关`WebAPI`的作用。

## Getting Started

```c#
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
     public void ConfigureServices(IServiceCollection services)
     {
            services.AddAmap(options =>
            {
                options.Key = Configuration.GetSection("Amap:Key");
            }) ;
     }
}
```



## Contributions



本项目遵循[GitHub flow](https://guides.github.com/introduction/flow/)模式进行协作，欢迎加入。:smile: