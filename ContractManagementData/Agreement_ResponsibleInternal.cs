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
    [KnownType(typeof(InternalPerson))]
    [KnownType(typeof(InternalRole))]
    public partial class Agreement_ResponsibleInternal
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
        public virtual int InternalRole_id
        {
            get { return _internalRole_id; }
            set
            {
                if (_internalRole_id != value)
                {
                    if (InternalRole != null && InternalRole.ID != value)
                    {
                        InternalRole = null;
                    }
                    _internalRole_id = value;
                }
            }
        }
        private int _internalRole_id;
        [DataMember]
        public virtual int InternalPerson_id
        {
            get { return _internalPerson_id; }
            set
            {
                if (_internalPerson_id != value)
                {
                    if (InternalPerson != null && InternalPerson.ID != value)
                    {
                        InternalPerson = null;
                    }
                    _internalPerson_id = value;
                }
            }
        }
        private int _internalPerson_id;

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
        
    
        [DataMember]
        public virtual InternalPerson InternalPerson
        {
            get { return _internalPerson; }
            set
            {
                if (!ReferenceEquals(_internalPerson, value))
                {
                    var previousValue = _internalPerson;
                    _internalPerson = value;
                    FixupInternalPerson(previousValue);
                }
            }
        }
        private InternalPerson _internalPerson;
        
    
        [DataMember]
        public virtual InternalRole InternalRole
        {
            get { return _internalRole; }
            set
            {
                if (!ReferenceEquals(_internalRole, value))
                {
                    var previousValue = _internalRole;
                    _internalRole = value;
                    FixupInternalRole(previousValue);
                }
            }
        }
        private InternalRole _internalRole;

        #endregion

        #region Association Fixup
    
        private void FixupAgreement(Agreement previousValue)
        {
            if (previousValue != null && previousValue.Agreement_ResponsibleInternal.Contains(this))
            {
                previousValue.Agreement_ResponsibleInternal.Remove(this);
            }
    
            if (Agreement != null)
            {
                if (!Agreement.Agreement_ResponsibleInternal.Contains(this))
                {
                    Agreement.Agreement_ResponsibleInternal.Add(this);
                }
                if (Agreement_id != Agreement.ID)
                {
                    Agreement_id = Agreement.ID;
                }
            }
        }
    
        private void FixupInternalPerson(InternalPerson previousValue)
        {
            if (previousValue != null && previousValue.Agreement_ResponsibleInternal.Contains(this))
            {
                previousValue.Agreement_ResponsibleInternal.Remove(this);
            }
    
            if (InternalPerson != null)
            {
                if (!InternalPerson.Agreement_ResponsibleInternal.Contains(this))
                {
                    InternalPerson.Agreement_ResponsibleInternal.Add(this);
                }
                if (InternalPerson_id != InternalPerson.ID)
                {
                    InternalPerson_id = InternalPerson.ID;
                }
            }
        }
    
        private void FixupInternalRole(InternalRole previousValue)
        {
            if (previousValue != null && previousValue.Agreement_ResponsibleInternal.Contains(this))
            {
                previousValue.Agreement_ResponsibleInternal.Remove(this);
            }
    
            if (InternalRole != null)
            {
                if (!InternalRole.Agreement_ResponsibleInternal.Contains(this))
                {
                    InternalRole.Agreement_ResponsibleInternal.Add(this);
                }
                if (InternalRole_id != InternalRole.ID)
                {
                    InternalRole_id = InternalRole.ID;
                }
            }
        }

        #endregion

    }
}
