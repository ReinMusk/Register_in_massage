using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Register_in_massage
{
    public class LocalRepository
    {
        SQLiteConnection database;
        public LocalRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Masseur>();
            database.CreateTable<User>();
            database.CreateTable<Appointment>();
        }
        public int SaveUser(User usr)
        {
            return database.Insert(usr);
        }
        public int SaveMasseur(Masseur ms)
        {
            return database.Insert(ms);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }
        public int DeleteMasseur(int id)
        {
            return database.Delete<Masseur>(id);
        }
        public Masseur GetMs(int id)
        {
            return database.Get<Masseur>(id);
        }
        public User GetUs(int id)
        {
            return database.Get<User>(id);
        }

        public List<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public List<Masseur> GetMasseurs()
        {
            return database.Table<Masseur>().ToList();
        }

        public User GetUser(string num)
        {
            var user = new User();
            foreach (var item in GetUsers())
            {
                if (item.Number == num)
                {
                    user = item;
                }
                else
                    user = null;
            }

            return user;
        }

        public int SaveAppointment(Appointment app)
        {
            return database.Insert(app);
        }

        public List<Appointment> GetAllAppointments()
        {
            return database.Table<Appointment>().ToList();
        }

        public List<Appointment> GetUserAppointments(User user)
        {
            return database.Table<Appointment>().Where(x => x.IdUser == user.Id).ToList();
        }

        public bool UserIsCorrect(User user)
        {
            return database.Get<User>(x => x.Number == user.Number && x.Password == user.Password) != null;
        }

        //public Building GetBuildingByProject(Project project)
        //{
        //    return database.Get<Building>(x => x.Id == project.BuildId);
        //}
        //public bool UserIsCorrect(Minecrafter minecrafter)
        //{
        //    return database.Get<Minecrafter>(x => x.Login == minecrafter.Login && x.Password == minecrafter.Password) != null;
        //}

        //public void AddMinecrafter(Minecrafter minecrafter)
        //{
        //    database.Insert(minecrafter);
        //}
        //public List<Project> GetProjects()
        //{
        //    return database.Table<Project>().ToList();
        //}
        //public List<string> GetBuildingTypes()
        //{
        //    var types = new List<string>();
        //    foreach (Project project in GetProjects())
        //    {
        //        types.Add(project.BuildType);
        //    }
        //    return types.Distinct().ToList();
        //}
        //public int AddToFavourites(Project project)
        //{
        //    return database.Update(project);
        //}

        //public List<Building> GetFavourites()
        //{
        //    var favProjects = GetProjects().Where(x => x.IsFavourite).ToList();
        //    var favBuildings = new List<Building>();
        //    foreach (var project in favProjects)
        //    {
        //        favBuildings.Add(GetBuildingByProject(project));
        //    }
        //    return favBuildings;
        //}
    }
}
