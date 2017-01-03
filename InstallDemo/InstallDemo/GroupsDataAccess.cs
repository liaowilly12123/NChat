using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace InstallDemo
{
   public class GroupsDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<GroupData> Groups { get; set; }

        public GroupsDataAccess()
        {
            //connection method to connect to database
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            //creates a table
            database.CreateTable<GroupData>();

            this.Groups = new ObservableCollection<GroupData>(database.Table<GroupData>());

            //if table is empty, initialize the collection
            if (!database.Table<GroupData>().Any())
            {
                AddNewGroup();
            }
        }

        public void AddNewGroup()
        {
            this.Groups.Add(new GroupData
            {
                groupName = "GroupName",
                //adding contacts may be shown here or just added using edit button
            });
        }

        //use LINQ to query and filter data
        public IEnumerable<GroupData> GetFilteredGroups(string groupname)
        {
            lock (collisionLock)
            {
                var query = from grouper in database.Table<GroupData>()
                            where grouper.groupName == groupname
                            select grouper;
                return query.AsEnumerable();
            }
        }
        
        public GroupData GetGroup(int id)
        {
            lock (collisionLock)
            {
                return database.Table<GroupData>().FirstOrDefault(groupdata => groupdata.ID == id);
            }
        }

        public int SaveGroup(GroupData GroupInstance)
        {
            lock (collisionLock)
            {
                //if group id is equal to 0 it means there is no group saved, if not zero then there is already a group that exists
                if (GroupInstance.ID != 0)
                {
                    database.Update(GroupInstance);
                    return GroupInstance.ID;
                }
                else
                {
                    database.Insert(GroupInstance);
                    return GroupInstance.ID;
                }
            }
        }

        public void SaveAllGroups()
        {
            lock (collisionLock)
            {
                foreach (var groupInstance in this.Groups)
                {
                    if (groupInstance.ID != 0)
                    {
                        database.Update(groupInstance);
                    }
                    else
                    {
                        database.Insert(groupInstance);
                    }
                }
            }
        }


        public int DeleteGroup(GroupData GroupInstance)
        {
            var id = GroupInstance.ID;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<GroupData>(id);
                }
            }
            this.Groups.Remove(GroupInstance);
            return id;
        }
    }
}
