using System;
using Firebase.Firestore;
using WorriedWednesday.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WorriedWednesday.Droid.Extensions
{
  public static class DocumentReferenceExtensions
  {
    public static T Convert<T>(this DocumentSnapshot doc) where T : IIdentifiable
    {
      try
      {
        var jsonStr = JsonConvert.SerializeObject(doc.Data.ToDictionary());
        var item = JsonConvert.DeserializeObject<T>(jsonStr);
        item.Id = doc.Id;
        return item;
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine("EXCEPTION:" + e);
      }
      return default;
    }
    public static List<T> Convert<T>(this QuerySnapshot docs) where T : IIdentifiable
    {
      var list = new List<T>();
      foreach (var doc in docs.Documents)
      {
        list.Add(doc.Convert<T>());
      }
      return list;
    }
  }
}