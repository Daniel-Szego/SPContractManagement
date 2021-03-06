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
    [KnownType(typeof(Agreement_Todo))]
    public partial class TodoFlag
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
        public virtual ICollection<Agreement_Todo> Agreement_Todo
        {
            get
            {
                if (_agreement_Todo == null)
                {
                    var newCollection = new FixupCollection<Agreement_Todo>();
                    newCollection.CollectionChanged += FixupAgreement_Todo;
                    _agreement_Todo = newCollection;
                }
                return _agreement_Todo;
            }
            set
            {
                if (!ReferenceEquals(_agreement_Todo, value))
                {
                    var previousValue = _agreement_Todo as FixupCollection<Agreement_Todo>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAgreement_Todo;
                    }
                    _agreement_Todo = value;
                    var newValue = value as FixupCollection<Agreement_Todo>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAgreement_Todo;
                    }
                }
            }
        }
        private ICollection<Agreement_Todo> _agreement_Todo;

        #endregion

        #region Association Fixup
    
        private void FixupAgreement_Todo(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Agreement_Todo item in e.NewItems)
                {
                    item.TodoFlag = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Agreement_Todo item in e.OldItems)
                {
                    if (ReferenceEquals(item.TodoFlag, this))
                    {
                        item.TodoFlag = null;
                    }
                }
            }
        }

        #endregion

    }
}
