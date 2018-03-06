using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AtosContractManagementData;

namespace AtosContractManagementSOAPServcie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICMService" in both code and config file together.
    /// <summary>
    /// SOAP Schnittstelle für die Hauptfunktionalitäten.
    /// </summary>
    [ServiceContract]
    public interface ICMService
    {
        #region 1_Agreement

        // Agreement
        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement</returns>
        [OperationContract]
        List<Agreement> GetAgreements();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement</param>
        /// <returns>Agreement für die spezifische ID </returns>
        [OperationContract]
        List<Agreement> GetAgreementByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement</param>
        [OperationContract]
        void InsertAgreement(Agreement agreement);

        /// <summary>
        /// Schnittstelle : Existierte Agreement in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement(Agreement agreement);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement(Agreement agreement);

        #endregion

        #region 2_Agreement_AccountUnit

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_AccountUnit aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_AccountUnit</returns>
        [OperationContract]
        List<Agreement_AccountUnit> GetAgreement_AccountUnits();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_AccountUnit aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_AccountUnit</param>
        /// <returns>Agreement_AccountUnit für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_AccountUnit> GetAgreement_AccountUnitByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_AccountUnit hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_AccountUnit</param>
        [OperationContract]
        void InsertAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_AccountUnit in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_AccountUnit die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_AccountUnit in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_AccountUnit die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit);

        #endregion

        #region 3_Agreement_CostActual

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_CostActual aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_CostActual</returns>
        [OperationContract]
        List<Agreement_CostActual> GetAgreement_CostActuals();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_CostActual aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_CostActual</param>
        /// <returns>Agreement_CostActual für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_CostActual> GetAgreement_CostActualByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_CostActual hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_CostActual</param>
        [OperationContract]
        void InsertAgreement_CostActual(Agreement_CostActual agreement_CostActual);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_CostActual in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_CostActual die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_CostActual(Agreement_CostActual agreement_CostActual);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_CostActual in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_CostActual die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_CostActual(Agreement_CostActual agreement_CostActual);

        #endregion

        #region 4_Agreement_Memo

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_Memo aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_Memo</returns>
        [OperationContract]
        List<Agreement_Memo> GetAgreement_Memos();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_Memo aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_Memo</param>
        /// <returns>Agreement_Memo für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_Memo> GetAgreement_MemoByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_Memo hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_Memo</param>
        [OperationContract]
        void InsertAgreement_Memo(Agreement_Memo agreement_Memo);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_Memo in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_Memo die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_Memo(Agreement_Memo agreement_Memo);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_CostActual in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_CostActual die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_Memo(Agreement_Memo agreement_Memo);

        #endregion

        #region 5_Agreement_ResponsibleExternal

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_ResponsibleExternal aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_ResponsibleExternal</returns>
        [OperationContract]
        List<Agreement_ResponsibleExternal> GetAgreement_ResponsibleExternals();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_ResponsibleExternal aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_ResponsibleExternal</param>
        /// <returns>Agreement_ResponsibleExternal für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_ResponsibleExternal> GetAgreement_ResponsibleExternalByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_ResponsibleExternal hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_ResponsibleExternal</param>
        [OperationContract]
        void InsertAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_ResponsibleExternal in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_ResponsibleExternal die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_ResponsibleExternal in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_ResponsibleExternal die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal);

        #endregion

        #region 6_Agreement_ResponsibleInternal

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_ResponsibleInternal aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_ResponsibleInternal</returns>
        [OperationContract]
        List<Agreement_ResponsibleInternal> GetAgreement_ResponsibleInternals();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_ResponsibleInternal aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_ResponsibleInternal</param>
        /// <returns>Agreement_ResponsibleInternal für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_ResponsibleInternal> GetAgreement_ResponsibleInternalByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_ResponsibleInternal hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_ResponsibleInternal</param>
        [OperationContract]
        void InsertAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_ResponsibleInternal in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_ResponsibleInternal die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_ResponsibleInternal in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_ResponsibleInternal die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal);

        #endregion

        #region 7_Agreement_SalesActual

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_SalesActual aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_SalesActual</returns>
        [OperationContract]
        List<Agreement_SalesActual> GetAgreement_SalesActuals();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_SalesActual aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_SalesActual</param>
        /// <returns>Agreement_SalesActual für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_SalesActual> GetAgreement_SalesActualByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_SalesActual hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_SalesActual</param>
        [OperationContract]
        void InsertAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_SalesActual in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_SalesActual die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_SalesActual in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_SalesActual die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual);

        #endregion

        #region 8_Agreement_SalesPlan

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_SalesPlan aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_SalesPlan</returns>
        [OperationContract]
        List<Agreement_SalesPlan> GetAgreement_SalesPlans();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_SalesPlan aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_SalesPlan</param>
        /// <returns>Agreement_SalesPlan für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_SalesPlan> GetAgreement_SalesPlanByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_SalesPlan hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_SalesPlan</param>
        [OperationContract]
        void InsertAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_SalesPlan in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_SalesPlan die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_SalesPlan in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_SalesPlan die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan);

        #endregion

        #region 9_Agreement_Todo

        /// <summary>
        /// Schnittstelle : Auslesen alle Agreement_Todo aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement_Todo</returns>
        [OperationContract]
        List<Agreement_Todo> GetAgreement_Todos();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Agreement_Todo aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement_Todo</param>
        /// <returns>Agreement_Todo für die spezifische ID </returns>
        [OperationContract]
        List<Agreement_Todo> GetAgreement_TodoByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Agreement_Todo hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_Todo</param>
        [OperationContract]
        void InsertAgreement_Todo(Agreement_Todo agreement_Todo);

        /// <summary>
        /// Schnittstelle : Existierte Agreement_Todo in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement_Todo die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreement_Todo(Agreement_Todo agreement_Todo);

        /// <summary>
        /// Schnittstelle :  Existierte Agreement_Todo in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement_Todo die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreement_Todo(Agreement_Todo agreement_Todo);

        #endregion

        #region 10_AgreementStatus

        /// <summary>
        /// Schnittstelle : Auslesen alle AgreementStatus aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den AgreementStatus</returns>
        [OperationContract]
        List<AgreementStatus> GetAgreementStatuss();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische AgreementStatus aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der AgreementStatus</param>
        /// <returns>AgreementStatus für die spezifische ID </returns>
        [OperationContract]
        List<AgreementStatus> GetAgreementStatusByID(int id);

        /// <summary>
        /// Schnittstelle : Neue AgreementStatus hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement_Todo</param>
        [OperationContract]
        void InsertAgreementStatus(AgreementStatus agreementStatus);

        /// <summary>
        /// Schnittstelle : Existierte AgreementStatus in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">AgreementStatus die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateAgreementStatus(AgreementStatus agreementStatus);

        /// <summary>
        /// Schnittstelle :  Existierte AgreementStatus in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">AgreementStatus die gelöscht werden muss</param>
        [OperationContract]
        void DeleteAgreementStatus(AgreementStatus agreementStatus);

        #endregion

        #region 11_Contract

        // Contract
        /// <summary>
        /// Schnittstelle : Auslesen alle Contracts aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Contract</returns>
        [OperationContract]
        List<Contract> GetContracts();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Contract aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Contract</param>
        /// <returns>Contract für die spezifische ID </returns>
        [OperationContract]
        List<Contract> GetContractByID(string id);

        //[OperationContract]
        //List<ContractWrapper> GetContractsSimple();

        /// <summary>
        /// Schnittstelle : Neue Contract hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Contract</param>
        [OperationContract]
        void InsertContract(Contract contract);

        /// <summary>
        /// Schnittstelle : Existierte Contract in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Contract die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateContract(Contract currentContract);

        /// <summary>
        /// Schnittstelle : Existierte Contract in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Contract die gelöscht werden muss</param>
        [OperationContract]
        void DeleteContract(Contract contract);

        #endregion

        #region 12_Contract_Document

        // Contract document
        /// <summary>
        /// Schnittstelle : Auslesen alle Contract_Document aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Contract_Document</returns>
        [OperationContract]
        List<Contract_Document> GetContract_Document();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Contract_Document aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="_id">ID der Contract_Document</param>
        /// <returns>Contract_Document für die spezifische ID </returns>
        [OperationContract]
        List<Contract_Document> GetContract_DocumentByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Contract_Document hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract_Document">Neue Contract_Document</param>
        [OperationContract]
        void InsertContract_Document(Contract_Document contract_Document);

        /// <summary>
        /// Schnittstelle : Existierte Contract_Document in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract_Document">Contract_Document die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateContract_Document(Contract_Document currentContract_Document);

        /// <summary>
        /// Schnittstelle : Existierte Contract_Document in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract_Document">Contract_Document die gelöscht werden muss</param>
        [OperationContract]
        void DeleteContract_Document(Contract_Document contract_Document);

        #endregion

        #region 13_Document_Type

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle DocumentTypes aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den DocumentTypes</returns>
        [OperationContract]
        List<DocumentType> GetDocumentTypes();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische DocumentType aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der DocumentType</param>
        /// <returns>DocumentType für die spezifische ID</returns>
        [OperationContract]
        List<DocumentType> GetDocumentTypeByID(int id);

        /// <summary>
        /// Schnittstelle : Neue DocumentType hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue DocumentType</param>
        [OperationContract]
        void InsertDocumentType(DocumentType documentType);

        /// <summary>
        /// Schnittstelle : Existierte DocumentType in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">DocumentType die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateDocumentType(DocumentType currentDocumentType);

        /// <summary>
        /// Schnittstelle : Existierte DocumentType in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">DocumentType die gelöscht werden muss</param>
        [OperationContract]
        void DeleteDocumentType(DocumentType documentType);

        #endregion

        #region 14_ExpiryCategory

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle ExpiryCategory aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den ExpiryCategory</returns>
        [OperationContract]
        List<ExpiryCategory> GetExpiryCategorys();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische ExpiryCategory aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der ExpiryCategory</param>
        /// <returns>ExpiryCategory für die spezifische ID</returns>
        [OperationContract]
        List<ExpiryCategory> GetExpiryCategoryByID(int id);

        /// <summary>
        /// Schnittstelle : Neue ExpiryCategory hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue ExpiryCategory</param>
        [OperationContract]
        void InsertExpiryCategory(ExpiryCategory expiryCategory);

        /// <summary>
        /// Schnittstelle : Existierte ExpiryCategory in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">ExpiryCategory die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateExpiryCategory(ExpiryCategory expiryCategory);

        /// <summary>
        /// Schnittstelle : Existierte ExpiryCategory in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">ExpiryCategory die gelöscht werden muss</param>
        [OperationContract]
        void DeleteExpiryCategory(ExpiryCategory expiryCategory);

        #endregion

        #region 15_ExternalPerson

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle ExternalPerson aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den ExternalPerson</returns>
        [OperationContract]
        List<ExternalPerson> GetExternalPersons();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische ExternalPerson aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der ExternalPerson</param>
        /// <returns>ExternalPerson für die spezifische ID</returns>
        [OperationContract]
        List<ExternalPerson> GetExternalPersonByID(int id);

        /// <summary>
        /// Schnittstelle : Neue ExternalPerson hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue ExternalPerson</param>
        [OperationContract]
        void InsertExternalPerson(ExternalPerson externalPerson);

        /// <summary>
        /// Schnittstelle : Existierte ExternalPerson in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">ExternalPerson die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateExternalPerson(ExternalPerson externalPerson);

        /// <summary>
        /// Schnittstelle : Existierte ExternalPerson in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">ExternalPerson die gelöscht werden muss</param>
        [OperationContract]
        void DeleteExternalPerson(ExternalPerson externalPerson);

        #endregion

        #region 16_ExternalRole

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle ExternalRole aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den ExternalRole</returns>
        [OperationContract]
        List<ExternalRole> GetExternalRoles();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische ExternalRole aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der ExternalRole</param>
        /// <returns>ExternalRole für die spezifische ID</returns>
        [OperationContract]
        List<ExternalRole> GetExternalRoleByID(int id);

        /// <summary>
        /// Schnittstelle : Neue ExternalRole hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue ExternalRole</param>
        [OperationContract]
        void InsertExternalRole(ExternalRole externalRole);

        /// <summary>
        /// Schnittstelle : Existierte ExternalRole in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">ExternalRole die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateExternalRole(ExternalRole externalRole);

        /// <summary>
        /// Schnittstelle : Existierte ExternalRole in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">ExternalRole die gelöscht werden muss</param>
        [OperationContract]
        void DeleteExternalRole(ExternalRole externalRole);

        #endregion

        #region 17_Import_SalesActual

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle Import_SalesActual aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den Import_SalesActual</returns>
        [OperationContract]
        List<Import_SalesActual> GetImport_SalesActuals();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Import_SalesActual aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der Import_SalesActual</param>
        /// <returns>Import_SalesActual für die spezifische ID</returns>
        [OperationContract]
        List<Import_SalesActual> GetImport_SalesActualByID(Guid id);

        /// <summary>
        /// Schnittstelle : Neue Import_SalesActual hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Import_SalesActual</param>
        [OperationContract]
        void InsertImport_SalesActual(Import_SalesActual import_SalesActual);

        /// <summary>
        /// Schnittstelle : Existierte Import_SalesActual in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Import_SalesActual die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateImport_SalesActual(Import_SalesActual import_SalesActual);

        /// <summary>
        /// Schnittstelle : Existierte Import_SalesActual in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Import_SalesActual die gelöscht werden muss</param>
        [OperationContract]
        void DeleteImport_SalesActual(Import_SalesActual import_SalesActual);

        #endregion

        #region 18_InternalPerson

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle InternalPerson aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den InternalPerson</returns>
        [OperationContract]
        List<InternalPerson> GetInternalPersons();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische InternalPerson aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der InternalPerson</param>
        /// <returns>InternalPerson für die spezifische ID</returns>
        [OperationContract]
        List<InternalPerson> GetInternalPersonByID(int id);

        /// <summary>
        /// Schnittstelle : Neue InternalPerson hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue InternalPerson</param>
        [OperationContract]
        void InsertInternalPerson(InternalPerson internalPerson);

        /// <summary>
        /// Schnittstelle : Existierte InternalPerson in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">InternalPerson die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateInternalPerson(InternalPerson internalPerson);

        /// <summary>
        /// Schnittstelle : Existierte InternalPerson in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">InternalPerson die gelöscht werden muss</param>
        [OperationContract]
        void DeleteInternalPerson(InternalPerson internalPerson);

        #endregion

        #region 19_InternalRole

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle InternalRole aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den InternalRole</returns>
        [OperationContract]
        List<InternalRole> GetInternalRoles();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische InternalRole aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der InternalRole</param>
        /// <returns>InternalRole für die spezifische ID</returns>
        [OperationContract]
        List<InternalRole> GetInternalRoleByID(int id);

        /// <summary>
        /// Schnittstelle : Neue InternalRole hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue InternalRole</param>
        [OperationContract]
        void InsertInternalRole(InternalRole internalRole);

        /// <summary>
        /// Schnittstelle : Existierte InternalRole in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">InternalRole die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateInternalRole(InternalRole internalRole);

        /// <summary>
        /// Schnittstelle : Existierte InternalRole in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">InternalRole die gelöscht werden muss</param>
        [OperationContract]
        void DeleteInternalRole(InternalRole internalRole);

        #endregion

        #region 20_MemoType

        // Document type
        /// <summary>
        /// Schnittstelle : Auslesen alle MemoType aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den MemoType</returns>
        [OperationContract]
        List<MemoType> GetMemoTypes();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische MemoType aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der MemoType</param>
        /// <returns>MemoType für die spezifische ID</returns>
        [OperationContract]
        List<MemoType> GetMemoTypeByID(int id);

        /// <summary>
        /// Schnittstelle : Neue MemoType hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue MemoType</param>
        [OperationContract]
        void InsertMemoType(MemoType memoType);

        /// <summary>
        /// Schnittstelle : Existierte MemoType in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">MemoType die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateMemoType(MemoType memoType);

        /// <summary>
        /// Schnittstelle : Existierte MemoType in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">MemoType die gelöscht werden muss</param>
        [OperationContract]
        void DeleteMemoType(MemoType memoType);

        #endregion

        #region 21_Organisation

        /// <summary>
        /// Schnittstelle : Auslesen alle Organisation aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den Organisation</returns>
        [OperationContract]
        List<Organisation> GetOrganisations();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Organisation aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der Organisation</param>
        /// <returns>Organisation für die spezifische ID</returns>
        [OperationContract]
        List<Organisation> GetOrganisationByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Organisation hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Organisation</param>
        [OperationContract]
        void InsertOrganisation(Organisation organisation);

        /// <summary>
        /// Schnittstelle : Existierte Organisation in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Organisation die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateOrganisation(Organisation organisation);

        /// <summary>
        /// Schnittstelle : Existierte Organisation in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Organisation die gelöscht werden muss</param>
        [OperationContract]
        void DeleteOrganisation(Organisation organisation);

        #endregion

        #region 22_RevenueDimension

        /// <summary>
        /// Schnittstelle : Auslesen alle RevenueDimension aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den RevenueDimension</returns>
        [OperationContract]
        List<RevenueDimension> GetRevenueDimensions();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische RevenueDimension aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der RevenueDimension</param>
        /// <returns>RevenueDimension für die spezifische ID</returns>
        [OperationContract]
        List<RevenueDimension> GetRevenueDimensionByID(int id);

        /// <summary>
        /// Schnittstelle : Neue RevenueDimension hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue RevenueDimension</param>
        [OperationContract]
        void InserRevenueDimension(RevenueDimension revenueDimension);

        /// <summary>
        /// Schnittstelle : Existierte RevenueDimension in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">RevenueDimension die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateRevenueDimension(RevenueDimension revenueDimension);

        /// <summary>
        /// Schnittstelle : Existierte RevenueDimension in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">RevenueDimension die gelöscht werden muss</param>
        [OperationContract]
        void DeleteRevenueDimension(RevenueDimension revenueDimension);

        #endregion

        #region 23_RevenueTrend

        /// <summary>
        /// Schnittstelle : Auslesen alle RevenueTrend aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den RevenueTrend</returns>
        [OperationContract]
        List<RevenueTrend> GetRevenueTrends();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische RevenueTrend aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der RevenueTrend</param>
        /// <returns>RevenueTrend für die spezifische ID</returns>
        [OperationContract]
        List<RevenueTrend> GetRevenueTrendByID(int id);

        /// <summary>
        /// Schnittstelle : Neue RevenueTrend hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue RevenueTrend</param>
        [OperationContract]
        void InserRevenueTrend(RevenueTrend revenueTrend);

        /// <summary>
        /// Schnittstelle : Existierte RevenueTrend in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">RevenueTrend die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateRevenueTrend(RevenueTrend revenueTrend);

        /// <summary>
        /// Schnittstelle : Existierte RevenueTrend in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">RevenueTrend die gelöscht werden muss</param>
        [OperationContract]
        void DeleteRevenueTrend(RevenueTrend revenueTrend);

        #endregion

        #region 24_Sector

        /// <summary>
        /// Schnittstelle : Auslesen alle Sector aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den Sector</returns>
        [OperationContract]
        List<Sector> GetSectors();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische Sector aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der Sector</param>
        /// <returns>Sector für die spezifische ID</returns>
        [OperationContract]
        List<Sector> GetSectorByID(int id);

        /// <summary>
        /// Schnittstelle : Neue Sector hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Sector</param>
        [OperationContract]
        void InserSector(Sector sector);

        /// <summary>
        /// Schnittstelle : Existierte Sector in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Sector die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateSector(Sector sector);

        /// <summary>
        /// Schnittstelle : Existierte Sector in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Sector die gelöscht werden muss</param>
        [OperationContract]
        void DeleteSector(Sector sector);

        #endregion

        #region 25_TodoFlag

        /// <summary>
        /// Schnittstelle : Auslesen alle TodoFlag aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den TodoFlag</returns>
        [OperationContract]
        List<TodoFlag> GetTodoFlags();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische TodoFlag aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der TodoFlag</param>
        /// <returns>TodoFlag für die spezifische ID</returns>
        [OperationContract]
        List<TodoFlag> GetTodoFlagByID(int id);

        /// <summary>
        /// Schnittstelle : Neue TodoFlag hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue TodoFlag</param>
        [OperationContract]
        void InserTodoFlag(TodoFlag todoFlag);

        /// <summary>
        /// Schnittstelle : Existierte TodoFlag in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">TodoFlag die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateTodoFlag(TodoFlag todoFlag);

        /// <summary>
        /// Schnittstelle : Existierte TodoFlag in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">TodoFlag die gelöscht werden muss</param>
        [OperationContract]
        void DeleteTodoFlag(TodoFlag todoFlag);

        #endregion

        #region 26_TodoPriority

        /// <summary>
        /// Schnittstelle : Auslesen alle TodoPriority aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den TodoPriority</returns>
        [OperationContract]
        List<TodoPriority> GetTodoPrioritys();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische TodoPriority aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der TodoPriority</param>
        /// <returns>TodoPriority für die spezifische ID</returns>
        [OperationContract]
        List<TodoPriority> GetTodoPriorityByID(int id);

        /// <summary>
        /// Schnittstelle : Neue TodoPriority hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue TodoPriority</param>
        [OperationContract]
        void InsertTodoPriority(TodoPriority todoPriority);

        /// <summary>
        /// Schnittstelle : Existierte TodoPriority in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">TodoPriority die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateTodoPriority(TodoPriority todoPriority);

        /// <summary>
        /// Schnittstelle : Existierte TodoPriority in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">TodoPriority die gelöscht werden muss</param>
        [OperationContract]
        void DeleteTodoPriority(TodoPriority todoPriority);

        #endregion

        #region 27_TodoType

        /// <summary>
        /// Schnittstelle : Auslesen alle TodoType aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den TodoType</returns>
        [OperationContract]
        List<TodoType> GetTodoTypes();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische TodoType aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der TodoType</param>
        /// <returns>TodoType für die spezifische ID</returns>
        [OperationContract]
        List<TodoType> GetTodoTypeByID(int id);

        /// <summary>
        /// Schnittstelle : Neue TodoType hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue TodoType</param>
        [OperationContract]
        void InsertTodoType(TodoType todoType);

        /// <summary>
        /// Schnittstelle : Existierte TodoType in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">TodoType die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateTodoType(TodoType todoType);

        /// <summary>
        /// Schnittstelle : Existierte TodoType in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">TodoType die gelöscht werden muss</param>
        [OperationContract]
        void DeleteTodoType(TodoType todoType);

        #endregion

        #region 28_TowerDelivery

        /// <summary>
        /// Schnittstelle : Auslesen alle TowerDelivery aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den TowerDelivery</returns>
        [OperationContract]
        List<TowerDelivery> GetTowerDeliverys();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische TowerDelivery aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der TowerDelivery</param>
        /// <returns>TowerDelivery für die spezifische ID</returns>
        [OperationContract]
        List<TowerDelivery> GetTowerDeliveryByID(int id);

        /// <summary>
        /// Schnittstelle : Neue TowerDelivery hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue TowerDelivery</param>
        [OperationContract]
        void InsertTowerDelivery(TowerDelivery towerDelivery);

        /// <summary>
        /// Schnittstelle : Existierte TowerDelivery in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">TowerDelivery die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateTowerDelivery(TowerDelivery towerDelivery);

        /// <summary>
        /// Schnittstelle : Existierte TowerDelivery in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">TowerDelivery die gelöscht werden muss</param>
        [OperationContract]
        void DeleteTowerDelivery(TowerDelivery towerDelivery);

        #endregion

        #region 29_TowerService

        /// <summary>
        /// Schnittstelle : Auslesen alle TowerService aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den TowerService</returns>
        [OperationContract]
        List<TowerService> GetTowerServices();

        /// <summary>
        /// Schnittstelle : Auslesen eine spezifische TowerService aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der TowerService</param>
        /// <returns>TowerService für die spezifische ID</returns>
        [OperationContract]
        List<TowerService> GetTowerServiceByID(int id);

        /// <summary>
        /// Schnittstelle : Neue TowerService hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue TowerService</param>
        [OperationContract]
        void InsertTowerService(TowerService towerService);

        /// <summary>
        /// Schnittstelle : Existierte TowerService in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">TowerService die aktualiziert werden muss</param>
        [OperationContract]
        void UpdateTowerService(TowerService towerService);

        /// <summary>
        /// Schnittstelle : Existierte TowerService in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">TowerService die gelöscht werden muss</param>
        [OperationContract]
        void DeleteTowerService(TowerService towerService);

        #endregion

        #region 30_vwImportBulk

        /// <summary>
        /// Schnittstelle : Auslesen alle vwImportBulk aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den vwImportBulk</returns>
        [OperationContract]
        List<vwImportBulk> GetvwImportBulks();

        #endregion



        #region Stored_Procedures

        //StartImport_ByProfile
        /// <summary>
        /// Schnittstelle : StartImport_ByProfile stored procedure in der Atos Contract Management Datenbank mit profil Name zu starten.
        /// </summary>
        /// <param name="id">Profil Name</param>
        [OperationContract]
        void StartImportByProfile(string profileId);

        #endregion
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    }
