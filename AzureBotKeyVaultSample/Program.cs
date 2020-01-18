// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
namespace AzureBotKeyVaultSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        //Here inside the webhost I add the reference to the keyvault with the configuration class
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            var root = config.Build();
            var vault = root["KeyVault:Vault"];
            var clientId = root["KeyVault:ClientId"];
            var secret = root["KeyVault:ClientSecret"];

            if (!string.IsNullOrEmpty(vault))
            {
              config.AddAzureKeyVault(vault, clientId, secret);
            }


        })
        .UseStartup<Startup>();
    }
}

