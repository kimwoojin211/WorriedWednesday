using System;
using Firebase.Firestore;
using WorriedWednesday.Services;

namespace WorriedWednesday.Droid.Extensions
{
  public static class DocumentReferenceExtensions
  {
    public static T Convert<T>(this DocumentSnapshot doc) where T : IIdentifiable
    {
      try
      {
        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(doc.Data.ToDictionary());
        var item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
        item.Id = doc.Id;
        return item;
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine("EXCEPTION");
      }
      return default;
    }
  }
}