﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoapClient.ServiceReference1 {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebService1Soap")]
    public interface WebService1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/verListadoEvento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet verListadoEvento();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/verListadoEvento", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> verListadoEventoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/compraTicket", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void compraTicket(string cod_evento, string fecha_compra, string fono_contacto, string nombre_cliente, string num_ticket, string rut_cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/compraTicket", ReplyAction="*")]
        System.Threading.Tasks.Task compraTicketAsync(string cod_evento, string fecha_compra, string fono_contacto, string nombre_cliente, string num_ticket, string rut_cliente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : SoapClient.ServiceReference1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<SoapClient.ServiceReference1.WebService1Soap>, SoapClient.ServiceReference1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public System.Data.DataSet verListadoEvento() {
            return base.Channel.verListadoEvento();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> verListadoEventoAsync() {
            return base.Channel.verListadoEventoAsync();
        }
        
        public void compraTicket(string cod_evento, string fecha_compra, string fono_contacto, string nombre_cliente, string num_ticket, string rut_cliente) {
            base.Channel.compraTicket(cod_evento, fecha_compra, fono_contacto, nombre_cliente, num_ticket, rut_cliente);
        }
        
        public System.Threading.Tasks.Task compraTicketAsync(string cod_evento, string fecha_compra, string fono_contacto, string nombre_cliente, string num_ticket, string rut_cliente) {
            return base.Channel.compraTicketAsync(cod_evento, fecha_compra, fono_contacto, nombre_cliente, num_ticket, rut_cliente);
        }
    }
}
