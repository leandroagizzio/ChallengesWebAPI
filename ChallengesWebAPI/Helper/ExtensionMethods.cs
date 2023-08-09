using System.Reflection;

namespace ChallengesWebAPI.Helper
{
    public static class ExtensionMethods
    {
        public static T CopyToMe<T, U>(this T receiver, U sender) {
            Type receiverType = receiver.GetType();
            Type senderType = sender.GetType();

            PropertyInfo[] senderProperties = senderType.GetProperties();

            foreach (PropertyInfo senderProperty in senderProperties) {
                if (senderProperty.CanRead && senderProperty.CanWrite) {

                    PropertyInfo receiverProperty = receiverType.GetProperty(senderProperty.Name);

                    if (receiverProperty != null && receiverProperty.PropertyType == senderProperty.PropertyType) {
                        receiverProperty.SetValue(receiver, senderProperty.GetValue(sender));
                    }

                }
            }

            return receiver;
        }
    }
}
