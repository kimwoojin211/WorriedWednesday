﻿//using Android.App;
//using Android.Content;
//using Android.Gms.Tasks;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Firebase.Firestore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.Gms.Tasks;
//using Task = Android.Gms.Tasks.Task;
//using WorriedWednesday.Services;
//using WorriedWednesday.Droid.Extensions;

//namespace WorriedWednesday.Droid
//{
//  public class OnDocumentCompleteListener<T> : Java.Lang.Object, IOnCompleteListener
//    where T : IIdentifiable
//  {
//    private TaskCompletionSource<T> _tcs;
//    public OnDocumentCompleteListener(TaskCompletionSource<T> tcs)
//    {
//      _tcs = tcs;
//    }

//    public void OnComplete(Task task)
//    {
//      if(task.IsSuccessful)
//      {
//        var docObj = task.Result;
//        if(docObj is DocumentSnapshot docSS)
//        {
//          _tcs.TrySetResult(docSS.Convert<T>());
//          return;
//        }
//      }
//      //something went wrong
//      _tcs.TrySetResult(default);

//    }
//  }
//}