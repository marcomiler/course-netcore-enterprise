﻿namespace PackageGroup.Ecommerce.Transversal.Common
{
    public interface IAppLoger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
