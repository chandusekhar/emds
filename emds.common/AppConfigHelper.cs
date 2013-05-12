using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace emds.common
{
    public static class AppConfigHelper
    {
        /// <summary>
        /// SZ Получает строку из настроек приложения
        /// </summary>
        /// <param name="key">Нет проверки на null</param>
        /// <returns>Может вернуть null</returns>
        public static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetMongoDBConnectionString
        {
            get { return GetAppSettingValue("mongoDBConnect"); }
        }

        public static string GetDBName
        {
            get { return GetAppSettingValue("dbName"); }
        }

        public static string GetCollectionName
        {
            get { return GetAppSettingValue("collectionName"); }
        }

    }
}
