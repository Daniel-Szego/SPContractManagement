using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Threading;

namespace ContractManagementData
{
    /// <summary>
    /// DomainServices: Datenbank spezifishe Dienstleistungen 
    /// </summary>
    public class DomainService : IDisposable
    {
        /// <summary>
        /// Referenze auf der EntityModel
        /// </summary>
        AgreementEntities ObjectContext = null;

        public DomainService()
        {
          ObjectContext = new AgreementEntities();
          ObjectContext.ContextOptions.ProxyCreationEnabled = false;
        }


        #region 1_Agreement

            /// <summary>
            /// Auslesen alle Agreement aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement</returns>
            public IQueryable<Agreement> GetAgreements()
            {
                return this.ObjectContext.Agreement;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement</param>
            /// <returns>Agreement für die spezifische ID </returns>
            public IQueryable<Agreement> GetAgreementByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement</param>
            public void InsertAgreement(Agreement agreement)
            {
                agreement.Agreement_AccountUnit = new FixupCollection<Agreement_AccountUnit>();
                agreement.Agreement_CostActual = new FixupCollection<Agreement_CostActual>();
                agreement.Agreement_Memo = new FixupCollection<Agreement_Memo>();
                agreement.Agreement_ResponsibleExternal = new FixupCollection<Agreement_ResponsibleExternal>();
                agreement.Agreement_ResponsibleInternal = new FixupCollection<Agreement_ResponsibleInternal>();
                agreement.Agreement_SalesActual = new FixupCollection<Agreement_SalesActual>();
                agreement.Agreement_SalesPlan = new FixupCollection<Agreement_SalesPlan>();
                agreement.Agreement_Todo = new FixupCollection<Agreement_Todo>();
                this.ObjectContext.Agreement.AddObject(agreement);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement die aktualiziert werden muss</param>
            public void UpdateAgreement(Agreement agreement)
            {
                this.ObjectContext.Agreement.Attach(agreement);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement, EntityState.Modified);
                this.ObjectContext.SaveChanges();

                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement die gelöscht werden muss</param>
            public void DeleteAgreement(Agreement agreement)
            {
                var cntToDelete = this.GetAgreementByID(agreement.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement.DeleteObject(cntToDelete.First<Agreement>());
                    this.ObjectContext.SaveChanges();
                }
            }

        #endregion 

        #region 2_Agreement_AccountUnit

            /// <summary>
            /// Auslesen alle Agreement aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement</returns>
            public IQueryable<Agreement_AccountUnit> GetAgreement_AccountUnits()
            {
                return this.ObjectContext.Agreement_AccountUnit;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_AccountUnit aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_AccountUnit</param>
            /// <returns>Agreement_AccountUnit für die spezifische ID </returns>
            public IQueryable<Agreement_AccountUnit> GetAgreement_AccountUnitByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_AccountUnit
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_AccountUnit hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_AccountUnit</param>
            public void InsertAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
            {
                this.ObjectContext.Agreement_AccountUnit.AddObject(agreement_AccountUnit);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_AccountUnit in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_AccountUnit die aktualiziert werden muss</param>
            public void UpdateAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
            {
                this.ObjectContext.Agreement_AccountUnit.Attach(agreement_AccountUnit);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_AccountUnit, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_AccountUnit in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_AccountUnit die gelöscht werden muss</param>
            public void DeleteAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
            {
                var cntToDelete = this.GetAgreement_AccountUnitByID(agreement_AccountUnit.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_AccountUnit.DeleteObject(cntToDelete.First<Agreement_AccountUnit>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 3_Agreement_CostActual

            /// <summary>
            /// Auslesen alle Agreement_CostActual aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_CostActual</returns>
            public IQueryable<Agreement_CostActual> GetAgreement_CostActuals()
            {
                return this.ObjectContext.Agreement_CostActual;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_CostActual aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_CostActual</param>
            /// <returns>Agreement_CostActual für die spezifische ID </returns>
            public IQueryable<Agreement_CostActual> GetAgreement_CostActualByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_CostActual
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_AccountUnit hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_AccountUnit</param>
            public void InsertAgreement_CostActual(Agreement_CostActual agreement_CostActual)
            {
                this.ObjectContext.Agreement_CostActual.AddObject(agreement_CostActual);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_AccountUnit in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_AccountUnit die aktualiziert werden muss</param>
            public void UpdateAgreement_CostActual(Agreement_CostActual agreement_CostActual)
            {
                this.ObjectContext.Agreement_CostActual.Attach(agreement_CostActual);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_CostActual, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_CostActual in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_CostActual die gelöscht werden muss</param>
            public void DeleteAgreement_CostActual(Agreement_CostActual agreement_CostActual)
            {
                var cntToDelete = this.GetAgreement_CostActualByID(agreement_CostActual.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_CostActual.DeleteObject(cntToDelete.First<Agreement_CostActual>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 4_Agreement_Memo

            /// <summary>
            /// Auslesen alle Agreement_Memo aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_Memo</returns>
            public IQueryable<Agreement_Memo> GetAgreement_Memos()
            {
                return this.ObjectContext.Agreement_Memo;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_Memo aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_Memo</param>
            /// <returns>Agreement_Memo für die spezifische ID </returns>
            public IQueryable<Agreement_Memo> GetAgreement_MemoByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_Memo
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_Memo hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_AccountUnit</param>
            public void InsertAgreement_Memo(Agreement_Memo agreement_Memo)
            {
                this.ObjectContext.Agreement_Memo.AddObject(agreement_Memo);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_Memo in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_Memo die aktualiziert werden muss</param>
            public void UpdateAgreement_Memo(Agreement_Memo agreement_Memo)
            {
                this.ObjectContext.Agreement_Memo.Attach(agreement_Memo);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_Memo, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_Memo in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_Memo die gelöscht werden muss</param>
            public void DeleteAgreement_Memo(Agreement_Memo agreement_Memo)
            {
                var cntToDelete = this.GetAgreement_MemoByID(agreement_Memo.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_Memo.DeleteObject(cntToDelete.First<Agreement_Memo>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 5_Agreement_ResponsibleExternal

            /// <summary>
            /// Auslesen alle Agreement_ResponsibleExternal aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_ResponsibleExternal</returns>
            public IQueryable<Agreement_ResponsibleExternal> GetAgreement_ResponsibleExternals()
            {
                return this.ObjectContext.Agreement_ResponsibleExternal;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_ResponsibleExternal aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_ResponsibleExternal</param>
            /// <returns>Agreement_ResponsibleExternal für die spezifische ID </returns>
            public IQueryable<Agreement_ResponsibleExternal> GetAgreement_ResponsibleExternalByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_ResponsibleExternal
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_ResponsibleExternal hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_ResponsibleExternal</param>
            public void InsertAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
            {
                this.ObjectContext.Agreement_ResponsibleExternal.AddObject(agreement_ResponsibleExternal);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_ResponsibleExternal in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_ResponsibleExternal die aktualiziert werden muss</param>
            public void UpdateAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
            {
                this.ObjectContext.Agreement_ResponsibleExternal.Attach(agreement_ResponsibleExternal);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_ResponsibleExternal, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_ResponsibleExternal in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_ResponsibleExternal die gelöscht werden muss</param>
            public void DeleteAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
            {
                var cntToDelete = this.GetAgreement_ResponsibleExternalByID(agreement_ResponsibleExternal.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_ResponsibleExternal.DeleteObject(cntToDelete.First<Agreement_ResponsibleExternal>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 6_Agreement_ResponsibleInternal

            /// <summary>
            /// Auslesen alle Agreement_ResponsibleInternal aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_ResponsibleInternal</returns>
            public IQueryable<Agreement_ResponsibleInternal> GetAgreement_ResponsibleInternals()
            {
                return this.ObjectContext.Agreement_ResponsibleInternal;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_ResponsibleInternal aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_ResponsibleInternal</param>
            /// <returns>Agreement_ResponsibleInternal für die spezifische ID </returns>
            public IQueryable<Agreement_ResponsibleInternal> GetAgreement_ResponsibleInternalByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_ResponsibleInternal
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_ResponsibleInternal hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_ResponsibleInternal</param>
            public void InsertAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
            {
           
                this.ObjectContext.Agreement_ResponsibleInternal.AddObject(agreement_ResponsibleInternal);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_ResponsibleInternal in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_ResponsibleInternal die aktualiziert werden muss</param>
            public void UpdateAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
            {
                this.ObjectContext.Agreement_ResponsibleInternal.Attach(agreement_ResponsibleInternal);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_ResponsibleInternal, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_ResponsibleInternal in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_ResponsibleInternal die gelöscht werden muss</param>
            public void DeleteAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
            {
                var cntToDelete = this.GetAgreement_ResponsibleInternalByID(agreement_ResponsibleInternal.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_ResponsibleInternal.DeleteObject(cntToDelete.First<Agreement_ResponsibleInternal>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 7_Agreement_SalesActual

            /// <summary>
            /// Auslesen alle Agreement_SalesActual aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_SalesActual</returns>
            public IQueryable<Agreement_SalesActual> GetAgreement_SalesActuals()
            {
                return this.ObjectContext.Agreement_SalesActual;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_SalesActual aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_SalesActual</param>
            /// <returns>Agreement_SalesActual für die spezifische ID </returns>
            public IQueryable<Agreement_SalesActual> GetAgreement_SalesActualByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_SalesActual
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_SalesActual hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_SalesActual</param>
            public void InsertAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
            {
                this.ObjectContext.Agreement_SalesActual.AddObject(agreement_SalesActual);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_SalesActual in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_SalesActual die aktualiziert werden muss</param>
            public void UpdateAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
            {
                this.ObjectContext.Agreement_SalesActual.Attach(agreement_SalesActual);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_SalesActual, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_SalesActual in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_SalesActual die gelöscht werden muss</param>
            public void DeleteAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
            {
                var cntToDelete = this.GetAgreement_SalesActualByID(agreement_SalesActual.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_SalesActual.DeleteObject(cntToDelete.First<Agreement_SalesActual>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 8_Agreement_SalesPlan

            /// <summary>
            /// Auslesen alle Agreement_SalesPlan aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_SalesPlan</returns>
            public IQueryable<Agreement_SalesPlan> GetAgreement_SalesPlans()
            {
                return this.ObjectContext.Agreement_SalesPlan;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_SalesPlan aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_SalesPlan</param>
            /// <returns>Agreement_SalesPlan für die spezifische ID </returns>
            public IQueryable<Agreement_SalesPlan> GetAgreement_SalesPlanByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_SalesPlan
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_SalesPlan hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_SalesPlan</param>
            public void InsertAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
            {
                this.ObjectContext.Agreement_SalesPlan.AddObject(agreement_SalesPlan);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_SalesPlan in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_SalesPlan die aktualiziert werden muss</param>
            public void UpdateAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
            {
                this.ObjectContext.Agreement_SalesPlan.Attach(agreement_SalesPlan);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_SalesPlan, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_SalesPlan in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_SalesPlan die gelöscht werden muss</param>
            public void DeleteAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
            {
                var cntToDelete = this.GetAgreement_SalesPlanByID(agreement_SalesPlan.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_SalesPlan.DeleteObject(cntToDelete.First<Agreement_SalesPlan>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 9_Agreement_Todo

            /// <summary>
            /// Auslesen alle Agreement_Todo aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Agreement_Todo</returns>
            public IQueryable<Agreement_Todo> GetAgreement_Todos()
            {
                return this.ObjectContext.Agreement_Todo;
            }


            /// <summary>
            /// Auslesen eine spezifische Agreement_Todo aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Agreement_Todo</param>
            /// <returns>Agreement_Todo für die spezifische ID </returns>
            public IQueryable<Agreement_Todo> GetAgreement_TodoByID(int _id)
            {
                var res = from agr in this.ObjectContext.Agreement_Todo
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Agreement_Todo hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Agreement_Todo</param>
            public void InsertAgreement_Todo(Agreement_Todo agreement_Todo)
            {
                this.ObjectContext.Agreement_Todo.AddObject(agreement_Todo);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_Todo in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Agreement_Todo die aktualiziert werden muss</param>
            public void UpdateAgreement_Todo(Agreement_Todo agreement_Todo)
            {
                this.ObjectContext.Agreement_Todo.Attach(agreement_Todo);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreement_Todo, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Agreement_Todo in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Agreement_Todo die gelöscht werden muss</param>
            public void DeleteAgreement_Todo(Agreement_Todo agreement_Todo)
            {
                var cntToDelete = this.GetAgreement_TodoByID(agreement_Todo.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Agreement_Todo.DeleteObject(cntToDelete.First<Agreement_Todo>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 10_AgreementStatus

            /// <summary>
            /// Auslesen alle AgreementStatus aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den AgreementStatus</returns>
            public IQueryable<AgreementStatus> GetAgreementStatuss()
            {
                return this.ObjectContext.AgreementStatus;
            }


            /// <summary>
            /// Auslesen eine spezifische AgreementStatus aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der AgreementStatus</param>
            /// <returns>AgreementStatus für die spezifische ID </returns>
            public IQueryable<AgreementStatus> GetAgreementStatusByID(int _id)
            {
                var res = from agr in this.ObjectContext.AgreementStatus
                          where agr.ID == _id
                          select agr;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue AgreementStatus hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue AgreementStatus</param>
            public void InsertAgreementStatus(AgreementStatus agreementStatus)
            {
                agreementStatus.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.AgreementStatus.AddObject(agreementStatus);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte AgreementStatus in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">AgreementStatus die aktualiziert werden muss</param>
            public void UpdateAgreementStatus(AgreementStatus agreementStatus)
            {
                this.ObjectContext.AgreementStatus.Attach(agreementStatus);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(agreementStatus, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte AgreementStatus in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">AgreementStatus die gelöscht werden muss</param>
            public void DeleteAgreementStatus(AgreementStatus agreementStatus)
            {
                var cntToDelete = this.GetAgreementStatusByID(agreementStatus.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.AgreementStatus.DeleteObject(cntToDelete.First<AgreementStatus>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion 

        #region 11_Contract

            /// <summary>
            /// Auslesen alle Contracts aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Contract</returns>
            public IQueryable<Contract> GetContracts()
            {
                return this.ObjectContext.Contract;
            }

            /// <summary>
            /// Auslesen eine spezifische Contract aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="contractNumber">ID der Contract</param>
            /// <returns>Contract für die spezifische ID </returns>
            public IQueryable<Contract> GetContractByID(string contractNumber)
            {
                var res = from contract in this.ObjectContext.Contract
                          where contract.ContractNumber.Equals(contractNumber)
                          select contract;
                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Contract hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Contract</param>
            public void InsertContract(Contract contract)
            {
                try
                {
                    contract.Agreement = new FixupCollection<Agreement>();
                    contract.Contract_Document = new FixupCollection<Contract_Document>();
                    this.ObjectContext.Contract.AddObject(contract);
                    this.ObjectContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Existierte Contract in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Contract die aktualiziert werden muss</param>
            public void UpdateContract(Contract currentContract)
            {
                this.ObjectContext.Contract.Attach(currentContract);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(currentContract, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Contract in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Contract die gelöscht werden muss</param>
            public void DeleteContract(Contract contract)
            {
                try
                {
                    var cntToDelete = this.GetContractByID(contract.ContractNumber);
                    if (cntToDelete.Count() > 0)
                    {
                        this.ObjectContext.Contract.DeleteObject(cntToDelete.First<Contract>());
                        this.ObjectContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion

        #region 12_Contract_Document

            /// <summary>
            /// Auslesen alle Contract_Document aus der Contract Management Datenbank. 
            /// </summary>
            /// <returns>Liste den Contract_Document</returns>
            public IQueryable<Contract_Document> GetContract_Document()
            {
                return this.ObjectContext.Contract_Document;
            }

            /// <summary>
            /// Auslesen eine spezifische Contract_Document aus der Contract Management Datenbank.
            /// </summary>
            /// <param name="_id">ID der Contract_Document</param>
            /// <returns>Contract_Document für die spezifische ID </returns>
            public IQueryable<Contract_Document> GetContractDocumentByID(int _id)
            {
                var res = from contractDoc in this.ObjectContext.Contract_Document
                          where contractDoc.ID == _id
                          select contractDoc;

                return res.DefaultIfEmpty();
            }

            /// <summary>
            /// Neue Contract_Document hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract_Document">Neue Contract_Document</param>
            public void InsertContract_Document(Contract_Document contract_Document)
            {
                this.ObjectContext.Contract_Document.AddObject(contract_Document);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Contract_Document in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract_Document">Contract_Document die aktualiziert werden muss</param>
            public void UpdateContract_Document(Contract_Document currentContract_Document)
            {
                this.ObjectContext.Contract_Document.Attach(currentContract_Document);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(currentContract_Document, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Contract_Document in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract_Document">Contract_Document die gelöscht werden muss</param>
            public void DeleteContract_Document(Contract_Document contract_Document)
            {
                var cntToDelete = this.GetContractDocumentByID(contract_Document.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Contract_Document.DeleteObject(cntToDelete.First<Contract_Document>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 13_DocumentTypes

            /// <summary>
            /// Auslesen alle DocumentTypes aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den DocumentTypes</returns>
            public IQueryable<DocumentType> GetDocumentTypes()
            {
                return this.ObjectContext.DocumentType;
            }

            /// <summary>
            ///  Auslesen eine spezifische DocumentType aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der DocumentType</param>
            /// <returns>DocumentType für die spezifische ID</returns>
            public IQueryable<DocumentType> GetDocumentTypeByID(int _id)
            {
                var res = from docType in this.ObjectContext.DocumentType
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue DocumentType hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue DocumentType</param>
            public void InsertDocumentType(DocumentType documentType)
            {
                documentType.Contract_Document = new FixupCollection<Contract_Document>();
                this.ObjectContext.DocumentType.AddObject(documentType);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte DocumentType in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">DocumentType die aktualiziert werden muss</param>
            public void UpdateDocumentType(DocumentType currentDocumentType)
            {
                this.ObjectContext.DocumentType.Attach(currentDocumentType);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(currentDocumentType, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte DocumentType in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">DocumentType die gelöscht werden muss</param>
            public void DeleteDocumentType(DocumentType documentType)
            {
                var cntToDelete = this.GetDocumentTypeByID(documentType.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.DocumentType.DeleteObject(cntToDelete.First<DocumentType>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 14_ExpiryCategory

            /// <summary>
            /// Auslesen alle ExpiryCategory aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den ExpiryCategory</returns>
            public IQueryable<ExpiryCategory> GetExpiryCategorys()
            {
                return this.ObjectContext.ExpiryCategory;
            }

            /// <summary>
            ///  Auslesen eine spezifische ExpiryCategory aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der ExpiryCategory</param>
            /// <returns>ExpiryCategory für die spezifische ID</returns>
            public IQueryable<ExpiryCategory> GetExpiryCategoryByID(int _id)
            {
                var res = from docType in this.ObjectContext.ExpiryCategory
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue ExpiryCategory hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue ExpiryCategory</param>
            public void InsertExpiryCategory(ExpiryCategory expiryCategory)
            {
                expiryCategory.Agreement_SalesActual = new FixupCollection<Agreement_SalesActual>();
                this.ObjectContext.ExpiryCategory.AddObject(expiryCategory);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExpiryCategory in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">ExpiryCategory die aktualiziert werden muss</param>
            public void UpdateExpiryCategory(ExpiryCategory expiryCategory)
            {
                this.ObjectContext.ExpiryCategory.Attach(expiryCategory);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(expiryCategory, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExpiryCategory in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">ExpiryCategory die gelöscht werden muss</param>
            public void DeleteExpiryCategory(ExpiryCategory expiryCategory)
            {
                var cntToDelete = this.GetExpiryCategoryByID(expiryCategory.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.ExpiryCategory.DeleteObject(cntToDelete.First<ExpiryCategory>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 15_ExternalPerson

            /// <summary>
            /// Auslesen alle ExternalPerson aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den ExternalPerson</returns>
            public IQueryable<ExternalPerson> GetExternalPersons()
            {
                return this.ObjectContext.ExternalPerson;
            }

            /// <summary>
            ///  Auslesen eine spezifische ExternalPerson aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der ExternalPerson</param>
            /// <returns>ExternalPerson für die spezifische ID</returns>
            public IQueryable<ExternalPerson> GetExternalPersonByID(int _id)
            {
                var res = from docType in this.ObjectContext.ExternalPerson
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue ExternalPerson hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue ExternalPerson</param>
            public void InsertExternalPerson(ExternalPerson externalPerson)
            {
                externalPerson.Agreement_ResponsibleExternal = new FixupCollection<Agreement_ResponsibleExternal>();
                this.ObjectContext.ExternalPerson.AddObject(externalPerson);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExternalPerson in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">ExternalPerson die aktualiziert werden muss</param>
            public void UpdateExternalPerson(ExternalPerson externalPerson)
            {
                this.ObjectContext.ExternalPerson.Attach(externalPerson);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(externalPerson, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExternalPerson in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">ExternalPerson die gelöscht werden muss</param>
            public void DeleteExternalPerson(ExternalPerson externalPerson)
            {
                var cntToDelete = this.GetExternalPersonByID(externalPerson.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.ExternalPerson.DeleteObject(cntToDelete.First<ExternalPerson>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 16_ExternalRole

            /// <summary>
            /// Auslesen alle ExternalRole aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den ExternalRole</returns>
            public IQueryable<ExternalRole> GetExternalRoles()
            {
                return this.ObjectContext.ExternalRole;
            }

            /// <summary>
            ///  Auslesen eine spezifische ExternalRole aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der ExternalRole</param>
            /// <returns>ExternalPerson für die spezifische ID</returns>
            public IQueryable<ExternalRole> GetExternalRoleByID(int _id)
            {
                var res = from docType in this.ObjectContext.ExternalRole
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue ExternalRole hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue ExternalRole</param>
            public void InsertExternalRole(ExternalRole externalRole)
            {
                externalRole.Agreement_ResponsibleExternal = new FixupCollection<Agreement_ResponsibleExternal>();
                this.ObjectContext.ExternalRole.AddObject(externalRole);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExternalRole in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">ExternalRole die aktualiziert werden muss</param>
            public void UpdateExternalRole(ExternalRole externalRole)
            {
                this.ObjectContext.ExternalRole.Attach(externalRole);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(externalRole, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte ExternalRole in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">ExternalRole die gelöscht werden muss</param>
            public void DeleteExternalRole(ExternalRole externalRole)
            {
                var cntToDelete = this.GetExternalRoleByID(externalRole.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.ExternalRole.DeleteObject(cntToDelete.First<ExternalRole>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 17_Import_SalesActual

            /// <summary>
            /// Auslesen alle Import_SalesActual aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den Import_SalesActual</returns>
            public IQueryable<Import_SalesActual> GetImport_SalesActuals()
            {
                return this.ObjectContext.Import_SalesActual;
            }

            /// <summary>
            ///  Auslesen eine spezifische Import_SalesActual aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der Import_SalesActual</param>
            /// <returns>Import_SalesActual für die spezifische ID</returns>
            public IQueryable<Import_SalesActual> GetImport_SalesActualByID(Guid _id)
            {
                var res = from docType in this.ObjectContext.Import_SalesActual
                          where docType.GUID.Equals(_id)
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue Import_SalesActual hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue ExternalRole</param>
            public void InsertImport_SalesActual(Import_SalesActual import_SalesActual)
            {
                this.ObjectContext.Import_SalesActual.AddObject(import_SalesActual);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Import_SalesActual in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Import_SalesActual die aktualiziert werden muss</param>
            public void UpdateImport_SalesActual(Import_SalesActual import_SalesActual)
            {
                this.ObjectContext.Import_SalesActual.Attach(import_SalesActual);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(import_SalesActual, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Import_SalesActual in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Import_SalesActual die gelöscht werden muss</param>
            public void DeleteImport_SalesActual(Import_SalesActual import_SalesActual)
            {
                var cntToDelete = this.GetImport_SalesActualByID(Guid.Parse(import_SalesActual.GUID));
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Import_SalesActual.DeleteObject(cntToDelete.First<Import_SalesActual>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 18_InternalRole

            /// <summary>
            /// Auslesen alle InternalRole aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den InternalRole</returns>
            public IQueryable<InternalRole> GetInternalRoles()
            {
                return this.ObjectContext.InternalRole;
            }

            /// <summary>
            ///  Auslesen eine spezifische InternalRole aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der InternalRole</param>
            /// <returns>InternalRole für die spezifische ID</returns>
            public IQueryable<InternalRole> GetInternalRoleByID(int _id)
            {
                var res = from docType in this.ObjectContext.InternalRole
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue InternalRole hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue InternalRole</param>
            public void InsertInternalRole(InternalRole internalRole)
            {
                internalRole.Agreement_ResponsibleInternal = new FixupCollection<Agreement_ResponsibleInternal>();
                this.ObjectContext.InternalRole.AddObject(internalRole);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte InternalRole in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">InternalRole die aktualiziert werden muss</param>
            public void UpdateInternalRole(InternalRole internalRole)
            {
                this.ObjectContext.InternalRole.Attach(internalRole);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internalRole, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte InternalRole in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">InternalRole die gelöscht werden muss</param>
            public void DeleteInternalRole(InternalRole internalRole)
            {
                var cntToDelete = this.GetInternalRoleByID(internalRole.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.InternalRole.DeleteObject(cntToDelete.First<InternalRole>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 19_InternalPerson

            /// <summary>
            /// Auslesen alle InternalPerson aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den InternalPerson</returns>
            public IQueryable<InternalPerson> GetInternalPersons()
            {
                return this.ObjectContext.InternalPerson;
            }

            /// <summary>
            ///  Auslesen eine spezifische InternalPerson aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der InternalPerson</param>
            /// <returns>InternalPerson für die spezifische ID</returns>
            public IQueryable<InternalPerson> GetInternalPersonByID(int _id)
            {
                var res = from docType in this.ObjectContext.InternalPerson
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue InternalPerson hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue InternalPerson</param>
            public void InsertInternalPerson(InternalPerson internalPerson)
            {
                internalPerson.Agreement_Memo = new FixupCollection<Agreement_Memo>();
                internalPerson.Agreement_ResponsibleInternal = new FixupCollection<Agreement_ResponsibleInternal>();
                internalPerson.Agreement_Todo = new FixupCollection<Agreement_Todo>();
                internalPerson.Agreement_Todo1 = new FixupCollection<Agreement_Todo>();
                this.ObjectContext.InternalPerson.AddObject(internalPerson);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte InternalPerson in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">InternalPerson die aktualiziert werden muss</param>
            public void UpdateInternalPerson(InternalPerson internalPerson)
            {
                this.ObjectContext.InternalPerson.Attach(internalPerson);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internalPerson, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte InternalPerson in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">InternalPerson die gelöscht werden muss</param>
            public void DeleteInternalPerson(InternalPerson internalPerson)
            {
                var cntToDelete = this.GetInternalPersonByID(internalPerson.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.InternalPerson.DeleteObject(cntToDelete.First<InternalPerson>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 20_MemoType

            /// <summary>
            /// Auslesen alle MemoType aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den MemoType</returns>
            public IQueryable<MemoType> GetMemoTypes()
            {
                return this.ObjectContext.MemoType;
            }

            /// <summary>
            ///  Auslesen eine spezifische MemoType aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der MemoType</param>
            /// <returns>MemoType für die spezifische ID</returns>
            public IQueryable<MemoType> GetMemoTypeByID(int _id)
            {
                var res = from docType in this.ObjectContext.MemoType
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue MemoType hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue MemoType</param>
            public void InsertMemoType(MemoType memoType)
            {
                memoType.Agreement_Memo = new FixupCollection<Agreement_Memo>();
                this.ObjectContext.MemoType.AddObject(memoType);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte MemoType in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">MemoType die aktualiziert werden muss</param>
            public void UpdateMemoType(MemoType memoType)
            {
                this.ObjectContext.MemoType.Attach(memoType);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(memoType, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte MemoType in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">MemoType die gelöscht werden muss</param>
            public void DeleteMemoType(MemoType memoType)
            {
                var cntToDelete = this.GetMemoTypeByID(memoType.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.MemoType.DeleteObject(cntToDelete.First<MemoType>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 21_Organisation

            /// <summary>
            /// Auslesen alle Organisation aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den Organisation</returns>
            public IQueryable<Organisation> GetOrganisations()
            {
                return this.ObjectContext.Organisation;
            }

            /// <summary>
            ///  Auslesen eine spezifische Organisation aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der Organisation</param>
            /// <returns>Organisation für die spezifische ID</returns>
            public IQueryable<Organisation> GetOrganisationByID(int _id)
            {
                var res = from docType in this.ObjectContext.Organisation
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue Organisation hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Organisation</param>
            public void InsertOrganisation(Organisation organisation)
            {
                organisation.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.Organisation.AddObject(organisation);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Organisation in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Organisation die aktualiziert werden muss</param>
            public void UpdateOrganisation(Organisation organisation)
            {
                this.ObjectContext.Organisation.Attach(organisation);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(organisation, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Organisation in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Organisation die gelöscht werden muss</param>
            public void DeleteOrganisation(Organisation organisation)
            {
                var cntToDelete = this.GetOrganisationByID(organisation.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Organisation.DeleteObject(cntToDelete.First<Organisation>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 22_RevenueDimension

            /// <summary>
            /// Auslesen alle RevenueDimension aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den RevenueDimension</returns>
            public IQueryable<RevenueDimension> GetRevenueDimensions()
            {
                return this.ObjectContext.RevenueDimension;
            }

            /// <summary>
            ///  Auslesen eine spezifische RevenueDimension aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der RevenueDimension</param>
            /// <returns>RevenueDimension für die spezifische ID</returns>
            public IQueryable<RevenueDimension> GetRevenueDimensionByID(int _id)
            {
                var res = from docType in this.ObjectContext.RevenueDimension
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue RevenueDimension hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue RevenueDimension</param>
            public void InsertRevenueDimension(RevenueDimension revenueDimension)
            {
                revenueDimension.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.RevenueDimension.AddObject(revenueDimension);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte RevenueDimension in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">RevenueDimension die aktualiziert werden muss</param>
            public void UpdateRevenueDimension(RevenueDimension revenueDimension)
            {
                this.ObjectContext.RevenueDimension.Attach(revenueDimension);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(revenueDimension, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte RevenueDimension in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">RevenueDimension die gelöscht werden muss</param>
            public void DeleteRevenueDimension(RevenueDimension revenueDimension)
            {
                var cntToDelete = this.GetRevenueDimensionByID(revenueDimension.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.RevenueDimension.DeleteObject(cntToDelete.First<RevenueDimension>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 23_RevenueTrend

            /// <summary>
            /// Auslesen alle RevenueTrend aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den RevenueTrend</returns>
            public IQueryable<RevenueTrend> GetRevenueTrends()
            {
                return this.ObjectContext.RevenueTrend;
            }

            /// <summary>
            ///  Auslesen eine spezifische RevenueTrend aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der RevenueTrend</param>
            /// <returns>RevenueTrend für die spezifische ID</returns>
            public IQueryable<RevenueTrend> GetRevenueTrendByID(int _id)
            {
                var res = from docType in this.ObjectContext.RevenueTrend
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue RevenueDimension hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue RevenueDimension</param>
            public void InsertRevenueTrend(RevenueTrend revenueTrend)
            {
                revenueTrend.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.RevenueTrend.AddObject(revenueTrend);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte RevenueTrend in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">RevenueTrend die aktualiziert werden muss</param>
            public void UpdateRevenueTrend(RevenueTrend revenueTrend)
            {
                this.ObjectContext.RevenueTrend.Attach(revenueTrend);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(revenueTrend, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte RevenueTrend in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">RevenueTrend die gelöscht werden muss</param>
            public void DeleteRevenueTrend(RevenueTrend revenueTrend)
            {
                var cntToDelete = this.GetRevenueTrendByID(revenueTrend.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.RevenueTrend.DeleteObject(cntToDelete.First<RevenueTrend>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 24_Sector

            /// <summary>
            /// Auslesen alle Sector aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den Sector</returns>
            public IQueryable<Sector> GetSectors()
            {
                return this.ObjectContext.Sector;
            }

            /// <summary>
            ///  Auslesen eine spezifische Sector aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der Sector</param>
            /// <returns>Sector für die spezifische ID</returns>
            public IQueryable<Sector> GetSectorByID(int _id)
            {
                var res = from docType in this.ObjectContext.Sector
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue Sector hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue Sector</param>
            public void InsertSector(Sector sector)
            {
                sector.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.Sector.AddObject(sector);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Sector in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">Sector die aktualiziert werden muss</param>
            public void UpdateSector(Sector sector)
            {
                this.ObjectContext.Sector.Attach(sector);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sector, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Sector in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Sector die gelöscht werden muss</param>
            public void DeleteSector(Sector sector)
            {
                var cntToDelete = this.GetSectorByID(sector.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.Sector.DeleteObject(cntToDelete.First<Sector>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 25_TodoFlag

            /// <summary>
            /// Auslesen alle TodoFlag aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TodoFlag</returns>
            public IQueryable<TodoFlag> GetTodoFlags()
            {
                return this.ObjectContext.TodoFlag;
            }

            /// <summary>
            ///  Auslesen eine spezifische TodoFlag aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der TodoFlag</param>
            /// <returns>TodoFlag für die spezifische ID</returns>
            public IQueryable<TodoFlag> GetTodoFlagByID(int _id)
            {
                var res = from docType in this.ObjectContext.TodoFlag
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue TodoFlag hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue TodoFlag</param>
            public void InsertTodoFlag(TodoFlag todoFlag)
            {
                todoFlag.Agreement_Todo = new FixupCollection<Agreement_Todo>();
                this.ObjectContext.TodoFlag.AddObject(todoFlag);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TodoFlag in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">TodoFlag die aktualiziert werden muss</param>
            public void UpdateTodoFlag(TodoFlag todoFlag)
            {
                this.ObjectContext.TodoFlag.Attach(todoFlag);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(todoFlag, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte Sector in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">Sector die gelöscht werden muss</param>
            public void DeleteTodoFlag(TodoFlag todoFlag)
            {
                var cntToDelete = this.GetTodoFlagByID(todoFlag.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.TodoFlag.DeleteObject(cntToDelete.First<TodoFlag>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 26_TodoPriority

            /// <summary>
            /// Auslesen alle TodoPriority aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TodoPriority</returns>
            public IQueryable<TodoPriority> GetTodoPrioritys()
            {
                return this.ObjectContext.TodoPriority;
            }

            /// <summary>
            ///  Auslesen eine spezifische TodoPriority aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der TodoPriority</param>
            /// <returns>TodoPriority für die spezifische ID</returns>
            public IQueryable<TodoPriority> GetTodoPriorityByID(int _id)
            {
                var res = from docType in this.ObjectContext.TodoPriority
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue TodoPriority hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue TodoPriority</param>
            public void InsertTodoPriority(TodoPriority todoPriority)
            {
                todoPriority.Agreement_Todo = new FixupCollection<Agreement_Todo>();
                this.ObjectContext.TodoPriority.AddObject(todoPriority);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TodoPriority in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">TodoPriority die aktualiziert werden muss</param>
            public void UpdateTodoPriority(TodoPriority todoPriority)
            {
                this.ObjectContext.TodoPriority.Attach(todoPriority);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(todoPriority, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TodoPriority in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">TodoPriority die gelöscht werden muss</param>
            public void DeleteTodoPriority(TodoPriority todoPriority)
            {
                var cntToDelete = this.GetTodoPriorityByID(todoPriority.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.TodoPriority.DeleteObject(cntToDelete.First<TodoPriority>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 27_TodoType

            /// <summary>
            /// Auslesen alle TodoType aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TodoType</returns>
            public IQueryable<TodoType> GetTodoTypes()
            {
                return this.ObjectContext.TodoType;
            }

            /// <summary>
            ///  Auslesen eine spezifische TodoType aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der TodoType</param>
            /// <returns>TodoType für die spezifische ID</returns>
            public IQueryable<TodoType> GetTodoTypeByID(int _id)
            {
                var res = from docType in this.ObjectContext.TodoType
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue TodoType hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue TodoType</param>
            public void InsertTodoType(TodoType todoType)
            {
                todoType.Agreement_Todo = new FixupCollection<Agreement_Todo>();
                this.ObjectContext.TodoType.AddObject(todoType);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TodoType in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">TodoType die aktualiziert werden muss</param>
            public void UpdateTodoType(TodoType todoType)
            {
                this.ObjectContext.TodoType.Attach(todoType);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(todoType, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TodoType in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">TodoType die gelöscht werden muss</param>
            public void DeleteTodoType(TodoType todoType)
            {
                var cntToDelete = this.GetTodoTypeByID(todoType.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.TodoType.DeleteObject(cntToDelete.First<TodoType>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 28_TowerDelivery

            /// <summary>
            /// Auslesen alle TowerDelivery aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TowerDelivery</returns>
            public IQueryable<TowerDelivery> GetTowerDeliverys()
            {
                return this.ObjectContext.TowerDelivery;
            }

            /// <summary>
            ///  Auslesen eine spezifische TowerDelivery aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der TowerDelivery</param>
            /// <returns>TowerDelivery für die spezifische ID</returns>
            public IQueryable<TowerDelivery> GetTowerDeliveryByID(int _id)
            {
                var res = from docType in this.ObjectContext.TowerDelivery
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue TowerDelivery hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue TowerDelivery</param>
            public void InsertTowerDelivery(TowerDelivery towerDelivery)
            {
                towerDelivery.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.TowerDelivery.AddObject(towerDelivery);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TowerDelivery in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">TowerDelivery die aktualiziert werden muss</param>
            public void UpdateTowerDelivery(TowerDelivery towerDelivery)
            {
                this.ObjectContext.TowerDelivery.Attach(towerDelivery);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(towerDelivery, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TowerDelivery in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">TowerDelivery die gelöscht werden muss</param>
            public void DeleteTowerDelivery(TowerDelivery towerDelivery)
            {
                var cntToDelete = this.GetTowerDeliveryByID(towerDelivery.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.TowerDelivery.DeleteObject(cntToDelete.First<TowerDelivery>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 29_TowerService

            /// <summary>
            /// Auslesen alle TowerService aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TowerService</returns>
            public IQueryable<TowerService> GetTowerServices()
            {
                return this.ObjectContext.TowerService;
            }

            /// <summary>
            ///  Auslesen eine spezifische TowerService aus der Contract Management Datenbank. 
            /// </summary>
            /// <param name="_id">ID der TowerService</param>
            /// <returns>TowerService für die spezifische ID</returns>
            public IQueryable<TowerService> GetTowerServiceByID(int _id)
            {
                var res = from docType in this.ObjectContext.TowerService
                          where docType.ID == _id
                          select docType;

                return res.DefaultIfEmpty();
            }


            /// <summary>
            /// Neue TowerService hinzufügen zu dem der Contract Management Datenbank.
            /// </summary>
            /// <param name="contract">Neue TowerService</param>
            public void InsertTowerService(TowerService towerService)
            {
                towerService.Agreement = new FixupCollection<Agreement>();
                this.ObjectContext.TowerService.AddObject(towerService);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TowerService in dem der Contract Management Datenbank zu aktualizieren.
            /// </summary>
            /// <param name="currentContract">TowerService die aktualiziert werden muss</param>
            public void UpdateTowerService(TowerService towerService)
            {
                this.ObjectContext.TowerService.Attach(towerService);
                this.ObjectContext.ObjectStateManager.ChangeObjectState(towerService, EntityState.Modified);
                this.ObjectContext.SaveChanges();
            }

            /// <summary>
            /// Existierte TowerService in dem der Contract Management Datenbank zu löschen.
            /// </summary>
            /// <param name="contract">TowerService die gelöscht werden muss</param>
            public void DeleteTowerService(TowerService towerService)
            {
                var cntToDelete = this.GetTowerServiceByID(towerService.ID);
                if (cntToDelete.Count() > 0)
                {
                    this.ObjectContext.TowerService.DeleteObject(cntToDelete.First<TowerService>());
                    this.ObjectContext.SaveChanges();
                }
            }

            #endregion

        #region 30_vWImportBulk

            /// <summary>
            /// Auslesen alle TowerService aus der Contract Management Datenbank.
            /// </summary>
            /// <returns>Liste den TowerService</returns>
            public IQueryable<vwImportBulk> GetvWImportBulks()
            {
                return this.ObjectContext.vwImportBulk;
            }

            #endregion

        #region 31_ImportBulk

        // Implementation to be done if necessary.

        #endregion

        #region 31_ImportOption

            // Implementation to be done if necessary.

        #endregion


        #region StoredProcedures_DirectAccess

            /// <summary>
            /// StartImport_ByProfile stored procedure in der Contract Management Datenbank mit profil Name zu starten.
        /// </summary>
        /// <param name="id">Profil Name</param>
            public void StartImportByProfile(string id)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {

                    var eintityConnection = this.ObjectContext.Connection as EntityConnection;
                    SqlConnection conn = eintityConnection.StoreConnection as SqlConnection;
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(Constants.StartImport_SalesActualProcName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.CommandTimeout = 300;
                            cmd.Parameters.Add(Constants.StartImport_SalesActualParName, SqlDbType.NVarChar);
                            cmd.Parameters[Constants.StartImport_SalesActualParName].Value = id;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (!(conn.State == ConnectionState.Closed))
                        {
                            conn.Close();
                        }
                    }
                });
            }

        #endregion

        #region Dispose

            public void Dispose()
        {


        }


        #endregion

        }
}
