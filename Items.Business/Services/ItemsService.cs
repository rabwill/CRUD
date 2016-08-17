using System.Collections.Generic;
using System.Linq;
using Items.Business.DAL.Entities;
using Items.Business.Services.Interfaces;

namespace Items.Business.Services
{
    /// <summary>
    /// Interface resolved by simple injector
    /// </summary>
    public interface IItemsService : IService<Item>
    { }

    /// <summary>
    /// Mock service to simulate the database access layer
    /// </summary>
    public class ItemsService : IItemsService
    {
        #region Auto increment index

        private static int autoIncrementIndex = 0;

        private static int GetIndex()
        {
            autoIncrementIndex++;
            return autoIncrementIndex;
        }

        #endregion


        // Mock database with some sample data

        private static readonly List<Item> mockDatabase = new List<Item>
        {
            new Item{Id = GetIndex(),Place = "Melbourne",UserName = "Rabia",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Melbourne",UserName = "Joshua",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Melbourne",UserName = "James",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Sydney",UserName = "Whity",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Sydney",UserName = "Pon",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Melbourne",UserName = "Nisha",DateOfTravel="",FlightCost="",FlightName="",Website=""},
            new Item{Id = GetIndex(),Place = "Melbourne",UserName = "Sam",DateOfTravel="",FlightCost="",FlightName="",Website=""},
        };

        public Item Add(Item item)
        {

            mockDatabase.Add(item);
            item.Id = GetIndex();
            return item;
        }

        public Item Get(int id)
        {
            return mockDatabase.SingleOrDefault(item => item.Id == id);
        }

        public Item Get(string name)
        {
            return mockDatabase.SingleOrDefault(item => item.UserName == name);
        }

        public IEnumerable<Item> GetAll()
        {
            return mockDatabase;
        }

        public bool Update(Item updatedItem)
        {
            // Null check
            if (updatedItem == null) return false;

            // Item must exists
            if (!this.Any(updatedItem.Id)) return false;

            var serverItem = mockDatabase.Find(item => item.Id == updatedItem.Id);

            serverItem.Place = updatedItem.Place;
            serverItem.DateOfTravel = updatedItem.DateOfTravel;
            serverItem.UserName = updatedItem.UserName;
            serverItem.FlightCost = updatedItem.FlightCost;
            serverItem.FlightName = updatedItem.FlightName;
            serverItem.Website = updatedItem.Website;

            return true;
        }

        public bool Remove(int id)
        {
            var itemToRemove = mockDatabase.SingleOrDefault(item => item.Id == id);
            if (itemToRemove == null) return false;
            return mockDatabase.Remove(itemToRemove);
        }

        public bool Remove(string name)
        {
            var itemToRemove = this.Get(name);
            if (itemToRemove == null)
                return false;

            return this.Remove(itemToRemove.Id);
        }

        public bool Any(int id)
        {
            return mockDatabase.Any(item => item.Id == id);
        }

        public bool Any(string name)
        {
            return mockDatabase.Any(item => item.UserName == name);
        }

        public void Dispose()
        {
            mockDatabase.Clear();
        }
    }
}