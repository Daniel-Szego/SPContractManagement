using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using ContractManagementData;

namespace ContractManagementService
{
    /// <summary>
    /// Rest Webservicse Prototype. Momentan nur SOAP Webservice ist benutzt.
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class RestService
    {
        #region Services_Contract

        [WebGet(UriTemplate = "/getcontracts")]
        public List<Contract> GetContracts()
        {
            List<Contract> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContracts().ToList<Contract>();    
            }

            return res;
        }

        [WebGet(UriTemplate = "/getcontractbyid/id={id}")]
        public List<Contract> GetContractByID(string id)
        {
            List<Contract> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContractByID(id).ToList<Contract>();
            }
            return res;
        }


        //[WebGet(UriTemplate = "/getcontractssimple")]
        //public List<ContractWrapper> GetContractsSimple()
        //{
        //    List<ContractWrapper> res = null;
        //    using (DomainService service = new DomainService())
        //    {
        //        res = service.GetContractsSimple().ToList<ContractWrapper>();
        //    }

        //    return res;
        //}


        [WebInvoke(UriTemplate = "/insertcontracts", Method = "POST")]
        public void InsertContract(Contract contract)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertContract(contract);
            }
        }

        [WebInvoke(UriTemplate = "/UpdateContract", Method = "PUT")]
        public void UpdateContract(Contract currentContract)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateContract(currentContract);
            }
        }

        [WebInvoke(UriTemplate = "/deletecontract", Method = "DELETE")]
        public void DeleteContract(Contract contract)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateContract(contract);
            }
        }

        #endregion

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Contract_Document' query.

        #region Contract_Document_services

        [WebGet(UriTemplate = "")]
        public List<Contract_Document> GetContract_Documents()
        {
            List<Contract_Document> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContract_Document().ToList<Contract_Document>();
            }
            return res;
        }

        [WebGet(UriTemplate = "/getcontract_documentbyid/id={id}")]
        public List<Contract_Document> GetContract_DocumentByID(int id)
        {
            List<Contract_Document> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetContractDocumentByID(id).ToList<Contract_Document>();
            }
            return res;
        }


        [WebInvoke(UriTemplate = "/insertcontract_document", Method = "POST")]
        public void InsertContract_Document(Contract_Document contract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertContract_Document(contract_Document);
            }
        }

        [WebInvoke(UriTemplate = "/updatecontract_document", Method = "PUT")]
        public void UpdateContract_Document(Contract_Document currentContract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateContract_Document(currentContract_Document);
            }
        }

        [WebInvoke(UriTemplate = "/DeleteContract_Document", Method = "DELETE")]
        public void DeleteContract_Document(Contract_Document contract_Document)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteContract_Document(contract_Document);
            }
        }

        #endregion

        #region DocumentType_Services

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocumentTypes' query.
        [WebGet(UriTemplate = "/getdocumenttypes")]
        public List<DocumentType> GetDocumentTypes()
        {
            List<DocumentType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetDocumentTypes().ToList<DocumentType>();
            }

            return res;
        }

        [WebGet(UriTemplate = "/getdocumenttypebyid/id={id}")]
        public List<DocumentType> GetDocumentTypeByID(int id)
        {
            List<DocumentType> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetDocumentTypeByID(id).ToList<DocumentType>();
            }
            return res;
        }

        [WebInvoke(UriTemplate = "/insertdocumenttype", Method = "POST")]
        public void InsertDocumentType(DocumentType documentType)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertDocumentType(documentType);
            }
        }

        [WebInvoke(UriTemplate = "/updatedocumenttype", Method = "PUT")]
        public void UpdateDocumentType(DocumentType currentDocumentType)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateDocumentType(currentDocumentType);
            }
        }

        [WebInvoke(UriTemplate = "/deletedocumenttype", Method = "DELETE")]
        public void DeleteDocumentType(DocumentType documentType)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteDocumentType(documentType);
            }
        }

        #endregion

        #region Agreement_Services

        [WebGet(UriTemplate = "/getagreements")]
        public List<Agreement> GetAgreements()
        {
            List<Agreement> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreements().ToList<Agreement>();
            }

            return res;
        }

        [WebGet(UriTemplate = "/getagreementbyid/id={id}")]
        public List<Agreement> GetAgreementByID(int id)
        {
            List<Agreement> res = null;
            using (DomainService service = new DomainService())
            {
                res = service.GetAgreementByID(id).ToList<Agreement>();
            }
            return res;
        }

        [WebInvoke(UriTemplate = "/insertagreement", Method = "POST")]
        public void InsertAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.InsertAgreement(agreement);
            }
        }

        [WebInvoke(UriTemplate = "/updateagreement", Method = "PUT")]
        public void UpdateAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.UpdateAgreement(agreement);
            }
        }

        [WebInvoke(UriTemplate = "/deleteagreement", Method = "DELETE")]
        public void DeleteAgreement(Agreement agreement)
        {
            using (DomainService service = new DomainService())
            {
                service.DeleteAgreement(agreement);
            }
        }

        #endregion

    }
}
