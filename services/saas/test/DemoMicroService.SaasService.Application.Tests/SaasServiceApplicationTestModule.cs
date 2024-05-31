﻿using DemoMicroService.SaasService.Application;
using Volo.Abp.Modularity;

namespace DemoMicroService.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
