﻿namespace TheCodeJunkie.Leetspeak.Bootstrapping
{
    using System;
    using System.Linq;

    public class BootstrapperLocator
    {
        public static IBootstrapper Bootstrapper;

        static BootstrapperLocator()
        {
            var selectedBootstrapperType = AppDomainScanner
                .Types<IBootstrapper>()
                .FirstOrDefault(type => type != typeof(DefaultBootstrapper)) ?? typeof(DefaultBootstrapper);

            Bootstrapper = Activator.CreateInstance(selectedBootstrapperType) as IBootstrapper;
        }
    }
}