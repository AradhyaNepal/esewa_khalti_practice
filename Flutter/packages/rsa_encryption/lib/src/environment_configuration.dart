/// DO NOT COPY SAME CODE ON THE OTHER PROJECT.
///
/// CREATE OTHER KEY FOR THAT PROJECT USING BELOW UNCOMMENTED CODE
///
/// USING SAME KEY MEANS YOU ARE LEAKING SECURITY OF THIS APP.
class RSAKey{
  static String privateKey='''''';
  static String publicKey='''''';
}


//From : https://stackoverflow.com/a/5246045
//openssl genrsa -out mykey.pem <MAX THE BETTER>
//openssl rsa -in mykey.pem -pubout > mykey.pub
//openssl rsa -in key.pem -pubout -out pubkey.pem
//ssh-keygen -y -f key.pem > key.pub