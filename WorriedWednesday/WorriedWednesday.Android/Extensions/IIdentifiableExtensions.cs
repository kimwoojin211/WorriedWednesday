using System;
using System.Collections.Generic;
using WorriedWednesday.Services;
using Java.Util;

namespace WorriedWednesday.Droid.Extensions
{
  public static class IIdentifiableExtensions
  {

    public static HashMap Convert(this IIdentifiable item)
    {
      var map = new HashMap();
      var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
      var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

      foreach (var key in propertyDict.Keys)
      {
        if (key.Equals("Id"))
          continue;
        var val = propertyDict[key];
        Java.Lang.Object javaVal = null;
        if (val is string str)
          javaVal = new Java.Lang.String(str);
        else if (val is double dbl)
          javaVal = new Java.Lang.Double(dbl);
        else if (val is int intVal)
          javaVal = new Java.Lang.Integer(intVal);
        else if (val is DateTime dt)
          javaVal = dt.ToString();
        else if (val is bool boolVal)
          javaVal = new Java.Lang.Boolean(boolVal);

        if (javaVal != null)
          map.Put(key, javaVal);
      }

      return map;
    }
  }
}