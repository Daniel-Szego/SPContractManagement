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
    public partial class Agreement_AccountUnit
    {
        #region Primitive Properties
        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }
        [DataMember]
        public virtual int Agreement_id
        {
            get { return _agreement_id; }
            set
            {
                if (_agreement_id != value)
                {
                    if (Agreement != null && Agreement.ID != value)
                    {
                        Agreement = null;
                    }
                    _agreement_id = value;
                }
            }
        }
        private int _agreement_id;
        [DataMember]
        public virtual Nullable<int> AccountUnit
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual Agreement Agreement
        {
            get { return _agreement; }
            set
            {
                if (!ReferenceEquals(_agreement, value))
                {
                    var previousValue = _agreement;
                    _agreement = value;
                    FixupAgreement(previousValue);
                }
            }
        }
        private Agreement _agreement;

        #endregion

        #region Association Fixup
    
        private void FixupAgreement(Agreement previousValue)
        {
            if (previousValue != null && previousValue.Agreement_AccountUnit.Contains(this))
            {
                previousValue.Agreement_AccountUnit.Remove(this);
            }
    
            if (Agreement != null)
            {
                if (!Agreement.Agreement_AccountUnit.Contains(this))
                {
                    Agreement.Agreement_AccountUnit.Add(this);
                }
                if (Agreement_id != Agreement.ID)
                {
                    Agreement_id = Agreement.ID;
                }
            }
        }

        #endregion

    }
}
