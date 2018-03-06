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
    [KnownType(typeof(Agreement))]
    public partial class RevenueDimension
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
        public virtual ICollection<Agreement> Agreement
        {
            get
            {
                if (_agreement == null)
                {
                    var newCollection = new FixupCollection<Agreement>();
                    newCollection.CollectionChanged += FixupAgreement;
                    _agreement = newCollection;
                }
                return _agreement;
            }
            set
            {
                if (!ReferenceEquals(_agreement, value))
                {
                    var previousValue = _agreement as FixupCollection<Agreement>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAgreement;
                    }
                    _agreement = value;
                    var newValue = value as FixupCollection<Agreement>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAgreement;
                    }
                }
            }
        }
        private ICollection<Agreement> _agreement;

        #endregion

        #region Association Fixup
    
        private void FixupAgreement(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Agreement item in e.NewItems)
                {
                    item.RevenueDimension = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Agreement item in e.OldItems)
                {
                    if (ReferenceEquals(item.RevenueDimension, this))
                    {
                        item.RevenueDimension = null;
                    }
                }
            }
        }

        #endregion

    }
}
