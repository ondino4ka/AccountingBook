﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingBookData.AccountingBookServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoryDto", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "o")]
    [System.SerializableAttribute()]
    public partial class CategoryDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PidField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Pid {
            get {
                return this.PidField;
            }
            set {
                if ((this.PidField.Equals(value) != true)) {
                    this.PidField = value;
                    this.RaisePropertyChanged("Pid");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "oException")]
    [System.SerializableAttribute()]
    public partial class ServiceFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubjectDetailsDto", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "o")]
    [System.SerializableAttribute()]
    public partial class SubjectDetailsDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InventoryNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InventoryNumber {
            get {
                return this.InventoryNumberField;
            }
            set {
                if ((this.InventoryNumberField.Equals(value) != true)) {
                    this.InventoryNumberField = value;
                    this.RaisePropertyChanged("InventoryNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Photo {
            get {
                return this.PhotoField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoField, value) != true)) {
                    this.PhotoField = value;
                    this.RaisePropertyChanged("Photo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDto", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "o")]
    [System.SerializableAttribute()]
    public partial class UserDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AccountingBookData.AccountingBookServiceReference.RoleDto[] RolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AccountingBookData.AccountingBookServiceReference.RoleDto[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoleDto", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "o")]
    [System.SerializableAttribute()]
    public partial class RoleDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoleName {
            get {
                return this.RoleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleNameField, value) != true)) {
                    this.RoleNameField = value;
                    this.RaisePropertyChanged("RoleName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StateDto", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
        "o")]
    [System.SerializableAttribute()]
    public partial class StateDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StateName {
            get {
                return this.StateNameField;
            }
            set {
                if ((object.ReferenceEquals(this.StateNameField, value) != true)) {
                    this.StateNameField = value;
                    this.RaisePropertyChanged("StateName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountingBookServiceReference.IAccountingBookService")]
    public interface IAccountingBookService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetCategories", ReplyAction="http://tempuri.org/IAccountingBookService/GetCategoriesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetCategoriesServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.CategoryDto[] GetCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetCategories", ReplyAction="http://tempuri.org/IAccountingBookService/GetCategoriesResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.CategoryDto[]> GetCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjects", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetSubjectsServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjects();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjects", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectsResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectsByCategoryId", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectsByCategoryIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetSubjectsByCategoryIdServiceFaultFaul" +
            "t", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjectsByCategoryId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectsByCategoryId", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectsByCategoryIdResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectsByCategoryIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectInformationById", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectInformationByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetSubjectInformationByIdServiceFaultFa" +
            "ult", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto GetSubjectInformationById(int inventoryNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectInformationById", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectInformationByIdResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto> GetSubjectInformationByIdAsync(int inventoryNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetUserByName", ReplyAction="http://tempuri.org/IAccountingBookService/GetUserByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetUserByNameServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.UserDto GetUserByName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetUserByName", ReplyAction="http://tempuri.org/IAccountingBookService/GetUserByNameResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.UserDto> GetUserByNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/IsValidUser", ReplyAction="http://tempuri.org/IAccountingBookService/IsValidUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/IsValidUserServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        bool IsValidUser(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/IsValidUser", ReplyAction="http://tempuri.org/IAccountingBookService/IsValidUserResponse")]
        System.Threading.Tasks.Task<bool> IsValidUserAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetRolesByUserId", ReplyAction="http://tempuri.org/IAccountingBookService/GetRolesByUserIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetRolesByUserIdServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.RoleDto[] GetRolesByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetRolesByUserId", ReplyAction="http://tempuri.org/IAccountingBookService/GetRolesByUserIdResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.RoleDto[]> GetRolesByUserIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetCategoriesByName", ReplyAction="http://tempuri.org/IAccountingBookService/GetCategoriesByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetCategoriesByNameServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.CategoryDto[] GetCategoriesByName(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetCategoriesByName", ReplyAction="http://tempuri.org/IAccountingBookService/GetCategoriesByNameResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.CategoryDto[]> GetCategoriesByNameAsync(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectByNameCategoryIdAndStateId", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectByNameCategoryIdAndStateIdRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetSubjectByNameCategoryIdAndStateIdSer" +
            "viceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjectByNameCategoryIdAndStateId(System.Nullable<int> categoryId, System.Nullable<int> stateId, string subjectName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetSubjectByNameCategoryIdAndStateId", ReplyAction="http://tempuri.org/IAccountingBookService/GetSubjectByNameCategoryIdAndStateIdRes" +
            "ponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectByNameCategoryIdAndStateIdAsync(System.Nullable<int> categoryId, System.Nullable<int> stateId, string subjectName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetStates", ReplyAction="http://tempuri.org/IAccountingBookService/GetStatesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(AccountingBookData.AccountingBookServiceReference.ServiceFault), Action="http://tempuri.org/IAccountingBookService/GetStatesServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/AccountingBookService.Contracts.Models.Dt" +
            "oException")]
        AccountingBookData.AccountingBookServiceReference.StateDto[] GetStates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountingBookService/GetStates", ReplyAction="http://tempuri.org/IAccountingBookService/GetStatesResponse")]
        System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.StateDto[]> GetStatesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountingBookServiceChannel : AccountingBookData.AccountingBookServiceReference.IAccountingBookService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountingBookServiceClient : System.ServiceModel.ClientBase<AccountingBookData.AccountingBookServiceReference.IAccountingBookService>, AccountingBookData.AccountingBookServiceReference.IAccountingBookService {
        
        public AccountingBookServiceClient() {
        }
        
        public AccountingBookServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountingBookServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountingBookServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountingBookServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AccountingBookData.AccountingBookServiceReference.CategoryDto[] GetCategories() {
            return base.Channel.GetCategories();
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.CategoryDto[]> GetCategoriesAsync() {
            return base.Channel.GetCategoriesAsync();
        }
        
        public AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjects() {
            return base.Channel.GetSubjects();
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectsAsync() {
            return base.Channel.GetSubjectsAsync();
        }
        
        public AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjectsByCategoryId(int id) {
            return base.Channel.GetSubjectsByCategoryId(id);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectsByCategoryIdAsync(int id) {
            return base.Channel.GetSubjectsByCategoryIdAsync(id);
        }
        
        public AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto GetSubjectInformationById(int inventoryNumber) {
            return base.Channel.GetSubjectInformationById(inventoryNumber);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto> GetSubjectInformationByIdAsync(int inventoryNumber) {
            return base.Channel.GetSubjectInformationByIdAsync(inventoryNumber);
        }
        
        public AccountingBookData.AccountingBookServiceReference.UserDto GetUserByName(string userName) {
            return base.Channel.GetUserByName(userName);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.UserDto> GetUserByNameAsync(string userName) {
            return base.Channel.GetUserByNameAsync(userName);
        }
        
        public bool IsValidUser(string userName, string password) {
            return base.Channel.IsValidUser(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsValidUserAsync(string userName, string password) {
            return base.Channel.IsValidUserAsync(userName, password);
        }
        
        public AccountingBookData.AccountingBookServiceReference.RoleDto[] GetRolesByUserId(int userId) {
            return base.Channel.GetRolesByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.RoleDto[]> GetRolesByUserIdAsync(int userId) {
            return base.Channel.GetRolesByUserIdAsync(userId);
        }
        
        public AccountingBookData.AccountingBookServiceReference.CategoryDto[] GetCategoriesByName(string categoryName) {
            return base.Channel.GetCategoriesByName(categoryName);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.CategoryDto[]> GetCategoriesByNameAsync(string categoryName) {
            return base.Channel.GetCategoriesByNameAsync(categoryName);
        }
        
        public AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[] GetSubjectByNameCategoryIdAndStateId(System.Nullable<int> categoryId, System.Nullable<int> stateId, string subjectName) {
            return base.Channel.GetSubjectByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.SubjectDetailsDto[]> GetSubjectByNameCategoryIdAndStateIdAsync(System.Nullable<int> categoryId, System.Nullable<int> stateId, string subjectName) {
            return base.Channel.GetSubjectByNameCategoryIdAndStateIdAsync(categoryId, stateId, subjectName);
        }
        
        public AccountingBookData.AccountingBookServiceReference.StateDto[] GetStates() {
            return base.Channel.GetStates();
        }
        
        public System.Threading.Tasks.Task<AccountingBookData.AccountingBookServiceReference.StateDto[]> GetStatesAsync() {
            return base.Channel.GetStatesAsync();
        }
    }
}
