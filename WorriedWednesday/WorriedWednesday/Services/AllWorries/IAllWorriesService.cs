using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.AllWorries
{
  //separate firestore databse for everyone's worries.
  //stretch goal: make it so that worries in this database are automatically deleted after like. a day or something
  //stretch goal: create an algorithm where worries that are recent and have less replies are more likely to appear at the front of the list
  public interface IAllWorriesService
  {
    //Adds new worry to worry database
    Task<bool> LogWorryAsync(Worry worry);

    //Get list of worries to worry database
    Task<List<Worry>> GetWorriesAsync();
  }
}
