
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using EFWeb;
namespace DataAccess
{
    public class UnitOfWorkDB : UnitOfWorkBase
    {        
        public UnitOfWorkDB() : base("")
        {
            try
            {
                base.DbContext = new dbwebEntities();                
                UnitOfWorkDB unitOfWorkHbf = this;
                ((IObjectContextAdapter)base.DbContext).ObjectContext.SavingChanges += new EventHandler(unitOfWorkHbf.OnSavingChanges);
            }
            catch (Exception exception)
            {
            }
        }

        public override void OnSavingChanges(object sender, EventArgs e)
        {
            //ObjectStateEntry objectStateEntry = null;
            Models.ModelBase entity;
            base.OnSavingChanges(sender, e);
            ObjectStateManager objectStateManager = ((IObjectContextAdapter)base.DbContext).ObjectContext.ObjectStateManager;
            IEnumerable<ObjectStateEntry> objectStateEntries = objectStateManager.GetObjectStateEntries(EntityState.Added);
            foreach (ObjectStateEntry objectStateEntry in objectStateEntries)
            {
                entity = objectStateEntry.Entity as Models.ModelBase;
                if (entity != null)
                {                  
                    
                }
            }
            IEnumerable<ObjectStateEntry> objectStateEntries1 = objectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (ObjectStateEntry objectStateEntry1 in objectStateEntries1)
            {
                entity = objectStateEntry1.Entity as Models.ModelBase;           
            }
            IEnumerable<ObjectStateEntry> objectStateEntries2 = objectStateManager.GetObjectStateEntries(EntityState.Deleted);
        }
    }
}