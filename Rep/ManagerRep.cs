﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;

namespace v1336.Rep
{
    public class ManagerRep : IRep
    {
        private DBContext db;

        public ManagerRep()
        {
            db = new DBContext();
        }

        public ObservableCollection<Manager> GetAll()
        {
            db.Managers.Load();
            return db.Managers.Local;
        }

        IDbObject IRep.GetById(int id)
        {
            return GetById(id);
        }

        public void Add(IDbObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IDbObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IDbObject obj)
        {
            db.Managers.Remove(obj as Manager);
            db.SaveChanges();
        }

        ObservableCollection<IDbObject> IRep.GetAll()
        {
            db.Managers.Load();
            return new ObservableCollection<IDbObject>(db.Managers.Local);
        }

        public Manager GetById(int id)
        {
            return db.Managers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Manager obj)
        {
            db.Managers.Add(obj);
            db.SaveChanges();
        }

        public void Update(Manager obj)
        {
            db.Managers.Attach(obj);
            var entry = db.Entry(obj);
            entry.Property(e => e.FirstName).IsModified = true;
            db.SaveChanges();
        }

        public void Delete(Manager obj)
        {
            db.Managers.Remove(obj);
            db.SaveChanges();
        }
    }
}
