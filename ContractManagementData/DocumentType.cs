//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace ContractManagementData
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Contract_Document))]
    public partial class DocumentType
    {
        #region Primitive Properties
        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Caption
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<Contract_Document> Contract_Document
        {
            get
            {
                if (_contract_Document == null)
                {
                    var newCollection = new FixupCollection<Contract_Document>();
                    newCollection.CollectionChanged += FixupContract_Document;
                    _contract_Document = newCollection;
                }
                return _contract_Document;
            }
            set
            {
                if (!ReferenceEquals(_contract_Document, value))
                {
                    var previousValue = _contract_Document as FixupCollection<Contract_Document>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupContract_Document;
                    }
                    _contract_Document = value;
                    var newValue = value as FixupCollection<Contract_Document>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupContract_Document;
                    }
                }
            }
        }
        private ICollection<Contract_Document> _contract_Document;

        #endregion

        #region Association Fixup
    
        private void FixupContract_Document(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Contract_Document item in e.NewItems)
                {
                    item.DocumentType = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Contract_Document item in e.OldItems)
                {
                    if (ReferenceEquals(item.DocumentType, this))
                    {
                        item.DocumentType = null;
                    }
                }
            }
        }

        #endregion

    }
}
