using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data.Objects.DataClasses;
using ContractManagementData;

namespace ContractManagementData
{

    /// <summary>
    /// Wrapper Klasse für die Datenbank Objekte, Momentan ist es nicht benutzt.
    /// </summary>
    [KnownType(typeof(AgreementWrapper))]
    [DataContract]
    public class AgreementWrapper
    {

            public AgreementWrapper()
            {
            }
            [DataMember]
            public string AgreementNumber { get; set; }

            [DataMember]
            public Nullable<int> AgreementStatus_id { get; set; }

            [DataMember]
            public Nullable<decimal> AmountPlanPerMonth { get; set; }

            [DataMember]
            public Contract Contract { get; set; }

            //public EntityCollection<Contract_Document> Contract_Document { get; set; }

            [DataMember]
            public string ContractNumber { get; set; }

            [DataMember]
            public string Country { get; set; }

            [DataMember]
            public string Debitor { get; set; }

            [DataMember]
            public int ID { get; set; }

            [DataMemberAttribute()]
            public string OrderNumber { get; set; }

            [DataMember]
            public Nullable<int> Organisation_id { get; set; }

            [DataMember]
            public Nullable<int> RevenueDimension_id { get; set; }

            [DataMember]
            public Nullable<int> RevenueTrend_id { get; set; }

            [DataMemberAttribute()]
            public string SAPContractNumber { get; set; }

            [DataMember]
            public Nullable<int> Sector_id { get; set; }

            [DataMember]
            public Nullable<int> TowerDelivery_id { get; set; }

            [DataMember]
            public Nullable<int> TowerService_id { get; set; }
        }

    /// <summary>
    /// Wrapper Klasse für die Datenbank Objekte, Momentan ist es nicht benutzt.
    /// </summary>
    [KnownType(typeof(ContractWrapper))]
    [DataContract]
    public class ContractWrapper
    {

            // Metadata classes are not meant to be instantiated.
            public ContractWrapper()
            {
            }

            //public EntityCollection<Contract_Document> Contract_Document { get; set; }
            [DataMember]
            public string ContractName { get; set; }

        [DataMember]
            public string ContractNumber { get; set; }
    }

/// <summary>
    /// Wrapper Klasse für die Datenbank Objekte, Momentan ist es nicht benutzt.
/// </summary>
    [KnownType(typeof(Contract_DocumentWrapper))]
    [DataContract]
    public class Contract_DocumentWrapper
    {

            public Contract_DocumentWrapper()
            {
            }

            [DataMember]
            public Nullable<int> Agreement_id { get; set; }

            //public Contract Contract { get; set; }

            [DataMember]
            public string Contract_Number { get; set; }

            [DataMember]
            public byte[] DocumentFileBinary { get; set; }

            [DataMember]
            public string DocumentFilePath { get; set; }

            [DataMember]
            public string DocumentKeyword { get; set; }

            [DataMember]
            public DocumentType DocumentType { get; set; }

            [DataMember]
            public int DocumentType_id { get; set; }

            [DataMember]
            public int ID { get; set; }

    }

    /// <summary>
    /// Wrapper Klasse für die Datenbank Objekte, Momentan ist es nicht benutzt.
    /// </summary>
    [KnownType(typeof(DocumentTypeWrapper))]
    [DataContract]
    public class DocumentTypeWrapper
    {

         public DocumentTypeWrapper()
         {
         }

         [DataMember]
         public string Caption { get; set; }

            //public EntityCollection<Contract_Document> Contract_Document { get; set; }

         [DataMember]
         public int ID { get; set; }

        }
}
