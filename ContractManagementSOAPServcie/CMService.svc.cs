using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using Microsoft.SharePoint.Client.ServerRuntime;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Services;
using AtosContractManagementData;


namespace AtosContractManagementSOAPServcie
{
    /// <summary>
    /// SOAP Service für die ATOS Contractmanagement Funktionalitäten.
    /// </summary>
    //[BasicHttpBindingServiceMetadataExchangeEndpointAttribute]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CMService : ICMService
    {

        #region 1_Agreement

        /// <summary>
        /// SOAP Service : Auslesen alle Agreement aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Agreement</returns>
        public List<Agreement> GetAgreements()
        {
            List<Agreement> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreements().ToList<Agreement>();
            }

            return res;
        }

        /// <summary>
        /// SOAP Service : Auslesen eine spezifische Agreement aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Agreement</param>
        /// <returns>Agreement für die spezifische ID </returns>
        public List<Agreement> GetAgreementByID(int id)
        {
            List<Agreement> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreementByID(id).ToList<Agreement>();
            }
            return res;
        }

        /// <summary>
        /// SOAP Service : Neue Agreement hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Agreement</param>
        public void InsertAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement(agreement);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte Agreement in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Agreement die aktualiziert werden muss</param>
        public void UpdateAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement(agreement);
            }
        }

        /// <summary>
        /// SOAP Service :  Existierte Agreement in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Agreement die gelöscht werden muss</param>
        public void DeleteAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement(agreement);
            }
        }

        #endregion

        #region 2_Agreement_AccountUnits

        List<Agreement_AccountUnit> ICMService.GetAgreement_AccountUnits()
        {
            List<Agreement_AccountUnit> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_AccountUnits().ToList<Agreement_AccountUnit>();
            }
            return res;
        }  

        List<Agreement_AccountUnit> ICMService.GetAgreement_AccountUnitByID(int id)
        {
            List<Agreement_AccountUnit> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_AccountUnitByID(id).ToList<Agreement_AccountUnit>();
            }
            return res;
        }

        void ICMService.InsertAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_AccountUnit(agreement_AccountUnit);
            }
        }

        void ICMService.UpdateAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_AccountUnit(agreement_AccountUnit);
            }
        }

        void ICMService.DeleteAgreement_AccountUnit(Agreement_AccountUnit agreement_AccountUnit)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_AccountUnit(agreement_AccountUnit);
            }
        }

        #endregion

        #region 3_Agreement_CostActual

        List<Agreement_CostActual> ICMService.GetAgreement_CostActuals()
        {
            List<Agreement_CostActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_CostActuals().ToList<Agreement_CostActual>();
            }
            return res;
        }

        List<Agreement_CostActual> ICMService.GetAgreement_CostActualByID(int id)
        {
            List<Agreement_CostActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_CostActualByID(id).ToList<Agreement_CostActual>();
            }
            return res;
        }

        void ICMService.InsertAgreement_CostActual(Agreement_CostActual agreement_CostActual)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_CostActual(agreement_CostActual);
            }
        }

        void ICMService.UpdateAgreement_CostActual(Agreement_CostActual agreement_CostActual)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_CostActual(agreement_CostActual);
            }
        }

        void ICMService.DeleteAgreement_CostActual(Agreement_CostActual agreement_CostActual)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_CostActual(agreement_CostActual);
            }
        }

        #endregion

        #region 4_Agreement_Memos

        List<Agreement_Memo> ICMService.GetAgreement_Memos()
        {
            List<Agreement_Memo> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_Memos().ToList<Agreement_Memo>();
            }
            return res;
        }

        List<Agreement_Memo> ICMService.GetAgreement_MemoByID(int id)
        {
            List<Agreement_Memo> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_MemoByID(id).ToList<Agreement_Memo>();
            }
            return res;
        }

        void ICMService.InsertAgreement_Memo(Agreement_Memo agreement_Memo)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_Memo(agreement_Memo);
            }
        }

        void ICMService.UpdateAgreement_Memo(Agreement_Memo agreement_Memo)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_Memo(agreement_Memo);
            }
        }

        void ICMService.DeleteAgreement_Memo(Agreement_Memo agreement_Memo)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_Memo(agreement_Memo);
            }
        }

        #endregion

        #region 5_Agreement_ResponsibleExternal

        List<Agreement_ResponsibleExternal> ICMService.GetAgreement_ResponsibleExternals()
        {
            List<Agreement_ResponsibleExternal> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_ResponsibleExternals().ToList<Agreement_ResponsibleExternal>();
            }
            return res;
        }

        List<Agreement_ResponsibleExternal> ICMService.GetAgreement_ResponsibleExternalByID(int id)
        {
            List<Agreement_ResponsibleExternal> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_ResponsibleExternalByID(id).ToList<Agreement_ResponsibleExternal>();
            }
            return res;
        }

        void ICMService.InsertAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_ResponsibleExternal(agreement_ResponsibleExternal);
            }
        }

        void ICMService.UpdateAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_ResponsibleExternal(agreement_ResponsibleExternal);
            }
        }

        void ICMService.DeleteAgreement_ResponsibleExternal(Agreement_ResponsibleExternal agreement_ResponsibleExternal)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_ResponsibleExternal(agreement_ResponsibleExternal);
            }
        }

        #endregion

        #region 6_Agreement_ResponsibleInternal

        List<Agreement_ResponsibleInternal> ICMService.GetAgreement_ResponsibleInternals()
        {
            List<Agreement_ResponsibleInternal> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_ResponsibleInternals().ToList<Agreement_ResponsibleInternal>();
            }
            return res;
        }

        List<Agreement_ResponsibleInternal> ICMService.GetAgreement_ResponsibleInternalByID(int id)
        {
            List<Agreement_ResponsibleInternal> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_ResponsibleInternalByID(id).ToList<Agreement_ResponsibleInternal>();
            }
            return res;
        }

        void ICMService.InsertAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_ResponsibleInternal(agreement_ResponsibleInternal);
            }
        }

        void ICMService.UpdateAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_ResponsibleInternal(agreement_ResponsibleInternal);
            }
        }

        void ICMService.DeleteAgreement_ResponsibleInternal(Agreement_ResponsibleInternal agreement_ResponsibleInternal)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_ResponsibleInternal(agreement_ResponsibleInternal);
            }
        }

        #endregion

        #region 7_Agreement_SalesActual

        List<Agreement_SalesActual> ICMService.GetAgreement_SalesActuals()
        {
            List<Agreement_SalesActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_SalesActuals().ToList<Agreement_SalesActual>();
            }
            return res;
        }

        List<Agreement_SalesActual> ICMService.GetAgreement_SalesActualByID(int id)
        {
            List<Agreement_SalesActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_SalesActualByID(id).ToList<Agreement_SalesActual>();
            }
            return res;
        }

        void ICMService.InsertAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_SalesActual(agreement_SalesActual);
            }
        }

        void ICMService.UpdateAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_SalesActual(agreement_SalesActual);
            }
        }

        void ICMService.DeleteAgreement_SalesActual(Agreement_SalesActual agreement_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_SalesActual(agreement_SalesActual);
            }
        }

        #endregion

        #region 8_Agreement_SalesPlan

        List<Agreement_SalesPlan> ICMService.GetAgreement_SalesPlans()
        {
            List<Agreement_SalesPlan> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_SalesPlans().ToList<Agreement_SalesPlan>();
            }
            return res;
        }

        List<Agreement_SalesPlan> ICMService.GetAgreement_SalesPlanByID(int id)
        {
            List<Agreement_SalesPlan> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_SalesPlanByID(id).ToList<Agreement_SalesPlan>();
            }
            return res;
        }

        void ICMService.InsertAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_SalesPlan(agreement_SalesPlan);
            }
        }

        void ICMService.UpdateAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_SalesPlan(agreement_SalesPlan);
            }
        }

        void ICMService.DeleteAgreement_SalesPlan(Agreement_SalesPlan agreement_SalesPlan)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_SalesPlan(agreement_SalesPlan);
            }
        }

        #endregion

        #region 9_Agreement_Todo

        List<Agreement_Todo> ICMService.GetAgreement_Todos()
        {
            List<Agreement_Todo> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_Todos().ToList<Agreement_Todo>();
            }
            return res;
        }

        List<Agreement_Todo> ICMService.GetAgreement_TodoByID(int id)
        {
            List<Agreement_Todo> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreement_TodoByID(id).ToList<Agreement_Todo>();
            }
            return res;
        }

        void ICMService.InsertAgreement_Todo(Agreement_Todo agreement_Todo)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement_Todo(agreement_Todo);
            }
        }

        void ICMService.UpdateAgreement_Todo(Agreement_Todo agreement_Todo)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement_Todo(agreement_Todo);
            }
        }

        void ICMService.DeleteAgreement_Todo(Agreement_Todo agreement_Todo)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement_Todo(agreement_Todo);
            }
        }

        #endregion

        #region 10_AgreementStatus

        List<AgreementStatus> ICMService.GetAgreementStatuss()
        {
            List<AgreementStatus> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreementStatuss().ToList<AgreementStatus>();
            }
            return res;
        }

        List<AgreementStatus> ICMService.GetAgreementStatusByID(int id)
        {
            List<AgreementStatus> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreementStatusByID(id).ToList<AgreementStatus>();
            }
            return res;
        }

        void ICMService.InsertAgreementStatus(AgreementStatus agreementStatus)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreementStatus(agreementStatus);
            }
        }

        void ICMService.UpdateAgreementStatus(AgreementStatus agreementStatus)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreementStatus(agreementStatus);
            }
        }

        void ICMService.DeleteAgreementStatus(AgreementStatus agreementStatus)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreementStatus(agreementStatus);
            }
        }

        #endregion

        #region 11_Contract

        /// <summary>
        /// SOAP Service : Auslesen alle Contracts aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Contract</returns>
        public List<Contract> GetContracts()
        {
            List<Contract> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContracts().ToList<Contract>();
            }

            return res;
        }

        /// <summary>
        /// SOAP Service : Auslesen eine spezifische Contract aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="contractNumber">ID der Contract</param>
        /// <returns>Contract für die spezifische ID </returns>
        public List<Contract> GetContractByID(string id)
        {
            List<Contract> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContractByID(id).ToList<Contract>();
            }
            return res;
        }

        /// <summary>
        /// SOAP Service : Neue Contract hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue Contract</param>
        public void InsertContract(Contract contract)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertContract(contract);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte Contract in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">Contract die aktualiziert werden muss</param>
        public void UpdateContract(Contract currentContract)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateContract(currentContract);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte Contract in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">Contract die gelöscht werden muss</param>
        public void DeleteContract(Contract contract)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteContract(contract);
            }
        }

        #endregion

        #region 12_Contract_Document

        /// <summary>
        /// SOAP Service : Auslesen alle Contract_Document aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <returns>Liste den Contract_Document</returns>
        public List<Contract_Document> GetContract_Document()
        {
            List<Contract_Document> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContract_Document().ToList<Contract_Document>();
            }

            return res;
        }

        /// <summary>
        /// SOAP Service : Auslesen eine spezifische Contract_Document aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="_id">ID der Contract_Document</param>
        /// <returns>Contract_Document für die spezifische ID </returns>
        public List<Contract_Document> GetContract_DocumentByID(int id)
        {
            List<Contract_Document> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContractDocumentByID(id).ToList<Contract_Document>();
            }
            return res;
        }

        /// <summary>
        /// SOAP Service : Neue Contract_Document hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract_Document">Neue Contract_Document</param>
        public void InsertContract_Document(Contract_Document contract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertContract_Document(contract_Document);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte Contract_Document in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract_Document">Contract_Document die aktualiziert werden muss</param>
        public void UpdateContract_Document(Contract_Document currentContract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateContract_Document(currentContract_Document);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte Contract_Document in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract_Document">Contract_Document die gelöscht werden muss</param>
        public void DeleteContract_Document(Contract_Document contract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteContract_Document(contract_Document);
            }
        }

        #endregion

        #region 13_DocumentTypes

        /// <summary>
        /// SOAP Service : Auslesen alle DocumentTypes aus der Atos Contract Management Datenbank.
        /// </summary>
        /// <returns>Liste den DocumentTypes</returns>
        public List<DocumentType> GetDocumentTypes()
        {
            List<DocumentType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetDocumentTypes().ToList<DocumentType>();
            }

            return res;
        }

        /// <summary>
        /// SOAP Service : Auslesen eine spezifische DocumentType aus der Atos Contract Management Datenbank. 
        /// </summary>
        /// <param name="_id">ID der DocumentType</param>
        /// <returns>DocumentType für die spezifische ID</returns>
        public List<DocumentType> GetDocumentTypeByID(int id)
        {
            List<DocumentType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetDocumentTypeByID(id).ToList<DocumentType>();
            }
            return res;
        }

        /// <summary>
        /// SOAP Service : Neue DocumentType hinzufügen zu dem der Atos Contract Management Datenbank.
        /// </summary>
        /// <param name="contract">Neue DocumentType</param>
        public void InsertDocumentType(DocumentType documentType)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertDocumentType(documentType);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte DocumentType in dem der Atos Contract Management Datenbank zu aktualizieren.
        /// </summary>
        /// <param name="currentContract">DocumentType die aktualiziert werden muss</param>
        public void UpdateDocumentType(DocumentType currentDocumentType)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateDocumentType(currentDocumentType);
            }
        }

        /// <summary>
        /// SOAP Service : Existierte DocumentType in dem der Atos Contract Management Datenbank zu löschen.
        /// </summary>
        /// <param name="contract">DocumentType die gelöscht werden muss</param>
        public void DeleteDocumentType(DocumentType documentType)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteDocumentType(documentType);
            }
        }

        #endregion

        #region 14_ExpiryCategory

        List<ExpiryCategory> ICMService.GetExpiryCategorys()
        {
            List<ExpiryCategory> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExpiryCategorys().ToList<ExpiryCategory>();
            }
            return res;
        }

        List<ExpiryCategory> ICMService.GetExpiryCategoryByID(int id)
        {
            List<ExpiryCategory> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExpiryCategoryByID(id).ToList<ExpiryCategory>();
            }
            return res;
        }

        void ICMService.InsertExpiryCategory(ExpiryCategory expiryCategory)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertExpiryCategory(expiryCategory);
            }
        }

        void ICMService.UpdateExpiryCategory(ExpiryCategory expiryCategory)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateExpiryCategory(expiryCategory);
            }
        }

        void ICMService.DeleteExpiryCategory(ExpiryCategory expiryCategory)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteExpiryCategory(expiryCategory);
            }
        }

        #endregion

        #region 15_ExternalPerson

        List<ExternalPerson> ICMService.GetExternalPersons()
        {
            List<ExternalPerson> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExternalPersons().ToList<ExternalPerson>();
            }
            return res;
        }

        List<ExternalPerson> ICMService.GetExternalPersonByID(int id)
        {
            List<ExternalPerson> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExternalPersonByID(id).ToList<ExternalPerson>();
            }
            return res;
        }

        void ICMService.InsertExternalPerson(ExternalPerson externalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertExternalPerson(externalPerson);
            }
        }

        void ICMService.UpdateExternalPerson(ExternalPerson externalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateExternalPerson(externalPerson);
            }
        }

        void ICMService.DeleteExternalPerson(ExternalPerson externalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteExternalPerson(externalPerson);
            }
        }

        #endregion

        #region 16_ExternalRole

        List<ExternalRole> ICMService.GetExternalRoles()
        {
            List<ExternalRole> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExternalRoles().ToList<ExternalRole>();
            }
            return res;
        }

        List<ExternalRole> ICMService.GetExternalRoleByID(int id)
        {
            List<ExternalRole> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetExternalRoleByID(id).ToList<ExternalRole>();
            }
            return res;
        }

        void ICMService.InsertExternalRole(ExternalRole externalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertExternalRole(externalRole);
            }
        }

        void ICMService.UpdateExternalRole(ExternalRole externalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateExternalRole(externalRole);
            }
        }

        void ICMService.DeleteExternalRole(ExternalRole externalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteExternalRole(externalRole);
            }
        }

        #endregion

        #region 17_Import_SalesActual

        List<Import_SalesActual> ICMService.GetImport_SalesActuals()
        {
            List<Import_SalesActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetImport_SalesActuals().ToList<Import_SalesActual>();
            }
            return res;
        }

        List<Import_SalesActual> ICMService.GetImport_SalesActualByID(Guid id)
        {
            List<Import_SalesActual> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetImport_SalesActualByID(id).ToList<Import_SalesActual>();
            }
            return res;
        }

        void ICMService.InsertImport_SalesActual(Import_SalesActual import_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertImport_SalesActual(import_SalesActual);
            }
        }

        void ICMService.UpdateImport_SalesActual(Import_SalesActual import_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateImport_SalesActual(import_SalesActual);
            }
        }

        void ICMService.DeleteImport_SalesActual(Import_SalesActual import_SalesActual)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteImport_SalesActual(import_SalesActual);
            }
        }

        #endregion

        #region 18_InternalPerson

        List<InternalPerson> ICMService.GetInternalPersons()
        {
            List<InternalPerson> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetInternalPersons().ToList<InternalPerson>();
            }
            return res;
        }

        List<InternalPerson> ICMService.GetInternalPersonByID(int id)
        {
            List<InternalPerson> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetInternalPersonByID(id).ToList<InternalPerson>();
            }
            return res;
        }

        void ICMService.InsertInternalPerson(InternalPerson internalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertInternalPerson(internalPerson);
            }
        }

        void ICMService.UpdateInternalPerson(InternalPerson internalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateInternalPerson(internalPerson);
            }
        }

        void ICMService.DeleteInternalPerson(InternalPerson internalPerson)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteInternalPerson(internalPerson);
            }
        }

        #endregion

        #region 19_InternalRole

        List<InternalRole> ICMService.GetInternalRoles()
        {
            List<InternalRole> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetInternalRoles().ToList<InternalRole>();
            }
            return res;
        }

        List<InternalRole> ICMService.GetInternalRoleByID(int id)
        {
            List<InternalRole> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetInternalRoleByID(id).ToList<InternalRole>();
            }
            return res;
        }

        void ICMService.InsertInternalRole(InternalRole internalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertInternalRole(internalRole);
            }
        }

        void ICMService.UpdateInternalRole(InternalRole internalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateInternalRole(internalRole);
            }
        }

        void ICMService.DeleteInternalRole(InternalRole internalRole)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteInternalRole(internalRole);
            }
        }

        #endregion

        #region 20_MemoTypes

        List<MemoType> ICMService.GetMemoTypes()
        {
            List<MemoType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetMemoTypes().ToList<MemoType>();
            }
            return res;
        }

        List<MemoType> ICMService.GetMemoTypeByID(int id)
        {
            List<MemoType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetMemoTypeByID(id).ToList<MemoType>();
            }
            return res;
        }

        void ICMService.InsertMemoType(MemoType memoType)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertMemoType(memoType);
            }
        }

        void ICMService.UpdateMemoType(MemoType memoType)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateMemoType(memoType);
            }
        }

        void ICMService.DeleteMemoType(MemoType memoType)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteMemoType(memoType);
            }
        }

        #endregion

        #region 21_Organisation

        List<Organisation> ICMService.GetOrganisations()
        {
            List<Organisation> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetOrganisations().ToList<Organisation>();
            }
            return res;
        }

        List<Organisation> ICMService.GetOrganisationByID(int id)
        {
            List<Organisation> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetOrganisationByID(id).ToList<Organisation>();
            }
            return res;
        }

        void ICMService.InsertOrganisation(Organisation organisation)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertOrganisation(organisation);
            }
        }

        void ICMService.UpdateOrganisation(Organisation organisation)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateOrganisation(organisation);
            }
        }

        void ICMService.DeleteOrganisation(Organisation organisation)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteOrganisation(organisation);
            }
        }

        #endregion

        #region 22_RevenueDimension

        List<RevenueDimension> ICMService.GetRevenueDimensions()
        {
            List<RevenueDimension> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetRevenueDimensions().ToList<RevenueDimension>();
            }
            return res;
        }

        List<RevenueDimension> ICMService.GetRevenueDimensionByID(int id)
        {
            List<RevenueDimension> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetRevenueDimensionByID(id).ToList<RevenueDimension>();
            }
            return res;
        }

        void ICMService.InserRevenueDimension(RevenueDimension revenueDimension)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertRevenueDimension(revenueDimension);
            }
        }

        void ICMService.UpdateRevenueDimension(RevenueDimension revenueDimension)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateRevenueDimension(revenueDimension);
            }
        }

        void ICMService.DeleteRevenueDimension(RevenueDimension revenueDimension)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteRevenueDimension(revenueDimension);
            }
        }

        #endregion

        #region 23_RevenueTrend

        List<RevenueTrend> ICMService.GetRevenueTrends()
        {
            List<RevenueTrend> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetRevenueTrends().ToList<RevenueTrend>();
            }
            return res;

        }

        List<RevenueTrend> ICMService.GetRevenueTrendByID(int id)
        {
            List<RevenueTrend> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetRevenueTrendByID(id).ToList<RevenueTrend>();
            }
            return res;
        }

        void ICMService.InserRevenueTrend(RevenueTrend revenueTrend)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertRevenueTrend(revenueTrend);
            }
        }

        void ICMService.UpdateRevenueTrend(RevenueTrend revenueTrend)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateRevenueTrend(revenueTrend);
            }
        }

        void ICMService.DeleteRevenueTrend(RevenueTrend revenueTrend)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteRevenueTrend(revenueTrend);
            }
        }

        #endregion

        #region 24_Sectors

        List<Sector> ICMService.GetSectors()
        {
            List<Sector> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetSectors().ToList<Sector>();
            }
            return res;
        }

        List<Sector> ICMService.GetSectorByID(int id)
        {
            List<Sector> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetSectorByID(id).ToList<Sector>();
            }
            return res;
        }

        void ICMService.InserSector(Sector sector)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertSector(sector);
            }
        }

        void ICMService.UpdateSector(Sector sector)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateSector(sector);
            }
        }

        void ICMService.DeleteSector(Sector sector)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteSector(sector);
            }
        }

        #endregion

        #region 25_TodoFlag

        List<TodoFlag> ICMService.GetTodoFlags()
        {
            List<TodoFlag> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoFlags().ToList<TodoFlag>();
            }
            return res;
        }

        List<TodoFlag> ICMService.GetTodoFlagByID(int id)
        {
            List<TodoFlag> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoFlagByID(id).ToList<TodoFlag>();
            }
            return res;
        }

        void ICMService.InserTodoFlag(TodoFlag todoFlag)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertTodoFlag(todoFlag);
            }
        }

        void ICMService.UpdateTodoFlag(TodoFlag todoFlag)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateTodoFlag(todoFlag);
            }
        }

        void ICMService.DeleteTodoFlag(TodoFlag todoFlag)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteTodoFlag(todoFlag);
            }
        }

        #endregion

        #region 26_TodoPriority

        List<TodoPriority> ICMService.GetTodoPrioritys()
        {
            List<TodoPriority> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoPrioritys().ToList<TodoPriority>();
            }
            return res;
        }

        List<TodoPriority> ICMService.GetTodoPriorityByID(int id)
        {
            List<TodoPriority> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoPriorityByID(id).ToList<TodoPriority>();
            }
            return res;
        }

        void ICMService.InsertTodoPriority(TodoPriority todoPriority)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertTodoPriority(todoPriority);
            }
        }

        void ICMService.UpdateTodoPriority(TodoPriority todoPriority)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateTodoPriority(todoPriority);
            }
        }

        void ICMService.DeleteTodoPriority(TodoPriority todoPriority)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteTodoPriority(todoPriority);
            }
        }

        #endregion

        #region 27_TodoTypes

        List<TodoType> ICMService.GetTodoTypes()
        {
            List<TodoType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoTypes().ToList<TodoType>();
            }
            return res;
        }

        List<TodoType> ICMService.GetTodoTypeByID(int id)
        {
            List<TodoType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTodoTypeByID(id).ToList<TodoType>();
            }
            return res;
        }

        void ICMService.InsertTodoType(TodoType todoType)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertTodoType(todoType);
            } 
        }

        void ICMService.UpdateTodoType(TodoType todoType)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateTodoType(todoType);
            }
        }

        void ICMService.DeleteTodoType(TodoType todoType)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteTodoType(todoType);
            }
        }

        #endregion

        #region 28_TowerDelivery

        List<TowerDelivery> ICMService.GetTowerDeliverys()
        {
            List<TowerDelivery> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTowerDeliverys().ToList<TowerDelivery>();
            }
            return res;

        }

        List<TowerDelivery> ICMService.GetTowerDeliveryByID(int id)
        {
            List<TowerDelivery> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTowerDeliveryByID(id).ToList<TowerDelivery>();
            }
            return res;
        }

        void ICMService.InsertTowerDelivery(TowerDelivery towerDelivery)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertTowerDelivery(towerDelivery);
            }
        }

        void ICMService.UpdateTowerDelivery(TowerDelivery towerDelivery)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateTowerDelivery(towerDelivery);
            }
        }

        void ICMService.DeleteTowerDelivery(TowerDelivery towerDelivery)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteTowerDelivery(towerDelivery);
            }
        }

        #endregion

        #region 29_TowerService

        List<TowerService> ICMService.GetTowerServices()
        {
            List<TowerService> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTowerServices().ToList<TowerService>();
            }
            return res;
        }

        List<TowerService> ICMService.GetTowerServiceByID(int id)
        {
            List<TowerService> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetTowerServiceByID(id).ToList<TowerService>();
            }
            return res;
        }

        void ICMService.InsertTowerService(TowerService towerService)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertTowerService(towerService);
            }
        }

        void ICMService.UpdateTowerService(TowerService towerService){
            using (DomainService service = new DomainService())
            {
                service.UpdateTowerService(towerService);
            }
        }

        void ICMService.DeleteTowerService(TowerService towerService)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteTowerService(towerService);
            }
        }

        #endregion

        #region 30_vwImportBulk

        List<vwImportBulk> ICMService.GetvwImportBulks()
        {
            List<vwImportBulk> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetvWImportBulks().ToList<vwImportBulk>();
            }
            return res;
        }

        #endregion


        #region StoredProcedures

        /// <summary>
        /// SOAP Service : StartImport_ByProfile stored procedure in der Atos Contract Management Datenbank mit profil Name zu starten.
        /// </summary>
        /// <param name="id">Profil Name</param>
        public void StartImportByProfile(string profileId)
        {
            using (DomainService service = new DomainService())
            {
                service.StartImportByProfile(profileId);
            }
        }

        #endregion

    }
}
