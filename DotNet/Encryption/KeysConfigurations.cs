namespace EsewaPractice.Encryption
{
    public class KeysConfigurations
    {
        static public string MobilePublicKey = @"-----BEGIN PUBLIC KEY-----
MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA+IKD9z6mOrZp2qJ8k6QR
j/nBrPWWXWQdI4sgEoLzP/yHf6MHal0epjveQNF5Ra4773bn7XqXGesO3UOPgMoF
3HYMQQc1wTYNaqGmdn5mrRXvBpS05rmeIK3TxynHsLPAoZBhS3pDDItAgHx339Bq
ufmeEWfrEUbUqcpHrsXVdupiGJZNWgrOMyfuuGocfO2ZMakrCLsPZ3R2HgWA1wlw
nUwaVbrGgZRs3SWoCY0GOXbZI6FA83Ycdwp5zvAXesuKMXDTQ6zdHkh0eaJ6mmSj
YIoegcKEAA0FLggkN5YGFxSYPrp0lW8MIipB6DWS0pUnNDJLxf+tofIOAuexnKxJ
xBo5J0cqMB+XrYWLvYMz731dkKWOkA9kakpRiFT2P+5Qh27ujCWZNepUqjhaUeME
1fEl1F8hs2KKyJpYSe0wKusL3DAuFcMT1voaneo2tMSqxodItnPwjD7gg9NDNYzX
SyPMDxU8ccFuOcmlEDlBEyOB1iLNnuegHpOnISIIs9HmGAqSV5TvsUb+JlQEQYWS
GoWmgbxusYqtEPyt7K1XbEujuQjJdltZOgnNpzvTUI8odxjwgj/S42ECvmSH1nc2
yK5BhdY3GR7b0m+vfWgA8qVNsER2CLq6QdFU7u/Q9fsXlhkAdcih8FnQn7iBKlra
XZw4b5KFKpCYEWOvw+uc1B0CAwEAAQ==
-----END PUBLIC KEY-----
";
    


        /// <summary>
        /// Generally we never puts Mobile Private Key in the backend, 
        /// Its very insure thing to do
        /// 
        /// It makes no sense of using RSA for encyption
        /// 
        /// But since i don't know how to do unit testing in .Net, 
        /// and feeling lazy to create seperate key for testing,
        /// I am doing this wrong thing.
        /// </summary>
    static public string MobilePrivatekey = @"-----BEGIN RSA PRIVATE KEY-----
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
-----END RSA PRIVATE KEY-----
";
    }
}
