﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3082.
// 
#pragma warning disable 1591

namespace EZakaz.RichClient.localhost {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BaseWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class BaseWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetPriceOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOrdersListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOrderItemsOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddNewOrderOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BaseWebService() {
            this.Url = global::EZakaz.RichClient.Properties.Settings.Default.EZakaz_RichClient_localhost_Service1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetPriceCompletedEventHandler GetPriceCompleted;
        
        /// <remarks/>
        public event GetOrdersListCompletedEventHandler GetOrdersListCompleted;
        
        /// <remarks/>
        public event GetOrderItemsCompletedEventHandler GetOrderItemsCompleted;
        
        /// <remarks/>
        public event AddNewOrderCompletedEventHandler AddNewOrderCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPrice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public PriceDto GetPrice(string userName) {
            object[] results = this.Invoke("GetPrice", new object[] {
                        userName});
            return ((PriceDto)(results[0]));
        }
        
        /// <remarks/>
        public void GetPriceAsync(string userName) {
            this.GetPriceAsync(userName, null);
        }
        
        /// <remarks/>
        public void GetPriceAsync(string userName, object userState) {
            if ((this.GetPriceOperationCompleted == null)) {
                this.GetPriceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPriceOperationCompleted);
            }
            this.InvokeAsync("GetPrice", new object[] {
                        userName}, this.GetPriceOperationCompleted, userState);
        }
        
        private void OnGetPriceOperationCompleted(object arg) {
            if ((this.GetPriceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPriceCompleted(this, new GetPriceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetOrdersList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderDto[] GetOrdersList() {
            object[] results = this.Invoke("GetOrdersList", new object[0]);
            return ((OrderDto[])(results[0]));
        }
        
        /// <remarks/>
        public void GetOrdersListAsync() {
            this.GetOrdersListAsync(null);
        }
        
        /// <remarks/>
        public void GetOrdersListAsync(object userState) {
            if ((this.GetOrdersListOperationCompleted == null)) {
                this.GetOrdersListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrdersListOperationCompleted);
            }
            this.InvokeAsync("GetOrdersList", new object[0], this.GetOrdersListOperationCompleted, userState);
        }
        
        private void OnGetOrdersListOperationCompleted(object arg) {
            if ((this.GetOrdersListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOrdersListCompleted(this, new GetOrdersListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetOrderItems", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderItemDto[] GetOrderItems(int orderId) {
            object[] results = this.Invoke("GetOrderItems", new object[] {
                        orderId});
            return ((OrderItemDto[])(results[0]));
        }
        
        /// <remarks/>
        public void GetOrderItemsAsync(int orderId) {
            this.GetOrderItemsAsync(orderId, null);
        }
        
        /// <remarks/>
        public void GetOrderItemsAsync(int orderId, object userState) {
            if ((this.GetOrderItemsOperationCompleted == null)) {
                this.GetOrderItemsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderItemsOperationCompleted);
            }
            this.InvokeAsync("GetOrderItems", new object[] {
                        orderId}, this.GetOrderItemsOperationCompleted, userState);
        }
        
        private void OnGetOrderItemsOperationCompleted(object arg) {
            if ((this.GetOrderItemsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOrderItemsCompleted(this, new GetOrderItemsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddNewOrder", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddNewOrder(OrderItemDto[] items, string userName) {
            this.Invoke("AddNewOrder", new object[] {
                        items,
                        userName});
        }
        
        /// <remarks/>
        public void AddNewOrderAsync(OrderItemDto[] items, string userName) {
            this.AddNewOrderAsync(items, userName, null);
        }
        
        /// <remarks/>
        public void AddNewOrderAsync(OrderItemDto[] items, string userName, object userState) {
            if ((this.AddNewOrderOperationCompleted == null)) {
                this.AddNewOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddNewOrderOperationCompleted);
            }
            this.InvokeAsync("AddNewOrder", new object[] {
                        items,
                        userName}, this.AddNewOrderOperationCompleted, userState);
        }
        
        private void OnAddNewOrderOperationCompleted(object arg) {
            if ((this.AddNewOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddNewOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PriceDto {
        
        private ItemDto[] itemsField;
        
        private string[] categoriesField;
        
        /// <remarks/>
        public ItemDto[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        /// <remarks/>
        public string[] Categories {
            get {
                return this.categoriesField;
            }
            set {
                this.categoriesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ItemDto {
        
        private int idField;
        
        private string nameField;
        
        private decimal priceField;
        
        private System.Nullable<int> restField;
        
        private string manufacterField;
        
        private string packField;
        
        private string categoryField;
        
        private System.Nullable<System.DateTime> dateField;
        
        private System.Nullable<int> receiptIdField;
        
        private int productIdField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public decimal Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Rest {
            get {
                return this.restField;
            }
            set {
                this.restField = value;
            }
        }
        
        /// <remarks/>
        public string Manufacter {
            get {
                return this.manufacterField;
            }
            set {
                this.manufacterField = value;
            }
        }
        
        /// <remarks/>
        public string Pack {
            get {
                return this.packField;
            }
            set {
                this.packField = value;
            }
        }
        
        /// <remarks/>
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> ReceiptId {
            get {
                return this.receiptIdField;
            }
            set {
                this.receiptIdField = value;
            }
        }
        
        /// <remarks/>
        public int ProductId {
            get {
                return this.productIdField;
            }
            set {
                this.productIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class OrderItemDto {
        
        private int idField;
        
        private string nameField;
        
        private decimal priceField;
        
        private System.Nullable<int> receiptIdField;
        
        private int productIdField;
        
        private int countField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public decimal Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> ReceiptId {
            get {
                return this.receiptIdField;
            }
            set {
                this.receiptIdField = value;
            }
        }
        
        /// <remarks/>
        public int ProductId {
            get {
                return this.productIdField;
            }
            set {
                this.productIdField = value;
            }
        }
        
        /// <remarks/>
        public int Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class OrderDto {
        
        private System.DateTime dateSentField;
        
        private int idField;
        
        private string clientNameField;
        
        private int clientIdField;
        
        /// <remarks/>
        public System.DateTime DateSent {
            get {
                return this.dateSentField;
            }
            set {
                this.dateSentField = value;
            }
        }
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string ClientName {
            get {
                return this.clientNameField;
            }
            set {
                this.clientNameField = value;
            }
        }
        
        /// <remarks/>
        public int ClientId {
            get {
                return this.clientIdField;
            }
            set {
                this.clientIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetPriceCompletedEventHandler(object sender, GetPriceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPriceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPriceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PriceDto Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PriceDto)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetOrdersListCompletedEventHandler(object sender, GetOrdersListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOrdersListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOrdersListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderDto[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderDto[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetOrderItemsCompletedEventHandler(object sender, GetOrderItemsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOrderItemsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOrderItemsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderItemDto[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderItemDto[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void AddNewOrderCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591