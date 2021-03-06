﻿
namespace FindIt.Domain.Models {

    using System.IO;
    using System.Xml.Serialization;

    public class UserInfo {
        public string DisplayName { get; set; }
        public string ClaimsIdentifier { get; set; }
        public int UserId { get; set; }

        public override string ToString() {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            using (var stream = new StringWriter()) {
                serializer.Serialize(stream, this);
                return stream.ToString();
            }
        }

        public static UserInfo FromString(string userContextData) {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            using (var stream = new StringReader(userContextData)) {
                return serializer.Deserialize(stream) as UserInfo;
            }
        }
    }
}
