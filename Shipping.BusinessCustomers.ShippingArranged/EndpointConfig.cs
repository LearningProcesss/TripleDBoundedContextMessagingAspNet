using NServiceBus;
namespace Shipping.BusinessCustomers.ShippingArranged
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, AsA_Publisher
    {
        public void Init()
        {
            Configure.With()
                     .DefiningCommandsAs(t => t.Namespace != null
                         && t.Namespace.Contains("Commands"))
                     .DefiningEventsAs(t => t.Namespace != null
                         && t.Namespace.Contains("Events"));
        }
    }
}
