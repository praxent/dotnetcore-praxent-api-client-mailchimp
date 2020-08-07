using System;
using Autofac;
using Mandrill;
using Microsoft.Extensions.Configuration;

namespace Praxent.API.Client.Mailchimp
{
    public static class Bootstrapper
    {
        public static ContainerBuilder AddMailChimpClient(this ContainerBuilder builder, IConfiguration configuration)
        {
            try
            {
                var mandrillApiKey = configuration.GetValue<string>("MANDRILL_API_KEY");
                builder.RegisterInstance(new MandrillApi(mandrillApiKey).Messages).As<IMandrillMessagesApi>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            builder.RegisterType<MandrillApiClient>().As<IMandrillApiClient>();

            return builder;
        }
    }
}