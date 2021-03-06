//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace ContractManagementData
{
    public partial class AgreementEntities : ObjectContext
    {
        public const string ConnectionString = "name=AgreementEntities";
        public const string ContainerName = "AgreementEntities";
    
        #region Constructors
    
        public AgreementEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public AgreementEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public AgreementEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Contract> Contract
        {
            get { return _contract  ?? (_contract = CreateObjectSet<Contract>("Contract")); }
        }
        private ObjectSet<Contract> _contract;
    
        public ObjectSet<DocumentType> DocumentType
        {
            get { return _documentType  ?? (_documentType = CreateObjectSet<DocumentType>("DocumentType")); }
        }
        private ObjectSet<DocumentType> _documentType;
    
        public ObjectSet<Contract_Document> Contract_Document
        {
            get { return _contract_Document  ?? (_contract_Document = CreateObjectSet<Contract_Document>("Contract_Document")); }
        }
        private ObjectSet<Contract_Document> _contract_Document;
    
        public ObjectSet<Agreement> Agreement
        {
            get { return _agreement  ?? (_agreement = CreateObjectSet<Agreement>("Agreement")); }
        }
        private ObjectSet<Agreement> _agreement;
    
        public ObjectSet<Agreement_AccountUnit> Agreement_AccountUnit
        {
            get { return _agreement_AccountUnit  ?? (_agreement_AccountUnit = CreateObjectSet<Agreement_AccountUnit>("Agreement_AccountUnit")); }
        }
        private ObjectSet<Agreement_AccountUnit> _agreement_AccountUnit;
    
        public ObjectSet<Agreement_CostActual> Agreement_CostActual
        {
            get { return _agreement_CostActual  ?? (_agreement_CostActual = CreateObjectSet<Agreement_CostActual>("Agreement_CostActual")); }
        }
        private ObjectSet<Agreement_CostActual> _agreement_CostActual;
    
        public ObjectSet<Agreement_Memo> Agreement_Memo
        {
            get { return _agreement_Memo  ?? (_agreement_Memo = CreateObjectSet<Agreement_Memo>("Agreement_Memo")); }
        }
        private ObjectSet<Agreement_Memo> _agreement_Memo;
    
        public ObjectSet<Agreement_ResponsibleExternal> Agreement_ResponsibleExternal
        {
            get { return _agreement_ResponsibleExternal  ?? (_agreement_ResponsibleExternal = CreateObjectSet<Agreement_ResponsibleExternal>("Agreement_ResponsibleExternal")); }
        }
        private ObjectSet<Agreement_ResponsibleExternal> _agreement_ResponsibleExternal;
    
        public ObjectSet<Agreement_ResponsibleInternal> Agreement_ResponsibleInternal
        {
            get { return _agreement_ResponsibleInternal  ?? (_agreement_ResponsibleInternal = CreateObjectSet<Agreement_ResponsibleInternal>("Agreement_ResponsibleInternal")); }
        }
        private ObjectSet<Agreement_ResponsibleInternal> _agreement_ResponsibleInternal;
    
        public ObjectSet<Agreement_SalesActual> Agreement_SalesActual
        {
            get { return _agreement_SalesActual  ?? (_agreement_SalesActual = CreateObjectSet<Agreement_SalesActual>("Agreement_SalesActual")); }
        }
        private ObjectSet<Agreement_SalesActual> _agreement_SalesActual;
    
        public ObjectSet<Agreement_SalesPlan> Agreement_SalesPlan
        {
            get { return _agreement_SalesPlan  ?? (_agreement_SalesPlan = CreateObjectSet<Agreement_SalesPlan>("Agreement_SalesPlan")); }
        }
        private ObjectSet<Agreement_SalesPlan> _agreement_SalesPlan;
    
        public ObjectSet<Agreement_Todo> Agreement_Todo
        {
            get { return _agreement_Todo  ?? (_agreement_Todo = CreateObjectSet<Agreement_Todo>("Agreement_Todo")); }
        }
        private ObjectSet<Agreement_Todo> _agreement_Todo;
    
        public ObjectSet<AgreementStatus> AgreementStatus
        {
            get { return _agreementStatus  ?? (_agreementStatus = CreateObjectSet<AgreementStatus>("AgreementStatus")); }
        }
        private ObjectSet<AgreementStatus> _agreementStatus;
    
        public ObjectSet<ExpiryCategory> ExpiryCategory
        {
            get { return _expiryCategory  ?? (_expiryCategory = CreateObjectSet<ExpiryCategory>("ExpiryCategory")); }
        }
        private ObjectSet<ExpiryCategory> _expiryCategory;
    
        public ObjectSet<ExternalPerson> ExternalPerson
        {
            get { return _externalPerson  ?? (_externalPerson = CreateObjectSet<ExternalPerson>("ExternalPerson")); }
        }
        private ObjectSet<ExternalPerson> _externalPerson;
    
        public ObjectSet<ExternalRole> ExternalRole
        {
            get { return _externalRole  ?? (_externalRole = CreateObjectSet<ExternalRole>("ExternalRole")); }
        }
        private ObjectSet<ExternalRole> _externalRole;
    
        public ObjectSet<Import_SalesActual> Import_SalesActual
        {
            get { return _import_SalesActual  ?? (_import_SalesActual = CreateObjectSet<Import_SalesActual>("Import_SalesActual")); }
        }
        private ObjectSet<Import_SalesActual> _import_SalesActual;
    
        public ObjectSet<InternalPerson> InternalPerson
        {
            get { return _internalPerson  ?? (_internalPerson = CreateObjectSet<InternalPerson>("InternalPerson")); }
        }
        private ObjectSet<InternalPerson> _internalPerson;
    
        public ObjectSet<InternalRole> InternalRole
        {
            get { return _internalRole  ?? (_internalRole = CreateObjectSet<InternalRole>("InternalRole")); }
        }
        private ObjectSet<InternalRole> _internalRole;
    
        public ObjectSet<MemoType> MemoType
        {
            get { return _memoType  ?? (_memoType = CreateObjectSet<MemoType>("MemoType")); }
        }
        private ObjectSet<MemoType> _memoType;
    
        public ObjectSet<Organisation> Organisation
        {
            get { return _organisation  ?? (_organisation = CreateObjectSet<Organisation>("Organisation")); }
        }
        private ObjectSet<Organisation> _organisation;
    
        public ObjectSet<RevenueDimension> RevenueDimension
        {
            get { return _revenueDimension  ?? (_revenueDimension = CreateObjectSet<RevenueDimension>("RevenueDimension")); }
        }
        private ObjectSet<RevenueDimension> _revenueDimension;
    
        public ObjectSet<RevenueTrend> RevenueTrend
        {
            get { return _revenueTrend  ?? (_revenueTrend = CreateObjectSet<RevenueTrend>("RevenueTrend")); }
        }
        private ObjectSet<RevenueTrend> _revenueTrend;
    
        public ObjectSet<Sector> Sector
        {
            get { return _sector  ?? (_sector = CreateObjectSet<Sector>("Sector")); }
        }
        private ObjectSet<Sector> _sector;
    
        public ObjectSet<TodoFlag> TodoFlag
        {
            get { return _todoFlag  ?? (_todoFlag = CreateObjectSet<TodoFlag>("TodoFlag")); }
        }
        private ObjectSet<TodoFlag> _todoFlag;
    
        public ObjectSet<TodoPriority> TodoPriority
        {
            get { return _todoPriority  ?? (_todoPriority = CreateObjectSet<TodoPriority>("TodoPriority")); }
        }
        private ObjectSet<TodoPriority> _todoPriority;
    
        public ObjectSet<TodoType> TodoType
        {
            get { return _todoType  ?? (_todoType = CreateObjectSet<TodoType>("TodoType")); }
        }
        private ObjectSet<TodoType> _todoType;
    
        public ObjectSet<TowerDelivery> TowerDelivery
        {
            get { return _towerDelivery  ?? (_towerDelivery = CreateObjectSet<TowerDelivery>("TowerDelivery")); }
        }
        private ObjectSet<TowerDelivery> _towerDelivery;
    
        public ObjectSet<TowerService> TowerService
        {
            get { return _towerService  ?? (_towerService = CreateObjectSet<TowerService>("TowerService")); }
        }
        private ObjectSet<TowerService> _towerService;
    
        public ObjectSet<vwImportBulk> vwImportBulk
        {
            get { return _vwImportBulk  ?? (_vwImportBulk = CreateObjectSet<vwImportBulk>("vwImportBulk")); }
        }
        private ObjectSet<vwImportBulk> _vwImportBulk;
    
        public ObjectSet<ImportBulk> ImportBulk
        {
            get { return _importBulk  ?? (_importBulk = CreateObjectSet<ImportBulk>("ImportBulk")); }
        }
        private ObjectSet<ImportBulk> _importBulk;
    
        public ObjectSet<ImportOption> ImportOption
        {
            get { return _importOption  ?? (_importOption = CreateObjectSet<ImportOption>("ImportOption")); }
        }
        private ObjectSet<ImportOption> _importOption;

        #endregion

    }
}
