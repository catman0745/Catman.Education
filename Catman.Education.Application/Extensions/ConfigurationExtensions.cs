namespace Catman.Education.Application.Extensions
{
    using System;
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        public static string GetValue(this IConfiguration configuration, string parameterName) =>
            configuration[parameterName] ?? throw new Exception($"{parameterName} required");

        public static TParameter GetValue<TParameter>(
            this IConfiguration configuration,
            string parameterName,
            Func<string, TParameter> toParameterType) =>
            toParameterType(configuration.GetValue(parameterName));

        public static string GetValue(this IConfiguration configuration, string parameterName, string defaultValue) =>
            configuration[parameterName] ?? defaultValue;

        public static TParameter GetValue<TParameter>(
            this IConfiguration configuration,
            string parameterName,
            TParameter defaultValue,
            Func<string, TParameter> toParameterType) =>
            configuration[parameterName] == null
                ? defaultValue
                : toParameterType(configuration[parameterName]);

        public static int GetValue(this IConfiguration configuration, string parameterName, int defaultValue) =>
            configuration.GetValue(parameterName, defaultValue, int.Parse);
    }
}
